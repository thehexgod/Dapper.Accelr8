
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
    public class PersonCountryRegionReader : EntityReader<string, PersonCountryRegion>
    {
        public PersonCountryRegionReader(
            PersonCountryRegionTableInfo tableInfo
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

		//Child Count 3
		//Parent Count 0
				//Is CompoundKey True
		protected static IEntityReader<CompoundKey , SalesCountryRegionCurrency> GetSalesCountryRegionCurrencyReader()
		{
			return s_loc8r.GetReader<CompoundKey , SalesCountryRegionCurrency>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , SalesSalesTerritory> GetSalesSalesTerritoryReader()
		{
			return s_loc8r.GetReader<int , SalesSalesTerritory>();
		}

				//Is CompoundKey False
		protected static IEntityReader<int , PersonStateProvince> GetPersonStateProvinceReader()
		{
			return s_loc8r.GetReader<int , PersonStateProvince>();
		}

		
		/// <summary>
		/// Sets the children of type SalesCountryRegionCurrency on the parent on SalesCountryRegionCurrencies.
		/// From foriegn key FK_CountryRegionCurrency_CountryRegion_CountryRegionCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesCountryRegionCurrencies(IList<PersonCountryRegion> results, IList<object> children)
		{
			//Child Id Type: CompoundKey
			//Child Type: SalesCountryRegionCurrency

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesCountryRegionCurrency>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesCountryRegionCurrencies = typedChildren.Where(b =>  b.CountryRegionCode == r.Id ).ToList();
				r.SalesCountryRegionCurrencies.ToList().ForEach(b => { b.Loaded = false; b.PersonCountryRegion = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type SalesSalesTerritory on the parent on SalesSalesTerritories.
		/// From foriegn key FK_SalesTerritory_CountryRegion_CountryRegionCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenSalesSalesTerritories(IList<PersonCountryRegion> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: SalesSalesTerritory

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<SalesSalesTerritory>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.SalesSalesTerritories = typedChildren.Where(b =>  b.CountryRegionCode == r.Id ).ToList();
				r.SalesSalesTerritories.ToList().ForEach(b => { b.Loaded = false; b.PersonCountryRegion = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

		/// <summary>
		/// Sets the children of type PersonStateProvince on the parent on PersonStateProvinces.
		/// From foriegn key FK_StateProvince_CountryRegion_CountryRegionCode
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		public void SetChildrenPersonStateProvinces(IList<PersonCountryRegion> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: PersonStateProvince

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<PersonStateProvince>();

			foreach (var r in results)
			{
				if (r == null)
					continue;
				r.Loaded = false;
				

				r.PersonStateProvinces = typedChildren.Where(b =>  b.CountryRegionCode == r.Id ).ToList();
				r.PersonStateProvinces.ToList().ForEach(b => { b.Loaded = false; b.PersonCountryRegion = r; b.Loaded = true; });
				
				r.Loaded = true;
			}
		}

			/// <summary>
		/// Loads the table Person.CountryRegion into class PersonCountryRegion
		/// </summary>
		/// <param name="results">PersonCountryRegion</param>
		/// <param name="row"></param>
        public override PersonCountryRegion LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new PersonCountryRegion();
			domain.Loaded = false;

			domain.Id = GetRowData<string>(dataRow, "CountryRegionCode"); 
      		domain.Name = GetRowData<object>(dataRow, "Name"); 
      		domain.ModifiedDate = GetRowData<DateTime>(dataRow, "ModifiedDate"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified string Id.
		/// </summary>
		/// <param name="results">IEntityReader<string, PersonCountryRegion></param>
		/// <param name="id">string</param>
        public override IEntityReader<string, PersonCountryRegion> WithAllChildrenForExisting(PersonCountryRegion existing)
        {
						WithChildForParentValues(GetSalesCountryRegionCurrencyReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenSalesCountryRegionCurrencies);
						WithChildForParentValues(GetSalesSalesTerritoryReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenSalesSalesTerritories);
						WithChildForParentValues(GetPersonStateProvinceReader()
				, new object[] {  existing.Id,  } 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenPersonStateProvinces);
			
            return this;
        }


        public override void SetAllChildrenForExisting(PersonCountryRegion entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

						WithChildForParentValues(GetSalesCountryRegionCurrencyReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenSalesCountryRegionCurrencies);

						WithChildForParentValues(GetSalesSalesTerritoryReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenSalesSalesTerritories);

						WithChildForParentValues(GetPersonStateProvinceReader()
				, new object[] {  entity.Id,  } 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenPersonStateProvinces);

			
QueryResultForChildrenOnly(new List<PersonCountryRegion>() { entity });
			entity.Loaded = false;
			GetSalesCountryRegionCurrencyReader().SetAllChildrenForExisting(entity.SalesCountryRegionCurrencies);
			GetSalesSalesTerritoryReader().SetAllChildrenForExisting(entity.SalesSalesTerritories);
			GetPersonStateProvinceReader().SetAllChildrenForExisting(entity.PersonStateProvinces);
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<PersonCountryRegion> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			entities = entities.Where(e => e != null).ToList();

            if (entities.Count < 1)
                return;

			WithChildForParentsValues(GetSalesCountryRegionCurrencyReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenSalesCountryRegionCurrencies);

			WithChildForParentsValues(GetSalesSalesTerritoryReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenSalesSalesTerritories);

			WithChildForParentsValues(GetPersonStateProvinceReader()
				, entities.Select(s => new object[] {  s.Id,  }).ToList() 
				, new string[] {  "CountryRegionCode",  }
				, SetChildrenPersonStateProvinces);

					
			QueryResultForChildrenOnly(entities);

			GetSalesCountryRegionCurrencyReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesCountryRegionCurrencies).ToList());
			GetSalesSalesTerritoryReader().SetAllChildrenForExisting(entities.SelectMany(e => e.SalesSalesTerritories).ToList());
			GetPersonStateProvinceReader().SetAllChildrenForExisting(entities.SelectMany(e => e.PersonStateProvinces).ToList());
					
		}
    }
}
		