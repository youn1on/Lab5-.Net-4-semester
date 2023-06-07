using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class DeliveryTypeValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid delivery type! Please, select between 'SelfPickup', 'ByPost' and 'ByCourier'.";
    protected override string? Validate(FormData form)
    {
        if (Enum.TryParse(form.DeliveryType, out DeliveryType _))
        {
            return null;
        }
        return _errorMessage;
    }
}