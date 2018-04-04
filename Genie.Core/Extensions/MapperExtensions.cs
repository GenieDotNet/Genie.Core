﻿using System;
using System.Data;
using System.Threading.Tasks;
using System.Linq;
using Genie.Core.Infrastructure.Models;
using Genie.Core.Mapper;
using QB = Genie.Core.Infrastructure.Querying.QueryBuilder;

namespace Genie.Core.Extensions
{
    public static class MapperExtensions
    {
        /// <summary>
        /// Inserts an entity into table "T" and returns identity id.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToInsert">Entity to insert</param>
        /// <returns>Identity of inserted entity</returns>
        public static long? Insert(this IDbConnection connection, BaseModel entityToInsert)
        {
            using (connection)
            {
                connection.Open();
                var cmd = QB.Insert(entityToInsert);
                connection.Execute(cmd, entityToInsert);
                var r = connection.Query(QB.GetId()).ToList();
                long id = 0;
                if (r.Any())
                {
                    try
                    {
                        id = (long)r.First().id;
                    }
                    catch (Exception)
                    { /*Ignored*/ }
                }
                return id;
            }
        }



        /// <summary>
        /// Inserts an entity into table "T" and returns identity id asynchronously.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToInsert">Entity to insert</param>
        /// <returns>Identity of inserted entity</returns>
        public static async Task<long?> InsertAsync(this IDbConnection connection, BaseModel entityToInsert)
        {
            using (connection)
            {
                connection.Open();
                var cmd = QB.Insert(entityToInsert);
                await connection.ExecuteAsync(cmd, entityToInsert);
                var r = (await connection.QueryAsync(QB.GetId())).ToList();
                long id = 0;
                if (r.Any())
                {
                    try
                    {
                        id = (long)r.First().id;
                    }
                    catch (Exception)
                    { /*Ignored*/ }
                }
                return id;
            }
        }

        /// <summary>
        /// Updates entity in table "Ts", checks if the entity is modified if the entity is tracked by the Get() extension.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToUpdate">Entity to be updated</param>
        /// <param name="queryBuilder"></param>
        /// <returns>true if updated, false if not found or not modified (tracked entities)</returns>
        public static bool Update(this IDbConnection connection, BaseModel entityToUpdate, QB queryBuilder)
        {
            var query = queryBuilder.Update(entityToUpdate);
            if (query == null)
            {
                return false;
            }
            using (connection)
            {
                connection.Open();
                var updated = connection.Execute(query, entityToUpdate);
                return updated > 0;
            }
        }

        /// <summary>
        /// Updates entity in table "Ts", checks if the entity is modified if the entity is tracked by the Get() extension asynchronously.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entityToUpdate">Entity to be updated</param>
        /// <param name="queryBuilder"></param>
        /// <returns>true if updated, false if not found or not modified (tracked entities)</returns>
        public static async Task<bool> UpdateAsync(this IDbConnection connection, BaseModel entityToUpdate, QB queryBuilder)
        {
            var query = queryBuilder.Update(entityToUpdate);
            if (query == null)
            {
                return false;
            }
            using (connection)
            {
                connection.Open();
                var updated = await connection.ExecuteAsync(query, entityToUpdate);
                return updated > 0;
            }
        }

        /// <summary>
        /// Delete entity in table "Ts".
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entity"></param>
        /// <param name="queryBuilder"></param>
        /// <returns>true if deleted, false if not found</returns>
        public static bool Delete(this IDbConnection connection, BaseModel entity, QB queryBuilder)
        {
            using (connection)
            {
                connection.Open();
                var deleted = connection.Execute(queryBuilder.Delete(entity), entity) > 0;
                return deleted;
            }
        }


        /// <summary>
        /// Delete entity in table "Ts" asynchronously.
        /// </summary>
        /// <param name="connection">Open SqlConnection</param>
        /// <param name="entity"></param>
        /// <param name="queryBuilder"></param>
        /// <returns>true if deleted, false if not found</returns>
        public static async Task<bool> DeleteAsync(this IDbConnection connection, BaseModel entity, QB queryBuilder)
        {
            using (connection)
            {
                connection.Open();
                var deleted = await connection.ExecuteAsync(queryBuilder.Delete(entity), entity) > 0;
                return deleted;
            }
        }
    }
}