using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public class User
{
    private static int _idCounter = 1;
    
    public int Id { get; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public UserType UserType { get; set; }

    public User(string name, string surname, UserType userType)
    {
        Id = _idCounter++;
        Name = name;
        Surname = surname;
        UserType = userType;
    }
}