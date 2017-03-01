
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
    public class SalesSalesOrderHeaderSalesReasonWriter : EntityWriter<int, SalesSalesOrderHeaderSalesReason>
    {
        public SalesSalesOrderHeaderSalesReasonWriter
			(SalesSalesOrderHeaderSalesReasonTableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
			, ILoc8 loc8r) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, loc8r)
		{

		}

		
		static IEntityWriter<int, SalesSalesOrderHeader> GetSalesSalesOrderHeaderWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesOrderHeader>>(); }
		static IEntityWriter<int, SalesSalesReason> GetSalesSalesReasonWriter()
		{ return _locator.Resolve<IEntityWriter<int, SalesSalesReason>>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, SalesSalesOrderHeaderSalesReason entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((SalesSalesOrderHeaderSalesReasonColumnNames)f.Key)
                {
                    
					case SalesSalesOrderHeaderSalesReasonColumnNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(SalesSalesOrderHeaderSalesReason entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			var salesSalesOrderHeader320 = GetSalesSalesOrderHeaderWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderSalesReasonCascadeNames.salessalesorderheader.ToString()) || _cascades.Contains("all")) && entity.SalesSalesOrderHeader != null)
			if (Cascade(salesSalesOrderHeader320, entity.SalesSalesOrderHeader, context))
				WithParent(salesSalesOrderHeader320, entity);

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
			var salesSalesReason321 = GetSalesSalesReasonWriter();
		if ((_cascades.Contains(SalesSalesOrderHeaderSalesReasonCascadeNames.salessalesreason.ToString()) || _cascades.Contains("all")) && entity.SalesSalesReason != null)
			if (Cascade(salesSalesReason321, entity.SalesSalesReason, context))
				WithParent(salesSalesReason321, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, SalesSalesOrderHeaderSalesReason entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesOrderHeader_SalesOrderID
			if (entity.SalesSalesOrderHeader != null)
				entity.SalesSalesOrderHeaderSalesReason = entity.SalesSalesOrderHeader.Id;

			//From Foreign Key FK_SalesOrderHeaderSalesReason_SalesReason_SalesReasonID
			if (entity.SalesSalesReason != null)
				entity.SalesSalesOrderHeaderSalesReason = entity.SalesSalesReason.Id;

		}

		protected override void RemoveRelations(SalesSalesOrderHeaderSalesReason entity, ScriptContext context)
        {
				}
	}
}
		