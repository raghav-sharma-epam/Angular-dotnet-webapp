using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using API.Controllers.Interface;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers.Repository
{
    public class AccountRepo : IAccountInterface
    {
        private readonly StoreContext _db;
        public ITokenService _tokenservice { get; }
        public AccountRepo(StoreContext db, ITokenService tokenservice)
        {
            _tokenservice = tokenservice;
            _db = db;

        }

        public Task<ActionResult<UserDto>> Register(RegisterDto registerdto)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AppUser>> Login(LoginDto logindto)
        {
            throw new NotImplementedException();
        }
    }
}