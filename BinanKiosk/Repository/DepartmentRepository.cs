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
            query = @"SELECT Department_ID,Department_Name,Dep_Description,department_image_path";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 4); i++)
            {
                departments.Add(new Department {
					Department_ID = Int32.Parse(Objects[i * 4].ToString()),
					Department_Name = Objects[1 + (i * 4)].ToString(),
					Department_Description = Objects[2 + (i * 4)].ToString(),
					Department_Image_Path = Objects[2 + (i * 4)].ToString()
				});
            }
            return departments;
        }
    }
}
