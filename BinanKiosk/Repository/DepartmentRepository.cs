using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Repository
{
    public class DepartmentRepository : RepositoryBase
    {
        //declaration of variables
        private List<Object> Objects;
        private String query = "";
        Dictionary<string, Object> myDictionaryData;

        //Get All Department
        public IList<Department> GetAll_Department()
        {
            IList<Department> departments = new List<Department>();
            query = @"SELECT Department_ID,Department_Name,Dep_Description,floors.Room_ID,Room_Label from Departments,floors "+
                "where departments.room_ID = floors.room_ID";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 5); i++)
            {
                departments.Add(new Department { Department_ID = Int32.Parse(Objects[i * 5].ToString()), Department_Name = Objects[1 + (i * 5)].ToString(), Department_Description = Objects[2 + (i * 5)].ToString(),
                    Room = new Floor { Room_ID = Objects[3 + (i * 5)].ToString(), Room_Label = Objects[4 + (i * 5)].ToString() }  });
            }
            return departments;
        }
        //Get a specific department
        public Department GetDepartment(string DepartmentName)
        {
            query = @"SELECT Officials_ID,First_Name,Last_Name,Middle_Initial,Suffex,positions.Position_ID,position_name,departments.Department_ID,Department_Name,Dep_Description,floors.Room_ID,Room_Label " +
                "from officials,positions,departments,floors where officials.position_id = positions.position_ID and officials.department_ID = departments.department_ID and departments.room_ID = floors.room_ID and Department_Name = ?Department_Name";
            myDictionaryData = new Dictionary<string, Object>() { { "?Department_Name", DepartmentName } };
            Objects = Get(query, myDictionaryData);
                
            return new Department
            {
                Department_ID = Int32.Parse(Objects[0].ToString()),
                Department_Name = Objects[1].ToString(),
                Department_Description = Objects[2].ToString(),
                Room = new Floor { Room_ID = Objects[3].ToString(), Room_Label = Objects[4].ToString() }
            };
        }
    }
}
