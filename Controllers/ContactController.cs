using ApplicationCore.Constants;
using ApplicationCore.Entities;
using ApplicationCore.Helpers;
using ApplicationCore.Services;
using ApplicationCore.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Net;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TitanWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly ILogger<SliderController> _logger;

        public ContactController(IContactService contactService, ILogger<SliderController> logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        /// <summary>
        /// Get all contact
        /// </summary>
        /// <returns> Response of list all contact </returns>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation(ContentManager.LogGetAllContactTable);
            var contacts = await _contactService.GetAll();

            return Ok(new Response<IEnumerable<Contact>>(contacts, HttpStatusCode.OK, ContentManager.SuccessGetAllContacts));
        }

        /// <summary>
        /// Get contact by id
        /// </summary>
        /// <param name="id"> Id of contact </param>
        /// <returns> Response of contact </returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById([FromRoute] int id)
        {
            _logger.LogInformation(ContentManager.LogGetContactByID);
            if (!ModelState.IsValid)
            {
                throw new InvalidModelStateException();
            }
            var contact = await _contactService.GetById(id);

            return Ok(new Response<Contact>(contact, HttpStatusCode.OK, ContentManager.SuccessGetContactByID));
        }

        /// <summary>
        /// Create contact
        /// </summary>
        /// <param name="contact"> Contact param from reqest body </param>
        /// <returns> Response of Created contact </returns>
        [HttpPost]
        public async Task<IActionResult> CreateContact([FromBody] Contact contact)
        {
            _logger.LogInformation(ContentManager.LogCreateContact);
            var createdContact = await _contactService.Add(contact);
            if (!createdContact)
            {
                return BadRequest(new ErrorResponse(ContentManager.FailCreateContact, HttpStatusCode.BadRequest));
            }

            return Ok(new Response<Contact>(contact, HttpStatusCode.Created, ContentManager.SuccessCreateContact));
        }
    }
}
