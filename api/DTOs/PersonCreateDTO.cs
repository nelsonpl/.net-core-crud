using Api.Models;

namespace Api.DTOs
{
    public class PersonCreateDTO
    {
        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }

        public PersonCreateDTO()
        {
        }

        public PersonCreateDTO(Person person)
        {
            Name = person.Name;
            BirthDate = person.BirthDate;
            Email = person.Email;
            PhoneNumber = person.PhoneNumber;
            Address = person.Address;
            City = person.City;
            State = person.State;
            Country = person.Country;
            ZipCode = person.ZipCode;
        }
        
    }
}
