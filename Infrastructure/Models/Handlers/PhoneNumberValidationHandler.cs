using System.Text.RegularExpressions;
using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class PhoneNumberValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid phone number format! Please, input your number in format '+380505050505'. Use only numbers and '+' symbol.";
    private Regex _pattern = new(@"^\+(?:\d ?){6,14}\d$");
    protected override string? Validate(FormData form)
    {
        if (_pattern.IsMatch(form.PhoneNumber.Trim())) return null;
        return _errorMessage;
    }
}