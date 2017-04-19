
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
    public class ProductionDocumentWriter : EntityWriter<Microsoft.SqlServer.Types.SqlHierarchyId, ProductionDocument>
    {
        public ProductionDocumentWriter
			(ProductionDocumentTableInfo tableInfo
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

		
		static IEntityWriter<int, HumanResourcesEmployee> GetHumanResourcesEmployeeWriter()
		{ return s_loc8r.GetWriter<int, HumanResourcesEmployee>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, ProductionDocument entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((ProductionDocumentFieldNames)f.Key)
                {
                    
					case ProductionDocumentFieldNames.DocumentLevel:
						parms.Add(GetParamName("DocumentLevel", actionType, taskIndex, ref count), entity.DocumentLevel);
						break;
					case ProductionDocumentFieldNames.Title:
						parms.Add(GetParamName("Title", actionType, taskIndex, ref count), entity.Title);
						break;
					case ProductionDocumentFieldNames.Owner:
						parms.Add(GetParamName("Owner", actionType, taskIndex, ref count), entity.Owner);
						break;
					case ProductionDocumentFieldNames.FolderFlag:
						parms.Add(GetParamName("FolderFlag", actionType, taskIndex, ref count), entity.FolderFlag);
						break;
					case ProductionDocumentFieldNames.FileName:
						parms.Add(GetParamName("FileName", actionType, taskIndex, ref count), entity.FileName);
						break;
					case ProductionDocumentFieldNames.FileExtension:
						parms.Add(GetParamName("FileExtension", actionType, taskIndex, ref count), entity.FileExtension);
						break;
					case ProductionDocumentFieldNames.Revision:
						parms.Add(GetParamName("Revision", actionType, taskIndex, ref count), entity.Revision);
						break;
					case ProductionDocumentFieldNames.ChangeNumber:
						parms.Add(GetParamName("ChangeNumber", actionType, taskIndex, ref count), entity.ChangeNumber);
						break;
					case ProductionDocumentFieldNames.Status:
						parms.Add(GetParamName("Status", actionType, taskIndex, ref count), entity.Status);
						break;
					case ProductionDocumentFieldNames.DocumentSummary:
						parms.Add(GetParamName("DocumentSummary", actionType, taskIndex, ref count), entity.DocumentSummary);
						break;
					case ProductionDocumentFieldNames.Document:
						parms.Add(GetParamName("Document", actionType, taskIndex, ref count), entity.Document);
						break;
					case ProductionDocumentFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case ProductionDocumentFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(ProductionDocument entity, ScriptContext context)
        {
            if (entity == null)
                return;

		
		
			//From Foreign Key FK_Document_Employee_Owner
			var humanResourcesEmployee101 = GetHumanResourcesEmployeeWriter();
		if ((_cascades.Contains(ProductionDocumentCascadeNames.humanresourcesemployee_p.ToString()) || _cascades.Contains("all")) && entity.HumanResourcesEmployee != null)
			if (Cascade(humanResourcesEmployee101, entity.HumanResourcesEmployee, context))
				WithParent(humanResourcesEmployee101, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, ProductionDocument entity)
        {
            if (entity == null)
                return;

				
			//From Foreign Key FK_Document_Employee_Owner
			if (entity.HumanResourcesEmployee != null)
				entity.Owner = entity.HumanResourcesEmployee.Id;

		}

		protected override void RemoveRelations(ProductionDocument entity, ScriptContext context)
        {
				}
	}
}
		