using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Controllers.Interface;
using API.Data;
using API.DTO;
using API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Account")]
    public class AccountController : ControllerBase
    {
        public StoreContext _context { get; }
        public ITokenService _service { get; }
        private readonly IMapper _mapper;
        public AccountController(StoreContext context, ITokenService service, IMapper mapper)
        {
            _mapper = mapper;
            _service = service;
            _context = context;

        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerdto)
        {
            bool val = DuplicateUser(registerdto.userName);
            if (val == true) { return Unauthorized("UserName  already exists, Please use any other name"); }
            else
            {
                using var hmac = new HMACSHA512();
                var user = new AppUser
                {
                    userName = registerdto.userName,
                    passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerdto.password)),
                    passwordSalt = hmac.Key,
                    Gender=registerdto.Gender,
                    City=registerdto.City,
                    Country=registerdto.Country,
                    Interests=registerdto.Interest,
                    Introduction=registerdto.Introduction,
                    DateofBirth=registerdto.DateofBirth
                };
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return new UserDto
                {
                    userName = registerdto.userName,
                    Token = _service.CreateToken(user)
                };

            }
        }
        [HttpGet]
        public bool DuplicateUser(string name)
        {
            var user = _context.Users.Any(x => x.userName == name);
            if (!user == true)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult<AppUserDto>> Login(LoginDto logindto)
        {
            var user = await _context
            .Users.Include(p=>p.Photos)
            .SingleOrDefaultAsync(x =>
             x.userName == logindto.userName);

            if (user == null) return new AppUserDto()
            {
                userName = "Invalid Username"
            };
            using var hmac = new HMACSHA512(user.passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(logindto.password));
            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.passwordHash[i]) return Unauthorized("Invalid Username");
            }

            return _mapper.Map<AppUserDto>(user);

        }

        [HttpGet("GetAllUsers")]
        public List<AppUserDto> GetAllUsers()
        {
            var user = _context.Users.ToList();
            return _mapper.Map<List<AppUserDto>>(user);
        }
    }
}