using BinanKiosk.Models;
using System;
using System.Collections.Generic;

namespace BinanKiosk.Repository
{
	public class OfficeRepository : RepositoryBase
	{
		//declaration of variables
		private List<Object> Objects;
		private String query = "";
		Dictionary<string, Object> myDictionaryData;


		//Get All Job Categories
		public IList<Office> GetAll_Office()
		{
			IList<Office> Office = new List<Office>();
			query = @"SELECT departments.Department_ID, Department_Name, Dep_description, department_image_path, "+
				"office_id, office_name, room_name, offices_image_path from offices,departments where offices.department_id = departments.department_id";
			Objects = Get(query, null);
			for (int i = 0; i < (Objects.Count / 8); i++)
			{
				Office.Add(new Office
				{
					department = new Department() { Department_ID = int.Parse(Objects[i * 8].ToString()), Department_Name = Objects[1 + (i * 8)].ToString(), Department_Description = Objects[2 + (i * 8)].ToString(), Department_Image_Path = Objects[3 + (i * 8)].ToString() },
					Office_ID = int.Parse(Objects[4 + (i * 8)].ToString()),
					Office_Name = Objects[5 + (i * 8)].ToString(),
					Room_Name = Objects[6 + (i * 8)].ToString(),
					image_path = Objects[7 + (i * 8)].ToString(),
				});
			}
			return Office;
		}
	}
}
