// ------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Genie (http://www.github.com/rusith/genie).
//  
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
// ------------------------------------------------------------------------------


using System.Collections.Generic;
using TestDAL.Infrastructure.Filters.Abstract;

namespace TestDAL.Infrastructure.Filters.Concrete
{
    public abstract class BaseOrderContext : IOrderContext
    {
        protected BaseOrderContext() { Expressions = new Queue<string>(); }
        protected Queue<string> Expressions { get; set; }
        public void And() { Expressions.Enqueue(","); }
        public void Add(string expression) { Expressions.Enqueue(expression); }
        public Queue<string> GetOrderExpressions() { return Expressions; }
    }
}
