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
#if !NETSTANDARD1_3
namespace TestDAL.Dapper
{
    internal sealed class DataTableHandler : SqlMapper.ITypeHandler
    {
        public object Parse(Type destinationType, object value)
        {
            throw new NotImplementedException();
        }

        public void SetValue(IDbDataParameter parameter, object value)
        {
            TableValuedParameter.Set(parameter, value as DataTable, null);
        }
    }
}
#endif
