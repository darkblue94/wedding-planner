using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wedding.Models{
    public class Users
    {

    [Key]
    public int UserId { get; set; }

    public string first_name { get; set; }

    public string last_name { get; set; }

    public string email { get; set; }

    public string password { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime created_at { get; set; }
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
    public DateTime updated_at { get; set; }

    public List<Weddings> attending_wedding;

    public List<Guest> guest ; 

    public Users(){
        attending_wedding= new List<Weddings>();
        guest=new List<Guest>();

    }
    
    }
}
