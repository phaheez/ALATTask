using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ALAT.Core.DTOs
{
    public class CreateCustomerRequest
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public int StateId { get; set; }

        [Required]
        public int LgaId { get; set; }
    }

    public class OtpRequest
    {
        [Required]
        public string OtpCode { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }

    public class Response
    {
        public bool Success { get; set; }
        public string Message { get; set; }
    }

    public class CustomerResponse
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsVerified { get; set; }
        public string State { get; set; }
        public string Lga { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
