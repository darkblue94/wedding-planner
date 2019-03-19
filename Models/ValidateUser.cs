using System;
using System.ComponentModel.DataAnnotations;

namespace wedding.Models
{

    public class ValidateUser
    {


        [Required(ErrorMessage = "Must Provide First Name")]
        [MinLength(3, ErrorMessage = "First Name Must Be Atleast 3 Characters")]
        public string first_name { get; set; }

        [Required(ErrorMessage = "Must Provide Last Name")]
        [MinLength(3, ErrorMessage = "First Name Must Be Atleast 3 Characters")]
        public string last_name { get; set; }

        [Required(ErrorMessage = "Must Provide Email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }

        [MinLength(8)]
        [Required(ErrorMessage = "Please provide password")]
        [DataType(DataType.Password)]

        public string password { get; set; }



        [Required]
        [DataType(DataType.Password)]
        [Compare("password", ErrorMessage = "Passwords must match")]
        public string confirmpassword { get; set; }

    }

}