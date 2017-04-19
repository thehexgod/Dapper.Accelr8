
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
    public class SalesCurrencyRateReader : EntityReader<int, SalesCurrencyRate>
    {
        public SalesCurrencyRateReader(
            SalesCurrencyRateTableInfo tableInfo
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

		//Child Count 1
		//Parent Count 2
				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesOrderHeader> GetSalesSalesOrderHeaderReader()
		{
			return s_loc8r.GetReader<int , SalesSalesOrderHeader>();
		}

		
		/// <summary>
		/// Sets the children of type SalesSalesOrderHeader on the parent on SalesSalesOrderHeaders.
		/// From foriegn key FK_SalesOrderHeader_CurrencyRate_CurrencyRateID
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesOrderHeaders(IList<SalesCurrencyRate> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesOrderHeader

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesOrderHeader>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesOrderHeaders = typedChildren.Where(b =>  b.CurrencyRateID == r.Id ).ToList();
				r.SalesSalesOrderHeaders.ToList().ForEach(b => { b.Loaded = false; b.SalesCurrencyRate = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Sales.CurrencyRate into class SalesCurrencyRate
		/// </summary>
		/// <param name="results">SalesCurrencyRate</param>
		/// <param name="row"></param>
        public override SalesCurrencyRate LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new SalesCurrencyRate();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "CurrencyRateID"); 
      		domain.CurrencyRateDate = GetRowData<DateTime>(dataRow, "CurrencyRateDate"); 
      		domain.FromCurrencyCode = GetRowData<string>(dataRow, "FromCurrencyCode"); 
      		domain.ToCurrencyCode = GetRowData<string>(dataRow, "ToCurrencyCode"); 
      		domain.AverageRate = GetRowData<decimal>(dataRow, "AverageRate"); 
      		domain.EndOfDayRate = GetRowData<decimal>(dataRow, "EndOfDayRate"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, SalesCurrencyRate></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, SalesCurrencyRate> WithAllChildrenForExisting(SalesCurrencyRate existing)
        {
						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CurrencyRateID",  }
				, SetChildrenSalesSalesOrderHeaders);
			
            return this;
        }


        public override void SetAllChildrenForExisting(SalesCurrencyRate entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesSalesOrderHeaderReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CurrencyRateID",  }
				, SetChildrenSalesSalesOrderHeaders);

			
QueryResultForChildrenOnly(new List<SalesCurrencyRate>() { entity });
			entity.Loaded = false;
			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entity.SalesSalesOrderHeaders);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<SalesCurrencyRate> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesSalesOrderHeaderReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CurrencyRateID",  }
				, SetChildrenSalesSalesOrderHeaders);

					
			QueryResultForChildrenOnly(entities);

			GetSalesSalesOrderHeaderReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesOrderHeaders).ToList());
					
		}
    }
}
		