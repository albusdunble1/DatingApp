using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using API.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(DataContext context){
            
            // check if there are any users in the database
            if(await context.Users.AnyAsync()) return;

            var userData = await System.IO.File.ReadAllTextAsync("Data/UserSeedData.json");
            
            // deserializes the json file into an Object
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);
            

            foreach (var user in users){
                
                using var hmac = new HMACSHA512();

                user.UserName = user.UserName.ToLower();
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("123123"));
                user.PasswordSalt = hmac.Key;

                // adding tracking using entity framework, doesnt do anything to the database yet
                context.Users.Add(user);
            }

            await context.SaveChangesAsync();


        }
    }
}