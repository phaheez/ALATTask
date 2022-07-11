using ALAT.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.Core.Interfaces
{
    public interface ICustomerRepository
    {
        Task<List<CustomerResponse>> GetCustomersAsync();
        Task<Response> CreateCustomerAsync(CreateCustomerRequest request);
        Task<Response> VerifyCustomerPhoneAsync(OtpRequest request);
    }
}
