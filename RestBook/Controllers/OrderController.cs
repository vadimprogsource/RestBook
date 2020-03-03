using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestBook.Api.Entity;
using RestBook.Api.Provider;
using RestBook.Api.Service;
using RestBook.Data.ORM;
using RestBook.Models;

namespace RestBook.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IAccessTokenService     m_token_service;
        private readonly IOrderProcessingService m_order_processing;
        private readonly IOrderProvider m_order_provider;


        public OrderController(IAccessTokenService accessTokenService, IOrderProcessingService orderProcessingService,IOrderProvider orderProvider )
        {
            m_token_service    = accessTokenService;
            m_order_processing = orderProcessingService;
            m_order_provider = orderProvider;
        }



        [HttpPost("active")]
        public async Task<IActionResult> GetActiveOrders([FromBody]AccessTokenModel model)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return BadRequest();
            }

            return Ok((await m_order_provider.GetActiveOrders(accessToken.User)).Select(x=>new OrderModel(accessToken , x)).ToArray());
        }



        [HttpPost("{guid}")]
        public async Task<IActionResult> GetActiveOrders([FromBody]AccessTokenModel model, Guid guid)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return BadRequest();
            }

            IRetailOrder order = await m_order_provider.GetOrder(accessToken.User, guid);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(new OrderModel(accessToken , order));
        }


        [HttpPost("create/{orgGuid}")]
        public async Task<IActionResult> CreateOrder([FromBody]AccessTokenModel model,Guid orgGuid)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return BadRequest();
            }

            IRetailOrder order =   await m_order_processing.CreateNewOrder(accessToken.User,orgGuid);
            return Ok(new OrderModel(accessToken , order));
        }

        [HttpPost("add/{locationGuid}/{placeCode}/{productGuid}/{qty}")]
        public async Task<IActionResult> AddToOrder([FromBody]OrderModel model, Guid locationGuid, string placeCode, Guid productGuid, decimal qty)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return Forbid();
            }

            IRetailOrder order = model;
            model.Customer     = accessToken.User;
       
            if (string.IsNullOrWhiteSpace(order.OrderNumber) || order.OrderedAt == DateTime.MinValue)
            {
                order = await m_order_processing.CreateNewOrder(accessToken.User, DataOrgMapper.ORG.Guid);
            }

            order = await m_order_processing.AddToOrder(order, locationGuid, placeCode, productGuid,Math.Abs(qty));
            return Ok(new OrderModel(accessToken, order));
        }

        [HttpPost("remove/{locationGuid}/{placeCode}/{productGuid}/{qty}")]
        public async Task<IActionResult> RemoveFromOrder([FromBody]OrderModel model, Guid locationGuid, string placeCode, Guid productGuid, decimal qty)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return Forbid();
            }

            model.Customer = accessToken.User;
            IRetailOrder order = await m_order_processing.RemoveFromOrder(model, locationGuid, placeCode, productGuid, Math.Abs(qty));
            return Ok(new OrderModel(accessToken, order));
        }

        [HttpPut("push")]
        public async Task<IActionResult> PushOrder([FromBody]OrderModel model)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return Forbid();
            }

            model.Customer = accessToken.User;
            await m_order_processing.PushOrder(model);

            return Ok();

        }


        [HttpDelete("cancel")]
        public async Task<IActionResult> CancelOrder([FromBody]OrderModel model)
        {
            IAccessToken accessToken = await m_token_service.GetToken(model.Token);

            if (accessToken == null || accessToken.HasExpired)
            {
                return Forbid();
            }

            model.Customer = accessToken.User;
            await m_order_processing.CancelOrder(model);

            return Ok();
        }
    }
}