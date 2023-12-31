﻿using FluentValidation.Results;

namespace Phoenix.BusinessManagement.ClientModel.Helper
{
    public static class FluentValidationHelper
    {
        public static List<string> GetErrorMessage(List<ValidationFailure> errors)
        {
            List<string> errorsMessages = new List<string>();
            foreach (var failure in errors)
            {
                errorsMessages.Add(failure.ErrorMessage);
            }
            return errorsMessages;
        }
    }
}
