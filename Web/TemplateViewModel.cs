using Cerberus.Tool.TemplateEngine.Business;
using System;
using System.Runtime.Serialization;

namespace Cerberus.Tool.TemplateEngine.Web
{
	[DataContract]
	public class TemplateViewModel
	{
		[DataMember(IsRequired = true)]
		public int Id
		{
			get;
			private set;
		}

		[DataMember]
		public string Name
		{
			get;
			set;
		}

		public DateTime CreatedDate
		{
			get;
			private set;
		}

		public DateTime LastModifiedDate
		{
			get;
			private set;
		}

		[DataMember]
		public string CreatedDateAsString
		{
			get
			{
				return this.CreatedDate.ToString();
			}
			set { }
		}

		[DataMember]
		public string LastModifiedDateAsString
		{
			get
			{
				return this.LastModifiedDate.ToString();
			}
			set { }
		}

		public static TemplateViewModel CreateFromModel(Template template)
		{
			return new TemplateViewModel
			{
				Id = template.Id,
				Name = template.Name,
				CreatedDate = template.CreatedDate,
				LastModifiedDate = template.LastModifiedDate
			};
		}
	}
}
