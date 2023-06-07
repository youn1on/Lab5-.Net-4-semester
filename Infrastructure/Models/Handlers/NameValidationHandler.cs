using System.Text.RegularExpressions;
using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class NameValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid name structure! Please, use only Latin letters, spaces or hyphens.";
    private Regex _pattern = new(@"^[A-Z][a-z ]*(?:-[A-Z][a-z ]*)?$");
    protected override string? Validate(FormData form)
    {
        if (_pattern.IsMatch(form.Name.Trim())) return null;
        return _errorMessage;
    }
}