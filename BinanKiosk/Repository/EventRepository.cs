using BinanKiosk.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinanKiosk.Repository
{
	public class EventRepository : RepositoryBase
	{
		//declaration of variables
		private List<Object> Objects;
		private String query = "";
		Dictionary<string, Object> myDictionaryData;

		//Get All Event Slider Images
		public IList<Event_Slider> GetAll_Slider_Images()
		{
			IList<Event_Slider> slider_Images = new List<Event_Slider>();
			query = @"SELECT * from slider_images";
			Objects = Get(query, null);
			for (int i = 0; i < (Objects.Count / 2); i++)
			{
				slider_Images.Add(new Event_Slider
				{
					ID = Int32.Parse(Objects[i * 2].ToString()),
					Image_Name = Objects[1 + (i * 2)].ToString()
				});
			}
			return slider_Images;
		}
	}
}
