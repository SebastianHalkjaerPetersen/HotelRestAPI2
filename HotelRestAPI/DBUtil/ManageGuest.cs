using ModelLibrary;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelRestAPI.DBUtil
{
    public class ManageGuest
    {



        private const string ConectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private const string GET_ALL = "Select * from Guest";
        private const string GET_ONE = "Select * from Guest where Guest_No = @Id";
        private const string INSERT = "Insert into Guest values(@Id, @Name, @Address)";
        private const string UPDATE = "update Guest set Guest_No = @GuestID, Name = @Name, Address = @Address where Guest_No = @Id";
        private const string DELETE = "Delete from Guest where Guest_No = @Id";


        public IEnumerable<Guest> Get()
        {
            List<Guest> guestliste = new List<Guest>();
            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader Reader = cmd.ExecuteReader();
            while (Reader.Read())
            {
                Guest guest = readGuest(Reader);
                guestliste.Add(guest);
            }

            conn.Close();
            return guestliste;
        }

        private Guest readGuest(SqlDataReader reader)
        {
            Guest guest = new Guest();
            guest.ID = reader.GetInt32(0);
            guest.Name = reader.GetString(1);
            guest.Address = reader.GetString(2);

            return guest;
        }

        public Guest Get(int id)
        {
            Guest guest1 = null;
            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                guest1 = readGuest(Reader);

            }

            conn.Close();
            return guest1;
        }


        public bool Post(Guest guest)
        {

            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);

            cmd.Parameters.AddWithValue("@Id", guest.ID);
            cmd.Parameters.AddWithValue("@Name", guest.Name);
            cmd.Parameters.AddWithValue("@Address", guest.Address);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;
            conn.Close();
            return ok;

        }


        public bool Put(int id, Guest guest)
        {
            SqlConnection conn = new SqlConnection(ConectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);

            cmd.Parameters.AddWithValue("@GuestID", guest.ID);
            cmd.Parameters.AddWithValue("@Name", guest.Name);
            cmd.Parameters.AddWithValue("@Address", guest.Address);
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