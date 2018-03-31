// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Genie (http://www.github.com/rusith/genie).
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------


using System;
using System.Data;
using System.Threading.Tasks;
using TestDAL.Infrastructure.Models.Concrete;
using System.Collections.Generic;
using TestDAL.Infrastructure.Repositories.Abstract;

namespace TestDAL.Infrastructure.Interfaces
{
    /// <summary>
    /// A unit of work is a collection of operations on a data source. operations could be updates, deletes, inserts
    /// </summary>
	public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// Starts a transaction on this unit of work
        /// </summary>
        /// <returns>A new transaction</returns>
        IDbTransaction BeginTransaction();

	    void AddOp(IOperation operation);
        void AddObj(BaseModel obj);


        /// <summary>
        /// The Company repository that belongs to this unit of work.
        /// </summary>
        ICompanyRepository CompanyRepository { get; }


        /// <summary>
        /// The CompanyRole repository that belongs to this unit of work.
        /// </summary>
        ICompanyRoleRepository CompanyRoleRepository { get; }


        /// <summary>
        /// The CompanyType repository that belongs to this unit of work.
        /// </summary>
        ICompanyTypeRepository CompanyTypeRepository { get; }


        /// <summary>
        /// The EmailActivationRecord repository that belongs to this unit of work.
        /// </summary>
        IEmailActivationRecordRepository EmailActivationRecordRepository { get; }


        /// <summary>
        /// The User repository that belongs to this unit of work.
        /// </summary>
        IUserRepository UserRepository { get; }


        /// <summary>
        /// The UserAuthToken repository that belongs to this unit of work.
        /// </summary>
        IUserAuthTokenRepository UserAuthTokenRepository { get; }


        /// <summary>
        /// The UserCompany repository that belongs to this unit of work.
        /// </summary>
        IUserCompanyRepository UserCompanyRepository { get; }





        /// <summary>
        /// The procedure container that belongs to this unit of work
        /// </summary>
		IProcedureContainer Procedures { get; }
        
        /// <summary>
        /// This will commit all changes to the data source performed in this unit of work one by one. including all tracked changes of the objects retrieved from this unit of work
        /// </summary>
        void Commit();

        /// <summary>
        /// This will commit all changes to the data source asynchronously performed in this unit of work one by one. including all tracked changes of the objects retrieved from this unit of work
        /// </summary>
        Task CommitAsync();
    }
}

