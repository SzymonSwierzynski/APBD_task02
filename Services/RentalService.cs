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
    
    private decimal CalculatePenalty(Rental rental)
    {
        if (rental.returnDate <= rental.DueDate) return 0;

        int daysLate = (rental.returnDate.Value - rental.DueDate).Days;
        return daysLate * 10;
    }

    public void RentEquipment(int userId, int equipmentId, int days)
    {
        var user = _users.FirstOrDefault(u => u.Id == userId);
        var equipment = _equipment.FirstOrDefault(e => e.Id == equipmentId);

        if (user == null || equipment == null)
            throw new Exception("User or equipment not found");
        if (!equipment.IsAvailable)
            throw new Exception("Equipment unavailable");

        int activeRentals = _rentals.Count(r => r.User == user && !r.IsReturned);
        if (activeRentals >= GetUserLimit(user))
            throw new Exception("User exceeded rental limit");

        var rental = new Rental(user, equipment, DateTime.Now, DateTime.Now.AddDays(days));
        
        _rentals.Add(rental);
        equipment.Status = EquipmentStatus.Rented;
    }

    public void ReturnEquipment(int equipmentId)
    {
        var rental = _rentals.FirstOrDefault(r => r.Equipment.Id == equipmentId && !r.IsReturned);

        if (rental == null)
            throw new Exception("Active rental not found");

        var returnDate = DateTime.Now;

        rental.Return(returnDate, 0);
        var penalty = CalculatePenalty(rental);

        rental.Return(returnDate, penalty);
        rental.Equipment.Status = EquipmentStatus.Available;
    }

    public List<Equipment> GetAllEquipment() => _equipment;

    public List<Equipment> GetAvailableEquipment()
    {
        return _equipment.Where(e => e.IsAvailable).ToList();
    }

    public List<Rental> GetUserActiveRentals(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && !r.IsReturned).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _rentals.Where(r => r.IsOverdue).ToList();
    }
}