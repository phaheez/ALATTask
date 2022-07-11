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

        public ValuesRepository(CustomerContext context, IMapper mapper)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<List<StateResponse>> GetStatesAsync()
        {
            var states = await _context.States.AsNoTracking().ToListAsync();
            var list = _mapper.Map<List<StateResponse>>(states);

            return list;
        }

        public async Task<List<LgaResponse>> GetLgasAsync()
        {
            var lgas = await _context.Lgas.Include(s => s.State).AsNoTracking().ToListAsync();
            var list = _mapper.Map<List<LgaResponse>>(lgas);

            return list;
        }

        public async Task<List<LgaResponse>> GetLgasByStateIdAsync(int stateId)
        {
            var lgas = await _context.Lgas
                .AsNoTracking()
                .Include(s => s.State)
                .Where(p => p.State.Id == stateId)
                .ToListAsync();

            var list = _mapper.Map<List<LgaResponse>>(lgas);
            return list;
        }
    }
}
