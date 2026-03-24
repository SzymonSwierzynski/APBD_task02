using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public class Equipment
{
    private static int _idCounter = 1;
    
    public int Id { get; }
    public string Name { get; set; }
    public EquipmentStatus Status  { get; set; }

    public bool IsAvailable => Status == EquipmentStatus.Available;

    protected Equipment(string name)
    {
        Id = _idCounter++;
        Name = name;
        Status = EquipmentStatus.Available;
    }
}