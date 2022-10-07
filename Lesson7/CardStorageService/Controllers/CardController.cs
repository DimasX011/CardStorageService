using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Models;
using CardStorageService.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace CardStorageService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardController : ControllerBase
    {

        private readonly ILogger<CardController> _logger;
        private readonly ICardRepositoryService _cardRepositoryService;
        private readonly IMapper _mapper;
        private readonly IValidator<CreateCardRequest> _createCardRequestValidator;



        public CardController(ILogger<CardController> logger,
            ICardRepositoryService cardRepositoryService, IMapper mapper, IValidator<CreateCardRequest> createcardrequestvalidator)
        {
            _logger = logger;
            _cardRepositoryService = cardRepositoryService;
            _mapper = mapper;
            _createCardRequestValidator = createcardrequestvalidator;
        }



        [HttpPost("create")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        public IActionResult Create([FromBody] CreateCardRequest request)
        {
            try
            {
                ValidationResult validationResults = _createCardRequestValidator.Validate(request);
                if (!validationResults.IsValid)
                    return BadRequest(validationResults.ToDictionary());
                if (Convert.ToInt32(request.CVV2).GetType() != typeof(int))
                {
                    return BadRequest(validationResults.ToDictionary());
                }
                var cardid = _cardRepositoryService.Create(_mapper.Map<Card>(request));
                return Ok(new CreateCardResponse
                {
                    CardId = cardid.ToString()
                });
            }
            catch (Exception e)
            {
                if (e.Message == "Input string was not in a correct format.")
                {
                    _logger.LogError(e, "Сheck the correctness of the card data entry.");
                    return Ok(new CreateCardResponse
                    {
                        ErrorCode = 1015,
                        ErrorMessage = "Сheck the correctness of the card data entry"
                    });
                }
                _logger.LogError(e, "Create card error.");
                return Ok(new CreateCardResponse
                {
                    ErrorCode = 1012,
                    ErrorMessage = "Create card error."
                });
            }

        }

        [HttpGet("get-by-client-id")]
        [ProducesResponseType(typeof(GetCardsResponse), StatusCodes.Status200OK)]
        public IActionResult GetByClientId([FromQuery] string clientId)
        {
            try
            {
                var cards = _cardRepositoryService.GetByClientId(clientId);
                return Ok(new GetCardsResponse
                {
                    Cards = _mapper.Map<List<CardDto>>(cards)
                });
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Get cards error.");
                return Ok(new GetCardsResponse
                {
                    ErrorCode = 1013,
                    ErrorMessage = "Get cards error."
                });
            }
        }


    }
}
