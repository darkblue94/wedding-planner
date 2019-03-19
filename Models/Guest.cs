using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wedding.Models{


        public class Guest{
            
            [Key]
            public int GuestId {get;set;}
                 
            public int UserId{ get; set; }

            public Users user { get; set; }


            public int WeddingId{ get; set; }

            public Weddings wedding{ get; set; }






        }






    }