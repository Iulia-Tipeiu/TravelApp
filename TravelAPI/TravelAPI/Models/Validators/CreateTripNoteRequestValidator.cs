using FluentValidation;
using TravelAPI.Models.Requests;

namespace TravelAPI.Models.Validators
{
    public class CreateTripNoteRequestValidator : AbstractValidator<CreateTripNoteRequest>
    {
        public CreateTripNoteRequestValidator(IValidator<TripNote> tripNoteValidator) 
        {
            RuleFor(validator => validator.Note).SetValidator(tripNoteValidator);
        }

    }
}
