using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Dapper;
using FantaHackathon.Interface;
using FantaHackathon.Model;
using Newtonsoft.Json;
using static FantaHackathon.ResultFromGoogle.GoogleResult;

namespace FantaHackathon.Repository
{
    public class AccidentRepository : IAccidentRepository
    {

        private string connectionString;

        private string _googleBaseUrl;


        public AccidentRepository()
        {

            connectionString = @"Server=localhost;Database=FcdOne;Trusted_Connection=true;";
            _googleBaseUrl = "https://maps.googleapis.com/maps/api/geocode/json?latlng=";
        }

        public async Task<String> GetPlaceName(double lat, double lon)
        {
            var client = new HttpClient();

            var response = await client.GetAsync(_googleBaseUrl + lat + "," + lon + "&key=AIzaSyBVKoHudUgMEwgt3mfNLgYUtEqSesNw8EU");

            //some logic
            var content = await response.Content.ReadAsStringAsync();
            var responseObject = JsonConvert.DeserializeObject<RootObject>(content);

            
            var firstResult = responseObject.results.FirstOrDefault();

            if(firstResult != null) {
                AddressComponent addressComponent = firstResult.address_components[2];
                string longName = addressComponent.long_name;
                return longName;                
            }
            else return null;

            // foreach (var singleResult in responseObject.results)
            // {
            //     var location = singleResult.geometry.location;
            //     var latitude = location.lat;
            //     var longitude = location.lng;
            //     // Do whatever you want with them.
            //     Console.WriteLine(singleResult);
            // }

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

        public async Task Add(Accident item)
        {
            item.Location= await this.GetPlaceName(11.25,75.78);
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