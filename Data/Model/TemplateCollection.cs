using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class TemplateCollection : List<Template>
	{
		internal static TemplateCollection CreateDataObjectCollection(DataTable data)
		{
			var result = new TemplateCollection();

			foreach (DataRow row in data.Rows)
			{
				result.Add(Template.CreateFromData(row));
			}

			return result;
		}
	}
}
