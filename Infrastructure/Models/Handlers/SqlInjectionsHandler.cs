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
                form.Name.ToLower().Contains(kw) ||
                form.Patronymic is not null && form.Patronymic.ToLower().Contains(kw) ||
                form.Email.ToLower().Contains(kw) ||
                form.PhoneNumber.ToLower().Contains(kw) ||
                form.DeliveryType.ToLower().Contains(kw) ||
                form.Address is not null && form.Address.ToLower().Contains(kw) ||
                form.PostOfficeNumber is not null && form.PostOfficeNumber.ToLower().Contains(kw))
                return _errorMessage;
        }

        return null;
    }
}