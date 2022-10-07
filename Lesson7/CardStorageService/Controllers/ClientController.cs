using AutoMapper;
using CardStorageService.Data;
using CardStorageService.Models.Requests;
using CardStorageService.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CardStorageService.Controllers
{
  
        [Route("api/[controller]")]
        [ApiController]
        public class ClientController : ControllerBase
        {

            private readonly IClientRepositoryService _clientRepositoryService;
            private readonly ILogger<CardController> _logger;
            private readonly IMapper _mapper;
            private readonly IValidator<CreateClientRequest> _createClientRequestValidator;

            public ClientController(
                ILogger<CardController> logger,
                IClientRepositoryService clientRepositoryService,
                IMapper mapper,
                 IValidator<CreateClientRequest> createClientrequestValidator)
            {
                _logger = logger;
                _clientRepositoryService = clientRepositoryService;
                _createClientRequestValidator = createClientrequestValidator;
                _mapper = mapper;
            }

            [HttpPost("create")]
            [ProducesResponseType(typeof(CreateClientResponse), StatusCodes.Status200OK)]
            public IActionResult Create([FromBody] CreateClientRequest request)
            {
                try
                {
                    ValidationResult validationResults = _createClientRequestValidator.Validate(request);
                    if (!validationResults.IsValid)
                        return BadRequest(validationResults.ToDictionary());
                    var clientId = _clientRepositoryService.Create(_mapper.Map<Client>(request));
                    return Ok(new CreateClientResponse
                    {
                        ClientId = clientId
                    });
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "Create client error.");
                    return Ok(new CreateCardResponse
                    {
                        ErrorCode = 912,
                        ErrorMessage = "Create clinet error."
                    });
                }
            }

        }

}
