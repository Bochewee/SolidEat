using System.Threading.Tasks;
using SQLite;
using SolidEat.Models;
using System.Collections.Generic;

namespace SolidEat.Repositories
{
    public class UserRepository
    {
        private SQLiteAsyncConnection connection;

        public UserRepository(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<User>().Wait();
        }

        public async Task InitializeAsync()
        {
            await connection.CreateTableAsync<User>();
        }

        // Ajouter les paramètres pour age et role
        public async Task AddNewUserAsync(string firstName, string lastName, string email, string password, int age, string role)
        {
            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email,
                Password = password,
                Age = age,
                Role = role
            };
            await connection.InsertAsync(newUser);
        }

        public async Task<bool> CheckLoginAsync(string email, string password)
        {
            var user = await connection.Table<User>().FirstOrDefaultAsync(u => u.Email == email);
            return user != null && user.Password == password;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await connection.Table<User>().ToListAsync();
        }

        public async Task DeleteUserAsync(int userId)
        {
            await connection.DeleteAsync<User>(userId);
        }

        public async Task<List<User>> GetUsersByRoleAsync(string role)
        {
            // Adaptez la requête pour filtrer par rôle
            return await connection.Table<User>().Where(u => u.Role == role).ToListAsync();
        }
    }
}
