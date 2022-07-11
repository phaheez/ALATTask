using ALAT.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.UnitTests.MockData
{
    public class StateMockData
    {
        public static List<StateResponse> GetAllStates()
        {
            return new List<StateResponse>
            {
                new StateResponse{ Id = 1, StateName = "Lagos" },
                new StateResponse{ Id = 2, StateName = "Oyo" }
            };
        }
    }
}
