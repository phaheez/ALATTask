using ALAT.Core.DTOs;
using ALAT.Core.Entities;
using ALAT.Core.Exceptions;
using ALAT.Core.Interfaces;
using ALAT.Core.Utils;
using ALAT.Infrastructure.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CustomerContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(CustomerContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<Response> CreateCustomerAsync(CreateCustomerRequest request)
        {
            try
            {
                var customer = _mapper.Map<Customer>(request);

                var isEmailExist = await _context.Customers.SingleOrDefaultAsync(e => e.Email == customer.Email);
                if (isEmailExist != null)
                {
                    return new Response { Success = false, Message = "Customer Email already exist. Try with another one" };
                }

                customer.IsVerified = false;
                customer.CreatedAt = customer.UpdatedAt = DateUtil.GetCurrentDate();

                await _context.Customers.AddAsync(customer);
                await _context.SaveChangesAsync();

                var otp = new Otp
                {
                    CustomerId = customer.Id,
                    Passcode = "112233",
                    Expiry = DateUtil.GetCurrentDate().AddMinutes(10)
                };
                await _context.Otps.AddAsync(otp);
                await _context.SaveChangesAsync();

                return new Response { Success = true, Message = "Onboarding was successful. Kindly enter '112233' to verify your phone number" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = ex.Message };
            }
        }

        public async Task<List<CustomerResponse>> GetCustomersAsync()
        {
            var customers = await _context.Customers
                .Include(p => p.State)
                .Include(p => p.Lga)
                .AsNoTracking()
                .ToListAsync();
            var list = _mapper.Map<List<CustomerResponse>>(customers);
            return list;
        }

        public async Task<Response> VerifyCustomerPhoneAsync(OtpRequest request)
        {
            try
            {
                var otp = request.OtpCode;
                var email = request.Email;
                var phoneNo = request.PhoneNumber;

                var customer = await _context.Customers.FirstOrDefaultAsync(e => e.Email == email && e.PhoneNumber == phoneNo);
                if (customer != null)
                {
                    if (customer.IsVerified == false)
                    {
                        var custOtp = await _context.Otps.FirstOrDefaultAsync(p => p.Passcode == otp && p.CustomerId == customer.Id);
                        if (custOtp != null)
                        {
                            customer.IsVerified = true;
                            _context.Customers.Update(customer);
                            await _context.SaveChangesAsync();

                            return new Response { Success = true, Message = "Customer phoneNumber successfully verified" };
                            //if (custOtp.Expiry > DateTime.Now)
                            //{
                            //    customer.IsVerified = true;
                            //    _context.Customers.Update(customer);
                            //    await _context.SaveChangesAsync();

                            //    return new Response { Success = true, Message = "Customer phoneNumber successfully verified" };
                            //}

                            //return new Response { Success = false, Message = "OTP has expired" };
                        }

                        return new Response { Success = false, Message = "Invalid OTP" };
                    }

                    return new Response { Success = false, Message = "Customer has already been verified" };
                }

                return new Response { Success = false, Message = "Invalid Customer" };
            }
            catch (Exception ex)
            {
                return new Response { Success = false, Message = ex.Message };
            }
        }
    }
}
