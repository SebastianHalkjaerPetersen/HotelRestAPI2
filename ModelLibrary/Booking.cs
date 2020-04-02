using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary
{
    public class Booking
    {
		private int _id;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}
		private Hotel _hotel;

		public Hotel Hotel

		{
			get { return _hotel; }
			set { _hotel = value; }
		}

		private Room _room;

		public Room Room
		{
			get { return _room; }
			set { _room = value; }
		}

		private Guest _guest;

		public Guest Guest

		{
			get { return _guest; }
			set { _guest = value; }
		}

		private DateTime _dateFrom;

		public DateTime DateFrom
		{
			get { return _dateFrom; }
			set { _dateFrom = value; }
		}
		private DateTime _dateTo;

		public DateTime DateTo
		{
			get { return _dateTo; }
			set { _dateTo = value; }
		}

		public Booking()
		{

		}

		public Booking(int id, DateTime dateFrom, DateTime dateTo)
		{
			_id = id;
			_dateFrom = dateFrom;
			_dateTo = dateTo;
		}


	}
}
