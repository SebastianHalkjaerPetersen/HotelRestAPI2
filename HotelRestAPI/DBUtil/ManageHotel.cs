using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelRestAPI.DBUtil
{
    public class ManageHotel
    {

        //private const string ConectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string ConectionString =
            @"Data Source=sebastianserver.database.windows.net;Initial Catalog=SebatiansDatabase;User ID=SebastianAmin;Password=Secret1234;Connect Timeout=30;Encrypt=True;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL = "Select * from Hotel";
        private const string GET_ONE = "Select * from Hotel where Hotel_No = @Id";
        private const string INSERT = "Insert into Hotel values(@Id, @Name, @Address)";
        private const string UPDATE = "update Hotel set Hotel_No = @HotelID, Name = @Name, Address = @Address where Hotel_No = @Id";
        private const string DELETE = "Delete from Hotel where Hotel_No = @Id";


        public IEnumerable<Hotel> Get()
        {
            List<Hotel> hotelliste = new List<Hotel>();
            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader Reader = cmd.ExecuteReader();
            while(Reader.Read())
            {
                Hotel hotel = readHotel(Reader);
                hotelliste.Add(hotel);
            }

            conn.Close();
            return hotelliste; 
        }

        private Hotel readHotel(SqlDataReader reader)
        {
            Hotel hotel = new Hotel();
            hotel.ID = reader.GetInt32(0);
            hotel.Name = reader.GetString(1);
            hotel.Address = reader.GetString(2);

            return hotel;
        }

        public Hotel Get(int id)
        {
            Hotel hotel1 = null;
            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                hotel1 = readHotel(Reader);

            }

            conn.Close();
            return hotel1;
        }

        
        public bool Post(Hotel hotel)
        {

          

            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);

            cmd.Parameters.AddWithValue("@Id", hotel.ID);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;
            conn.Close();
            return ok;
           
            

            
        }

       
        public bool Put(int id, Hotel hotel)
        {
            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);

            cmd.Parameters.AddWithValue("@HotelID", hotel.ID);
            cmd.Parameters.AddWithValue("@Name", hotel.Name);
            cmd.Parameters.AddWithValue("@Address", hotel.Address);
            cmd.Parameters.AddWithValue("@Id", id);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;
            conn.Close();
            return ok;
        }

        
        public bool Delete(int id)
        {
            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);

            
            cmd.Parameters.AddWithValue("@Id", id);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;
            conn.Close();
            return ok;
        }


        
    }
}