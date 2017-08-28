
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;

using Dapper.Accelr8.Sql.AW2008DAO;
using Dapper.Accelr8.AW2008TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008TableInfos
{
	public enum PurchasingPurchaseOrderHeaderFieldNames
	{	
		Id, 	
		RevisionNumber, 	
		Status, 	
		EmployeeID, 	
		VendorID, 	
		ShipMethodID, 	
		OrderDate, 	
		ShipDate, 	
		SubTotal, 	
		TaxAmt, 	
		Freight, 	
		TotalDue, 	
		ModifiedDate, 	
	}

	public enum PurchasingPurchaseOrderHeaderCascadeNames
	{	
		purchasingpurchaseorderdetails, 	
		
		purchasingvendor_p, 	
		humanresourcesemployee_p, 	
		purchasingshipmethod_p, 	}

	public class PurchasingPurchaseOrderHeaderTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PurchasingPurchaseOrderHeaderColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingPurchaseOrderHeaderFieldNames.Id, "PurchaseOrderID" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.RevisionNumber, "RevisionNumber" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.Status, "Status" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.EmployeeID, "EmployeeID" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.VendorID, "VendorID" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.ShipMethodID, "ShipMethodID" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.OrderDate, "OrderDate" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.ShipDate, "ShipDate" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.SubTotal, "SubTotal" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.TaxAmt, "TaxAmt" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.Freight, "Freight" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.TotalDue, "TotalDue" }, 
						{ (int)PurchasingPurchaseOrderHeaderFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PurchasingPurchaseOrderHeaderIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PurchasingPurchaseOrderHeaderFieldNames.Id, "PurchaseOrderID" }, 
				};

		public PurchasingPurchaseOrderHeaderTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Purchasing";
			TableName = "Purchasing.PurchaseOrderHeader";
			TableAlias = "purchasingpurchaseorderheader";
			Columns = PurchasingPurchaseOrderHeaderColumnNames;
			IdColumns = PurchasingPurchaseOrderHeaderIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_PurchaseOrderHeader_Vendor_VendorID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PurchasingVendor>("PurchasingVendor")),
			TableName = "Purchasing.Vendor",
			Alias = TableAlias + "_" + "PurchasingVendor",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PurchasingVendor>("PurchasingVendor");
					var st = (entity as PurchasingPurchaseOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PurchasingVendor = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PurchasingVendorColumnNames.   .ToString()
					//PurchasingPurchaseOrderHeaderColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "VendorID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_PurchaseOrderHeader_Employee_EmployeeID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee")),
			TableName = "HumanResources.Employee",
			Alias = TableAlias + "_" + "HumanResourcesEmployee",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, HumanResourcesEmployee>("HumanResourcesEmployee");
					var st = (entity as PurchasingPurchaseOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.HumanResourcesEmployee = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//HumanResourcesEmployeeColumnNames.   .ToString()
					//PurchasingPurchaseOrderHeaderColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "EmployeeID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_PurchaseOrderHeader_ShipMethod_ShipMethodID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PurchasingShipMethod>("PurchasingShipMethod")),
			TableName = "Purchasing.ShipMethod",
			Alias = TableAlias + "_" + "PurchasingShipMethod",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PurchasingShipMethod>("PurchasingShipMethod");
					var st = (entity as PurchasingPurchaseOrderHeader);

					if (st == null || row == null)
						return st;

					if (row.ShipMethodID == null || row.ShipMethodID == default(int))
						return st;

					st.PurchasingShipMethod = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PurchasingShipMethodColumnNames.   .ToString()
					//PurchasingPurchaseOrderHeaderColumnNames.      .ToString()
					JoinField = "ShipMethodID",
					Operator = Operator.Equals,
					ParentField = "ShipMethodID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		