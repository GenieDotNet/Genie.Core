// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Genie (http://www.github.com/rusith/genie).
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------


using System.Collections.Generic;
using System.Data;

namespace TestDAL.Infrastructure.Filters.Abstract
{
    public interface IRepoQuery
    {
        string Target { get; set; }
        Queue<string> Where { get; set; }
        Queue<string> Order { get; set; }
        int? PageSize { get; set; }
        int? Page { get; set; }
        int? Limit { get; set; }
        int? Skip { get; set; }
        int? Take { get; set; }
        IDbTransaction Transaction { get; set; }
        IEnumerable<string> Columns { get; set; }
    }
}


