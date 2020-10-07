using CustomVocabulary.API.DTOs;
using FluentValidation;

namespace CustomVocabulary.API.Validators
{
    public class SaveVocabularyDtoValidator : AbstractValidator<SaveVocabularyDto>
    {
        public SaveVocabularyDtoValidator()
        {
            CascadeMode = CascadeMode.Stop;

            RuleFor(v => v.Name)
                .NotEmpty().WithMessage("You must declare a Name for your new Vocabulary!")
                .MaximumLength(50).WithMessage("This Name is to long!");
            RuleFor(v => v.Description)
                .NotEmpty().WithMessage("Let's give a Description for your new Vocabulary!");
        }
    }
}
