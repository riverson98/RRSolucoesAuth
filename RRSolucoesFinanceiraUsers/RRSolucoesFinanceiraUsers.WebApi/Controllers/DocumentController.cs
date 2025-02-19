using Microsoft.AspNetCore.Mvc;
using RRSolucoesFinanceiraUsers.Application.DTOs.requestDto;
using RRSolucoesFinanceiraUsers.Application.Interfaces;
using RRSolucoesFinanceiraUsers.Application.Services;
using RRSolucoesFinanceiraUsers.Domain.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RRSolucoesFinanceiraUsers.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly IService<DocumentEntity, DocumentDTO> _service;
        private readonly IDocumentService _documentService;

        public DocumentController(IService<DocumentEntity, DocumentDTO> service, IDocumentService docService)
        {
            _service = service;
            _documentService = docService;
        }

        // GET: api/<DocumentController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<DocumentController>/5
        [HttpGet("{id:int:min(1)}", Name = "GetDocumentById")]
        public async Task<ActionResult<DocumentDTO>> Get(int id)
        {
            var documentDto = await _documentService.GetDocumentById(id);

            if (documentDto.Id is null)
                return NotFound("Sorry this document can be found in our database");

            return Ok(documentDto);
        }

        // POST api/<DocumentController>
        [HttpPost]
        public async Task<ActionResult<DocumentDTO>> Post(DocumentDTO documentDto)
        {
            if (documentDto is null)
                return BadRequest();

            var documentDtoCreated = await _service.Add(documentDto);

            return new CreatedAtRouteResult("GetDocumentById", new { id = documentDtoCreated.Id }, documentDtoCreated);
        }

        // PUT api/<DocumentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<DocumentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
