using System.Collections.Generic;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class ControlPluginCollection : List<ControlPlugin>
	{
		internal Data.ControlPluginCollection CreateDataObjectCollection()
		{
			var list = new Data.ControlPluginCollection();

			foreach (var controlPlugin in this)
			{
				list.Add(controlPlugin.CreateDataObject());
			}

			return list;
		}

		internal static ControlPluginCollection CreateFromDataObjectCollection(Data.ControlPluginCollection collection)
		{
			var list = new ControlPluginCollection();

			foreach (var controlPlugin in collection)
			{
				list.Add(ControlPlugin.CreateFromDataObject(controlPlugin));
			}

			return list;
		}
	}
}
