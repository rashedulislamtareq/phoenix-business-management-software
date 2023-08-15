using FluentValidation;
using Phoenix.BusinessManagement.ClientModel.Models.HealthCheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Phoenix.BusinessManagement.ClientModel.Validator.HealthCheck
{
    public class HealthCheckCreateValidator : AbstractValidator<HealthCheckCreateVM>
    {
        public HealthCheckCreateValidator()
        {
            //Validation for Name
            RuleFor(obj => obj.Name).NotEmpty()
                .WithMessage("{PropertyName} is required")
                .Length(3, 100)
                .WithMessage("{PropertyName} must be between 03 and 100 characters long.")
                .Must(value => !Regex.IsMatch(value, @"[^\w\s\-']")).WithMessage("{PropertyName} cannot contain special characters")
                .Must(value => !value.Contains("||"))
                .WithMessage("{PropertyName} cannot contain the characters '||'")
                .Must(value => !value.Contains("&&"))
                .WithMessage("{PropertyName} cannot contain the characters '&&'")
                .Must(value => !value.StartsWith(" ") && !value.EndsWith(" ")).WithMessage("{PropertyName} cannot have leading or trailing spaces.");

            //Validation for Description
            RuleFor(obj => obj.Description) 
                .Length(0, 150)
                .Must(value => string.IsNullOrWhiteSpace(value) || (value.Length >= 3 && value.Length <= 150))
                .WithMessage("{PropertyName} must be between 3 and 150 characters long if provided.")
                .Must(value => !value.Contains("||"))
                .WithMessage("{PropertyName} cannot contain the characters '||'")
                .Must(value => !value.Contains("&&"))
                .WithMessage("{PropertyName} cannot contain the characters '&&'")
                .Must(value => string.IsNullOrWhiteSpace(value) || (!value.StartsWith(" ") && !value.EndsWith(" ")))
                .WithMessage("{PropertyName} cannot have leading or trailing spaces if provided.");

        }
    }

    public class HealthCheckUpdateValidator : AbstractValidator<HealthCheckUpdateVM>
    {
        public HealthCheckUpdateValidator(int id)
        {
            //Validation for Id
            RuleFor(x => x.Id).NotEmpty()
                .WithMessage("{PropertyName} is required")
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than zero.")
                .Equal(id).WithMessage("{PropertyName} must be same as the provided id.");

            //Validation for Name
            RuleFor(obj => obj.Name).NotEmpty()
                .WithMessage("{PropertyName} is required")
                .Length(3, 100)
                .WithMessage("{PropertyName} must be between 03 and 100 characters long.")
                .Must(value => !Regex.IsMatch(value, @"[^\w\s\-']")).WithMessage("{PropertyName} cannot contain special characters")
                .Must(value => !value.Contains("||"))
                .WithMessage("{PropertyName} cannot contain the characters '||'")
                .Must(value => !value.Contains("&&"))
                .WithMessage("{PropertyName} cannot contain the characters '&&'")
                .Must(value => !value.StartsWith(" ") && !value.EndsWith(" ")).WithMessage("{PropertyName} cannot have leading or trailing spaces.");

            //Validation for Description
            RuleFor(obj => obj.Description)
                .Length(0, 150)
                .Must(value => string.IsNullOrWhiteSpace(value) || (value.Length >= 3 && value.Length <= 150))
                .WithMessage("{PropertyName} must be between 3 and 150 characters long if provided.")
                .Must(value => !value.Contains("||"))
                .WithMessage("{PropertyName} cannot contain the characters '||'")
                .Must(value => !value.Contains("&&"))
                .WithMessage("{PropertyName} cannot contain the characters '&&'")
                .Must(value => string.IsNullOrWhiteSpace(value) || (!value.StartsWith(" ") && !value.EndsWith(" ")))
                .WithMessage("{PropertyName} cannot have leading or trailing spaces if provided.");

        }
    }
}
