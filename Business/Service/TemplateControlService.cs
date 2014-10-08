using Cerberus.Tool.TemplateEngine.Common;
using Cerberus.Tool.TemplateEngine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class TemplateControlService
	{
		internal void AddTemplateControls(int templateId, TemplateControlCollection templateControls)
		{
			if (templateControls.Count == 0)
			{
				return;
			}

			DataAccess.TemplateControlRepository.AddTemplateControls(templateId, templateControls.CreateDataObjectCollection());
		}

		internal TemplateControlCollection GetControls(int templateId, int documentId = 0, int documentTypeId = 0)
		{
			TemplateControlCollection result = null;

			if (documentId > 0)
			{
				result = TemplateControlCollection.CreateFromDataObjectCollection(DataAccess.TemplateControlRepository.GetControls(templateId, documentId, documentTypeId));
			}
			else
			{
				result = TemplateControlCollection.CreateFromDataObjectCollection(DataAccess.TemplateControlRepository.GetControls(templateId));
			}

			return result;
		}

		internal void UpdateTemplateControls(TemplateControlCollection templateControls)
		{
			if (templateControls.Count == 0)
			{
				return;
			}

			DataAccess.TemplateControlRepository.UpdateTemplateControls(templateControls.CreateDataObjectCollection());
		}

		internal void RemoveTemplateControlsNotInCollection(int templateId, IEnumerable<int> templateControlIds)
		{
			DataAccess.TemplateControlRepository.RemoveTemplateControlsNotInCollection(templateId, templateControlIds);
		}

		internal void ResetTemplateControlCreationGUIDs(int templateId)
		{
			DataAccess.TemplateControlRepository.ResetTemplateControlCreationGUIDs(templateId);
		}
	}
}
