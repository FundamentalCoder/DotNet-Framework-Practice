using C.Project.Generic;

var userRepository = new UserRepository();


var user1 = new User { Id = 1, Name = "John" };


userRepository.AddUser(user1);

var user2 = new User { Id = 2, Name = "Jane" };
userRepository.AddUser(user2);

var getUser = userRepository.GetUserById(1);
Console.WriteLine($"User 1: Id={getUser.Id}, Name={getUser.Name}");


var updatedUser1 = new User { Id = 1, Name = "John Doe" };
userRepository.UpdateUser(updatedUser1);

var getUser1 = userRepository.GetUserById(1);
Console.WriteLine($"User 1: Id={getUser1.Id}, Name={getUser1.Name}");



