using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Serialization;

namespace Cerberus.Tool.TemplateEngine.Business
{
	[DataContract]
	public class Template
	{
		private TemplateControlCollection templateControls = null;
		private ResolutionCollection resolutions = null;

		[DataMember(IsRequired = true)]
		public int Id
		{
			get;
			internal set;
		}

		[DataMember]
		public string Name
		{
			get;
			set;
		}

		public int CreatedByUserId
		{
			get;
			private set;
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

		[DataMember]
		public string VisualProperties
		{
			get;
			set;
		}

		[DataMember]
		public ResolutionCollection Resolutions
		{
			get
			{
				if (this.resolutions == null)
				{
					this.resolutions = TemplateManager.ResolutionService.GetResolutions(this.Id);
				}

				return this.resolutions;
			}

			set
			{
				this.resolutions = value;
			}
		}

		[DataMember]
		public TemplateControlCollection TemplateControls
		{
			get
			{
				if (this.templateControls == null)
				{
					this.templateControls = TemplateManager.TemplateControlService.GetControls(this.Id, this.DocumentId, this.DocumentTypeId);
				}

				return this.templateControls;
			}

			set
			{
				this.templateControls = value;
			}
		}

		public int DocumentId
		{
			get;
			internal set;
		}

		public int DocumentTypeId
		{
			get;
			internal set;
		}

		public Template()
		{
			this.CreatedDate = this.LastModifiedDate = DateTime.Now;
		}

		public bool Save(int userId, bool simpleSave = true)
		{
			if (this.Id > 0)
			{
				TemplateManager.TemplateService.UpdateTemplate(this);
			}
			else
			{
				this.CreatedByUserId = userId;
				TemplateManager.TemplateService.AddTemplate(this);
			}

			if (!simpleSave)
			{
				this.TemplateControls.Save(this.Id);
				this.Resolutions.Save(this.Id);
				this.templateControls = null;	//flag as dirty
				this.resolutions = null;		//flag as dirty
			}			

			return true;
		}

		internal Data.Template CreateDataObject()
		{
			return new Data.Template
			{
				Id = this.Id,
				Name = this.Name,
				CreatedByUserId = this.CreatedByUserId,
				CreatedDate = this.CreatedDate,
				LastModifiedDate = this.LastModifiedDate,
				VisualProperties = this.VisualProperties
			};
		}

		internal static Template CreateFromDataObject(Data.Template template)
		{
			return new Template
			{
				Id = template.Id,
				Name = template.Name,
				CreatedByUserId = template.CreatedByUserId,
				CreatedDate = template.CreatedDate,
				LastModifiedDate = template.LastModifiedDate,
				VisualProperties = template.VisualProperties
			};
		}

		public void ResetForCloning()
		{
			var templateControlIdMap = new Dictionary<int, int>();
			var creationControlId = -1;

			this.TemplateControls.ForEach(templateControl =>
			{
				templateControl.CreationGUID = creationControlId.ToString();
				templateControlIdMap[templateControl.Id] = creationControlId;
				templateControl.Id = 0;

				creationControlId--;
			});

			this.Resolutions.ForEach(resolution =>
			{
				resolution.Id = 0;
				var templateControlVisualProperties = new Dictionary<int, string>();
				foreach (var x in resolution.TemplateControlVisualProperties)
				{
					templateControlVisualProperties[templateControlIdMap[x.Key]] = x.Value;
				}

				resolution.TemplateControlVisualProperties = templateControlVisualProperties;
			});

			this.Id = 0;
		}

		public void SaveAs(int userId, int newArticleId)
		{
			Debug.Assert(newArticleId > 0);
			Debug.Assert(this.DocumentId > 0);
			Debug.Assert(this.DocumentTypeId > 0);
			Debug.Assert(this.Id > 0);

			var tmp = this.DocumentId;
			
			this.DocumentId = newArticleId;

			try
			{
				this.Save(userId, false);
			}
			finally
			{
				this.DocumentId = tmp;
			}
		}
	}
}
