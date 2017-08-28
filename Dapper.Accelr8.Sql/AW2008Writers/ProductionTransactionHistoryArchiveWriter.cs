
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
    public class ProductionTransactionHistoryArchiveWriter : EntityWriter<int, ProductionTransactionHistoryArchive>
    {
        public ProductionTransactionHistoryArchiveWriter
			(ProductionTransactionHistoryArchiveTableInfo tableInfo
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

		
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionTransactionHistoryArchive entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionTransactionHistoryArchiveFieldNames)f.Key)
                {
                    
					case ProductionTransactionHistoryArchiveFieldNames.ProductID:
						parms.Add(GetParamName("ProductID", actionType, taskIndex, ref count), entity.ProductID);
						break;
					case ProductionTransactionHistoryArchiveFieldNames.ReferenceOrderID:
						parms.Add(GetParamName("ReferenceOrderID", actionType, taskIndex, ref count), entity.ReferenceOrderID);
						break;
					case ProductionTransactionHistoryArchiveFieldNames.ReferenceOrderLineID:
						parms.Add(GetParamName("ReferenceOrderLineID", actionType, taskIndex, ref count), entity.ReferenceOrderLineID);
						break;
					case ProductionTransactionHistoryArchiveFieldNames.TransactionDate:
						parms.Add(GetParamName("TransactionDate", actionType, taskIndex, ref count), entity.TransactionDate);
						break;
					case ProductionTransactionHistoryArchiveFieldNames.TransactionType:
						parms.Add(GetParamName("TransactionType", actionType, taskIndex, ref count), entity.TransactionType);
						break;
					case ProductionTransactionHistoryArchiveFieldNames.Quantity:
						parms.Add(GetParamName("Quantity", actionType, taskIndex, ref count), entity.Quantity);
						break;
					case ProductionTransactionHistoryArchiveFieldNames.ActualCost:
						parms.Add(GetParamName("ActualCost", actionType, taskIndex, ref count), entity.ActualCost);
						break;
					case ProductionTransactionHistoryArchiveFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionTransactionHistoryArchive entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionTransactionHistoryArchive entity)
        {
            if (entity == null)
                return;

				
		}

		protected override void RemoveRelations(ProductionTransactionHistoryArchive entity, ScriptContext context)
        {
				}
	}
}
		