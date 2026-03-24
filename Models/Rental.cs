namespace APBD_TASK2.Models;

public class Rental
{
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal Penalty { get; private set; }

    public bool IsReturned => ReturnDate != null;
    public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;

    public Rental(User user, Equipment equipment, DateTime rentalDate, DateTime dueDate)
    {
        User = user;
        Equipment = equipment;
        RentalDate = rentalDate;
        DueDate = dueDate;
    }

    public void Return(DateTime returnDate, decimal penalty)
    {
        ReturnDate = returnDate;
        Penalty = penalty;
    }
}