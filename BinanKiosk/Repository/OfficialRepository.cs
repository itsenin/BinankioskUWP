using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Repository
{
    public class OfficialRepository : RepositoryBase
    {
        //declaration of variables
        private List<Object> Objects;
        private String query = "";
        Dictionary<string, Object> myDictionaryData;


        //Get All Job Categories
        public IList<Official> GetAll_Official()
        {
            IList<Official> officials = new List<Official>();
            query = @"SELECT Officials_ID,First_Name,Last_Name,Middle_Initial,Suffex,officials.Image_Path, "+
				"positions.Position_ID,position_name, "+
				"departments.Department_ID,Department_Name,Dep_Description, Department_Image_Path, "+
				"offices.Office_ID, Office_Name, Room_Name "+
                "from officials,positions,departments,offices "+
				"where officials.position_id = positions.position_ID and officials.office_ID = offices.office_ID and departments.department_id = offices.department_id";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 15); i++)
            {
                officials.Add(new Official { Officials_ID = Int32.Parse(Objects[i * 15].ToString()),
					First_Name = Objects[1 + (i * 15)].ToString(),
					Last_Name = Objects[2 + (i * 15)].ToString(),
					Middle_Initial = Objects[3 + (i * 15)].ToString(),
					Suffix = Objects[4 + (i * 15)].ToString(),
					Image_Path = Objects[5 + (i * 15)].ToString(),
					office = new Office { Office_ID = int.Parse(Objects[12 + (i * 15)].ToString()), Office_Name = Objects[13 + (i * 15)].ToString(), Room_Name = Objects[14 + (i * 15)].ToString(),
						department = new Department { Department_ID = int.Parse(Objects[8 + (i * 15)].ToString()), Department_Name = Objects[9 + (i * 15)].ToString(), Department_Description = Objects[10 + (i * 15)].ToString(), Department_Image_Path = Objects[11 + (i * 15)].ToString() }},
					position = new Position { Position_ID = int.Parse(Objects[6 + (i * 15)].ToString()), Position_Name = Objects[7 + (i * 15)].ToString() }
                    });
            }
            return officials;
        }
    }
}
