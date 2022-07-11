using ALAT.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.UnitTests.MockData
{
    public class LgaMockData
    {
        public static List<LgaResponse> GetAllLgas()
        {
            return new List<LgaResponse>
            {
                new LgaResponse{ Id = 1, LgaName = "Lagos Island"  },
                new LgaResponse{ Id = 2, LgaName = "Victoria Island" }
            };
        }
    }
}
