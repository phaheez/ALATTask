using System;
using System.Collections.Generic;
using System.Text;

namespace ALAT.Core.DTOs
{
    public class Bank
    {
        public List<Result> result { get; set; }
        public object errorMessage { get; set; }
        public object errorMessages { get; set; }
        public bool hasError { get; set; }
        public DateTime timeGenerated { get; set; }
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
