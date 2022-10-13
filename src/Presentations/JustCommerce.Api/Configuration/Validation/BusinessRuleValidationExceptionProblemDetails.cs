using JustCommerce.Modules.BuildingBlocks.Domain;
using Microsoft.AspNetCore.Mvc;

namespace JustCommerce.Api.Configuration.Validation
{
    public class BusinessRuleValidationExceptionProblemDetails : ProblemDetails
    {
        public BusinessRuleValidationExceptionProblemDetails(BusinessRuleValidationException exception)
        {
            Title = "Business rule broken";
            Status = StatusCodes.Status409Conflict;
            Detail = exception.Message;
            Type = "https://somedomain/business-rule-validation-error";
        }
    }
}