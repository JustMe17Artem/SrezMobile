using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SrezApp.DataBase
{
    [Table("Users")]
    public class User
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [Unique]
        public string Login { get; set; }
        public string Password { get; set; }
        public string FIO { get; set; }


    }
}
