
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
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008Writers
{
    public class ProductionProductListPriceHistoryWriter : EntityWriter<int, ProductionProductListPriceHistory>
    {
        public ProductionProductListPriceHistoryWriter
			(ProductionProductListPriceHistoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return _locator.Resolve<IEntityWriter<int, ProductionProduct>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionProductListPriceHistory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionProductListPriceHistoryColumnNames)f.Key)
                {
                    
					case ProductionProductListPriceHistoryColumnNames.EndDate:
						parms.Add(GetParamName("EndDate", actionType, taskIndex, ref count), entity.EndDate);
						break;
					case ProductionProductListPriceHistoryColumnNames.ListPrice:
						parms.Add(GetParamName("ListPrice", actionType, taskIndex, ref count), entity.ListPrice);
						break;
					case ProductionProductListPriceHistoryColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionProductListPriceHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_ProductListPriceHistory_Product_ProductID
			var productionProduct238 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionProductListPriceHistoryCascadeNames.productionproduct.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct238, entity.ProductionProduct, context))
				WithParent(productionProduct238, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionProductListPriceHistory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_ProductListPriceHistory_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductionProductListPriceHistory = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionProductListPriceHistory entity, ScriptContext context)
        {
				}
	}
}
		