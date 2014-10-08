using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class TemplateControlCollection : List<TemplateControl>
	{
		internal static TemplateControlCollection CreateFromData(DataTable data)
		{
			var result = new TemplateControlCollection();

			foreach (DataRow row in data.Rows)
			{
				result.Add(TemplateControl.CreateFromData(row));
			}

			return result;
		}
	}
}
