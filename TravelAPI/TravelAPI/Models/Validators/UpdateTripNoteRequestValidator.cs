using FluentValidation;
using TravelAPI.Models.Requests;

namespace TravelAPI.Models.Validators
{
    public class UpdateTripNoteRequestValidator : AbstractValidator<UpdateTripNoteRequest>
    {
        public UpdateTripNoteRequestValidator(IValidator<TripNote> tripNoteValidator) 
        {
            RuleFor(validator => validator.Id).NotEmpty().NotNull();

            RuleFor(validator => validator.Note).SetValidator(tripNoteValidator);
        }
    }
}
