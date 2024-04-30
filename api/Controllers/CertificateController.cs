using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.DTOs;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificateController : ControllerBase
    {
        private readonly IMongoCollection<Certificate> _certificateCollection;
        private readonly IMongoCollection<Person> _personCollection;

        public CertificateController(IMongoClient client)
        {
            var database = client.GetDatabase("dot-net-crud");
            _certificateCollection = database.GetCollection<Certificate>("Certificate");
            _personCollection = database.GetCollection<Person>("Person");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Certificate>>> Get()
        {
            var certificate = await _certificateCollection.Find(p => true).ToListAsync();
            return Ok(certificate);
        }

        [HttpPost]
        public async Task<ActionResult<Certificate>> Create(CertificateCreateDTO certificateDTO)
        {
            var certificate = new Certificate(certificateDTO)
            {
                Person = await _personCollection.Find(p => p.Id == certificateDTO.PersonId).FirstOrDefaultAsync()
            };

            await _certificateCollection.InsertOneAsync(certificate);
            return CreatedAtAction(nameof(GetById), new { id = certificate.Id }, certificate);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Certificate>> GetById(string id)
        {
            var certificate = await _certificateCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (certificate == null)
            {
                return NotFound();
            }
            return Ok(certificate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Certificate updatedCertificate)
        {
            var certificate = await _certificateCollection.FindOneAndReplaceAsync(p => p.Id == id, updatedCertificate);
            if (certificate == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _certificateCollection.DeleteOneAsync(p => p.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
