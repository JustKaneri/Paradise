using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ParadiseApi.Dto;
using ParadiseApi.Interfaces;
using ParadiseApi.Models;

namespace ParadiseApi.Controllers
{
    [Route("api/[controller]")]
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
        public IActionResult GetSubscription(int idUser)
        {
           var sub = _mapper.Map<List<SubscriptionsDto>>(_subscriptionRepository.GetSubscriptions(idUser));

            if (!ModelState.IsValid)
                return BadRequest(sub);

            if (sub.Count==0)
                return NotFound();

           return Ok(sub);
        }

        /// <summary>
        /// Get status subscrib
        /// </summary>
        /// <param name="idCanal"></param>
        /// <param name="idUser"></param>
        /// <returns>True or false</returns>
        [HttpGet("status/subscrib")]
        [ProducesResponseType(200)]
        public IActionResult IsSubscrib(int idCanal, int idUser)
        {
            var result = _subscriptionRepository.IsSubscrib(idCanal, idUser);

            return Ok(result);
        }

        /// <summary>
        /// Subscribe user on account
        /// </summary>
        /// <param name="idCanal"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost("account/{idCanal}/subscribe")]
        [ProducesResponseType(200)]
        public IActionResult Subscribe(int idCanal,int idUser)
        {
            var result = _subscriptionRepository.Subscribe(idCanal, idUser);

            return Ok(result);
        }

        /// <summary>
        /// Unscrube user on account
        /// </summary>
        /// <param name="idCanal"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpDelete("account/{idCanal}/unsubscribe")]
        [ProducesResponseType(200)]
        public IActionResult Unsubscribe(int idCanal, int idUser)
        {
            var result = _subscriptionRepository.Unsubscribe(idCanal, idUser);

            return Ok(result);
        }
    }
}
