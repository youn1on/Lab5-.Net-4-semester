using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public abstract class BaseHandler : IHandler
{
    public BaseHandler? Next;
    public void SetNextHandler(IHandler nextHandler)
    {
        Next = (BaseHandler)nextHandler;
    }
    
    public ValidationError? Handle(FormData form)
    {
        string? errorMessage = Validate(form);
        return  errorMessage is not null? new ValidationError(errorMessage) : Next?.Handle(form);
    }

    protected abstract string? Validate(FormData form);
}