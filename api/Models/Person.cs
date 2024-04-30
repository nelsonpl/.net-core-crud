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

        public DateTime BirthDate { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Invalid phone number format")]
        public string? PhoneNumber { get; set; }

        public string? Address { get; set; }

        public string? City { get; set; }

        public string? State { get; set; }

        public string? Country { get; set; }

        public string? ZipCode { get; set; }

        public int Age
        {
            get
            {
                var today = DateTime.Today;
                var age = today.Year - BirthDate.Year;
                if (BirthDate.Date > today.AddYears(-age))
                {
                    age--;
                }
                return age;

            }
        }

        public bool IsAdult()
        {
            return Age >= 18;
        }

        public bool IsValid(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (!IsAdult())
            {
                errorMessage = "The person must be at least 18 years old.";
                return false;
            }


            return true;
        }

        public Person()
        {
        }

        public Person(PersonCreateDTO personCreateDTO)
        {
            Name = personCreateDTO.Name;
            BirthDate = personCreateDTO.BirthDate;
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
