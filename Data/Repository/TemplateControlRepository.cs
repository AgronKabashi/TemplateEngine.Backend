using Cerberus.Tool.TemplateEngine.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class TemplateControlRepository
	{
		/// <summary>
		/// 
		/// </summary>
		public void AddTemplateControls(int templateId, TemplateControlCollection templateControls)
		{
			const string insertQuery = @"
				INSERT INTO 
					[Cerberus.TemplateEngine.TemplateControl]
					(
						ControlPluginId,
						TemplateId,
						FriendlyName,
						Content,
						VisualProperties,
						CreationGUID,
						Class
					)
				VALUES
				(
					(SELECT ControlPluginId FROM [Cerberus.TemplateEngine.ControlPlugin] WHERE ControlType=@ControlType{0}),
					@TemplateId,
					@FriendlyName{0},
					@Content{0},
					@VisualProperties{0},
					@CreationGUID{0},
					@Class{0}
				);";

			var command = SqlDbAccess.CreateTextCommand();

			var sb = new StringBuilder();
			var counter = 0;
			foreach (var templateControl in templateControls)
			{
				sb.AppendFormat(insertQuery, counter);

				SqlDbAccess.AddParameter(command, string.Format("@ControlType{0}", counter), SqlDbType.NVarChar, templateControl.ControlType);
				SqlDbAccess.AddParameter(command, string.Format("@FriendlyName{0}", counter), SqlDbType.NVarChar, templateControl.FriendlyName, 50);
				SqlDbAccess.AddParameter(command, string.Format("@Content{0}", counter), SqlDbType.NText, templateControl.Content);
				SqlDbAccess.AddParameter(command, string.Format("@VisualProperties{0}", counter), SqlDbType.NVarChar, templateControl.VisualProperties);
				SqlDbAccess.AddParameter(command, string.Format("@CreationGUID{0}", counter), SqlDbType.NVarChar, templateControl.CreationGUID);
				SqlDbAccess.AddParameter(command, string.Format("@Class{0}", counter), SqlDbType.NVarChar, templateControl.Class);

				counter++;
			}

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			command.CommandText = sb.ToString();

			SqlDbAccess.ExecuteNonQuery(command);
		}
		
		public TemplateControlCollection GetControls(int templateId)
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = @"
				SELECT
					TC.TemplateControlId,
					TC.FriendlyName,
					TC.Content,
					TC.VisualProperties,
					TC.CreationGUID,
					TC.Class,
					CP.Name as ControlName,
					CP.ControlType,
					CP.Category
				FROM
					[Cerberus.TemplateEngine.TemplateControl] TC
					JOIN [Cerberus.TemplateEngine.ControlPlugin] CP ON TC.ControlPluginId = CP.ControlPluginId
				WHERE
					TemplateId = @TemplateId";

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			return TemplateControlCollection.CreateFromData(SqlDbAccess.ExecuteSelect(command));
		}

		public TemplateControlCollection GetControls(int templateId, int documentId, int documentTypeId)
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = @"
				SELECT
					TC.TemplateControlId,
					TC.FriendlyName,
					IsNull(TCC.Content, TC.Content) AS Content,
					TC.Content AS DefaultContent,
					TC.VisualProperties,
					TC.CreationGUID,
					TC.Class,
					CP.Name as ControlName,
					CP.ControlType,
					CP.Category
				FROM
					[Cerberus.TemplateEngine.TemplateControl] TC
					JOIN [Cerberus.TemplateEngine.ControlPlugin] CP ON TC.ControlPluginId = CP.ControlPluginId
					LEFT JOIN [Cerberus.TemplateEngine.TemplateControlContent] TCC ON TCC.TemplateControlId = TC.TemplateControlId
						AND TCC.DocumentId=@DocumentId
						AND TCC.DocumentTypeId=@DocumentTypeId
				WHERE
					TemplateId = @TemplateId";

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);
			SqlDbAccess.AddParameter(command, "@DocumentId", SqlDbType.Int, documentId);
			SqlDbAccess.AddParameter(command, "@DocumentTypeId", SqlDbType.Int, documentTypeId);

			return TemplateControlCollection.CreateFromData(SqlDbAccess.ExecuteSelect(command));
		}

		public void UpdateTemplateControls(TemplateControlCollection templateControls)
		{
			const string updateQuery = @"
				UPDATE
					[Cerberus.TemplateEngine.TemplateControl]
				SET
					Content = @Content{0},
					FriendlyName = @FriendlyName{0},
					VisualProperties = @VisualProperties{0},
					Class = @Class{0}
				WHERE
					TemplateControlId = @TemplateControlId{0};";

			var command = SqlDbAccess.CreateTextCommand();

			var sb = new StringBuilder();
			var counter = 0;
			foreach (var templateControl in templateControls)
			{
				sb.AppendFormat(updateQuery, counter);

				SqlDbAccess.AddParameter(command, string.Format("@Content{0}", counter), SqlDbType.NVarChar, templateControl.Content);
				SqlDbAccess.AddParameter(command, string.Format("@FriendlyName{0}", counter), SqlDbType.NVarChar, templateControl.FriendlyName, 50);
				SqlDbAccess.AddParameter(command, string.Format("@VisualProperties{0}", counter), SqlDbType.NVarChar, templateControl.VisualProperties);
				SqlDbAccess.AddParameter(command, string.Format("@TemplateControlId{0}", counter), SqlDbType.Int, templateControl.Id);
				SqlDbAccess.AddParameter(command, string.Format("@Class{0}", counter), SqlDbType.NVarChar, templateControl.Class);

				counter++;
			}

			command.CommandText = sb.ToString();

			SqlDbAccess.ExecuteNonQuery(command);
		}

		public void RemoveTemplateControlsNotInCollection(int templateId, IEnumerable<int> templateControlIds)
		{
			var templateControlIdsAsString = templateControlIds.Count() > 0 ? string.Join(",", templateControlIds) : "-1";
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = string.Format(@"
				DELETE FROM
					[Cerberus.TemplateEngine.TemplateControl]
				WHERE
					TemplateId = @TemplateId
					AND TemplateControlId NOT IN ({0})",
				templateControlIdsAsString);

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			SqlDbAccess.ExecuteSelect(command);
		}

		public void ResetTemplateControlCreationGUIDs(int templateId)
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = "UPDATE [Cerberus.TemplateEngine.TemplateControl] SET CreationGUID=NULL WHERE TemplateId = @TemplateId";
			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);
			SqlDbAccess.ExecuteNonQuery(command);
		}
	}
}
