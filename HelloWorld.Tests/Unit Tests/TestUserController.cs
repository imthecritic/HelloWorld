using System;
using Xunit;



namespace HelloWorld.Tests
{
	//public class TestUserController
	//{
	//	[Fact]
	//	public void GetAllUsers_ShouldReturnAllUsers()
	//	{
 //           var testUsers = GetTestUsers();
 //           var controller = new UserController(testUsers);

	//		var result = controller.GetAll() as List<User>;
	//		Assert.AreEqual(testProducts.Count, result.Count);
	//	}


 //       [Fact]
	//	public void GetUser_ShouldReturnCorrectUser()
	//	{
 //           var testUsers = GetTestUsers();
 //           var controller = new UserController(testUsers);

	//		var result = controller.GetUser(4) as OkNegotiatedContentResult<User>;
	//		Assert.IsNotNull(result);
	//		Assert.AreEqual(testUsers[3].firstName, result.Content.firstName);
	//		Assert.AreEqual(testUsers[3].lastName, result.Content.lastName);

	//	}

 //       [Fact]
	//	public void GetUser_ShouldNotFindProduct()
	//	{
 //           var controller = new UserController(GetTestUsers());

	//		var result = controller.GetById(999);
	//		Assert.IsInstanceOfType(result, typeof(NotFoundResult));
	//	}

	//	private List<User> GetTestUsers()
	//	{
	//		var testUsers = new List<User>();
 //           testUsers.Add(new User { Id = 1, firstName = "John", lastName = "Doe", birthdate= new DateTime(1970,1,1) });
	//		testUsers.Add(new User { Id = 2, firstName = "Jasmine", lastName = "Farley", birthdate = new DateTime(1995, 3, 23) });
	//		testUsers.Add(new User { Id = 3, firstName = "Bob", lastName = "Johnson", birthdate = new DateTime(1980, 2, 15) });
	//		testUsers.Add(new User { Id = 4, firstName = "Sue", lastName = "Smith", birthdate = new DateTime(1990, 3, 27) });

	//		return testUsers;
	//	}
	//}
}