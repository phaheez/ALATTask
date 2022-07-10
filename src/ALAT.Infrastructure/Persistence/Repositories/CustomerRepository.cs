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

        public async Task<CustomerResponse> CreateCustomerAsync(CreateCustomerRequest request)
        {
            var customer = _mapper.Map<Customer>(request);
            customer.IsVerified = false;
            customer.CreatedAt = customer.UpdatedAt = DateUtil.GetCurrentDate();
            await _context.Customers.AddAsync(customer);
            var count = await _context.SaveChangesAsync();
            if(count == 1)
            {
                var otp = new Otp
                {
                    CustomerId = customer.Id,
                    Passcode = "112233",
                    Expiry = DateUtil.GetCurrentDate().AddMinutes(10)
                };
                await _context.Otps.AddAsync(otp);
            }

            return _mapper.Map<CustomerResponse>(customer);
        }

        public async Task<List<CustomerResponse>> GetCustomersAsync()
        {
            var customers = await _context.Customers
                .Include(p => p.State)
                .AsNoTracking()
                .ToListAsync();
            var list = _mapper.Map<List<CustomerResponse>>(customers);
            return list;
        }

        public async Task<bool> VerifyCustomerPhoneAsync(int customerId, OtpRequest request)
        {
            var otp = await _context.Otps.SingleOrDefaultAsync(p => p.CustomerId == customerId);
            if(otp != null)
            {
                if(otp.Passcode == request.OtpCode && otp.Expiry < DateTime.Now)
                {
                    var customer = await _context.Customers.FindAsync(customerId);
                    customer.IsVerified = true;
                    _context.Customers.Update(customer);
                    await _context.SaveChangesAsync();

                    return true;
                }

                return false;
            }

            throw new NotFoundException();
        }
    }
}
