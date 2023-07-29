using System.ComponentModel.DataAnnotations;

namespace Api.Validation
{
    public class IsInOther : ValidationAttribute
    {
        private string _other;
        public IsInOther(string other) 
        {
            _other = other;
        }


        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            var val = value as string;
            IList<string>? values = context.ObjectType.GetProperty(_other) as IList<string>;

            if (values == null) 
            {
                throw new Exception("Can't compare value to other property because other property is null");
            }

            if (values.Any(x => x ==  val))
            {
                return ValidationResult.Success;

            }

            return new ValidationResult("notInOther");

        }
    }
}
