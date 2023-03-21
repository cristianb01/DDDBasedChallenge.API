using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDBasedChallenge.Application.Communication
{
    public class Response<T>
    {
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        /// <summary>
        /// Creates a success response
        /// </summary>
        public Response(T data, string message = null)
        {
            Data = data;
            Message = message;
            Succeeded = true;
        }

        /// <summary>
        /// Creates an error response
        /// </summary>
        /// <param name="message">Error message</param>
        public Response(string message)
        {
            Succeeded = false;
            Message = message;
        }
    }
}
