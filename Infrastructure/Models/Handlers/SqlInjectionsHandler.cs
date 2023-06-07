using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class SqlInjectionsHandler : BaseHandler
{
    private string _errorMessage = "SQL injection possibility detected! Please, do not use keywords like 'select', 'delete', 'drop', 'update' and 'insert' or symbols like ';' and '='";
    private string[] _keywords = { "select", "delete", "drop", "update", "insert", ";", "="};
    protected override string? Validate(FormData form)
    {
        foreach (var kw in _keywords)
        {
            if (form.Surname.ToLower().Contains(kw) ||
                form.Surname.ToLower().Contains(kw) ||
                form.Surname.ToLower().Contains(kw) ||
                form.Surname.ToLower().Contains(kw) ||
                form.Surname.ToLower().Contains(kw) ||
                form.Surname.ToLower().Contains(kw) ||
                form.Surname.ToLower().Contains(kw) ||
                form.Surname.ToLower().Contains(kw))
                return _errorMessage;
        }

        return null;
    }
}