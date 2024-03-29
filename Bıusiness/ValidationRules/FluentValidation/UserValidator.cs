﻿using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.LastName).NotEmpty();
            RuleFor(p => p.LastName).MinimumLength(3);
            RuleFor(p => p.FirstName).NotEmpty();
            RuleFor(p => p.FirstName).MinimumLength(3);
            RuleFor(p => p.Email).NotEmpty();
            RuleFor(p => p.PasswordHash).NotEmpty();
            RuleFor(p => p.Email).MinimumLength(8);
            //RuleFor(p => p.FirstName).Must(StartWithA).WithMessage("A harfi ile başlamalıdır.");
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}
