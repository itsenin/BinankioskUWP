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


        //Get All Services
        public IList<Service> GetAll_Service()
        {
            IList<Service> services = new List<Service>();
            query = @"SELECT * from services";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 2); i++)
            {
                services.Add(new Service
                {
                    Service_ID = Int32.Parse(Objects[i * 2].ToString()),
                    Service_Name = Objects[1 + (i * 2)].ToString()
                });
            }
            return services;
        }
    }
}
