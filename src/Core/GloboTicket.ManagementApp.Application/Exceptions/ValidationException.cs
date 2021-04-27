using System;
using System.Collections.Generic;
using FluentValidation.Results;

namespace GloboTicket.ManagementApp.Application.Exceptions
{
    public class ValidationException : ApplicationException
    {
        private List<string> ValidationErrors { get;}
        public ValidationException(ValidationResult validationResult)
        {
            ValidationErrors = new List<string>();
            foreach (var validationResultError in validationResult.Errors)
            {
                ValidationErrors.Add(validationResultError.ErrorMessage);
            }
        }
    }
}