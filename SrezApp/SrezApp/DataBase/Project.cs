using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace SrezApp.DataBase
{
    [Table("Projects")]
    public class Project
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [Unique]
        public string Name { get; set; }
        public string Description { get; set; }
        public int ID_User { get; set; }
        public DateTime Date { get; set; } 
    }
}
