using Infrastructure.Models;

namespace Infrastructure.Interfaces;

public interface IHandler
{
    public ValidationError? Handle(FormData form);
    public void SetNextHandler(IHandler nextHandler);
}