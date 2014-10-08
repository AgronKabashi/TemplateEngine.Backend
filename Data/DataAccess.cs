using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public static class DataAccess
	{
		public static TemplateRepository TemplateRepository
		{
			get;
			private set;
		}

		public static TemplateControlRepository TemplateControlRepository
		{
			get;
			private set;
		}

		public static ControlPluginRepository ControlPluginRepository
		{
			get;
			private set;
		}

		public static ResolutionRepository ResolutionRepository
		{
			get;
			private set;
		}

		public static TemplateControlContentRepository TemplateControlContentRepository
		{
			get;
			private set;
		}

		static DataAccess()
		{
			TemplateRepository = new TemplateRepository();
			TemplateControlRepository = new TemplateControlRepository();
			ControlPluginRepository = new ControlPluginRepository();
			ResolutionRepository = new ResolutionRepository();
			TemplateControlContentRepository = new TemplateControlContentRepository();
		}
	}
}
