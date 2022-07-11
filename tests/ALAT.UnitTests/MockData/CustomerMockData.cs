using ALAT.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.UnitTests.MockData
{
    public class CustomerMockData
    {
        public static List<CustomerResponse> GetAllCustomers()
        {
            return new List<CustomerResponse>
            {
                new CustomerResponse
                {
                    Id = 1,
                    Email = "faizfasasi@gmail.com",
                    PhoneNumber = "08064902317",
                    IsVerified = true,
                    State = "Lagos",
                    Lga = "Lagos Island",
                    //CreatedAt = ""
                }
            };
        }

        public static CreateCustomerRequest NewCustomer()
        {
            return new CreateCustomerRequest
            {
                Email = "faizfasasi@gmail.com",
                Password = "123456",
                PhoneNumber = "08064902317",
                StateId = 1,
                LgaId = 1
            };
        }

        public static OtpRequest VerifyCustomerPhone()
        {
            return new OtpRequest
            {
                Email = "faizfasasi@gmail.com",
                OtpCode = "112233",
                PhoneNumber = "08064902317"
            };
        }
    }
}
