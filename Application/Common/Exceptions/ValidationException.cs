﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation.Results;

namespace Application.Common.Exceptions
{
    public  class ValidationException:Exception
    {
        public string Message {  get; set; }

        public Dictionary<string, string[]> Errors { get; set; }

        public ValidationException(IEnumerable<ValidationFailure> validationFailures)
        {
            Errors = validationFailures.GroupBy(error => error.PropertyName, error => error.ErrorMessage)
                .ToDictionary(a => a.Key, a => a.ToArray());
        }

        public ValidationException(string PropertyName, string error)
        {


            Errors.Add(PropertyName, new string[] { error });
        }
    }
}
