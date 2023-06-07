using Infrastructure.Interfaces;
using Infrastructure.Models;

namespace ConsoleApp;

public static class UserInterface
{
    public static void MainLoop(IHandler handlerChain)
    {
        while (true)
        {
            FormData? form = FillNewForm();
            if (form is null)
                break;

            var validationError = handlerChain.Handle(form);
            if (validationError is null)
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Successfully validated!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Validation error!");
                Console.WriteLine(validationError);
                Console.ResetColor();
            }

            Console.WriteLine();
        }

        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("Exiting...");
        Console.ResetColor();
    }

    private static FormData? FillNewForm()
    {
        string? name = GetInput("name");
        if (name is null) return null;

        string? surname = GetInput("surname");
        if (surname is null) return null;
        
        string? patronymic = GetInput("patronymic");
        if (patronymic is null) return null;
        
        string? phoneNumber = GetInput("phone number");
        if (phoneNumber is null) return null;
        
        string? email = GetInput("email");
        if (email is null) return null;
        
        string? deliveryType = GetInput("delivery type");
        if (deliveryType is null) return null;
        
        string? address = null, postOffice = null;
        if (deliveryType.Trim() != "SelfPickup")
        {
            address = GetInput("address");
            if (address is null) return null;

            if (deliveryType.Trim() != "ByPost")
            {
                postOffice = GetInput("post office number");
                if (postOffice is null) return null;
            }
        }

        return new FormData(name, surname, patronymic, phoneNumber, email, deliveryType, address, postOffice);
    }

    private static string? GetInput(string fieldName)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine($"Enter the {fieldName} or 'q' to exit: ");
        Console.ResetColor();
        
        var field = Console.ReadLine()!;
        return field == "q" ? null : field;
    }
}