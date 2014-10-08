using System;
using System.Data;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class ControlPlugin
	{
		public int Id
		{
			get;
			set;
		}

		public string ControlType
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public string ImageUrl
		{
			get;
			set;
		}

		public string Category
		{
			get;
			set;
		}

		internal static ControlPlugin CreateFromData(DataRow row)
		{
			return new ControlPlugin
			{
				Id = Convert.ToInt32(row["ControlPluginId"]),
				ControlType = row["ControlType"].ToString(),
				Name = row["Name"].ToString(),
				ImageUrl = row["ImageUrl"].ToString(),
				Category = row["Category"].ToString()
			};
		}
	}
}
