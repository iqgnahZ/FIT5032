using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FIT5032_MyCodeFirst.Models
{
    public class MyCodeFirst : DbContext
    {
        // Your context has been configured to use a 'MyCodeFirst' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FIT5032_MyCodeFirst.Models.MyCodeFirst' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'MyCodeFirst' 
        // connection string in the application configuration file.
        public MyCodeFirst()
            : base("name=MyCodeFirst")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}

    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Unit> Units { get; set; }

    }
    public class Unit
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Student Student { get; set; }
    }
}