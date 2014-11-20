using Cerberus.Tool.TemplateEngine.Common;
using Cerberus.Tool.TemplateEngine.Data;
using System;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class TemplateService
	{
		internal bool AddTemplate(Template template)
		{
			template.Id = DataAccess.TemplateRepository.AddTemplate(template.CreateDataObject());

			return template.Id > 0;
		}

		internal bool UpdateTemplate(Template template)
		{
			return DataAccess.TemplateRepository.UpdateTemplate(template.CreateDataObject());
		}

		public Template GetTemplate(int templateId)
		{
			return templateId > 0 ? Template.CreateFromDataObject(DataAccess.TemplateRepository.GetTemplate(templateId)) : null;
		}

		public Template GetDocumentTemplate(int templateId, int documentId, int documentTypeId)
		{
			var template = this.GetTemplate(templateId);
			
			if (template != null)
			{
				template.DocumentId = documentId;
				template.DocumentTypeId = documentTypeId;
			}

			return template;
		}

		public TemplateCollection GetTemplates(TemplateSearchParameters searchParameters = null)
		{
			return TemplateCollection.CreateFromDataObjectCollection(DataAccess.TemplateRepository.GetTemplates(searchParameters ?? new TemplateSearchParameters()));
		}

		public bool RemoveTemplate(int templateId)
		{
			return DataAccess.TemplateRepository.RemoveTemplate(templateId);
		}
	}
}