using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class Template
	{
		public int Id
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public int CreatedByUserId
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			set;
		}

		public DateTime LastModifiedDate
		{
			get;
			set;
		}

		public string VisualProperties
		{
			get;
			set;
		}

		internal static Template CreateFromData(DataRow row)
		{
			return new Template
			{
				Id = Convert.ToInt32(row["TemplateId"]),
				Name = row["Name"].ToString(),
				CreatedByUserId = Convert.ToInt32(row["CreatedByUserId"]),
				CreatedDate = (DateTime)row["CreatedDate"],
				LastModifiedDate = (DateTime)row["LastModifiedDate"],
				VisualProperties = row["VisualProperties"].ToString()
			};
		}
	}
}
