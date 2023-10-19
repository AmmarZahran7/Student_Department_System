using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace First_Task_Mvc.Models
{
    public class Department
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DeptId { get; set; }
        [Required,MaxLength(50)]
        public string DeptName { get; set; }    
        public string Address { get; set; }
        public virtual  ICollection<Student> Students { get; set; }=new HashSet<Student>();
       

    }
}
