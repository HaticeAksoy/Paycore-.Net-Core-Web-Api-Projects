using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaycoreWeek2.Models
{
    public class StaffValidator : AbstractValidator<Staff>  
    {
        public StaffValidator()
        {
            //name must be between 20 and 120 character and not in special character.
            RuleFor(x => x.Name).MinimumLength(20).MaximumLength(120).Matches(@"[A-Za-z0-9]").NotEmpty();

            //lastname musnt null and between 20 and 120 character.
            RuleFor(x => x.Lastname).Length(20, 120).Matches(@"[A-Za-z0-9]").NotEmpty();

            //must be between 10-10-2002 and 11-11-1945 .
            RuleFor(x => x.DateofBirth).NotEmpty().WithMessage("Boş Geçilemez").LessThan(new DateTime(2002, 10, 10)).GreaterThan(new DateTime(1945, 11, 11)).WithMessage("Dogum tarihi 10-10-2002 ile 11-11-1945 arasinda olmalıdır.");

            //must be salary min 2000 max 9000 .
            RuleFor(x => x.Salary).LessThan(9000).GreaterThan(2000);

            //must be  with the area code 
            RuleFor(x => x.PhoneNumber).NotEmpty().Matches(@"^[+90]").WithMessage("Alan kodu girilmek zorundadır.");

            // must not contain special characters.
            RuleFor(x => x.Email).NotEmpty().Matches(@"[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]{2,3}");
        }
    }
}
