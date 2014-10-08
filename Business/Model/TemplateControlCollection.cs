using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class TemplateControlCollection : List<TemplateControl>
	{
		internal Data.TemplateControlCollection CreateDataObjectCollection()
		{
			var list = new Data.TemplateControlCollection();

			foreach (var templateControl in this)
			{
				list.Add(templateControl.CreateDataObject());
			}

			return list;
		}

		internal static TemplateControlCollection CreateFromDataObjectCollection(Data.TemplateControlCollection templateCollection)
		{
			var list = new TemplateControlCollection();

			foreach (var templateControl in templateCollection)
			{
				list.Add(TemplateControl.CreateFromDataObject(templateControl));
			}

			return list;
		}

		internal void Save(int templateId)
		{
			var newControls = new TemplateControlCollection();
			var existingControls = new TemplateControlCollection();

			newControls.AddRange(this.FindAll(templateControl => templateControl.Id <= 0));
			existingControls.AddRange(this.FindAll(templateControl => templateControl.Id > 0));

			var existingControlIds = from tc in existingControls
									 select tc.Id;

			TemplateManager.TemplateControlService.RemoveTemplateControlsNotInCollection(templateId, existingControlIds);
			TemplateManager.TemplateControlService.AddTemplateControls(templateId, newControls);
			TemplateManager.TemplateControlService.UpdateTemplateControls(existingControls);
		}
	}
}
