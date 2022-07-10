using System;
using System.Collections.Generic;
using System.Text;

namespace ALAT.Core.DTOs
{
    public class LgaResponse
    {
        public int Id { get; set; }
        public string LgaName { get; set; }
        public StateResponse State { get; set; }
    }
}
