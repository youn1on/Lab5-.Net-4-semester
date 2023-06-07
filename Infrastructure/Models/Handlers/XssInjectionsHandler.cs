using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class XssInjectionsHandler : BaseHandler
{
    private string _errorMessage = "XSS injection possibility detected! Please, do not use keywords like 'script' and 'src=' or symbols like ';', '=', '<' and '>'.";
    private string[] _keywords = { "script", "src=", ";", "=", "<", ">"};
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