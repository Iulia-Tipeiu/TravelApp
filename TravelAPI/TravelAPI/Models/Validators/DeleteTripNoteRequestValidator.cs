using FluentValidation;
using TravelAPI.Models.Requests;

namespace TravelAPI.Models.Validators
{
    public class DeleteTripNoteRequestValidator : AbstractValidator<DeleteTripNoteRequest>
    {
        public DeleteTripNoteRequestValidator()
        { 
            RuleFor(validator => validator.Id).NotNull().NotEmpty();
        }
    }
}
