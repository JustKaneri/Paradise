using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

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
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpGet("subscriptions")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<SubscriptionsDto>))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetSubscription(int idUser)
        {
            string error = "";

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
        /// <param name="idUser"></param>
        /// <returns>True or false</returns>
        [HttpGet("user/{idCanal}/subscription/status")]
        [ProducesResponseType(200,Type = typeof(bool))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> IsSubscrib(int idCanal, int idUser)
        {
            var result = await _subscriptionRepository.IsSubscrib(idCanal, idUser);

            if (result.Status == StatusRequest.Error)
                return BadRequest(result.Error);

            return Ok(result.Result);
        }

        /// <summary>
        /// Subscribe user on account
        /// </summary>
        /// <param name="idCanal"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost("user/{idCanal}/subscribe")]
        [ProducesResponseType(200, Type = typeof(SubscriptionsDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Subscribe(int idCanal,int idUser)
        {
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
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpDelete("user/{idCanal}/unsubscribe")]
        [ProducesResponseType(200, Type = typeof(SubscriptionsDto))]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Unsubscribe(int idCanal, int idUser)
        {
            RequestResult<Subscription> requestResult = await _subscriptionRepository.Unsubscribe(idCanal, idUser);

            if (requestResult.Status == StatusRequest.Error)
                return BadRequest(requestResult.Error);

            var result = _mapper.Map<SubscriptionsDto>(requestResult.Result);

            return Ok(result);
        }
    }
}
