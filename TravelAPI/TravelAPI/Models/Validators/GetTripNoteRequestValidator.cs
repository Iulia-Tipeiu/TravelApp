using FluentValidation;
using System.Data;
using TravelAPI.Models.Requests;

namespace TravelAPI.Models.Validators
{
    public class GetTripNoteRequestValidator : AbstractValidator<GetTripNoteRequest>
    {
        public GetTripNoteRequestValidator() 
        {
            RuleFor(validator => validator.Id).NotNull().NotEmpty();
        }
    }
}
