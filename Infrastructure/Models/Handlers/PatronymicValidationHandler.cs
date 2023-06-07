using System.Text.RegularExpressions;
using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class PatronymicValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid patronymic structure! Please, use only Latin letters, spaces or hyphens.";
    private Regex _pattern = new(@"^[A-Z][a-z ]*(?:-[A-Z][a-z ]*)?$");
    protected override string? Validate(FormData form)
    {
        if (string.IsNullOrEmpty(form.Patronymic) || _pattern.IsMatch(form.Patronymic.Trim())) return null;
        return _errorMessage;
    }
}