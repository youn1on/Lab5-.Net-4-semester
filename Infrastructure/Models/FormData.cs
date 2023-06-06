namespace Infrastructure.Models;

public class FormData
{
    public string Surname { get; set; }
    public string Name { get; set; }
    public string? Patronymic { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string? Address { get; set; }
    public string DeliveryType { get; set; }
    public string? PostOfficeNumber { get; set; }

    public FormData(string name, string surname, string? patronymic, string phoneNumber, string email, string deliveryType, string? address, string? postOfficeNumber)
    {
        Name = name;
        Surname = surname;
        Patronymic = patronymic;
        PhoneNumber = phoneNumber;
        Email = email;
        DeliveryType = deliveryType;
        Address = address == "" ? null : address;
        PostOfficeNumber = postOfficeNumber == "" ? null : postOfficeNumber;
    }
}