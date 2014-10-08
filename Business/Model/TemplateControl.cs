using System;
using System.Runtime.Serialization;

namespace Cerberus.Tool.TemplateEngine.Business
{
	[DataContract]
	public class TemplateControl
	{
		[DataMember]
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

		[DataMember]
		public string FriendlyName
		{
			get;
			set;
		}

		[DataMember]
		public string ControlName
		{
			get;
			set;
		}

		[DataMember]
		public string Content
		{
			get;
			set;
		}

		[DataMember]
		public string DefaultContent
		{
			get;
			set;
		}

		[DataMember]
		public string VisualProperties
		{
			get;
			set;
		}

		[DataMember(IsRequired = true)]
		public string Category
		{
			get;
			private set;
		}

		[DataMember]
		public string CreationGUID
		{
			get;
			set;
		}

		[DataMember]
		public string Class
		{
			get;
			set;
		}

		public Data.TemplateControl CreateDataObject()
		{
			return new Data.TemplateControl
			{
				Id = this.Id,
				FriendlyName = this.FriendlyName,
				ControlName = this.ControlName,
				ControlType = this.ControlType,
				Content = this.Content,
				VisualProperties = this.VisualProperties,
				Category = this.Category,
				CreationGUID = this.CreationGUID,
				Class = this.Class
			};
		}

		public static TemplateControl CreateFromDataObject(Data.TemplateControl templateControl)
		{
			return new TemplateControl
			{
				Id = templateControl.Id,
				FriendlyName = templateControl.FriendlyName,
				ControlName = templateControl.ControlName,
				ControlType = templateControl.ControlType,
				Content = templateControl.Content,
				VisualProperties = templateControl.VisualProperties,
				Category = templateControl.Category,
				CreationGUID = templateControl.CreationGUID,
				Class = templateControl.Class
			};
		}
	}
}
