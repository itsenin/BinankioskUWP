using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Repository
{
    public class JobRepository : RepositoryBase
    {
        //declaration of variables
        private List<Object> Objects;
        private String query = "";
        Dictionary<string, Object> myDictionaryData;

        //Get All Job Categories
        public IList<M_Job_Category> GetAll_JobCategories()
        {
            IList<M_Job_Category> _Categories = new List<M_Job_Category>();
            query = @"SELECT * from jobs";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 2); i++)
            {
                _Categories.Add(new M_Job_Category { Job_ID = Int32.Parse(Objects[i * 2].ToString()), Job_Name = Objects[1 + (i * 2)].ToString() });
            }
            return _Categories;
        }
        //Get All Job List
        public IList<M_Job_Type> GetAll_JobTypes()
        {
            IList<M_Job_Type> _Job_Type = new List<M_Job_Type>();
            query = @"SELECT Job_TypeID, Job_Types, Job_Description, Job_Location, Job_Company,jobs.Job_ID,Job_Name from jobtypes,jobs where jobs.Job_ID = jobtypes.Job_ID";
            Objects = Get(query, null);
            for (int i = 0; i < (Objects.Count / 7); i++)
            {
                _Job_Type.Add(new M_Job_Type
                {
                    JobType_ID = Int32.Parse(Objects[i * 7].ToString()),
                    Job_Types = Objects[1 + (i * 7)].ToString(),
                    Job_Description = Objects[2 + (i * 7)].ToString(),
                    Job_Location = Objects[3 + (i * 7)].ToString(),
                    Job_Company = Objects[4 + (i * 7)].ToString(),
                    Category = new M_Job_Category { Job_ID = int.Parse(Objects[5 + (i * 7)].ToString()), Job_Name = Objects[6 + (i * 7)].ToString() }
                });
            }
            return _Job_Type;
        }
        //Get All Job Types using a category
        public IList<M_Job_Type> GetAll_JobTypes(M_Job_Category _Category)
        {
            IList<M_Job_Type> _Job_Type = new List<M_Job_Type>();
            query = @"SELECT Job_TypeID, Job_Types, Job_Description, Job_Location, Job_Company,jobs.Job_ID,Job_Name from jobtypes,jobs where jobs.job_id = ?job_id and jobs.Job_ID = jobtypes.Job_ID";
            myDictionaryData = new Dictionary<string, Object>() { { "?job_id", _Category.Job_ID } };
            Objects = Get(query, myDictionaryData);
            for (int i = 0; i < (Objects.Count / 7); i++)
            {
                _Job_Type.Add(new M_Job_Type
                {
                    JobType_ID = Int32.Parse(Objects[i * 7].ToString()),
                    Job_Types = Objects[1 + (i * 7)].ToString(),
                    Job_Description = Objects[2 + (i * 7)].ToString(),
                    Job_Location = Objects[3 + (i * 7)].ToString(),
                    Job_Company = Objects[4 + (i * 7)].ToString(),
                    Category = new M_Job_Category { Job_ID = int.Parse(Objects[5 + (i * 7)].ToString()), Job_Name = Objects[6 + (i * 7)].ToString() }
                });
            }
            return _Job_Type;
        }
    }
}