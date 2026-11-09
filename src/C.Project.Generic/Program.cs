using C.Project.Generic;

var userRepository = new UserRepository();

var baseRepository = new BaseRepository<User, int>();
var user = new User { Id = 1, Name = "John" };


baseRepository.Add(user);

Console.WriteLine( baseRepository.FindById(1).Name);

//------------------------------------------------------------------------//
var vehicleRepository = new BaseRepository<Vehicle, int>();

var auto = new Vehicle { Id = 1, Model = "Camry", Make = "Toyota" };

vehicleRepository.Add(auto);
var auto2 = new Vehicle { Id = 2, Model = "Civic", Make = "Honda" };

var baseRepositoryVehicle = new BaseRepository<Vehicle, int>();

var auto3 = new Vehicle { Id = 3, Model = "Model S", Make = "Tesla" };
baseRepositoryVehicle.Add(auto3);

baseRepositoryVehicle.Add(auto2);

baseRepository.GetAll().ToList().ForEach(u => Console.WriteLine($"User: Id={u.Id}, Name={u.Name}"));
vehicleRepository.GetAll().ToList().ForEach(v => Console.WriteLine($"Vehicle: Id={v.Id}, Make={v.Make}, Model={v.Model}"));





Console.WriteLine(vehicleRepository.FindById(1).Make);


//Console.WriteLine($"User: Id={user.Id}, Name={user.Name}");



//var user1 = new User { Id = 1, Name = "John" };


//userRepository.AddUser(user1);

//var user2 = new User { Id = 2, Name = "Jane" };
//userRepository.AddUser(user2);

//var getUser = userRepository.GetUserById(1);
//Console.WriteLine($"User 1: Id={getUser.Id}, Name={getUser.Name}");


//var updatedUser1 = new User { Id = 1, Name = "John Doe" };
//userRepository.UpdateUser(updatedUser1);

//var getUser1 = userRepository.GetUserById(1);
//Console.WriteLine($"User 1: Id={getUser1.Id}, Name={getUser1.Name}");



