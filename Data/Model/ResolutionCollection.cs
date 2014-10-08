using System;
using System.Collections.Generic;
using System.Data;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class ResolutionCollection : List<Resolution>
	{
		internal static ResolutionCollection CreateFromData(DataTable data)
		{
			var list = new ResolutionCollection();

			var lastResolutionId = 0;
			var currentResolutionId = 0;
			var templateControlId = 0;
			var visualProperties = string.Empty;
			Resolution resolution = null;

			foreach (DataRow row in data.Rows)
			{
				currentResolutionId = Convert.ToInt32(row["ResolutionId"]);

				if (lastResolutionId != currentResolutionId)
				{
					resolution = new Resolution
					{
						Id = currentResolutionId,
						ResolutionValue = Convert.ToInt32(row["Width"])
					};

					list.Add(resolution);

					lastResolutionId = currentResolutionId;
				}

				if (!row.IsNull("TemplateControlId"))
				{
					templateControlId = Convert.ToInt32(row["TemplateControlId"]);
					visualProperties = row["VisualProperties"].ToString();

					resolution.TemplateControlVisualProperties.Add(templateControlId, visualProperties);
				}
			}

			return list;
		}
	}
}
