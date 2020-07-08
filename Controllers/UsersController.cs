using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ElectronicsStore.Domain.Models;
using ElectronicsStore.Domain.Services;
using ElectronicsStore.Domain.Services.Communication;
using ElectronicsStore.Extensions;
using ElectronicsStore.Resources.Errors;
using ElectronicsStore.Resources.Requests;
using ElectronicsStore.Resources.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicsStore.Controllers {

    [ApiController, Route("api/v1/[controller]"), Authorize]
    public class UsersController : ControllerBase {

        private readonly IUsersService usersService;
        private readonly IMapper mapper;

        public UsersController(IUsersService usersService, IMapper mapper) {
            this.usersService = usersService;
            this.mapper = mapper;
        }

        [HttpGet("{username}"), AllowAnonymous]
        public async Task<ActionResult> GetUserByUsernameAsync(string username) {
            UserStatusResponse response = await usersService.FindUserByUsernameAsync(username);
            if (response.Status)
                return Ok(mapper.Map<User, UserResponse>(response.Resource));
            return NotFound(new ErrorResponse { Error = response.Message, Status = response.Status });
        }

        [HttpPost("update"), Consumes(contentType: "application/json", otherContentTypes: "multipart/form-data")]
        public async Task<ActionResult> UpdateAsync([FromForm] UserUpdateRequest request) {
            if (!ModelState.IsValid)
                return BadRequest(new ErrorResponse { Error = ModelState.GetErrorMessages(), Status = false });
            UserStatusResponse response = await usersService.UpdateAsync(request);
            if (response.Status)
                return Ok(mapper.Map<User, UserResponse>(response.Resource));
            return BadRequest(new ErrorResponse { Error = response.Message, Status = response.Status });
        }

        [HttpDelete("delete")]
        public async Task<ActionResult> DeleteAsync([FromQuery] UserIdRequest request) {
            bool status = await usersService.DeleteAsync(request.userId);
            if (status)
                return Ok();
            return NotFound(new ErrorResponse { Error = "User Not Found.", Status = status });
        }
    }
}
