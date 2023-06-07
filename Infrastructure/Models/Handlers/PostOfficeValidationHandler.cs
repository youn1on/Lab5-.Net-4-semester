using System.Text.RegularExpressions;
using Infrastructure.Interfaces;

namespace Infrastructure.Models.Handlers;

public class PostOfficeValidationHandler : BaseHandler
{
    private string _errorMessage = "Invalid post office format! Please, input your post office in format 'Country, City, 111'.";
    private Regex _pattern = new(@"^(?:[A-Z][a-z]+(?:-[A-Z][a-z]+)* *, *){2}\d+$");
    protected override string? Validate(FormData form)
    {
        if (Enum.Parse<DeliveryType>(form.DeliveryType) != DeliveryType.ByPost) return null;
        if (form.PostOfficeNumber is not null && _pattern.IsMatch(form.PostOfficeNumber.Trim()))
        {
            var splitted = form.PostOfficeNumber.Trim().Split(",", StringSplitOptions.TrimEntries);
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