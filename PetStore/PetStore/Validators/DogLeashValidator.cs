using FluentValidation;
using PetStore.data;


namespace PetStore.Validators
{
    internal class DogLeashValidator : AbstractValidator<ProductEntity>
    {
        //should we update name of DogLeashValidator since it is looking at prducts in general now?
        public DogLeashValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).MinimumLength(10).When(x => !string.IsNullOrEmpty(x.Description));
            RuleFor(x => x.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
        }
    }
}
