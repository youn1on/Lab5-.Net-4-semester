using Infrastructure.Interfaces;
using Infrastructure.Models.Handlers;

namespace ConsoleApp;

public static class Program
{
    public static void Main()
    {
        IHandler handlersChain = ConstructHandlers();
        UserInterface.MainLoop(handlersChain);
    }

    public static IHandler ConstructHandlers()
    {
        IHandler firstHandler = new SqlInjectionsHandler();
        IHandler xssHandler = new XssInjectionsHandler();
        firstHandler.SetNextHandler(xssHandler);
        IHandler nameHandler = new NameValidationHandler();
        xssHandler.SetNextHandler(nameHandler);
        IHandler surnameHandler = new SurnameValidationHandler();
        nameHandler.SetNextHandler(surnameHandler);
        IHandler patronymicHandler = new PatronymicValidationHandler();
        surnameHandler.SetNextHandler(patronymicHandler);
        IHandler emailHandler = new EmailValidationHandler();
        patronymicHandler.SetNextHandler(emailHandler);
        IHandler phoneNumberHandler = new PhoneNumberValidationHandler();
        emailHandler.SetNextHandler(phoneNumberHandler);
        IHandler deliveryHandler = new DeliveryTypeValidationHandler();
        phoneNumberHandler.SetNextHandler(deliveryHandler);
        IHandler addressHandler = new AddressValidationHandler();
        deliveryHandler.SetNextHandler(addressHandler);
        IHandler postOfficeNumberHandler = new PostOfficeValidationHandler();
        addressHandler.SetNextHandler(postOfficeNumberHandler);

        return firstHandler;
    }
}