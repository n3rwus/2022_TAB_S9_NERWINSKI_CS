﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tab_backend.Application.DTO;
using tab_backend.Application.Interfaces;

namespace tab_backend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [SwaggerOperation(Summary = "LoginRepository")]
        [HttpPost("login")]
        public IActionResult Login(UserLoginDTO model)
        {
            var response = _userService.LoginService(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }


        [SwaggerOperation(Summary = "RegisterRepository")]
        [HttpPost("register")]
        public IActionResult Register(UserRegisterDTO model)
        {
            var response = _userService.RegisterService(model);

            if (response == null)
                return BadRequest(new { message = "something went wrong" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAllService();
            return Ok(users);
        }

    }
}
