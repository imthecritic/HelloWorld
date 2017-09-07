using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using HelloWorld.ConsoleApp.Models;

namespace HelloWorld.ConsoleApp
{
    class Program
    {
		static HttpClient client = new HttpClient();

		static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
			RunAsync().Wait();
			
		}

		static void SayHelloToUser(User user)
		{
            Console.WriteLine("Hello, " + user.firstName + " " + user.lastName +
                              " Your email address is : " + user.email + 
                              " Your birthday is " +user.birthdate.ToShortDateString());
		}

		static async Task<Uri> CreateUserAsync(User user)
		{
            Console.WriteLine("In CreateUserAsync");
			HttpResponseMessage response = await client.PostAsJsonAsync("api/users", user);
			response.EnsureSuccessStatusCode();

			// return URI of the created resource.
			return response.Headers.Location;
		}

		static async Task<User> GetUserAsync(string path)
		{
			User user = null;
			HttpResponseMessage response = await client.GetAsync(path);
			if (response.IsSuccessStatusCode)
			{
                user = await response.Content.ReadAsAsync<User>();
			}
            return user;
		}

        static async Task<User> UpdateUserAsync(User user)
		{
            HttpResponseMessage response = await client.PutAsJsonAsync($"api/users/{user.Id.ToString()}", user);
			response.EnsureSuccessStatusCode();

			// Deserialize the updated product from the response body.
			user = await response.Content.ReadAsAsync<User>();
			return user;
		}

        static async Task<HttpStatusCode> DeleteUserAsync(long id)
		{
            HttpResponseMessage response = await client.DeleteAsync($"api/users/{id.ToString()}");
			return response.StatusCode;
		}

        static async Task RunAsync()
		{
			client.BaseAddress = new Uri("http://localhost:5000/");
			client.DefaultRequestHeaders.Accept.Clear();
			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

			try
			{
				// Create a new product
                User user = new User { firstName = "Jasmine", 
                    lastName = "Farley", 
                    email = "jasmine@email.com", 
                    birthdate= new DateTime(1995, 03, 23) };

				var url = await CreateUserAsync(user);
                Console.WriteLine($"Created at " + url.ToString());

				// Get the product
				user = await GetUserAsync(url.PathAndQuery);
                SayHelloToUser(user);

				// Update the product
				Console.WriteLine("Updating last name...");
                user.lastName = "Doe";
				await UpdateUserAsync(user);

				// Get the updated product
                user = await GetUserAsync(url.PathAndQuery);
                SayHelloToUser(user);

				// Delete the product
				var statusCode = await DeleteUserAsync(user.Id);
				Console.WriteLine($"Deleted (HTTP Status = " + (int)statusCode + ")");

			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}

			Console.ReadLine();
		}
    }
}
