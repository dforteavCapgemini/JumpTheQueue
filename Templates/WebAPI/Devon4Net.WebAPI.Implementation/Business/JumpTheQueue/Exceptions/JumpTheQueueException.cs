using Devon4Net.Infrastructure.Common.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Devon4Net.WebAPI.Implementation.Business.JumpTheQueue.Exceptions
{
    /// <summary>
    /// Custom exception JumpTheQueueException
    /// </summary>
    [Serializable]
    public class JumpTheQueueException : Exception, IWebApiException
    {
        
        public int StatusCode => StatusCodes.Status400BadRequest;

        
        public bool ShowMessage => true;

        public JumpTheQueueException()
        {
        }

        public JumpTheQueueException(string message)
            : base(message)
        {
        }
    }
}
