using System.Diagnostics.Tracing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Interface
{
    public interface IAccountInterface
    {
        Task<ActionResult<UserDto>> Register(RegisterDto registerdto);
        Task<ActionResult<AppUser>> Login (LoginDto logindto);
    }
}