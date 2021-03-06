﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ModelLibrary
{
    public class Guest
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

		public Guest()
		{

		}

		public Guest(int id, string name, string address)
		{
			_id = id;
			_name = name;
			_address = address;
		}

		public override string ToString()
		{
			return $"Hotel ID {ID} Name {Name} address {Address}";
		}



	}
}
