using Microsoft.AspNetCore.Mvc;
using RestBook.Api.Entity;
using RestBook.Api.Service;
using RestBook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestBook.Controllers
{

    [ApiController]
    [Route("api/profile")]
    public class ProfileController : ControllerBase
    {
        private readonly IUserAdminService    m_admin_service;
        private readonly IAccessTokenService  m_token_service;


        public ProfileController(IUserAdminService userAdminService , IAccessTokenService tokenService)
        {
            m_admin_service = userAdminService;
            m_token_service = tokenService;
        }

        [HttpPost("data")]
        public async Task<IActionResult> GetData([FromBody]AccessTokenModel model)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);
            
            if (accessToken == null || accessToken.HasExpired)
            {
                return NotFound();
            }

            return Ok(new UserDataModel(accessToken.User));

        }



        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserDataModel model)
        {
            IUserAccount ua = await m_admin_service.RegisterCustomer(model);

            if (ua == null)
            {
                return BadRequest();
            }

            IAccessToken accessToken = await m_token_service.GenerateToken(ua);

            if (!string.IsNullOrWhiteSpace(model.Password))
            {
                await m_admin_service.ResetPasspord(accessToken, model.Password, model.ConfirmPassword);
            }

            return Ok(new AccessTokenModel(accessToken));
        }

        [HttpPut("save/data")]
        public async Task<IActionResult> SaveData([FromBody]UserDataModel model)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return NotFound();
            }

            if (await m_admin_service.SaveUserData(accessToken, model, null))
            {
                return Ok(new AccessTokenModel(accessToken));
            }

            return Forbid();

        }

        [HttpPut("reset/password")]
        public async Task<IActionResult> ResetPassword([FromBody]UserDataModel model)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return NotFound();
            }

            if (await m_admin_service.ResetPasspord(accessToken, model.Password, model.ConfirmPassword))
            {
                return Ok(new AccessTokenModel(accessToken));
            }

            return Forbid();

        }


        [HttpPut("reset/login")]
        public async Task<IActionResult> ResetLogin([FromBody]UserDataModel model)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return NotFound();
            }

            if (await m_admin_service.ResetLoginName(accessToken, model.LoginName))
            {
                return Ok(new AccessTokenModel(accessToken));
            }

            return Forbid();

        }

    }
}
