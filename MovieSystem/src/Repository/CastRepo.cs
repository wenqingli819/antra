using Dapper;
using MovieShop.Entity;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MovieShop.Repository
{
    public class CastRepo : IGenericRepo<Cast>
    {
        public async Task<bool> DeleteAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            using (SqlConnection conn = new SqlConnection(DbHelper.connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync("spDeleteCast", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
            
        }


        public async Task<IEnumerable<Cast>> GetAllAsync()
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    var result =  await conn.QueryAsync<Cast>("spGetAllCasts", commandType: CommandType.StoredProcedure);
                    return result;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
        }


        public async Task<IEnumerable<Cast>> GetByIdAsync(int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            Cast cast = new Cast();
            using (SqlConnection conn = new SqlConnection(DbHelper.connectionString))
            {
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    cast = await conn.QueryFirstOrDefaultAsync<Cast>("spGetCastByID", parameters, commandType: CommandType.StoredProcedure);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return (IEnumerable<Cast>)cast;
        }

        public async Task<bool> InsertAsync(Cast item)
        {
            using (SqlConnection conn = new SqlConnection(DbHelper.connectionString))
            {
                var query = "insert into dbo.Cast(Name,Gender,TmdbUrl,ProfilePath) Values (@Name,@Gender,@TmdbUrl,@ProfilePath)";
                if (conn.State == ConnectionState.Closed)
                    conn.Open();
                try
                {
                    await conn.ExecuteAsync(query, new { item.Name, item.Gender,item.TmdbUrl,item.ProfilePath}, commandType: CommandType.Text);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (conn.State == ConnectionState.Open)
                        conn.Close();
                }
            }
            return true;
        }
        

        public async Task<bool> UpdateAsync(Cast item, int id)
        {
            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            parameters.Add("Name", item.Name, DbType.String);
            parameters.Add("TmdbUrl", item.TmdbUrl, DbType.String);
            parameters.Add("Gender", item.Gender, DbType.String);
            parameters.Add("ProfilePath", item.ProfilePath, DbType.String);

            using (SqlConnection conn = new SqlConnection(DbHelper.connectionString))
            {
                var result = new Cast();
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                try
                {
                    await conn.ExecuteAsync("spUpdateCast", parameters, commandType: CommandType.StoredProcedure);
                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if(conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }
                return true;
            }
        }
    }
}
