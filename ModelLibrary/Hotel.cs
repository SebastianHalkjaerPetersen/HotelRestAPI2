using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary
{
    public class Hotel
    {
		private int _id;

		public int ID
		{
			get { return _id; }
			set { _id = value; }
		}

		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _address;

		public string Address
		{
			get { return _address; }
			set { _address = value; }
		}

		public Hotel()
		{

		}

		public Hotel(int id, string name, string address)
		{
			_id = id;
			_name = name;
			_address = address;
		}

		public override string ToString()
		{
			return $"Hotel ID {ID} Name {Name} address {Address}";
		}

        public override bool Equals(object obj)
        {
            Hotel h = (Hotel) obj;
            if (ID == h.ID && Name == h.Name && Address == h.Address)
            {
                return true;
            }
            else
                return false;
        }

        
	}
}
