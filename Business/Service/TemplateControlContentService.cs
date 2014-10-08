using Cerberus.Tool.TemplateEngine.Data;
using System;
using System.Linq;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class TemplateControlContentService
	{
		public void UpdateTemplateControlContent(Template template, int documentId, int documentTypeId)
		{
			DataAccess.TemplateControlContentRepository.UpdateControlContent(documentId, documentTypeId, template.Id, template.TemplateControls.CreateDataObjectCollection());
		}

		public bool RemoveTemplateControlContent(int documentId, int documentTypeId)
		{
			return DataAccess.TemplateControlContentRepository.RemoveTemplateControlContent(documentId, documentTypeId);
		}
	}
}
