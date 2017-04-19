
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
    public class DatabaseLogReader : EntityReader<int, DatabaseLog>
    {
        public DatabaseLogReader(
            DatabaseLogTableInfo tableInfo
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

		//Child Count 0
		//Parent Count 0
		
			/// <summary>
		/// Loads the table DatabaseLog into class DatabaseLog
		/// </summary>
		/// <param name="results">DatabaseLog</param>
		/// <param name="row"></param>
        public override DatabaseLog LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new DatabaseLog();
			domain.Loaded = false;

			domain.Id = GetRowData<int>(dataRow, "DatabaseLogID"); 
      		domain.PostTime = GetRowData<DateTime>(dataRow, "PostTime"); 
      		domain.DatabaseUser = GetRowData<object>(dataRow, "DatabaseUser"); 
      		domain.Event = GetRowData<object>(dataRow, "Event"); 
      		domain.Schema = GetRowData<object>(dataRow, "Schema"); 
      		domain.Object = GetRowData<object>(dataRow, "Object"); 
      		domain.TSQL = GetRowData<string>(dataRow, "TSQL"); 
      		domain.XmlEvent = GetRowData<string>(dataRow, "XmlEvent"); 
      			
			domain.IsDirty = false;
			domain.Loaded = true;
			return domain;
		}

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, DatabaseLog></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, DatabaseLog> WithAllChildrenForExisting(DatabaseLog existing)
        {
			
            return this;
        }


        public override void SetAllChildrenForExisting(DatabaseLog entity)
        {
				
			entity.Loaded = true;
		}

		public override void SetAllChildrenForExisting(IList<DatabaseLog> entities)
        {
					
		}
    }
}
		