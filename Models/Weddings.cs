using System ;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wedding.Models{

        public class Weddings{
            [Key]
            public int WeddingId {get;set;}

            public string bride {get;set;}

            public string groom {get;set;}
            [DataType(DataType.Date)]
            [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
            public DateTime date {get;set;}

            public string adress{get;set;}
            
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]


        public DateTime created_at{get;set;}
            
            [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
            public DateTime updated_at {get;set;}

        public List<Guest> guest{get;set;}

        public Weddings(){
            guest = new List<Guest>();
        }

        }
    }