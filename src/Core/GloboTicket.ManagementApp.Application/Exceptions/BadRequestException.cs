using System;

namespace GloboTicket.ManagementApp.Application.Exceptions
{
    public class BadRequestException : ApplicationException
    {
        public BadRequestException(string message): base(message)
        {
            
        }
    }
}