using First_Task_Mvc.Context;
using First_Task_Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace First_Task_Mvc.BLL
{
    public class StudentBLL
    {
        TaskDb db = new TaskDb();
        public List<Student> GetAll()
        {
            return db.Students.Include(e=>e.Department).ToList();
        }
        public Student GetById(int id)
        {
            return db.Students.Include(e=> e.Department).SingleOrDefault(a=>a.Id==id);
        }
        public Student Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
            return student;
        }
        public void Delete(int id)
        {
            Student std=GetById(id);
            if(std != null)
            {
                db.Students.Remove(std);
                db.SaveChanges();
            }
        }
        public void Update(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
    }
}
