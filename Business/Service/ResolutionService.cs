using Cerberus.Tool.TemplateEngine.Data;
using System.Collections.Generic;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class ResolutionService
	{
		internal void AddResolutions(int templateId, ResolutionCollection resolutions)
		{
			if (resolutions.Count == 0)
			{
				return;
			}

			DataAccess.ResolutionRepository.AddResolutions(templateId, resolutions.CreateDataObjectCollection());
		}

		internal ResolutionCollection GetResolutions(int templateId)
		{
			return ResolutionCollection.CreateFromDataObjectCollection(DataAccess.ResolutionRepository.GetResolutions(templateId));
		}

		internal void UpdateResolutions(ResolutionCollection resolutions)
		{
			if (resolutions.Count == 0)
			{
				return;
			}

			DataAccess.ResolutionRepository.UpdateResolutions(resolutions.CreateDataObjectCollection());
		}

		internal void RemoveResolutionsNotInCollection(int templateId, IEnumerable<int> resolutionIds)
		{
			DataAccess.ResolutionRepository.RemoveResolutionsNotInCollection(templateId, resolutionIds);
		}
	}
}
