using System.Text.RegularExpressions;
using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class SurnameValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid surname structure! Please, use only Latin letters, spaces or hyphens.";
    private Regex _pattern = new(@"^[A-Z][a-z ]*(?:-[A-Z][a-z ]*)?$");
    protected override string? Validate(FormData form)
    {
        if (_pattern.IsMatch(form.Surname.Trim())) return null;
        return _errorMessage;
    }
}