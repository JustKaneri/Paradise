using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;
using System.Data;
using System.Security.Claims;

namespace ParadiseApi.Controllers
{
    [Route("api/v1/subscription")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IMapper _mapper;

        public SubscriptionController(ISubscriptionRepository subscriptionRepository,IMapper mapper)
        {
            _subscriptionRepository = subscriptionRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all subscrib for user
        /// </summary>
        /// <returns></returns>
        [HttpGet("subscriptions")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<SubscriptionsDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubscription()
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            var request = await _subscriptionRepository.GetSubscriptions(idUser);

            if (request.Status == StatusRequest.Error)
            {
                return BadRequest(request.Error);
            }

            var result = _mapper.Map<List<SubscriptionsDto>>(request.Result);

            if (result.Count==0)
                return NotFound();

           return Ok(result);
        }

        /// <summary>
        /// Get status subscrib
        /// </summary>
        /// <param name="idCanal"></param>
        /// <returns>True or false</returns>
        [HttpGet("user/{idCanal}/subscription/status")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200,Type = typeof(bool))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IsSubscrib(int idCanal)
        {       
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            var result = await _subscriptionRepository.IsSubscrib(idCanal, idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }


        /// <summary>
        /// Subscribe user on account
        /// </summary>
        /// <param name="idCanal"></param>
        /// <returns></returns>
        [HttpPost("user/{idCanal}/subscribe")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(SubscriptionsDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Subscribe(int idCanal)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            RequestResult<Subscription> requestResult = await _subscriptionRepository.Subscribe(idCanal, idUser);

            if (requestResult.Status == StatusRequest.Error)
                return BadRequest(requestResult.Error);

            var result = _mapper.Map<SubscriptionsDto>(requestResult.Result);

            return Ok(result);
        }

        /// <summary>
        /// Unscrube user on account
        /// </summary>
        /// <param name="idCanal"></param>
        /// <returns></returns>
        [HttpDelete("user/{idCanal}/unsubscribe")]
        [Authorize(Roles = "Administrator,User")]
        [ProducesResponseType(200, Type = typeof(SubscriptionsDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Unsubscribe(int idCanal)
        {
            var identity = HttpContext.User.Identity as ClaimsIdentity;
            int idUser = -1;
            if (identity != null)
            {
                idUser = int.Parse(identity.FindFirst("id").Value);
            }

            RequestResult<Subscription> requestResult = await _subscriptionRepository.Unsubscribe(idCanal, idUser);

            if (requestResult.Status == StatusRequest.Error)
                return BadRequest(requestResult.Error);

            var result = _mapper.Map<SubscriptionsDto>(requestResult.Result);

            return Ok(result);
        }
    }
}
