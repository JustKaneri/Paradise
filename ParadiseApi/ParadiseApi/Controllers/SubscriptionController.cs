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

        [HttpGet]
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

        [HttpGet("IsSubscrib")]
        [ProducesResponseType(200)]
        public IActionResult IsSubscrib(int idCanal, int idUser)
        {
            var result = _subscriptionRepository.IsSubscrib(idCanal, idUser);

            return Ok(result);
        }

        [HttpPost("Subscribe")]
        [ProducesResponseType(200)]
        public IActionResult Subscribe(int idCanal,int idUser)
        {
            var result = _subscriptionRepository.Subscribe(idCanal, idUser);

            return Ok(result);
        }

        [HttpPost("Unsubscribe")]
        [ProducesResponseType(200)]
        public IActionResult Unsubscribe(int idCanal, int idUser)
        {
            var result = _subscriptionRepository.Unsubscribe(idCanal, idUser);

            return Ok(result);
        }
    }
}
