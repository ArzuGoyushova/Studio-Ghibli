using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Application.Wrappers
{
    public class ServiceResponse<T>
    {
        public T Value { get; set; }
        public bool Success { get; set; } 
        public List<string> Errors { get; set; } = new List<string>(); 
        public string Message { get; set; }

        public ServiceResponse()
        {
        }

        public ServiceResponse(T value)
        {
            Value = value;
        }
        public ServiceResponse(T value, string message)
        {
            Value = value;
            Message = message;
        }
        public void SetErrors(List<string> errors)
        {
            Success = false;
            Errors = errors;
        }
    }

}
