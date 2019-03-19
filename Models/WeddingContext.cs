using System;
using Microsoft.EntityFrameworkCore;

namespace wedding.Models{



        public class WeddingContext: DbContext{

            public WeddingContext(DbContextOptions<WeddingContext> options): base (options) {}

            public DbSet<Guest> guests {get;set;}

            public DbSet<Users> users {get;set;}

            public DbSet<Weddings> weddings {get;set;}





        }




    }