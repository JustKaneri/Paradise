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
            string error = "";

            var subscribts = _subscriptionRepository.GetSubscriptions(idUser,ref error);

            if (subscribts == null)
            {
                return BadRequest(error);
            }

            var result = _mapper.Map<List<SubscriptionsDto>>(subscribts);

            if (!ModelState.IsValid)
                return BadRequest(error);

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
        [HttpGet("subscrib/status")]
        [ProducesResponseType(200,Type = typeof(bool))]
        public IActionResult IsSubscrib(int idCanal, int idUser)
        {
            string error = "";

            var result = _subscriptionRepository.IsSubscrib(idCanal, idUser,ref error);

            if (error != "")
                return BadRequest(error);

            return Ok(result);
        }

        /// <summary>
        /// Subscribe user on account
        /// </summary>
        /// <param name="idCanal"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpPost("account/{idCanal}/subscribe")]
        [ProducesResponseType(200, Type = typeof(SubscriptionsDto))]
        public IActionResult Subscribe(int idCanal,int idUser)
        {
            string error = "";

            var result = _mapper.Map<SubscriptionsDto>(_subscriptionRepository.Subscribe(idCanal, idUser,ref error));

            if (result == null)
                return BadRequest(error);

            return Ok(result);
        }

        /// <summary>
        /// Unscrube user on account
        /// </summary>
        /// <param name="idCanal"></param>
        /// <param name="idUser"></param>
        /// <returns></returns>
        [HttpDelete("account/{idCanal}/unsubscribe")]
        [ProducesResponseType(200, Type = typeof(SubscriptionsDto))]
        public IActionResult Unsubscribe(int idCanal, int idUser)
        {
            string error = "";

            var result = _mapper.Map<SubscriptionsDto>(_subscriptionRepository.Unsubscribe(idCanal, idUser,ref error));

            if (result == null)
                return BadRequest(error);

            return Ok(result);
        }
    }
}
