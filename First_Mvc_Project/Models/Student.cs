using Microsoft.AspNetCore.Cors;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Task_Mvc.Models
{
    public class Student
    {
        public int Id { get; set; }
        [StringLength(20,MinimumLength =3),Required(ErrorMessage ="****")]
        public string Name { get; set; }
        [StringLength(20, MinimumLength = 3)]

        public string Address { get; set; }
        [Range(20,35)]
        public int Age { get; set; }

        [RegularExpression(@"[a-zA-Z0-9_]+@+[a-zA-Z0-9]+[.]+[a-zA-Z0-9]{2,6}",ErrorMessage ="Email Doesnt Match Requirments")]
        [Required]
        [DataType(DataType.EmailAddress)]

        public string Email { get; set; }
        [Required(ErrorMessage ="*"),StringLength(20,MinimumLength =8)]
        [DataType(DataType.Password)]

        public  string Password { get; set; }

        [Display(Name="ConfirmPassword")]
        [Compare("Password",ErrorMessage ="Password Doesnt Match")]
        [NotMapped]
        [DataType(DataType.Password)]

        public string Cpassword { get; set; }

        [ForeignKey("Department")]
        [Display(Name ="Department")]
        public int DeptId { get; set;}
        public virtual Department Department { get; set; }


    }
}
