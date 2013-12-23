using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo.RvInfo
{
    public class RvSellerInfo
    {

        private int _sellerID;


        public int SellerID
        {
            get { return _sellerID; }
            set { _sellerID = value; }
        }
        private string _sellerName;


        public string SellerName
        {
            get { return _sellerName; }
            set { _sellerName = value; }
        }
        private string _address1;


        public string Address1
        {
            get { return _address1; }
            set { _address1 = value; }
        }
        private string _address2;


        public string Address2
        {
            get { return _address2; }
            set { _address2 = value; }
        }
        private string _city;


        public string City
        {
            get { return _city; }
            set { _city = value; }
        }
        private string _state;


        public string State
        {
            get { return _state; }
            set { _state = value; }
        }
        private string _zip;


        public string Zip
        {
            get { return _zip; }
            set { _zip = value; }
        }
        private int _country;


        public int Country
        {
            get { return _country; }
            set { _country = value; }
        }
        private string _phone;


        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private string _altPhone;


        public string AltPhone
        {
            get { return _altPhone; }
            set { _altPhone = value; }
        }
        private string _fax;


        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        private string _email;


        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        private string _altEmail;


        public string AltEmail
        {
            get { return _altEmail; }
            set { _altEmail = value; }
        }
        private string _notesForBuyers;



        public string NotesForBuyers
        {
            get { return _notesForBuyers; }
            set { _notesForBuyers = value; }
        }
    }
}
