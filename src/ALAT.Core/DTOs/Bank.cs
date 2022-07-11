using System;
using System.Collections.Generic;
using System.Text;

namespace ALAT.Core.DTOs
{
    public class Bank
    {
        public Result result { get; set; }
        public string errorMessage { get; set; }
        public List<string> errorMessages { get; set; }
        public bool hasError { get; set; }
        public string timeGenerated { get; set; }
    }

    public class Result
    {
        public string bankName { get; set; }
        public string bankCode { get; set; }
    }

    public class BankResponse
    {
        public int status { get; set; }
        public string message { get; set; }
        public Bank data { get; set; }
    }
}
