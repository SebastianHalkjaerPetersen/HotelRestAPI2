using System;
using ModelLibrary;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HotelRestAPI.DBUtil
{
    public class ManageBooking
    {
        private const string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=HotelDbtest3;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";


        private const string GET_ALL = "Select * from Booking";
        private const string GET_ONE = "Select * from Booking where Booking_id = @Id";
        private const string INSERT = "Insert into Booking values(@BookingId, @HotelNo, @GuestNo, @DateFrom, @DateTo, @RoomNo)";
        private const string UPDATE = "update Booking set Booking_id = @BookingId, Hotel_No = @HotelNo, Guest_No = @GuestNo, Date_From = @DateFrom, Date_To = @DateTo, Room_No = @RoomNo where Booking_id = @Id";
        private const string DELETE = "Delete from Booking where Booking_id = @Id";


        private Booking readBooking(SqlDataReader reader)
        {
            Booking booking = new Booking();
            booking.Hotel = new Hotel();
            booking.Room = new Room();
            booking.Guest = new Guest();
            booking.ID = reader.GetInt32(0);
            booking.Hotel.ID = reader.GetInt32(1);
            booking.Guest.ID = reader.GetInt32(2);
            booking.DateFrom = reader.GetDateTime(3);
            booking.DateTo = reader.GetDateTime(4);
            booking.Room.No = reader.GetInt32(5);
            return booking;
        }




        public IEnumerable<Booking> Get()
        {
            List<Booking> bookingList = new List<Booking>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ALL, conn);

            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Booking booking = readBooking(reader);
                bookingList.Add(booking);

            }



            conn.Close();
            return bookingList;
        }




        public Booking Get(int id)
        {
            Booking booking = null;
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(GET_ONE, conn);
            cmd.Parameters.AddWithValue("@Id", id);
            SqlDataReader Reader = cmd.ExecuteReader();
            if (Reader.Read())
            {
                booking = readBooking(Reader);

            }

            conn.Close();
            return booking;
        }


        //Booking_id = @BookingId, Hotel_No = @HotelNo, Guest_No = @GuestNo, Date_From = @DateFrom, Date_To = @DateTo, Room_No = @RoomNo
        public bool Post(Booking booking)
        {

            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(INSERT, conn);

            cmd.Parameters.AddWithValue("@BookingId", booking.ID);
            cmd.Parameters.AddWithValue("@HotelNo", booking.Hotel.ID);
            cmd.Parameters.AddWithValue("@GuestNo", booking.Guest.ID);
            cmd.Parameters.AddWithValue("@DateFrom", booking.DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", booking.DateTo);
            cmd.Parameters.AddWithValue("@RoomNo", booking.Room.No);
            

            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;
            conn.Close();
            return ok;

        }


        public bool Put(int id, Booking booking)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand cmd = new SqlCommand(UPDATE, conn);

            cmd.Parameters.AddWithValue("@BookingId", booking.ID);
            cmd.Parameters.AddWithValue("@HotelNo", booking.Hotel.ID);
            cmd.Parameters.AddWithValue("@GuestNo", booking.Guest.ID);
            cmd.Parameters.AddWithValue("@DateFrom", booking.DateFrom);
            cmd.Parameters.AddWithValue("@DateTo", booking.DateTo);
            cmd.Parameters.AddWithValue("@RoomNo", booking.Room.No);
            cmd.Parameters.AddWithValue("@Id", booking.ID);
            int numberOfRowsAffected = cmd.ExecuteNonQuery();
            bool ok = numberOfRowsAffected == 1;
            conn.Close();
            return ok;
        }

        public bool Delete(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
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