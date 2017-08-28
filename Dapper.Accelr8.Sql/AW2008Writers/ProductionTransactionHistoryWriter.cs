
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
    public class ProductionTransactionHistoryWriter : EntityWriter<int, ProductionTransactionHistory>
    {
        public ProductionTransactionHistoryWriter
			(ProductionTransactionHistoryTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{
			if (s_loc8r == null)
				s_loc8r = loc8r;
		}

		static ILoc8 s_loc8r = null;

		
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionTransactionHistory entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionTransactionHistoryFieldNames)f.Key)
                {
                    
					case ProductionTransactionHistoryFieldNames.ProductID:
						parms.Add(GetParamName("ProductID", actionType, taskIndex, ref count), entity.ProductID);
						break;
					case ProductionTransactionHistoryFieldNames.ReferenceOrderID:
						parms.Add(GetParamName("ReferenceOrderID", actionType, taskIndex, ref count), entity.ReferenceOrderID);
						break;
					case ProductionTransactionHistoryFieldNames.ReferenceOrderLineID:
						parms.Add(GetParamName("ReferenceOrderLineID", actionType, taskIndex, ref count), entity.ReferenceOrderLineID);
						break;
					case ProductionTransactionHistoryFieldNames.TransactionDate:
						parms.Add(GetParamName("TransactionDate", actionType, taskIndex, ref count), entity.TransactionDate);
						break;
					case ProductionTransactionHistoryFieldNames.TransactionType:
						parms.Add(GetParamName("TransactionType", actionType, taskIndex, ref count), entity.TransactionType);
						break;
					case ProductionTransactionHistoryFieldNames.Quantity:
						parms.Add(GetParamName("Quantity", actionType, taskIndex, ref count), entity.Quantity);
						break;
					case ProductionTransactionHistoryFieldNames.ActualCost:
						parms.Add(GetParamName("ActualCost", actionType, taskIndex, ref count), entity.ActualCost);
						break;
					case ProductionTransactionHistoryFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionTransactionHistory entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_TransactionHistory_Product_ProductID
			var productionProduct412 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionTransactionHistoryCascadeNames.productionproduct_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct412, entity.ProductionProduct, context))
				WithParent(productionProduct412, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionTransactionHistory entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_TransactionHistory_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductID = entity.ProductionProduct.Id;

		}

		protected override void RemoveRelations(ProductionTransactionHistory entity, ScriptContext context)
        {
				}
	}
}
		