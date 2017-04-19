
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
	public class ProductionProductCostHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<CompoundKey>
	{
			public ProductionProductCostHistory()
		{
					Id = new CompoundKey();
							
			IsDirty = false; 
			_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	 
		public static CompoundKey GetCompoundKeyFor(ProductionProductCostHistory dao)
		{
			return new CompoundKey()
			{
				Keys = new IComparable[]
				{ 		dao.ProductID,
							dao.StartDate,
						
				}
			};
		}

			
			protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
			
			protected DateTime _startDate;
		public DateTime StartDate 
		{ 
			get { return _startDate; }
			set 
			{ 
				_startDate = value;
				this.Id = GetCompoundKeyFor(this);

								IsDirty = true;
							}
		}
		
		
		protected DateTime? _endDate;
		public DateTime? EndDate 
		{ 
			get { return _endDate; }
			set 
			{ 
				_endDate = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _standardCost;
		public decimal StandardCost 
		{ 
			get { return _standardCost; }
			set 
			{ 
				_standardCost = value;  
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
		 
	//From Foreign Key FK_ProductCostHistory_Product_ProductID	
		protected ProductionProduct _productionProduct;
		public virtual ProductionProduct ProductionProduct 
		{ 
			get { return _productionProduct; }
			set 
			{ 
				_productionProduct = value;  
				IsDirty = true;
			}
		} 
				}
}

		