using System.Runtime.Serialization;

namespace Cerberus.Tool.TemplateEngine.Business
{
	[DataContract]
	public class ControlPlugin
	{
		[DataMember(IsRequired = true)]
		public int Id
		{
			get;
			internal set;
		}

		[DataMember(IsRequired = true)]
		public string ControlType
		{
			get;
			internal set;
		}

		[DataMember(IsRequired = true)]
		public string Name
		{
			get;
			internal set;
		}

		[DataMember(IsRequired = true)]
		public string ImageUrl
		{
			get;
			internal set;
		}

		[DataMember(IsRequired = true)]
		public string Category
		{
			get;
			internal set;
		}

		internal static ControlPlugin CreateFromDataObject(Data.ControlPlugin controlPlugin)
		{
			return new ControlPlugin
			{
				Id = controlPlugin.Id,
				ControlType = controlPlugin.ControlType,
				Name = controlPlugin.Name,
				ImageUrl = controlPlugin.ImageUrl,
				Category = controlPlugin.Category
			};
		}

		internal Data.ControlPlugin CreateDataObject()
		{
			return new Data.ControlPlugin
			{
				Id = this.Id,
				ControlType = this.ControlType,
				Name = this.Name,
				ImageUrl = this.ImageUrl,
				Category = this.Category
			};
		}
	}
}