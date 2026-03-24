using APBD_TASK2.Database;

var db = Singleton.Instance;
var service = new RentalService();

var student = new User("John", "Doe", UserType.Student);
var employee = new User("Anna", "Smith", UserType.Employee);

service.AddUser(student);
service.AddUser(employee);

var laptop = new Laptop("Dell XPS", 16, "i7");
service.AddEquipment(laptop);

service.RentEquipment(student.Id, laptop.Id, 2);

service.ReturnEquipment(laptop.Id);

var all = service.GetAllEquipment();