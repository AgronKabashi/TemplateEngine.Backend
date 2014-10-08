using System.Collections.Generic;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class TemplateCollection : List<Template>
	{
		internal Data.TemplateCollection CreateDataObjectCollection()
		{
			var list = new Data.TemplateCollection();

			foreach (var template in this)
			{
				list.Add(template.CreateDataObject());
			}

			return list;
		}

		internal static TemplateCollection CreateFromDataObjectCollection(Data.TemplateCollection templateCollection)
		{
			var list = new TemplateCollection();

			foreach (var template in templateCollection)
			{
				list.Add(Template.CreateFromDataObject(template));
			}

			return list;
		}
	}
}
