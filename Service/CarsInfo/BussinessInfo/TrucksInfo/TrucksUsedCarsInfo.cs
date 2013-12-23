using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo.TrucksInfo
{
    public class TrucksUsedCarsInfo
    {
        private int _postingID;

        public int PostingID
        {
            get { return _postingID; }
            set { _postingID = value; }
        }
        private int _carid;


        public int Carid
        {
            get { return _carid; }
            set { _carid = value; }
        }
        private int _sellerType;


        public int SellerType
        {
            get { return _sellerType; }
            set { _sellerType = value; }
        }
        private int _sellerID;


        public int SellerID
        {
            get { return _sellerID; }
            set { _sellerID = value; }
        }
        private DateTime _SaleDate;


        public DateTime SaleDate
        {
            get { return _SaleDate; }
            set { _SaleDate = value; }
        }
        private DateTime _dateOfPosting;


        public DateTime DateOfPosting
        {
            get { return _dateOfPosting; }
            set { _dateOfPosting = value; }
        }
        private DateTime _expirtyDate;


        public DateTime ExpirtyDate
        {
            get { return _expirtyDate; }
            set { _expirtyDate = value; }
        }
        private int _packageID;


        public int PackageID
        {
            get { return _packageID; }
            set { _packageID = value; }
        }
        private int _UserPackID;


        public int UserPackID
        {
            get { return _UserPackID; }
            set { _UserPackID = value; }
        }
        private int _paymentID;


        public int PaymentID
        {
            get { return _paymentID; }
            set { _paymentID = value; }
        }
        private DateTime _PaymentDate;


        public DateTime PaymentDate
        {
            get { return _PaymentDate; }
            set { _PaymentDate = value; }
        }
        private DateTime _PDDate;


        public DateTime PDDate
        {
            get { return _PDDate; }
            set { _PDDate = value; }
        }
        private int _PayActive;


        public int PayActive
        {
            get { return _PayActive; }
            set { _PayActive = value; }
        }
        private int _ListingActive;


        public int ListingActive
        {
            get { return _ListingActive; }
            set { _ListingActive = value; }
        }
        private int _isActive;


        public int IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
        }
        private int _AdStatus;


        public int AdStatus
        {
            get { return _AdStatus; }
            set { _AdStatus = value; }
        }
        private int _InternalreviewID;


        public int InternalreviewID
        {
            get { return _InternalreviewID; }
            set { _InternalreviewID = value; }
        }
        private int _cancelledBy;


        public int CancelledBy
        {
            get { return _cancelledBy; }
            set { _cancelledBy = value; }
        }
        private string _cancelledReason;


        public string CancelledReason
        {
            get { return _cancelledReason; }
            set { _cancelledReason = value; }
        }
        private DateTime _cancelledDate;


        public DateTime CancelledDate
        {
            get { return _cancelledDate; }
            set { _cancelledDate = value; }
        }
        private string _zipcode;

        public string Zipcode
        {
            get { return _zipcode; }
            set { _zipcode = value; }
        }
        private int _uid;


        public int Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        private string _Source;


        public string Source
        {
            get { return _Source; }
            set { _Source = value; }
        }

        private int _WCCallID;


        public int WCCallID
        {
            get { return _WCCallID; }
            set { _WCCallID = value; }
        }

        private int _SaleEnteredBy;


        public int SaleEnteredBy
        {
            get { return _SaleEnteredBy; }
            set { _SaleEnteredBy = value; }
        }
        private int _IsLocked;


        public int IsLocked
        {
            get { return _IsLocked; }
            set { _IsLocked = value; }
        }
        private DateTime _IsLockedDateTime;


        public DateTime IsLockedDateTime
        {
            get { return _IsLockedDateTime; }
            set { _IsLockedDateTime = value; }
        }
        private string _Ip;


        public string Ip
        {
            get { return _Ip; }
            set { _Ip = value; }
        }
        private DateTime _LastUpdatedDate;


        public DateTime LastUpdatedDate
        {
            get { return _LastUpdatedDate; }
            set { _LastUpdatedDate = value; }
        }
    }
}
