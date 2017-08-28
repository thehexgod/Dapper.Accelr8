
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Domain;
using System.Data.SqlTypes;

namespace Dapper.Accelr8.Sql.AW2008DAO
{
	public class ProductionProductModel : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionProductModel()
		{
							
			IsDirty = false; 
			_productionProducts = new List<ProductionProduct>();
		_productionProductModelIllustrations = new List<ProductionProductModelIllustration>();
		_productionProductModelProductDescriptionCultures = new List<ProductionProductModelProductDescriptionCulture>();
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected object _name;
		public object Name 
		{ 
			get { return _name; }
			set 
			{ 
				_name = value;  
				IsDirty = true;
			}
		} 
			
		protected string _catalogDescription;
		public string CatalogDescription 
		{ 
			get { return _catalogDescription; }
			set 
			{ 
				_catalogDescription = value;  
				IsDirty = true;
			}
		} 
			
		protected string _instructions;
		public string Instructions 
		{ 
			get { return _instructions; }
			set 
			{ 
				_instructions = value;  
				IsDirty = true;
			}
		} 
			
		protected Guid _rowguid;
		public Guid rowguid 
		{ 
			get { return _rowguid; }
			set 
			{ 
				_rowguid = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _modifiedDate;
		public DateTime ModifiedDate 
		{ 
			get { return _modifiedDate; }
			set 
			{ 
				_modifiedDate = value;  
				IsDirty = true;
			}
		} 
		 
	//From Foreign Key FK_Product_ProductModel_ProductModelID	
		protected IList<ProductionProduct> _productionProducts;
		public virtual IList<ProductionProduct> ProductionProducts 
		{ 
			get { return _productionProducts; }
			set 
			{ 
				_productionProducts = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductModelIllustration_ProductModel_ProductModelID	
		protected IList<ProductionProductModelIllustration> _productionProductModelIllustrations;
		public virtual IList<ProductionProductModelIllustration> ProductionProductModelIllustrations 
		{ 
			get { return _productionProductModelIllustrations; }
			set 
			{ 
				_productionProductModelIllustrations = value;  
				IsDirty = true;
			}
		} 
			 
	//From Foreign Key FK_ProductModelProductDescriptionCulture_ProductModel_ProductModelID	
		protected IList<ProductionProductModelProductDescriptionCulture> _productionProductModelProductDescriptionCultures;
		public virtual IList<ProductionProductModelProductDescriptionCulture> ProductionProductModelProductDescriptionCultures 
		{ 
			get { return _productionProductModelProductDescriptionCultures; }
			set 
			{ 
				_productionProductModelProductDescriptionCultures = value;  
				IsDirty = true;
			}
		} 
					}
}

		