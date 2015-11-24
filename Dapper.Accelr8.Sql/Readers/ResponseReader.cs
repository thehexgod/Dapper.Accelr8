

using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.Accelr8.Domain;
using Dapper.Accelr8.TableInfos;
using Dapper;
using Dapper.Accelr8.Sql;
using Dapper.Accelr8.Repo;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts.Readers;

namespace Dapper.Accelr8.Readers
{
    public class ResponseReader : EntityReader<int, Response>
    {
        public ResponseReader(
            TableInfo tableInfo
            , string connectionStringName
            , DapperExecuter executer
            , QueryBuilder queryBuilder
            , JoinBuilder joinBuilder
            , IServiceLocatorMarker serviceLocator) 
            : base(tableInfo, connectionStringName, executer, queryBuilder, joinBuilder, serviceLocator)
        { }

		//Child Count 1
		//Parent Count 1
		static IEntityReader<int , RoutedResponse> _routedResponseReader;
		static IEntityReader<int , RoutedResponse> GetRoutedResponseReader()
		{
			if (_routedResponseReader == null)
				_routedResponseReader = _locator.Resolve<IEntityReader<int , RoutedResponse>>();

			return _routedResponseReader;
		}

		
		/// <summary>
		/// Sets the children of type RoutedResponse on the parent on RoutedResponses.
		/// From foriegn key FK_RoutedResponses_Responses
		/// </summary>
		/// <param name="results"></param>
		/// <param name="children"></param>
		protected void SetChildrenRoutedResponses(IList<Response> results, IList<object> children)
		{
			//Child Id Type: int
			//Child Type: RoutedResponse

			if (results == null || results.Count < 1 || children == null || children.Count < 1)
				return;

			var typedChildren = children.OfType<RoutedResponse>();

			foreach (var r in results)
			{
				r.RoutedResponses = typedChildren.Where(b => b.ResponseId == r.Id).ToList();
				r.RoutedResponses.ToList().ForEach(b => b.Response = r);
			}
		}

			/// <summary>
		/// Loads the table Responses into class Response
		/// </summary>
		/// <param name="results">Response</param>
		/// <param name="row"></param>
        public override Response LoadEntity(dynamic row)
        {
            var dataRow = (IDictionary<string, object>)row;
            var domain = new Response();

			domain.Id = GetRowData<int>(dataRow, IdColumn);
			
			domain.SubmissionId = GetRowData<int>(dataRow, ResponseColumnNames.SubmissionId.ToString()); 	
			domain.DateReceived = GetRowData<DateTime>(dataRow, ResponseColumnNames.DateReceived.ToString()); 	
			domain.FilePath = GetRowData<string>(dataRow, ResponseColumnNames.FilePath.ToString()); 	
			domain.ResponseType = GetRowData<string>(dataRow, ResponseColumnNames.ResponseType.ToString()); 	
			domain.Tcr = GetRowData<string>(dataRow, ResponseColumnNames.TCR.ToString()); 	
			domain.Tcn = GetRowData<string>(dataRow, ResponseColumnNames.TCN.ToString()); 	
			domain.AgencyId = GetRowData<int?>(dataRow, ResponseColumnNames.AgencyId.ToString());             
			
			return domain;
        }

		/// <summary>
		/// Add All the children to the query for the specified int Id.
		/// </summary>
		/// <param name="results">IEntityReader<int, Response></param>
		/// <param name="id">int</param>
        public override IEntityReader<int, Response> WithAllChildrenForId(int id)
        {
			base.WithAllChildrenForId(id);

			
			WithChildForParentId(GetRoutedResponseReader(), id, IdColumn, SetChildrenRoutedResponses);
			
            return this;
        }

        public override void SetAllChildrenForExisting(Response entity)
        {
			ClearAllQueries();

            if (entity == null)
                return;

			WithChildForParentId(GetRoutedResponseReader(), entity.Id
				, RoutedResponseColumnNames.ResponseId.ToString()
				, SetChildrenRoutedResponses);

			QueryResultForChildrenOnly(new List<Response>() { entity });

			GetRoutedResponseReader().SetAllChildrenForExisting(entity.RoutedResponses);
				
		}

		public override void SetAllChildrenForExisting(IList<Response> entities)
        {
			ClearAllQueries();

            if (entities == null || entities.Count < 1)
                return;

			WithChildForParentIds(GetRoutedResponseReader()
				, entities.Where(e => e != null)
				.Select(s => s.Id)
				.ToArray(), RoutedResponseColumnNames.ResponseId.ToString()
				, SetChildrenRoutedResponses);

					
			QueryResultForChildrenOnly(entities);

			GetRoutedResponseReader().SetAllChildrenForExisting(entities.SelectMany(e => e.RoutedResponses).ToList());
					
		}
    }
}
		