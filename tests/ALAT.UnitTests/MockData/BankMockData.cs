using ALAT.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALAT.UnitTests.MockData
{
    public class BankMockData
    {
        public static BankResponse AllBanks()
        {
            return new BankResponse
            {
                status = 200,
                message = "success",
                data = new Bank()
                {
                    result = new List<Result>
                    {
                        new Result{ bankName = "ALATbyWEMA", bankCode = "035" },
                        new Result{ bankName = "WEMA BANK", bankCode = "035" },
                        new Result{ bankName = "ACCESS BANK", bankCode = "044" },
                        new Result{ bankName = "ASO SAVINGS", bankCode = "401" },
                        new Result{ bankName = "CITI BANK", bankCode = "023" }
                    }
                }
            };
        }
    }
}
