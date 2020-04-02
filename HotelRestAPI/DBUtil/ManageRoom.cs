using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelRestAPI.DBUtil
{
    public class ManageRoom
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        private const string GET_ALL = "Select * from Room";
        private const string GET_ONE = "select * from Room where Room_No = @No and Hotel_No = @HotelNo";
        private const string INSERT = "Insert into Room values(@No, @HotelID, @Type, @Price)";
        private const string UPDATE = "update Room set Room_No = @No, Hotel_No = @HotelNo, Types = @Type, Price = @Price where Room_No = @ID and Hotel_No = @HotelID";
        private const string DELETE = "Delete from Room where Room_No = @No and Hotel_No = @HotelNo";

        public IEnumerable<Room> Get()
        {
            List<Room> roomList = new List<Room>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Room room = readRoom(reader);
                roomList.Add(room);

            }



            conn.Close();
            return roomList;   
        }

        private Room readRoom(SqlDataReader reader)
        {
            Room room = new Room();
            room.No = reader.GetInt32(0);
            room.Hotel = new Hotel();
            room.Hotel.ID = reader.GetInt32(1);
            room.Type = reader.GetString(2);
            room.Price = reader.GetDouble(3);
            return room;
        }

        public Room Get(int id, int id2)
        {
            Room room = null;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@No", id);
            cmd.Parameters.AddWithValue("@HotelNo", id2);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                room = readRoom(reader);
            }

            conn.Close();
            return room;
        }

        public bool Post(Room room)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);
            cmd.Parameters.AddWithValue("@No", room.No);
            cmd.Parameters.AddWithValue("@HotelID", room.Hotel.ID);
            cmd.Parameters.AddWithValue("@Type", room.Type);
            cmd.Parameters.AddWithValue("@Price", room.Price);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            return ok;
        }
        public bool Put(int id, int id2, Room room)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);
            cmd.Parameters.AddWithValue("@No", room.No);
            cmd.Parameters.AddWithValue("@HotelNo", room.Hotel.ID);
            cmd.Parameters.AddWithValue("@Type", room.Type);
            cmd.Parameters.AddWithValue("@Price", room.Price);
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@HotelID", id2);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            conn.Close();
            return ok;
        }
        public bool Delete(int id, int id2)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(DELETE, conn);

            cmd.Parameters.AddWithValue("@No", id);
            cmd.Parameters.AddWithValue("@HotelNo", id2);

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;

            conn.Close();
            return ok;
        }


    }
}