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

namespace TestDAL.Dapper
{
    /// <summary>
    /// Handles variances in features per DBMS
    /// </summary>
    internal class FeatureSupport
    {
        private static readonly FeatureSupport
            Default = new FeatureSupport(false),
            Postgres = new FeatureSupport(true);

        /// <summary>
        /// Gets the feature set based on the passed connection
        /// </summary>
        /// <param name="connection">The connection to get supported features for.</param>
        public static FeatureSupport Get(IDbConnection connection)
        {
            string name = connection?.GetType().Name;
            if (string.Equals(name, "npgsqlconnection", StringComparison.OrdinalIgnoreCase)) return Postgres;
            return Default;
        }

        private FeatureSupport(bool arrays)
        {
            Arrays = arrays;
        }

        /// <summary>
        /// True if the db supports array columns e.g. Postgresql
        /// </summary>
        public bool Arrays { get; }
    }
}

