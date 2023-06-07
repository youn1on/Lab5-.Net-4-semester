using System.Text.RegularExpressions;
using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class EmailValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid email format! Please, input your email in acceptable format.";
    private Regex _pattern = new(@"^[\w-.]+@\w+(?:.[\w]+)*$");
    protected override string? Validate(FormData form)
    {
        if (_pattern.IsMatch(form.Email.Trim())) return null;
        return _errorMessage;
    }
}