using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Resources.Errors;
using ElectronicsStore.Resources.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.Controllers {

    [ApiController, Route("api/v1/[controller]")]
    public class UsersController : ControllerBase {

        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public UsersController(IUsersService usersService, IMapper mapper) {
            this.usersService = usersService;
            this.mapper = mapper;
        }

        [HttpGet("{username}")]
        public async Task<ActionResult> GetUserByIdAsync(string username) {
            UserStatusResponse response = await usersService.FindUserByUsernameAsync(username);
            if (response.Status)
                return Ok(mapper.Map<User, UserResponse>(response.Resource));
            return NotFound(new ErrorResponse { Error = response.Message, Status = response.Status });
        }
    }
}
