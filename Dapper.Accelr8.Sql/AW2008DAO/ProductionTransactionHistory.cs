
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
	public class ProductionTransactionHistory : Dapper.Accelr8.Repo.Domain.BaseEntity<int>
	{
			public ProductionTransactionHistory()
		{
							
			IsDirty = false; 
			_transactionDate = (DateTime)SqlDateTime.MinValue;
		_modifiedDate = (DateTime)SqlDateTime.MinValue;
		}


	
		
		protected int _productID;
		public int ProductID 
		{ 
			get { return _productID; }
			set 
			{ 
				_productID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _referenceOrderID;
		public int ReferenceOrderID 
		{ 
			get { return _referenceOrderID; }
			set 
			{ 
				_referenceOrderID = value;  
				IsDirty = true;
			}
		} 
			
		protected int _referenceOrderLineID;
		public int ReferenceOrderLineID 
		{ 
			get { return _referenceOrderLineID; }
			set 
			{ 
				_referenceOrderLineID = value;  
				IsDirty = true;
			}
		} 
			
		protected DateTime _transactionDate;
		public DateTime TransactionDate 
		{ 
			get { return _transactionDate; }
			set 
			{ 
				_transactionDate = value;  
				IsDirty = true;
			}
		} 
			
		protected string _transactionType;
		public string TransactionType 
		{ 
			get { return _transactionType; }
			set 
			{ 
				_transactionType = value;  
				IsDirty = true;
			}
		} 
			
		protected int _quantity;
		public int Quantity 
		{ 
			get { return _quantity; }
			set 
			{ 
				_quantity = value;  
				IsDirty = true;
			}
		} 
			
		protected decimal _actualCost;
		public decimal ActualCost 
		{ 
			get { return _actualCost; }
			set 
			{ 
				_actualCost = value;  
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
		 
	//From Foreign Key FK_TransactionHistory_Product_ProductID	
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

		