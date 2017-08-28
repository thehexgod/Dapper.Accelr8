
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
using Dapper.Accelr8.Repo.Extensions;
using Dapper.Accelr8.Repo.Parameters;
using Dapper.Accelr8.Repo.Contracts;

namespace Dapper.Accelr8.AW2008TableInfos
{
	public enum PersonPasswordFieldNames
	{	
		Id, 	
		PasswordHash, 	
		PasswordSalt, 	
		rowguid, 	
		ModifiedDate, 	
	}

	public enum PersonPasswordCascadeNames
	{	
		
		personperson_p, 	}

	public class PersonPasswordTableInfo : Dapper.Accelr8.Sql.TableInfo
	{	
	
		public static readonly IDictionary<int, string> PersonPasswordColumnNames 
		= new Dictionary<int, string>()
		{
					{ (int)PersonPasswordFieldNames.Id, "BusinessEntityID" }, 
						{ (int)PersonPasswordFieldNames.PasswordHash, "PasswordHash" }, 
						{ (int)PersonPasswordFieldNames.PasswordSalt, "PasswordSalt" }, 
						{ (int)PersonPasswordFieldNames.rowguid, "rowguid" }, 
						{ (int)PersonPasswordFieldNames.ModifiedDate, "ModifiedDate" }, 
				};	

		public static readonly IDictionary<int, string> PersonPasswordIdColumnNames
		= new Dictionary<int, string>()
		{
					{ (int)PersonPasswordFieldNames.Id, "BusinessEntityID" }, 
				};

		public PersonPasswordTableInfo(ILoc8 loc8r) : base(loc8r)
		{
			int c = 0;
			UniqueId = true;
			Schema = "Person";
			TableName = "Person.Password";
			TableAlias = "personpassword";
			Columns = PersonPasswordColumnNames;
			IdColumns = PersonPasswordIdColumnNames;

			Joins = new JoinInfo[] {
						//For Key FK_Password_Person_BusinessEntityID
			new JoinInfo() {
			Reader = new Func<IEntityReader>(() => Loc8r.GetReader<int, PersonPerson>("PersonPerson")),
			TableName = "Person.Person",
			Alias = TableAlias + "_" + "PersonPerson",
			Outer = false,
			Load = (entity, row) =>
				{ 
					var reader = Loc8r.GetReader<int, PersonPerson>("PersonPerson");
					var st = (entity as PersonPassword);

					if (st == null || row == null)
						return st;

					if (row.BusinessEntityID == null || row.BusinessEntityID == default(int))
						return st;

					st.PersonPerson = reader.LoadEntityObject(row);

					return st;
				},
			JoinQuery = new JoinQueryElement[]
			{
				new JoinQueryElement() 
				{ 
					//PersonPersonColumnNames.   .ToString()
					//PersonPasswordColumnNames.      .ToString()
					JoinField = "BusinessEntityID",
					Operator = Operator.Equals,
					ParentField = "BusinessEntityID",
					ParentTableAlias = TableAlias
				}
			} },
						};
		}
	}
}

		