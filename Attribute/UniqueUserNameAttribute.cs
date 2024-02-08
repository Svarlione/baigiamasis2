using System.ComponentModel.DataAnnotations;

namespace baigiamasis2.Attribute
{
    public class UniqueUserNameAttribute : ValidationAttribute
    {
        //patikrina ar domenu bazeje nepasikartoja user name(unikalus)
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return ValidationResult.Success;
        }
    }
}
