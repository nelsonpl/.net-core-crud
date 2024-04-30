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
    public class PersonController : ControllerBase
    {
        private readonly IMongoCollection<Person> _personCollection;

        public PersonController(IMongoClient client)
        {
            var database = client.GetDatabase("dot-net-crud");
            _personCollection = database.GetCollection<Person>("Person");
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> Get()
        {
            var person = await _personCollection.Find(p => true).ToListAsync();
            return Ok(person);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create(PersonCreateDTO personDTO)
        {
            var person = new Person(personDTO);

            await _personCollection.InsertOneAsync(person);
            return CreatedAtAction(nameof(GetById), new { id = person.Id }, person);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(string id)
        {
            var person = await _personCollection.Find(p => p.Id == id).FirstOrDefaultAsync();
            if (person == null)
            {
                return NotFound();
            }
            return Ok(person);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, Person updatedPerson)
        {
            var person = await _personCollection.FindOneAndReplaceAsync(p => p.Id == id, updatedPerson);
            if (person == null)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await _personCollection.DeleteOneAsync(p => p.Id == id);
            if (result.DeletedCount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
