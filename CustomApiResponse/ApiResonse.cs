using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomApiResponse
{
    public class ApiResonse
    {
        public int StatusCode { get; set; }
        public string ErrorMessage { get; set; }
        public object Response { get; set; }
    }
}
