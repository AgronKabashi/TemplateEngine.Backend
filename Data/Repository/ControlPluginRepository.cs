namespace Cerberus.Tool.TemplateEngine.Data
{
	public class ControlPluginRepository
	{
		public ControlPluginCollection GetControlPlugins()
		{
			var command = SqlDbAccess.CreateTextCommand();
			command.CommandText = @"
				SELECT
					ControlPluginId,
					ControlType,
					Name,
					ImageUrl,
					Category
				FROM
					[Cerberus.TemplateEngine.ControlPlugin]
				WHERE
					Enabled=1";

			return ControlPluginCollection.CreateFromData(SqlDbAccess.ExecuteSelect(command));
		}
	}
}
