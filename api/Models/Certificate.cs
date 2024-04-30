using System.ComponentModel.DataAnnotations;
using Api.DTOs;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Api.Models
{
    public class Certificate
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public Person Person { get; set; }

        [BsonRequired]
        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Issuer { get; set; }

        public string? Date { get; set; }

        public string? ExpirationDate { get; set; }

        public string? CredentialId { get; set; }

        public string? CredentialUrl { get; set; }

        public string? CredentialImageUrl { get; set; }

        public Certificate()
        {
        }

        public Certificate(CertificateCreateDTO certificateCreateDTO)
        {
            Name = certificateCreateDTO.Name;
            Description = certificateCreateDTO.Description;
            Issuer = certificateCreateDTO.Issuer;
            Date = certificateCreateDTO.Date;
            ExpirationDate = certificateCreateDTO.ExpirationDate;
            CredentialId = certificateCreateDTO.CredentialId;
            CredentialUrl = certificateCreateDTO.CredentialUrl;
            CredentialImageUrl = certificateCreateDTO.CredentialImageUrl;
        }
    }
}
