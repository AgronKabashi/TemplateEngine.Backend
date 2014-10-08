using Cerberus.Tool.TemplateEngine.Common;
using System;
using System.Data;
using System.Text;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class TemplateRepository
	{
		public int AddTemplate(Template template)
		{
			var command = SqlDbAccess.CreateTextCommand();

			command.CommandText = @"
				INSERT INTO 
					[Cerberus.TemplateEngine.Template]
					(
						Name,
						VisualProperties,
						CreatedByUserId,
						CreatedDate,
						LastModifiedDate
					)
				VALUES
					(
						@Name,
						@VisualProperties,
						@CreatedByUserId,
						GETDATE(),
						GETDATE()
					);

				DECLARE @IDENTITY INT;
				SELECT @IDENTITY=CAST(SCOPE_IDENTITY() AS INT);

				INSERT INTO
					[Cerberus.TemplateEngine.Resolution]
					(
						TemplateId
					)
				VALUES
					(
						@IDENTITY
					);

				SELECT @IDENTITY;";

			SqlDbAccess.AddParameter(command, "@Name", SqlDbType.NVarChar, template.Name);
			SqlDbAccess.AddParameter(command, "@CreatedByUserId", SqlDbType.Int, template.CreatedByUserId);
			SqlDbAccess.AddParameter(command, "@VisualProperties", SqlDbType.NVarChar, template.VisualProperties);

			return SqlDbAccess.ExecuteScalar<int>(command);
		}

		public bool UpdateTemplate(Template template)
		{
			var command = SqlDbAccess.CreateTextCommand();

			command.CommandText = @"
				UPDATE 
					[Cerberus.TemplateEngine.Template]
				SET
					Name = @Name,
					VisualProperties = @VisualProperties,
					LastModifiedDate = GETDATE()
				WHERE
					TemplateId = @TemplateId";

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, template.Id);
			SqlDbAccess.AddParameter(command, "@Name", SqlDbType.NVarChar, template.Name);
			SqlDbAccess.AddParameter(command, "@VisualProperties", SqlDbType.NVarChar, template.VisualProperties);

			return SqlDbAccess.ExecuteNonQuery(command) > 0;
		}

		public Template GetTemplate(int templateId)
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = @"
				SELECT 
					TemplateId,
					Name,
					CreatedByUserId,
					CreatedDate,
					LastModifiedDate,
					VisualProperties
				FROM 
					[Cerberus.TemplateEngine.Template]
				WHERE
					TemplateId = @TemplateId";

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			return Template.CreateFromData(SqlDbAccess.ExecuteSelect(command).Rows[0]);
		}

		public TemplateCollection GetTemplates(TemplateSearchParameters searchParameters)
		{
			var command = SqlDbAccess.CreateTextCommand();
			var sb = new StringBuilder(@"
				SELECT 
					TemplateId,
					Name,
					CreatedByUserId,
					CreatedDate,
					LastModifiedDate,
					VisualProperties
				FROM 
					[Cerberus.TemplateEngine.Template] ");

			if (searchParameters.CreatedByUserId > 0)
			{
				sb.AppendLine(" WHERE CreatedByUserId = @CreatedByUserId ");
				SqlDbAccess.AddParameter(command, "@CreatedByUserId", SqlDbType.Int, searchParameters.CreatedByUserId);
			}

			command.CommandText = sb.ToString();

			return TemplateCollection.CreateDataObjectCollection(SqlDbAccess.ExecuteSelect(command));
		}

		public bool RemoveTemplate(int templateId)
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = @"
				DELETE FROM
					[Cerberus.TemplateEngine.Template]
				WHERE
					TemplateId = @TemplateId";

			SqlDbAccess.AddParameter(command, "@TemplateId", SqlDbType.Int, templateId);

			return SqlDbAccess.ExecuteNonQuery(command) > 0;
		}
	}
}
