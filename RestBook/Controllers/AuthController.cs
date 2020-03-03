using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestBook.Api.Entity;
using RestBook.Api.Service;
using RestBook.Models;

namespace RestBook.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService m_auth_service;
        private readonly IAccessTokenService m_token_service;
        private readonly IMailService m_mail_service;
        private readonly ISmsService  m_sms_service;


        public AuthController(IAuthService authService , IAccessTokenService accessTokenService , IMailService mailService , ISmsService smsService) 
        {
            m_auth_service = authService;
            m_token_service = accessTokenService;
            m_mail_service = mailService;
            m_sms_service = smsService;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginModel model)
        {
           IAccessToken accessToken = await  m_auth_service.SignIn(model.Name, model.Password);

            if (accessToken == null)
            {
                return Forbid();
            }

            return Ok(new AccessTokenModel(accessToken));
        }

        [HttpPost("pin/gen")]
        public async Task<IActionResult> GenPinCode([FromBody]PinCodeModel model)
        {
            model.PinCode =  await m_auth_service.GeneratePinCode(model.Cellular, model.Email);

            if (string.IsNullOrWhiteSpace(model.PinCode))
            {
                return Forbid();
            }


            bool wasSent = false;

            if (!string.IsNullOrWhiteSpace(model.Cellular))
            {
                wasSent |= await m_mail_service.Send(model.Cellular , model.PinCode);
            }

            if (!string.IsNullOrWhiteSpace(model.Email))
            {
                wasSent |= await m_mail_service.Send(model.Email ,model.PinCode);
            }

            if (wasSent)
            {
                return Ok(model);
            }

            return BadRequest();
        }

        [HttpPost("pin/login")]
        public async Task<IActionResult> LoginByPinCode([FromBody]PinCodeModel model)
        {
            IAccessToken accessToken = await m_auth_service.LoginByPinCode(model.Cellular, model.Email, model.PinCode);
            
            if (accessToken == null || accessToken.HasExpired)
            {
                return Forbid();
            }

            return Ok(new AccessTokenModel(accessToken));
        }


        [HttpPost("logoff")]
        public async Task<IActionResult> Logoff([FromBody]AccessTokenModel model)
        {
            await m_auth_service.SignOut(model.Token);
            return Ok();

        }
    }


}