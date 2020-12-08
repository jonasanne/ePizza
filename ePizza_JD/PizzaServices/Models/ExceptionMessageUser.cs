using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ePizza_JD.Models
{
    public class ExceptionMessageUser
    {
        public string Error { get; set; }
        public string Message { get; set; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string ErrorRoute { get; set; }


    }
}
