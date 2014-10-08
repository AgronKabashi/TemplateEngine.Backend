using System;
using System.Data;
namespace Cerberus.Tool.TemplateEngine.Data
{
	public class TemplateControl
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

		public string FriendlyName
		{
			get;
			set;
		}

		public string ControlName
		{
			get;
			set;
		}

		public string Content
		{
			get;
			set;
		}

		public string VisualProperties
		{
			get;
			set;
		}

		public string Category
		{
			get;
			set;
		}

		public string CreationGUID
		{
			get;
			set;
		}

		public string Class
		{
			get;
			set;
		}

		internal static TemplateControl CreateFromData(DataRow row)
		{
			return new TemplateControl
			{
				Id = Convert.ToInt32(row["TemplateControlId"]),
				ControlType = row["ControlType"].ToString(),
				FriendlyName = row["FriendlyName"].ToString(),
				ControlName = row["ControlName"].ToString(),
				Content = row["Content"].ToString(),
				VisualProperties = row["VisualProperties"].ToString(),
				Category = row["Category"].ToString(),
				CreationGUID = row["CreationGUID"].ToString(),
				Class = row["Class"].ToString()
			};
		}
	}
}
