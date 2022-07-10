using ALAT.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.Core.Interfaces
{
    public interface IValuesRepository
    {
        Task<List<StateResponse>> GetStatesAsync();
        Task<List<LgaResponse>> GetLgasAsync();
        Task<List<LgaResponse>> GetLgasByStateIdAsync(int stateId);
    }
}
