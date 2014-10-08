using System.Collections.Generic;
using System.Linq;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class ResolutionCollection : List<Resolution>
	{
		internal Data.ResolutionCollection CreateDataObjectCollection()
		{
			var list = new Data.ResolutionCollection();

			foreach (var resolution in this)
			{
				list.Add(resolution.CreateDataObject());
			}

			return list;
		}

		internal static ResolutionCollection CreateFromDataObjectCollection(Data.ResolutionCollection resolutions)
		{
			var list = new ResolutionCollection();

			foreach (var resolution in resolutions)
			{
				list.Add(Resolution.CreateFromDataObject(resolution));
			}

			return list;
		}

		internal void Save(int templateId)
		{
			var newResolutions = new ResolutionCollection();
			var existingResolutions = new ResolutionCollection();

			newResolutions.AddRange(this.FindAll(resolution => resolution.Id == 0));
			existingResolutions.AddRange(this.FindAll(resolution => resolution.Id > 0));

			var existingResolutionIds = from r in existingResolutions
									 select r.Id;


			TemplateManager.ResolutionService.RemoveResolutionsNotInCollection(templateId, existingResolutionIds);

			//Update must be run first since it clears existing resolution values
			TemplateManager.ResolutionService.UpdateResolutions(existingResolutions);
			TemplateManager.ResolutionService.AddResolutions(templateId, newResolutions);
			TemplateManager.TemplateControlService.ResetTemplateControlCreationGUIDs(templateId);
		}
	}
}
