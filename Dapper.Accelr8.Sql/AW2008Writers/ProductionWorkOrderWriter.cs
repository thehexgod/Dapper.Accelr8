
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
    public class ProductionWorkOrderWriter : EntityWriter<int, ProductionWorkOrder>
    {
        public ProductionWorkOrderWriter
			(ProductionWorkOrderTableInfo tableInfo
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

		static IEntityWriter<int, ProductionWorkOrderRouting> GetProductionWorkOrderRoutingWriter()
		{ return s_loc8r.GetWriter<int, ProductionWorkOrderRouting>(); }
		
		static IEntityWriter<int, ProductionProduct> GetProductionProductWriter()
		{ return s_loc8r.GetWriter<int, ProductionProduct>(); }
		static IEntityWriter<short, ProductionScrapReason> GetProductionScrapReasonWriter()
		{ return s_loc8r.GetWriter<short, ProductionScrapReason>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionWorkOrder entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionWorkOrderFieldNames)f.Key)
                {
                    
					case ProductionWorkOrderFieldNames.ProductID:
						parms.Add(GetParamName("ProductID", actionType, taskIndex, ref count), entity.ProductID);
						break;
					case ProductionWorkOrderFieldNames.OrderQty:
						parms.Add(GetParamName("OrderQty", actionType, taskIndex, ref count), entity.OrderQty);
						break;
					case ProductionWorkOrderFieldNames.StockedQty:
						parms.Add(GetParamName("StockedQty", actionType, taskIndex, ref count), entity.StockedQty);
						break;
					case ProductionWorkOrderFieldNames.ScrappedQty:
						parms.Add(GetParamName("ScrappedQty", actionType, taskIndex, ref count), entity.ScrappedQty);
						break;
					case ProductionWorkOrderFieldNames.StartDate:
						parms.Add(GetParamName("StartDate", actionType, taskIndex, ref count), entity.StartDate);
						break;
					case ProductionWorkOrderFieldNames.EndDate:
						parms.Add(GetParamName("EndDate", actionType, taskIndex, ref count), entity.EndDate);
						break;
					case ProductionWorkOrderFieldNames.DueDate:
						parms.Add(GetParamName("DueDate", actionType, taskIndex, ref count), entity.DueDate);
						break;
					case ProductionWorkOrderFieldNames.ScrapReasonID:
						parms.Add(GetParamName("ScrapReasonID", actionType, taskIndex, ref count), entity.ScrapReasonID);
						break;
					case ProductionWorkOrderFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionWorkOrder entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_WorkOrderRouting_WorkOrder_WorkOrderID
			var productionWorkOrderRouting431 = GetProductionWorkOrderRoutingWriter();
			if (_cascades.Contains(ProductionWorkOrderCascadeNames.productionworkorderroutings.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrderRoutings)
					Cascade(productionWorkOrderRouting431, item, context);

			if (productionWorkOrderRouting431.Count > 0)
				WithChild(productionWorkOrderRouting431, entity);

		
		
			//From Foreign Key FK_WorkOrder_Product_ProductID
			var productionProduct432 = GetProductionProductWriter();
		if ((_cascades.Contains(ProductionWorkOrderCascadeNames.productionproduct_p.ToString()) || _cascades.Contains("all")) && entity.ProductionProduct != null)
			if (Cascade(productionProduct432, entity.ProductionProduct, context))
				WithParent(productionProduct432, entity);

			//From Foreign Key FK_WorkOrder_ScrapReason_ScrapReasonID
			var productionScrapReason433 = GetProductionScrapReasonWriter();
		if ((_cascades.Contains(ProductionWorkOrderCascadeNames.productionscrapreason_p.ToString()) || _cascades.Contains("all")) && entity.ProductionScrapReason != null)
			if (Cascade(productionScrapReason433, entity.ProductionScrapReason, context))
				WithParent(productionScrapReason433, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionWorkOrder entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_WorkOrderRouting_WorkOrder_WorkOrderID
			if (entity.ProductionWorkOrderRoutings != null && entity.ProductionWorkOrderRoutings.Count > 0)
				foreach (var rel in entity.ProductionWorkOrderRoutings)
					rel.WorkOrderID = entity.Id;

				
			//From Foreign Key FK_WorkOrder_Product_ProductID
			if (entity.ProductionProduct != null)
				entity.ProductID = entity.ProductionProduct.Id;

			//From Foreign Key FK_WorkOrder_ScrapReason_ScrapReasonID
			if (entity.ProductionScrapReason != null)
				entity.ScrapReasonID = entity.ProductionScrapReason.Id;

		}

		protected override void RemoveRelations(ProductionWorkOrder entity, ScriptContext context)
        {
					//From Foreign Key FK_WorkOrderRouting_WorkOrder_WorkOrderID
			var productionWorkOrderRouting437 = GetProductionWorkOrderRoutingWriter();
			if (_cascades.Contains(ProductionWorkOrderCascadeNames.productionworkorderrouting.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.ProductionWorkOrderRoutings)
					CascadeDelete(productionWorkOrderRouting437, item, context);

			if (productionWorkOrderRouting437.Count > 0)
				WithChild(productionWorkOrderRouting437, entity);

				}
	}
}
		