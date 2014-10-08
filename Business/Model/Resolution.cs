using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Cerberus.Tool.TemplateEngine.Business
{
	[DataContract]
	public class Resolution
	{
		[DataMember]
		public int Id
		{
			get;
			set;
		}

		[DataMember]
		public int ResolutionValue
		{
			get;
			set;
		}

		[DataMember]
		public Dictionary<int, string> TemplateControlVisualProperties
		{
			get;
			set;
		}

		internal Data.Resolution CreateDataObject()
		{
			return new Data.Resolution
			{
				Id = this.Id,
				ResolutionValue = this.ResolutionValue,
				TemplateControlVisualProperties = this.TemplateControlVisualProperties
			};
		}

		internal static Resolution CreateFromDataObject(Data.Resolution resolution)
		{
			return new Resolution
			{
				Id = resolution.Id,
				ResolutionValue = resolution.ResolutionValue,
				TemplateControlVisualProperties = resolution.TemplateControlVisualProperties
			};
		}
	}
}
