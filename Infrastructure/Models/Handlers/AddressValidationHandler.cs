using System.Text.RegularExpressions;
using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class AddressValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid address format! Please, input your address in format 'Country, City, Commercial Street, 121-A, flat 5'. Flat is optional.";
    private Regex _pattern = new(@"^(?:[A-Z][a-z]+(?:-[A-Z][a-z]+)* *, *){2}[A-Z][a-z]+(?:-[A-Z][a-z]+)* *Street, *\d+(?:-\w)?(?: *, *flat \d{1,4})?$");
    protected override string? Validate(FormData form)
    {
        if (Enum.Parse<DeliveryType>(form.DeliveryType) == DeliveryType.SelfPickup) return null;
        if (form.Address is not null && _pattern.IsMatch(form.Address.Trim()))
        {
            var splitted = form.Address.Trim().Split(",", StringSplitOptions.TrimEntries);
            foreach (var country in _availableCountries)
            {
                if (splitted[0] == country.countryName)
                {
                    foreach (var city in country.cities)
                    {
                        if (splitted[1] == city)
                            return null;
                        break;
                    }
                    
                    break;
                }
            }
        }

        return _errorMessage;
    }

    private (string countryName, string[] cities)[] _availableCountries =
    {
        ("Ukraine", new []{"Kyiv", "Zhytomyr", "Poltava", "Kharkiv", "Lviv"}),
        ("Poland", new []{"Warsaw", "Krakov", "Krolevets", "Gdansk"}),
        ("Germany", new []{"Berlin", "Frankfurt"})
    };
}