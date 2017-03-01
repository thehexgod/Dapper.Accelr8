
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
	public enum ProductionBillOfMaterialColumnNames
	{	
		BillOfMaterialsID, 	
		ProductAssemblyID, 	
		ComponentID, 	
		StartDate, 	
		EndDate, 	
		UnitMeasureCode, 	
		BOMLevel, 	
		PerAssemblyQty, 	
		ModifiedDate, 	
	}

	public enum ProductionBillOfMaterialCascadeNames
	{	
		
		productionunitmeasure_p, 	
		productionproduct_p, 	}

	public class ProductionBillOfMaterialTableInfo : Dapper.Accelr8.Sql.TableInfo
	{
		public ProductionBillOfMaterialTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			UniqueId = true;
			IdColumn = ProductionBillOfMaterialColumnNames.BillOfMaterialsID.ToString();
			//Schema = "Production.BillOfMaterials";
			TableName = "Production.BillOfMaterials";
			TableAlias = "productionbillofmaterial";
			ColumnNames = typeof(ProductionBillOfMaterialColumnNames).ToDataList<Type, int>();

			Joins = new JoinInfo[] {
						//For Key FK_BillOfMaterials_UnitMeasure_UnitMeasureCode
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure")),
			TableName = "Production.UnitMeasure",
			Alias = TableAlias + "_" + "ProductionUnitMeasure",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<string, ProductionUnitMeasure>("ProductionUnitMeasure");
					var st = (entity as ProductionBillOfMaterial);

					if (st == null || row == null)
						return st;

					if (row.UnitMeasureCode == null || row.UnitMeasureCode == default(string))
						return st;

					st.ProductionUnitMeasure = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionUnitMeasureColumnNames.   .ToString()
					//ProductionBillOfMaterialColumnNames.      .ToString()
					JoinField = "UnitMeasureCode",
					Operator = Operator.Equals,
					ParentField = "UnitMeasureCode",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BillOfMaterials_Product_ComponentID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionBillOfMaterial);

					if (st == null || row == null)
						return st;

					if (row.ProductID == null || row.ProductID == default(int))
						return st;

					st.ProductionProduct = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductColumnNames.   .ToString()
					//ProductionBillOfMaterialColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ComponentID",
					ParentTableAlias = TableAlias
				}
			} },
						//For Key FK_BillOfMaterials_Product_ProductAssemblyID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, ProductionProduct>("ProductionProduct")),
			TableName = "Production.Product",
			Alias = TableAlias + "_" + "ProductionProduct",
			Outer = true,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, ProductionProduct>("ProductionProduct");
					var st = (entity as ProductionBillOfMaterial);

					if (st == null || row == null)
						return st;

					if (row.ProductID == null || row.ProductID == default(int))
						return st;

					st.ProductionProduct = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//ProductionProductColumnNames.   .ToString()
					//ProductionBillOfMaterialColumnNames.      .ToString()
					JoinField = "ProductID",
					Operator = Operator.Equals,
					ParentField = "ProductAssemblyID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		