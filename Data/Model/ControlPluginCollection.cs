using System.Collections.Generic;
using System.Data;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class ControlPluginCollection : List<ControlPlugin>
	{
		internal static ControlPluginCollection CreateFromData(DataTable data)
		{
			var list = new ControlPluginCollection();

			foreach (DataRow row in data.Rows)
			{
				list.Add(ControlPlugin.CreateFromData(row));
			}

			return list;
		}
	}
}
