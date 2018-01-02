using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using FantaHackathon.Model;
using FantaHackathon.Interface;

namespace FantaHackathon.Repository{
    
    public class PedestrianRepository : IPedestrianRepository
    {

        private AccidentRepository _accidentRepository;
        private string connectionString;
        public PedestrianRepository()
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
                return dbConnection.Query<Accident>("SELECT * FROM AccidentTable where Lplate ='0'");
            }
        }

        public async Task Add(Accident item)
        {
            
            item.Location= await _accidentRepository.GetPlaceName(11.25,75.78);
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

    }

}