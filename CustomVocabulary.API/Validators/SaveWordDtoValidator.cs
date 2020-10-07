using CustomVocabulary.API.DTOs;
using FluentValidation;

namespace CustomVocabulary.API.Validators
{
    public class SaveWordDtoValidator : AbstractValidator<SaveWordDto>
    {
        public SaveWordDtoValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(w => w.Name)
                .NotEmpty().WithMessage("You did not write a new Word!")
                .MaximumLength(50).WithMessage("This word is to long!");
            RuleFor(w => w.Description)
                .NotEmpty().WithMessage("Let's give a Description for your new Word");
            RuleFor(w => w.VocabularyId)
                .NotEmpty();
        }
    }
}
