using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Repository
{
    public class ServiceRepository : RepositoryBase
    {
        //declaration of variables
        private List<Object> Objects;
        private String query = "";
        Dictionary<string, Object> myDictionaryData;
		
        //Get All Job Categories
        public IList<Service> GetAll_Service()
        {
            IList<Service> services = new List<Service>();
            query = @"SELECT service_id,service_name,image_name,offices.office_id, office_name,room_name,offices_image_path from services,offices where services.office_id = offices.office_id";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 7); i++)
            {
                services.Add(new Service
                {
                    Service_ID = Int32.Parse(Objects[i * 7].ToString()),
                    Service_Name = Objects[1 + (i * 7)].ToString(),
					Image_Path = Objects[2 + (i * 7)].ToString(),
					office = new Office { Office_ID = int.Parse(Objects[3 + (i * 7)].ToString()), Office_Name = Objects[4 + (i * 7)].ToString(), Room_Name= Objects[5 + (i * 7)].ToString(), image_path = Objects[6 + (i * 7)].ToString() }
				});
            }
            return services;
        }
    }
}
