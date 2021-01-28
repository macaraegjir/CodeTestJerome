using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeTest.Error
{
    public class ErrorHandling 
    {
        public void throwError(string ErrorResponse,string ErrorContent , HttpStatusCode statCode)
        {
            var resp = new HttpResponseMessage(statCode)
            {
                Content = new StringContent(ErrorContent),
                ReasonPhrase = "ErrorResponse"
            };
            throw new HttpResponseException(resp);
        }
    }
}