﻿using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Mc2.CrudTest.Infrastructure.Shared.Validations.Attributes;

public class ValidateEmailAttribute : ValidationAttribute
{
    public override string FormatErrorMessage(string name)
    {
        return base.FormatErrorMessage("email");
    }

    public override bool IsValid(object? emailValue)
    {
        string? email = emailValue.ToString();
        if (string.IsNullOrEmpty(email)) return false;

        Regex regex = new(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        return regex.IsMatch(email);
    }
}