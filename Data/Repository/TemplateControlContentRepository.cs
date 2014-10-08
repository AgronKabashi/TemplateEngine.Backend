using System;
using System.Collections.Generic;
using System.Data;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class TemplateControlContentRepository
	{
		public void UpdateControlContent(int documentId, int documentTypeId, int templateId, TemplateControlCollection templateControls)
		{
			var command = SqlDbAccess.CreateTextCommand();

			command.CommandText = @"
				DELETE 
					[Cerberus.TemplateEngine.TemplateControlContent]
				FROM
					[Cerberus.TemplateEngine.TemplateControlContent] TCC
					JOIN [Cerberus.TemplateEngine.TemplateControl] TC ON TC.TemplateControlId=TCC.TemplateControlId
						AND TCC.DocumentId=@DocumentId
						AND TCC.DocumentTypeId=@DocumentTypeId";

			SqlDbAccess.AddParameter(command, "@DocumentId", SqlDbType.Int, documentId);
			SqlDbAccess.AddParameter(command, "@DocumentTypeId", SqlDbType.Int, documentTypeId);
			SqlDbAccess.ExecuteNonQuery(command);

			command.CommandText = string.Format(@"
				INSERT INTO [Cerberus.TemplateEngine.TemplateControlContent]
					(
						DocumentId,
						DocumentTypeId,
						TemplateControlId,
						Content
					)
				VALUES
					(
						{0},
						{1},
						@TemplateControlId,
						@Content
					);",
				documentId,
				documentTypeId);

			var templateControlIdParameter = SqlDbAccess.AddParameter(command, "@TemplateControlId", SqlDbType.Int, 0);
			var contentParameter = SqlDbAccess.AddParameter(command, "@Content", SqlDbType.NText, string.Empty);

			foreach (var templateControl in templateControls)
			{
				templateControlIdParameter.Value = templateControl.Id;
				contentParameter.Value = templateControl.Content;

				SqlDbAccess.ExecuteNonQuery(command);
			}

			command.CommandText = @"
				DELETE 
					[Cerberus.TemplateEngine.TemplateControlContent]
				FROM
					[Cerberus.TemplateEngine.TemplateControlContent] TCC
					JOIN [Cerberus.TemplateEngine.TemplateControl] TC ON TC.TemplateControlId=TCC.TemplateControlId
						AND TCC.DocumentId=@DocumentId
						AND TCC.DocumentTypeId=@DocumentTypeId
						AND TC.Content = TCC.Content";
			SqlDbAccess.ExecuteNonQuery(command);
		}

		public bool RemoveTemplateControlContent(int documentId, int documentTypeId)
		{
			var command = SqlDbAccess.CreateTextCommand();

			command.CommandText = @"
				DELETE FROM
					[Cerberus.TemplateEngine.TemplateControlContent]
				WHERE
					DocumentId=@DocumentId
					AND DocumentTypeId=@DocumentTypeId";

			SqlDbAccess.AddParameter(command, "@DocumentId", SqlDbType.Int, documentId);
			SqlDbAccess.AddParameter(command, "@DocumentTypeId", SqlDbType.Int, documentTypeId);

			return SqlDbAccess.ExecuteNonQuery(command) > 0;
		}
	}
}