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
        Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request);
        Task<bool> VerifyCustomerPhoneAsync(int customerId, OtpRequest request);
    }
}
