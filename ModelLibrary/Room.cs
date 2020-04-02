using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary
{
    public class Room
    {
		private int _roomNo;

		public int No
		{
			get { return _roomNo; }
			set { _roomNo = value; }
		}

		private string _roomType;

		public string Type
		{
			get { return _roomType; }
			set { _roomType = value; }
		}

		private double _price;

		public double Price
		{
			get { return _price; }
			set { _price = value; }
		}

		public Hotel Hotel { get; set; }


		public Room()
		{

		}

		public Room(int roomNo, string roomType, double price)
		{
			No = roomNo;
			Type = roomType;
			Price = price;
		
		}


		public override string ToString()
		{
			return $"RoomNo {No}, RoomType {Type}, price of room {Price}, hotelNo {Hotel.ID}";
		}




	}
}
