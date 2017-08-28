
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
    public class PersonPersonWriter : EntityWriter<int, PersonPerson>
    {
        public PersonPersonWriter
			(PersonPersonTableInfo tableInfo
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

		static IEntityWriter<int, PersonBusinessEntityContact> GetPersonBusinessEntityContactWriter()
		{ return s_loc8r.GetWriter<int, PersonBusinessEntityContact>(); }
		static IEntityWriter<int, SalesCustomer> GetSalesCustomerWriter()
		{ return s_loc8r.GetWriter<int, SalesCustomer>(); }
		static IEntityWriter<int, PersonEmailAddress> GetPersonEmailAddressWriter()
		{ return s_loc8r.GetWriter<int, PersonEmailAddress>(); }
		static IEntityWriter<int, HumanResourcesEmployee> GetHumanResourcesEmployeeWriter()
		{ return s_loc8r.GetWriter<int, HumanResourcesEmployee>(); }
		static IEntityWriter<int, PersonPassword> GetPersonPasswordWriter()
		{ return s_loc8r.GetWriter<int, PersonPassword>(); }
		static IEntityWriter<int, SalesPersonCreditCard> GetSalesPersonCreditCardWriter()
		{ return s_loc8r.GetWriter<int, SalesPersonCreditCard>(); }
		static IEntityWriter<int, PersonPersonPhone> GetPersonPersonPhoneWriter()
		{ return s_loc8r.GetWriter<int, PersonPersonPhone>(); }
		
		static IEntityWriter<int, PersonBusinessEntity> GetPersonBusinessEntityWriter()
		{ return s_loc8r.GetWriter<int, PersonBusinessEntity>(); }
		
		/// <summary>
		/// Gets the Sql Parameters from the Entity and names them according to column, action, and batch task, and array count.
		/// </summary>
		/// <param name="results">Parameters for sql writes</param>
		/// <param name="row"></param>
        protected override IDictionary<string, object> GetParams(ActionType actionType, PersonPerson entity, int taskIndex, ref int count)
        {
            var parms = new Dictionary<string, object>();
			
			foreach (var f in ColumnNames)
            {
                switch ((PersonPersonFieldNames)f.Key)
                {
                    
					case PersonPersonFieldNames.PersonType:
						parms.Add(GetParamName("PersonType", actionType, taskIndex, ref count), entity.PersonType);
						break;
					case PersonPersonFieldNames.NameStyle:
						parms.Add(GetParamName("NameStyle", actionType, taskIndex, ref count), entity.NameStyle);
						break;
					case PersonPersonFieldNames.Title:
						parms.Add(GetParamName("Title", actionType, taskIndex, ref count), entity.Title);
						break;
					case PersonPersonFieldNames.FirstName:
						parms.Add(GetParamName("FirstName", actionType, taskIndex, ref count), entity.FirstName);
						break;
					case PersonPersonFieldNames.MiddleName:
						parms.Add(GetParamName("MiddleName", actionType, taskIndex, ref count), entity.MiddleName);
						break;
					case PersonPersonFieldNames.LastName:
						parms.Add(GetParamName("LastName", actionType, taskIndex, ref count), entity.LastName);
						break;
					case PersonPersonFieldNames.Suffix:
						parms.Add(GetParamName("Suffix", actionType, taskIndex, ref count), entity.Suffix);
						break;
					case PersonPersonFieldNames.EmailPromotion:
						parms.Add(GetParamName("EmailPromotion", actionType, taskIndex, ref count), entity.EmailPromotion);
						break;
					case PersonPersonFieldNames.AdditionalContactInfo:
						parms.Add(GetParamName("AdditionalContactInfo", actionType, taskIndex, ref count), entity.AdditionalContactInfo);
						break;
					case PersonPersonFieldNames.Demographics:
						parms.Add(GetParamName("Demographics", actionType, taskIndex, ref count), entity.Demographics);
						break;
					case PersonPersonFieldNames.rowguid:
						parms.Add(GetParamName("rowguid", actionType, taskIndex, ref count), entity.rowguid);
						break;
					case PersonPersonFieldNames.ModifiedDate:
						parms.Add(GetParamName("ModifiedDate", actionType, taskIndex, ref count), entity.ModifiedDate);
						break;
				}
			}

			return parms;
        }


		protected override void CascadeRelations(PersonPerson entity, ScriptContext context)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityContact_Person_PersonID
			var personBusinessEntityContact146 = GetPersonBusinessEntityContactWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personbusinessentitycontacts.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityContacts)
					Cascade(personBusinessEntityContact146, item, context);

			if (personBusinessEntityContact146.Count > 0)
				WithChild(personBusinessEntityContact146, entity);

			//From Foreign Key FK_Customer_Person_PersonID
			var salesCustomer147 = GetSalesCustomerWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.salescustomers.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCustomers)
					Cascade(salesCustomer147, item, context);

			if (salesCustomer147.Count > 0)
				WithChild(salesCustomer147, entity);

			//From Foreign Key FK_EmailAddress_Person_BusinessEntityID
			var personEmailAddress148 = GetPersonEmailAddressWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personemailaddresses.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonEmailAddresses)
					Cascade(personEmailAddress148, item, context);

			if (personEmailAddress148.Count > 0)
				WithChild(personEmailAddress148, entity);

			//From Foreign Key FK_Employee_Person_BusinessEntityID
			var humanResourcesEmployee149 = GetHumanResourcesEmployeeWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.humanresourcesemployees.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployees)
					Cascade(humanResourcesEmployee149, item, context);

			if (humanResourcesEmployee149.Count > 0)
				WithChild(humanResourcesEmployee149, entity);

			//From Foreign Key FK_Password_Person_BusinessEntityID
			var personPassword150 = GetPersonPasswordWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personpasswords.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPasswords)
					Cascade(personPassword150, item, context);

			if (personPassword150.Count > 0)
				WithChild(personPassword150, entity);

			//From Foreign Key FK_PersonCreditCard_Person_BusinessEntityID
			var salesPersonCreditCard151 = GetSalesPersonCreditCardWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.salespersoncreditcards.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesPersonCreditCards)
					Cascade(salesPersonCreditCard151, item, context);

			if (salesPersonCreditCard151.Count > 0)
				WithChild(salesPersonCreditCard151, entity);

			//From Foreign Key FK_PersonPhone_Person_BusinessEntityID
			var personPersonPhone152 = GetPersonPersonPhoneWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personpersonphones.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPersonPhones)
					Cascade(personPersonPhone152, item, context);

			if (personPersonPhone152.Count > 0)
				WithChild(personPersonPhone152, entity);

		
		
			//From Foreign Key FK_Person_BusinessEntity_BusinessEntityID
			var personBusinessEntity153 = GetPersonBusinessEntityWriter();
		if ((_cascades.Contains(PersonPersonCascadeNames.personbusinessentity_p.ToString()) || _cascades.Contains("all")) && entity.PersonBusinessEntity != null)
			if (Cascade(personBusinessEntity153, entity.PersonBusinessEntity, context))
				WithParent(personBusinessEntity153, entity);

				}

		protected override void UpdateIdsFromReferences(IList<string> cascades, PersonPerson entity)
        {
            if (entity == null)
                return;

			//From Foreign Key FK_BusinessEntityContact_Person_PersonID
			if (entity.PersonBusinessEntityContacts != null && entity.PersonBusinessEntityContacts.Count > 0)
				foreach (var rel in entity.PersonBusinessEntityContacts)
					rel.PersonID = entity.Id;

			//From Foreign Key FK_Customer_Person_PersonID
			if (entity.SalesCustomers != null && entity.SalesCustomers.Count > 0)
				foreach (var rel in entity.SalesCustomers)
					rel.PersonID = entity.Id;

			//From Foreign Key FK_EmailAddress_Person_BusinessEntityID
			if (entity.PersonEmailAddresses != null && entity.PersonEmailAddresses.Count > 0)
				foreach (var rel in entity.PersonEmailAddresses)
					rel.BusinessEntityID = entity.Id;

			//From Foreign Key FK_Employee_Person_BusinessEntityID
			if (entity.HumanResourcesEmployees != null && entity.HumanResourcesEmployees.Count > 0)
				foreach (var rel in entity.HumanResourcesEmployees)
					rel.BusinessEntityID = entity.Id;

			//From Foreign Key FK_Password_Person_BusinessEntityID
			if (entity.PersonPasswords != null && entity.PersonPasswords.Count > 0)
				foreach (var rel in entity.PersonPasswords)
					rel.BusinessEntityID = entity.Id;

			//From Foreign Key FK_PersonCreditCard_Person_BusinessEntityID
			if (entity.SalesPersonCreditCards != null && entity.SalesPersonCreditCards.Count > 0)
				foreach (var rel in entity.SalesPersonCreditCards)
					rel.BusinessEntityID = entity.Id;

			//From Foreign Key FK_PersonPhone_Person_BusinessEntityID
			if (entity.PersonPersonPhones != null && entity.PersonPersonPhones.Count > 0)
				foreach (var rel in entity.PersonPersonPhones)
					rel.BusinessEntityID = entity.Id;

				
			//From Foreign Key FK_Person_BusinessEntity_BusinessEntityID
			if (entity.PersonBusinessEntity != null)
				entity.BusinessEntityID = entity.PersonBusinessEntity.Id;

		}

		protected override void RemoveRelations(PersonPerson entity, ScriptContext context)
        {
					//From Foreign Key FK_BusinessEntityContact_Person_PersonID
			var personBusinessEntityContact162 = GetPersonBusinessEntityContactWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personbusinessentitycontact.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonBusinessEntityContacts)
					CascadeDelete(personBusinessEntityContact162, item, context);

			if (personBusinessEntityContact162.Count > 0)
				WithChild(personBusinessEntityContact162, entity);

					//From Foreign Key FK_Customer_Person_PersonID
			var salesCustomer163 = GetSalesCustomerWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.salescustomer.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesCustomers)
					CascadeDelete(salesCustomer163, item, context);

			if (salesCustomer163.Count > 0)
				WithChild(salesCustomer163, entity);

					//From Foreign Key FK_EmailAddress_Person_BusinessEntityID
			var personEmailAddress164 = GetPersonEmailAddressWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personemailaddress.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonEmailAddresses)
					CascadeDelete(personEmailAddress164, item, context);

			if (personEmailAddress164.Count > 0)
				WithChild(personEmailAddress164, entity);

					//From Foreign Key FK_Employee_Person_BusinessEntityID
			var humanResourcesEmployee165 = GetHumanResourcesEmployeeWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.humanresourcesemployee.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.HumanResourcesEmployees)
					CascadeDelete(humanResourcesEmployee165, item, context);

			if (humanResourcesEmployee165.Count > 0)
				WithChild(humanResourcesEmployee165, entity);

					//From Foreign Key FK_Password_Person_BusinessEntityID
			var personPassword166 = GetPersonPasswordWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personpassword.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPasswords)
					CascadeDelete(personPassword166, item, context);

			if (personPassword166.Count > 0)
				WithChild(personPassword166, entity);

					//From Foreign Key FK_PersonCreditCard_Person_BusinessEntityID
			var salesPersonCreditCard167 = GetSalesPersonCreditCardWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.salespersoncreditcard.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.SalesPersonCreditCards)
					CascadeDelete(salesPersonCreditCard167, item, context);

			if (salesPersonCreditCard167.Count > 0)
				WithChild(salesPersonCreditCard167, entity);

					//From Foreign Key FK_PersonPhone_Person_BusinessEntityID
			var personPersonPhone168 = GetPersonPersonPhoneWriter();
			if (_cascades.Contains(PersonPersonCascadeNames.personpersonphone.ToString()) || _cascades.Contains("all"))
				foreach (var item in entity.PersonPersonPhones)
					CascadeDelete(personPersonPhone168, item, context);

			if (personPersonPhone168.Count > 0)
				WithChild(personPersonPhone168, entity);

				}
	}
}
		