using Dapper;
using MovieShop.Entity;
using MovieShop.Repository;
using MovieShop.Service;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;


namespace MovieShop.UI
{
    class ManageFilmCast
    {
        private readonly FilmCastService filmCastService;

        public ManageFilmCast()
        {
            filmCastService = new FilmCastService();
        }

        async Task PrintAllAsync()
        {
            var casts = await filmCastService.GetAllAsync();
            if (casts == null)
            {
                Console.WriteLine("something wrong happened");
            }
            else
            {
                foreach (var item in casts)
                {
                    Console.WriteLine(item.Id + " \t " + item.Name + "\t" + item.@TmdbUrl + "\t" + item.Gender + "\t" + item.ProfilePath);
                }
            }
        }

        async Task PrintOneAsync()
        {
            var casts = await filmCastService.GetByIdAsync(1);
            if (casts == null)
            {
                Console.WriteLine("something wrong happened");
            }
            else
            {
                foreach (var item in casts)
                {
                    Console.WriteLine(item.Id + " \t " + item.Name + "\t" + item.@TmdbUrl + "\t" + item.Gender + "\t" + item.ProfilePath);
                }
            }
        }


        async Task DeleteOneAsync()
        {
            var result = await filmCastService.DeleteAsync(35214);
            if (result == null)
            {
                Console.WriteLine("something wrong happened");
            }
            else
            {
                Console.WriteLine(result);
            }
        }

        public void Run()
        {
            //PrintAllAsync();
            //PrintOneAsync();
            //DeleteOneAsync();


            #region simple method without procedure to test the GetAllCasts method         -- working ok
            //SqlConnection connection = new SqlConnection(DbHelper.connectionString);
            //connection.Open();

            //try
            //{
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandType = CommandType.Text;
            //    cmd.CommandText = "Select * from Cast";
            //    cmd.Connection = connection;
            //    var result= cmd.ExecuteReader();
            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("something wrong");
            //}
            //finally
            //{
            //    connection.Close();
            //    connection.Dispose();
            //}
            #endregion



            #region simple method with procedure to test the GetAllCasts method            -- working ok
            //SqlConnection connection = new SqlConnection(DbHelper.connectionString);
            //connection.Open();

            //try
            //{
            //    SqlCommand cmd = new SqlCommand
            //    {
            //        CommandType = CommandType.StoredProcedure,
            //        CommandText = "spGetAllCasts",
            //        Connection = connection
            //    };
            //    var result = cmd.ExecuteReader();


            //    //IEnumerable<FilmCast> typeData = result.Cast<IDataRecord>()
            //    //                                        .Select(data => new TypeData { Type = (string)dr["type"] });

            //    foreach (var item in result)
            //    {
            //        Console.WriteLine(item);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("something wrong");
            //}
            //finally
            //{
            //    connection.Close();
            //    connection.Dispose();
            //}
            #endregion




        }


        #region simple method without procedure to test the GetAllCasts method with dapper
        public async Task<IEnumerable<FilmCast>> GetAllAsyncWithDapperSimpleQuery()
        {
            using SqlConnection conn = new SqlConnection(DbHelper.connectionString);
            const string query = @"select * from Cast";
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            try
            {
                var result = await conn.QueryAsync<FilmCast>(query,CommandType.Text);
                Console.WriteLine(result);
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
        #endregion
    }
}
