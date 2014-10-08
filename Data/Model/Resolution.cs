using System.Collections.Generic;

namespace Cerberus.Tool.TemplateEngine.Data
{
	public class Resolution
	{
		public int Id
		{
			get;
			set;
		}

		public int ResolutionValue
		{
			get;
			set;
		}

		public Dictionary<int, string> TemplateControlVisualProperties
		{
			get;
			set;
		}

		public Resolution()
		{
			this.TemplateControlVisualProperties = new Dictionary<int, string>();
		}
	}
}
