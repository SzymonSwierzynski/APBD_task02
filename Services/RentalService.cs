using APBD_TASK2.Enum;
using APBD_TASK2.Interfaces;
using APBD_TASK2.Models;

namespace APBD_TASK2.Services;

public class RentalService : IRentalService
{
    private List<User> _users = new();
    private List<Equipment> _equipment = new();
    private List<Rental> _rentals = new();

    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddEquipment(Equipment equipment)
    {
        _equipment.Add(equipment);
    }

    private int GetUserLimit(User user)
    {
        return user.UserType == UserType.Student ? 2 : 5;
    }
    
    priivate decimal CalculatePenalty(Rental rental)
    {
        if (rental.returnDate <= rental.DueDate) return 0;

        int daysLate = (rental.returnDate.Value - rental.DueDate).Days;
        return daysLate * 10;
        {
            
        }
    }
}