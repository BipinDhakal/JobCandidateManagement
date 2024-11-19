using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JobCandidateManagement.UI.Models
{
    public class ResponseModel<TResult>
    {
        public TResult? Result { get; set; }

        public string Message { get; set; } = string.Empty;

        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.Accepted;

        public bool IsSuccess { get; set; }

        public Exception Exception { get; set; }
    }
}
