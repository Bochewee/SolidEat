using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SolidEat.Models
{
    [Table("User")]
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(50), Unique]
        public string Name { get; set; }
    }
}
