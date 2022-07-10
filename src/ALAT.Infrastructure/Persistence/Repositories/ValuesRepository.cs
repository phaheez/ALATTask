using ALAT.Core.DTOs;
using ALAT.Core.Interfaces;
using ALAT.Infrastructure.Persistence.Contexts;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.Infrastructure.Persistence.Repositories
{
    public class ValuesRepository : IValuesRepository
    {
        private readonly CustomerContext _context;
        private readonly IMapper _mapper;

        public List<StateResponse> states = new List<StateResponse>()
        {
            new StateResponse{ Id = 1, StateName = "Lagos" },
            new StateResponse{ Id = 2, StateName = "Oyo" }
        };

        public List<LgaResponse> lgas = new List<LgaResponse>()
        {
            new LgaResponse { Id = 1, LgaName = "Lagos Island", State = new StateResponse { Id = 1 } },
            new LgaResponse { Id = 2, LgaName = "Victoria Island", State = new StateResponse { Id = 1 } },
            new LgaResponse { Id = 3, LgaName = "Ibadan", State = new StateResponse { Id = 2 } },
            new LgaResponse { Id = 4, LgaName = "Saki", State = new StateResponse { Id = 2 } }
        };

        public ValuesRepository(CustomerContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<StateResponse>> GetStatesAsync()
        {
            return states;

            //var states = await _context.States
            //    .AsNoTracking()
            //    .ToListAsync();
            //var list = _mapper.Map<List<StateResponse>>(states);
            //return list;
        }

        public async Task<List<LgaResponse>> GetLgasAsync()
        {
            return lgas;

            //var lgas = await _context.Lgas
            //    .Include(s => s.State)
            //    .AsNoTracking()
            //    .ToListAsync();
            //var list = _mapper.Map<List<LgaResponse>>(lgas);
            //return list;
        }

        public async Task<List<LgaResponse>> GetLgasByStateIdAsync(int stateId)
        {
            var res = lgas.Where(p => p.State.Id == stateId).ToList();
            return res;
            //var lgas = await _context.Lgas
            //    .AsNoTracking()
            //    .Include(s => s.State)
            //    .Where(p => p.State.Id == stateId)
            //    .ToListAsync();
            //var list = _mapper.Map<List<LgaResponse>>(lgas);
            //return list;
        }
    }
}
