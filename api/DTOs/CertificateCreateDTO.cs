using Api.Models;

namespace Api.DTOs
{
    public class CertificateCreateDTO
    {
        public string PersonId { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public string? Issuer { get; set; }

        public string? Date { get; set; }

        public string? ExpirationDate { get; set; }

        public string? CredentialId { get; set; }

        public string? CredentialUrl { get; set; }

        public string? CredentialImageUrl { get; set; }

        public CertificateCreateDTO()
        {
        }

        public CertificateCreateDTO(Certificate certificate)
        {
            PersonId = certificate.Person.Id;
            Name = certificate.Name;
            Description = certificate.Description;
            Issuer = certificate.Issuer;
            Date = certificate.Date;
            ExpirationDate = certificate.ExpirationDate;
            CredentialId = certificate.CredentialId;
            CredentialUrl = certificate.CredentialUrl;
            CredentialImageUrl = certificate.CredentialImageUrl;
        }

    }
}
