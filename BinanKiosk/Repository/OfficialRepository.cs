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


        //Get All Officials
        public IList<Official> GetAll_Official()
        {
            IList<Official> officials = new List<Official>();
            query = @"SELECT Officials_ID,First_Name,Last_Name,Middle_Initial,Suffex,positions.Position_ID,position_name,departments.Department_ID,Department_Name,Dep_Description,floors.Room_ID,Room_Label " +
                "from officials,positions,departments,floors where officials.position_id = positions.position_ID and officials.department_ID = departments.department_ID and departments.room_ID = floors.room_ID";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 12); i++)
            {
                officials.Add(new Official
                {
                    Officials_ID = Int32.Parse(Objects[i * 12].ToString()),
                    First_Name = Objects[1 + (i * 12)].ToString(),
                    Middle_Initial = Objects[3 + (i * 12)].ToString(),
                    Last_Name = Objects[2 + (i * 12)].ToString(),
                    Suffix = Objects[4 + (i * 12)].ToString(),
                    position = new Position { Position_ID = int.Parse(Objects[5 + (i * 12)].ToString()), Position_Name = Objects[6 + (i * 12)].ToString() },
                    department = new Department
                    {
                        Department_ID = int.Parse(Objects[7 + (i * 12)].ToString()),
                        Department_Name = Objects[8 + (i * 12)].ToString(),
                        Department_Description = Objects[9 + (i * 12)].ToString(),
                        Room = new Floor { Room_ID = Objects[10 + (i * 12)].ToString(), Room_Label = Objects[11 + (i * 12)].ToString() }
                    },
                });
            }
            return officials;
        }
    }
}
