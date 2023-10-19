using First_Task_Mvc.Context;
using First_Task_Mvc.Models;

namespace First_Task_Mvc.BLL
{
    public class DepartmentBLL
    {
       TaskDb db=new TaskDb();
        public List<Department> GetAll()
        {

            return db.Departments.ToList();
        }
       
        public Department GetById(int id)
        {
            return db.Departments.SingleOrDefault(a => a.DeptId == id);
        }
        public Department Create(Department Dept)
        {
            db.Departments.Add(Dept);
            db.SaveChanges();
            return Dept;
        }
        public void Delete(int id)
        {
            Department dept= GetById(id);
            if (dept != null)
            {
                db.Departments.Remove(dept);
                db.SaveChanges();
            }
        }
        public void Update(Department Department)
        {
            db.Departments.Update(Department);
            db.SaveChanges();
        }
    }
}
