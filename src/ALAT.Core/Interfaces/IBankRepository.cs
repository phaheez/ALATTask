using ALAT.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.Core.Interfaces
{
    public interface IBankRepository
    {
        Task<Bank> GetAllBanks(string url, string subscriptionKey);
    }
}
