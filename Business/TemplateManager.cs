using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Business
{
	public static class TemplateManager
	{
		public static TemplateService TemplateService
		{
			get;
			private set;
		}

		public static TemplateControlService TemplateControlService
		{
			get;
			private set;
		}

		public static ControlPluginService ControlPluginService
		{
			get;
			private set;
		}

		public static ResolutionService ResolutionService
		{
			get;
			private set;
		}

		public static TemplateControlContentService TemplateControlContentService
		{
			get;
			private set;
		}

		static TemplateManager()
		{
			TemplateService = new TemplateService();
			TemplateControlService = new TemplateControlService();
			ControlPluginService = new ControlPluginService();
			ResolutionService = new ResolutionService();
			TemplateControlContentService = new TemplateControlContentService();
		}
	}
}
