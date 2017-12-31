using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Dapper;
using FantaHackathon.Interface;
using FantaHackathon.Model;


namespace FantaHackathon.Repository
{
    public class AccidentRepository : IAccidentRepository {

        private string connectionString;
        public AccidentRepository()
        {
            connectionString = @"Server=localhost;Database=FcdOne;Trusted_Connection=true;";
        }

        public IDbConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }


        public IEnumerable<Accident> GetAll()
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                dbConnection.Open();
                return dbConnection.Query<Accident>("SELECT * FROM AccidentTable");
            }
        }

        public void Add(Accident item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"INSERT INTO AccidentTable (Lplate,Longitude, 
                                Latitude ,Name ,Age ,Location ,Description) 
                                VALUES(@Lplate, @Longitude, @Latitude, @Name ,@Age ,@Location,
                                @Description)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, item);
            }
        }

        public Accident Search(int item)
        {
            using (IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "Select * from AccidentTable where Todoid = @id ";
                dbConnection.Open();
                List<Accident> todos = dbConnection.Query<Accident>(sQuery, new { id = item }).ToList();
                
                return todos.FirstOrDefault();
            }
        }

        public void Update(Accident item1)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = @"UPDATE AccidentTable SET Verified = @Verified
                                WHERE Id = @Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, item1);
            }
        }

        // public void Done(Accident item1)
        // {
        //     using (System.Data.IDbConnection dbConnection = GetConnection())
        //     {
        //         string sQuery = "UPDATE AccidentTable SET "
        //                         + " Done = @Done "
        //                        + " WHERE Todoid = @Todoid";
        //         dbConnection.Open();
        //         dbConnection.Query(sQuery, item1);
        //     }
        // }

        public Accident Delete(int item)
        {
            using (System.Data.IDbConnection dbConnection = GetConnection())
            {
                string sQuery = "delete from AccidentTable WHERE Id = @id";
                dbConnection.Open();
                List<Accident> accdnt = dbConnection.Query<Accident>(sQuery, new { id = item }).ToList();
                
                return accdnt.FirstOrDefault();
            }
        }
    }




}