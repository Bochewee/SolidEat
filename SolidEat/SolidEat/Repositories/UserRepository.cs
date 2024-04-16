using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using SolidEat.Models;
using SQLite;

namespace SolidEat.Repositories
{
    public class UserRepository
    {
        private SQLiteAsyncConnection connection;

        public string StatusMessage { get; set; }

        public UserRepository(string dbPath)
           {
               connection = new SQLiteAsyncConnection(dbPath);
               connection.CreateTableAsync<User>();
           }

        public async Task AddNewUserAsync(string name)
        {
            int result = 0;

            try
            {
                result = await connection.InsertAsync(new User { Name = name });

                StatusMessage = $"{result} utilisateur ajouté : {name}";
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible d'ajouter l'utilisateur : {name}.\n Erreur : {ex.Message}";
            }
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                return await connection.Table<User>().ToListAsync();
            }
            catch (Exception ex)
            {
                StatusMessage = $"Impossible de récupérer les utilisateurs.\n Erreur : {ex.Message}";
            }

            return new List<User>();    
        }
    }
}
