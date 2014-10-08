using Cerberus.Tool.TemplateEngine.Data;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public class ControlPluginService
	{
		public ControlPluginCollection GetControlPlugins()
		{
			return ControlPluginCollection.CreateFromDataObjectCollection(DataAccess.ControlPluginRepository.GetControlPlugins());
		}
	}
}
