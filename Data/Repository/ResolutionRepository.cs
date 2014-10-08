using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class ResolutionRepository
	{
		public void AddResolutions(int templateId, ResolutionCollection resolutions)
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = @"
				INSERT INTO 
					[Cerberus.TemplateEngine.Resolution]
					(
						TemplateId,
						Width						
					)
				VALUES
					(
						@TemplateId,
						@Width
					);
				SELECT CAST(SCOPE_IDENTITY() AS INT);";

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			var widthParameter = SqlDbAccess.AddParameter(command, "@Width", SqlDbType.Int, 0);

			foreach (var resolution in resolutions)
			{
				widthParameter.Value = resolution.ResolutionValue;

				resolution.Id = SqlDbAccess.ExecuteScalar<int>(command);
				this.UpdateResolutionValues(resolution.Id, resolution.TemplateControlVisualProperties);
			}
		}


		public ResolutionCollection GetResolutions(int templateId)
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = @"
				SELECT
					R.ResolutionId,
					R.Width,
					TCR.TemplateControlId,
					TCR.VisualProperties
				FROM 
					[Cerberus.TemplateEngine.Resolution] R
					LEFT JOIN [Cerberus.TemplateEngine.TemplateControlResolution] TCR ON R.ResolutionId=TCR.ResolutionId
				WHERE
					R.TemplateId = @TemplateId
				ORDER BY
					R.Width ASC";

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			return ResolutionCollection.CreateFromData(SqlDbAccess.ExecuteSelect(command));
		}

		public void UpdateResolutions(ResolutionCollection resolutions)
		{
			const string updateQuery = @"
				UPDATE
					[Cerberus.TemplateEngine.Resolution]
				SET
					Width = @Width{0}
				WHERE
					ResolutionId = @ResolutionId{0}";

			var command = SqlDbAccess.CreateTextCommand();

			var sb = new StringBuilder();
			var counter = 0;
			foreach (var resolution in resolutions)
			{
				sb.AppendFormat(updateQuery, counter);

				SqlDbAccess.AddParameter(command, string.Format("@ResolutionId{0}", counter), SqlDbType.Int, resolution.Id);
				SqlDbAccess.AddParameter(command, string.Format("@Width{0}", counter), SqlDbType.Int, resolution.ResolutionValue);

				this.UpdateResolutionValues(resolution.Id, resolution.TemplateControlVisualProperties);

				counter++;
			}

			command.CommandText = sb.ToString();

			SqlDbAccess.ExecuteNonQuery(command);
		}

		private void UpdateResolutionValues(int resolutionId, Dictionary<int, string> resolutionValues)
		{
			const string insertForNewTemplateControlQuery = @"INSERT INTO @tmp (CreationGUID, ResolutionId, VisualProperties) VALUES (@CreationGUID{0}, @ResolutionId, @VisualProperties{0});";
			const string insertForExistingTemplateControlQuery = @"
				INSERT INTO
					[Cerberus.TemplateEngine.TemplateControlResolution]
					(
						ResolutionId,
						TemplateControlId,
						VisualProperties
					)
				VALUES
					(
						@ResolutionId,
						@TemplateControlId{0},
						@VisualProperties{0}
					)";

			var command = SqlDbAccess.CreateTextCommand();

			var sb = new StringBuilder(@"
				DECLARE @tmp TABLE
				(
					CreationGUID NVARCHAR(10),
					ResolutionId INT,
					VisualProperties NVARCHAR(1024)
				);

				DELETE FROM [Cerberus.TemplateEngine.TemplateControlResolution]
				WHERE
					ResolutionId = @ResolutionId;
				");

			var counter = 0;
			foreach (var resolutionValue in resolutionValues)
			{
				if (resolutionValue.Key <= 0)
				{
					sb.AppendFormat(insertForNewTemplateControlQuery, counter);
					SqlDbAccess.AddParameter(command, string.Format("@CreationGUID{0}", counter), SqlDbType.NVarChar, resolutionValue.Key.ToString());
				}
				else
				{
					sb.AppendFormat(insertForExistingTemplateControlQuery, counter);
					SqlDbAccess.AddParameter(command, string.Format("@TemplateControlId{0}", counter), SqlDbType.Int, resolutionValue.Key);
				}

				SqlDbAccess.AddParameter(command, string.Format("@VisualProperties{0}", counter), SqlDbType.NVarChar, resolutionValue.Value);

				counter++;
			}

			SqlDbAccess.AddParameter(command, "@ResolutionId", SqlDbType.Int, resolutionId);

			sb.AppendFormat(@"
				INSERT INTO
					[Cerberus.TemplateEngine.TemplateControlResolution]
					(
						TemplateControlId,
						ResolutionId,
						VisualProperties
					)
				SELECT
					TC.TemplateControlId,
					@ResolutionId,
					T.VisualProperties
				FROM
					[Cerberus.TemplateEngine.TemplateControl] TC
					JOIN @tmp T ON TC.CreationGUID = T.CreationGUID;");

			command.CommandText = sb.ToString();

			SqlDbAccess.ExecuteNonQuery(command);
		}

		public void RemoveResolutionsNotInCollection(int templateId, IEnumerable<int> resolutionIds)
		{
			var resolutionIdsAsString = resolutionIds.Count() > 0 ? string.Join(",", resolutionIds) : "-1";
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = string.Format(@"
				DELETE FROM
					[Cerberus.TemplateEngine.Resolution]
				WHERE
					TemplateId = @TemplateId
					AND ResolutionId NOT IN ({0})",
				resolutionIdsAsString);

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			SqlDbAccess.ExecuteSelect(command);
		}

	}
}
