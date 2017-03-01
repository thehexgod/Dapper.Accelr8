
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

namespace Dapper.Accelr8.AW2008Readers
{
    public class ProductionWorkOrderReader : EntityReader<int, ProductionWorkOrder>
    {
        public ProductionWorkOrderReader(
            ProductionWorkOrderTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
        { }

		//Child Count 1
		//Parent Count 2
		static IEntityReader<int , ProductionWorkOrderRouting> _productionWorkOrderRoutingReader;
		protected static IEntityReader<int , ProductionWorkOrderRouting> GetProductionWorkOrderRoutingReader()
		{
			return _locator.Resolve<IEntityReader<int , ProductionWorkOrderRouting>>();
		}

		
		/// <summary>
		/// Sets the children of type ProductionWorkOrderRouting on the parent on ProductionWorkOrderRoutings.
		/// From foriegn key FK_WorkOrderRouting_WorkOrder_WorkOrderID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenProductionWorkOrderRoutings(IList<ProductionWorkOrder> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: ProductionWorkOrderRouting

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<ProductionWorkOrderRouting>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				r.ProductionWorkOrderRoutings = typedChildren.Where(b => b.ProductionWorkOrderRouting == r.Id).ToList();
				r.ProductionWorkOrderRoutings.ToList().ForEach(b => { b.Loaded = false; b.ProductionWorkOrder = r; b.Loaded = true; });
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Production.WorkOrder into class ProductionWorkOrder
		/// </summary>
		/// <param name="results">ProductionWorkOrder</param>
		/// <param name="row"></param>
        public override ProductionWorkOrder LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new ProductionWorkOrder();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, IdColumn);
				domain.ProductID = GetRowData<int>(dataRow, "ProductID"); 
      		domain.OrderQty = GetRowData<int>(dataRow, "OrderQty"); 
      		domain.StockedQty = GetRowData<int>(dataRow, "StockedQty"); 
      		domain.ScrappedQty = GetRowData<short>(dataRow, "ScrappedQty"); 
      		domain.StartDate = GetRowData<DateTime>(dataRow, "StartDate"); 
      		domain.EndDate = GetRowData<DateTime?>(dataRow, "EndDate"); 
      		domain.DueDate = GetRowData<DateTime>(dataRow, "DueDate"); 
      		domain.ScrapReasonID = GetRowData<short?>(dataRow, "ScrapReasonID"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, ProductionWorkOrder></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, ProductionWorkOrder> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetProductionWorkOrderRoutingReader(), id, IdColumn, SetChildrenProductionWorkOrderRoutings);
			
            return this;
        }

        public override void SetAllChildrenForExisting(ProductionWorkOrder entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetProductionWorkOrderRoutingReader(), entity.Id
				, ProductionWorkOrderRoutingColumnNames.WorkOrderID.ToString()
				, SetChildrenProductionWorkOrderRoutings);

			QueryResultForChildrenOnly(new List<ProductionWorkOrder>() { entity });
			entity.Loaded = false;
			GetProductionWorkOrderRoutingReader().SetAllChildrenForExisting(entity.ProductionWorkOrderRoutings);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<ProductionWorkOrder> entities)
        {
			ClearAllQueries();

			entities = entities.Where(e => e != null).ToList();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetProductionWorkOrderRoutingReader()
				, entities
				.Select(s => s.Id)
				.ToArray(), ProductionWorkOrderRoutingColumnNames.WorkOrderID.ToString()
				, SetChildrenProductionWorkOrderRoutings);

					
			QueryResultForChildrenOnly(entities);

			GetProductionWorkOrderRoutingReader().SetAllChildrenForExisting(entities.SelectMany(e => e.ProductionWorkOrderRoutings).ToList());
					
		}
    }
}
		