using System.ComponentModel.DataAnnotations;
using Api.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class Person
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public DateTime? BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }

        public int? Age
        {
            get
            {
                if (BirthDate.HasValue)
                {
                    var today = DateTime.Today;
                    var age = today.Year - BirthDate.Value.Year;
                    if (BirthDate.Value.Date > today.AddYears(-age))
                    {
                        age--;
                    }
                    return age;
                }
                return null;

            }
        }

        public Person()
        {
        }

        public Person(PersonCreateDTO personCreateDTO)
        {
            Name = personCreateDTO.Name;
            Email = personCreateDTO.Email;
            PhoneNumber = personCreateDTO.PhoneNumber;
            Address = personCreateDTO.Address;
            City = personCreateDTO.City;
            State = personCreateDTO.State;
            Country = personCreateDTO.Country;
            ZipCode = personCreateDTO.ZipCode;
        }
    }
}
