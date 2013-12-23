using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarsInfo
{
    [Serializable]
    public class UsedCarsInfoRV
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
        private string _sellerType;

        public string SellerType
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
        private int _paymentID;

        public int PaymentID
        {
            get { return _paymentID; }
            set { _paymentID = value; }
        }
        private bool _isActive;

        public bool IsActive
        {
            get { return _isActive; }
            set { _isActive = value; }
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
        private int uid;

        public int Uid
        {
            get { return uid; }
            set { uid = value; }
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
        private string _country;

        public string Country
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
        private string _model;

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }
        private string _make;

        public string Make
        {
            get { return _make; }
            set { _make = value; }
        }
        private int _yearOfMake;

        public int YearOfMake
        {
            get { return _yearOfMake; }
            set { _yearOfMake = value; }
        }
        private int _mileage;

        public int Mileage
        {
            get { return _mileage; }
            set { _mileage = value; }
        }
        private int _makeID;

        public int MakeID
        {
            get { return _makeID; }
            set { _makeID = value; }
        }
        private int _makeModelID;

        public int MakeModelID
        {
            get { return _makeModelID; }
            set { _makeModelID = value; }
        }
        private double _price;

        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
        private string _description;


        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _bodytype;

        public string Bodytype
        {
            get { return _bodytype; }
            set { _bodytype = value; }
        }
        private int _bodytypeID;

        public int BodytypeID
        {
            get { return _bodytypeID; }
            set { _bodytypeID = value; }
        }
        private string _Fueltype;

        public string Fueltype
        {
            get { return _Fueltype; }
            set { _Fueltype = value; }
        }
        private int _FueltypeId;

        public int FueltypeId
        {
            get { return _FueltypeId; }
            set { _FueltypeId = value; }
        }
        private string _exteriorColor;

        public string ExteriorColor
        {
            get { return _exteriorColor; }
            set { _exteriorColor = value; }
        }
        private string _numberOfSeats;

        public string NumberOfSeats
        {
            get { return _numberOfSeats; }
            set { _numberOfSeats = value; }
        }
        private string _numberOfDoors;

        public string NumberOfDoors
        {
            get { return _numberOfDoors; }
            set { _numberOfDoors = value; }
        }
        private string _numberOfCylinder;

        public string NumberOfCylinder
        {
            get { return _numberOfCylinder; }
            set { _numberOfCylinder = value; }
        }
        private string _Transmission;

        public string Transmission
        {
            get { return _Transmission; }
            set { _Transmission = value; }
        }
        private string _interiorColor;

        public string InteriorColor
        {
            get { return _interiorColor; }
            set { _interiorColor = value; }
        }
        private string _userFeedback;

        public string UserFeedback
        {
            get { return _userFeedback; }
            set { _userFeedback = value; }
        }
        private string _VIN;

        public string VIN
        {
            get { return _VIN; }
            set { _VIN = value; }
        }
        private string _PIC0;

        public string PIC0
        {
            get { return _PIC0; }
            set { _PIC0 = value; }
        }
        private string _PIC1;

        public string PIC1
        {
            get { return _PIC1; }
            set { _PIC1 = value; }
        }
        private string _PIC2;

        public string PIC2
        {
            get { return _PIC2; }
            set { _PIC2 = value; }
        }
        private string _PIC3;

        public string PIC3
        {
            get { return _PIC3; }
            set { _PIC3 = value; }
        }
        private string _PIC4;

        public string PIC4
        {
            get { return _PIC4; }
            set { _PIC4 = value; }
        }
        private string _PIC5;

        public string PIC5
        {
            get { return _PIC5; }
            set { _PIC5 = value; }
        }
        private string _PIC6;

        public string PIC6
        {
            get { return _PIC6; }
            set { _PIC6 = value; }
        }
        private string _PIC7;

        public string PIC7
        {
            get { return _PIC7; }
            set { _PIC7 = value; }
        }
        private string _PIC8;

        public string PIC8
        {
            get { return _PIC8; }
            set { _PIC8 = value; }
        }
        private string _PIC9;

        public string PIC9
        {
            get { return _PIC9; }
            set { _PIC9 = value; }
        }
        private string _PIC10;

        public string PIC10
        {
            get { return _PIC10; }
            set { _PIC10 = value; }
        }

        private string _PICLOC0;

        public string PICLOC0
        {
            get { return _PICLOC0; }
            set { _PICLOC0 = value; }
        }
        private string _PICLOC1;

        public string PICLOC1
        {
            get { return _PICLOC1; }
            set { _PICLOC1 = value; }
        }
        private string _PICLOC2;

        public string PICLOC2
        {
            get { return _PICLOC2; }
            set { _PICLOC2 = value; }
        }
        private string _PICLOC3;

        public string PICLOC3
        {
            get { return _PICLOC3; }
            set { _PICLOC3 = value; }
        }
        private string _PICLOC4;

        public string PICLOC4
        {
            get { return _PICLOC4; }
            set { _PICLOC4 = value; }
        }
        private string _PICLOC5;

        public string PICLOC5
        {
            get { return _PICLOC5; }
            set { _PICLOC5 = value; }
        }
        private string _PICLOC6;

        public string PICLOC6
        {
            get { return _PICLOC6; }
            set { _PICLOC6 = value; }
        }
        private string _PICLOC7;

        public string PICLOC7
        {
            get { return _PICLOC7; }
            set { _PICLOC7 = value; }
        }
        private string _PICLOC8;

        public string PICLOC8
        {
            get { return _PICLOC8; }
            set { _PICLOC8 = value; }
        }
        private string _PICLOC9;

        public string PICLOC9
        {
            get { return _PICLOC9; }
            set { _PICLOC9 = value; }
        }
        private string _PICLOC10;

        public string PICLOC10
        {
            get { return _PICLOC10; }
            set { _PICLOC10 = value; }
        }

        private string _PICLOC11;

        public string PICLOC11
        {
            get { return _PICLOC11; }
            set { _PICLOC11 = value; }
        }
        private string _PIC11;

        public string PIC11
        {
            get { return _PIC11; }
            set { _PIC11 = value; }
        }
        private string _PICLOC12;

        public string PICLOC12
        {
            get { return _PICLOC12; }
            set { _PICLOC12 = value; }
        }
        private string _PIC12;

        public string PIC12
        {
            get { return _PIC12; }
            set { _PIC12 = value; }
        }
        private string _PICLOC13;

        public string PICLOC13
        {
            get { return _PICLOC13; }
            set { _PICLOC13 = value; }
        }
        private string _PIC13;

        public string PIC13
        {
            get { return _PIC13; }
            set { _PIC13 = value; }
        }
        private string _PICLOC14;

        public string PICLOC14
        {
            get { return _PICLOC14; }
            set { _PICLOC14 = value; }
        }
        private string _PIC14;

        public string PIC14
        {
            get { return _PIC14; }
            set { _PIC14 = value; }
        }
        private string _PICLOC15;

        public string PICLOC15
        {
            get { return _PICLOC15; }
            set { _PICLOC15 = value; }
        }
        private string _PIC15;

        public string PIC15
        {
            get { return _PIC15; }
            set { _PIC15 = value; }
        }
        private string _PICLOC16;

        public string PICLOC16
        {
            get { return _PICLOC16; }
            set { _PICLOC16 = value; }
        }
        private string _PIC16;

        public string PIC16
        {
            get { return _PIC16; }
            set { _PIC16 = value; }
        }
        private string _PICLOC17;

        public string PICLOC17
        {
            get { return _PICLOC17; }
            set { _PICLOC17 = value; }
        }
        private string _PIC17;

        public string PIC17
        {
            get { return _PIC17; }
            set { _PIC17 = value; }
        }
        private string _PICLOC18;

        public string PICLOC18
        {
            get { return _PICLOC18; }
            set { _PICLOC18 = value; }
        }
        private string _PIC18;

        public string PIC18
        {
            get { return _PIC18; }
            set { _PIC18 = value; }
        }
        private string _PICLOC19;

        public string PICLOC19
        {
            get { return _PICLOC19; }
            set { _PICLOC19 = value; }
        }
        private string _PIC19;

        public string PIC19
        {
            get { return _PIC19; }
            set { _PIC19 = value; }
        }
        private string _PICLOC20;

        public string PICLOC20
        {
            get { return _PICLOC20; }
            set { _PICLOC20 = value; }
        }
        private string _PIC20;

        public string PIC20
        {
            get { return _PIC20; }
            set { _PIC20 = value; }
        }

        private string _PIC21;


        public string PIC21
        {
            get { return _PIC21; }
            set { _PIC21 = value; }
        }
        private string _PIC22;


        public string PIC22
        {
            get { return _PIC22; }
            set { _PIC22 = value; }
        }
        private string _PIC23;


        public string PIC23
        {
            get { return _PIC23; }
            set { _PIC23 = value; }
        }
        private string _PIC24;


        public string PIC24
        {
            get { return _PIC24; }
            set { _PIC24 = value; }
        }
        private string _PIC25;


        public string PIC25
        {
            get { return _PIC25; }
            set { _PIC25 = value; }
        }
        private string _PIC26;


        public string PIC26
        {
            get { return _PIC26; }
            set { _PIC26 = value; }
        }
        private string _PIC27;


        public string PIC27
        {
            get { return _PIC27; }
            set { _PIC27 = value; }
        }
        private string _PIC28;


        public string PIC28
        {
            get { return _PIC28; }
            set { _PIC28 = value; }
        }
        private string _PIC29;


        public string PIC29
        {
            get { return _PIC29; }
            set { _PIC29 = value; }
        }
        private string _PIC30;


        public string PIC30
        {
            get { return _PIC30; }
            set { _PIC30 = value; }
        }
        private string _PIC31;


        public string PIC31
        {
            get { return _PIC31; }
            set { _PIC31 = value; }
        }
        private string _PIC32;


        public string PIC32
        {
            get { return _PIC32; }
            set { _PIC32 = value; }
        }
        private string _PIC33;


        public string PIC33
        {
            get { return _PIC33; }
            set { _PIC33 = value; }
        }
        private string _PIC34;


        public string PIC34
        {
            get { return _PIC34; }
            set { _PIC34 = value; }
        }
        private string _PIC35;


        public string PIC35
        {
            get { return _PIC35; }
            set { _PIC35 = value; }
        }
        private string _PIC36;


        public string PIC36
        {
            get { return _PIC36; }
            set { _PIC36 = value; }
        }
        private string _PIC37;


        public string PIC37
        {
            get { return _PIC37; }
            set { _PIC37 = value; }
        }
        private string _PIC38;


        public string PIC38
        {
            get { return _PIC38; }
            set { _PIC38 = value; }
        }
        private string _PIC39;


        public string PIC39
        {
            get { return _PIC39; }
            set { _PIC39 = value; }
        }
        private string _PIC40;


        public string PIC40
        {
            get { return _PIC40; }
            set { _PIC40 = value; }
        }
        private string _PIC41;


        public string PIC41
        {
            get { return _PIC41; }
            set { _PIC41 = value; }
        }
        private string _PIC42;


        public string PIC42
        {
            get { return _PIC42; }
            set { _PIC42 = value; }
        }
        private string _PIC43;


        public string PIC43
        {
            get { return _PIC43; }
            set { _PIC43 = value; }
        }
        private string _PIC44;


        public string PIC44
        {
            get { return _PIC44; }
            set { _PIC44 = value; }
        }
        private string _PIC45;


        public string PIC45
        {
            get { return _PIC45; }
            set { _PIC45 = value; }
        }
        private string _PIC46;


        public string PIC46
        {
            get { return _PIC46; }
            set { _PIC46 = value; }
        }
        private string _PIC47;


        public string PIC47
        {
            get { return _PIC47; }
            set { _PIC47 = value; }
        }
        private string _PIC48;


        public string PIC48
        {
            get { return _PIC48; }
            set { _PIC48 = value; }
        }
        private string _PIC49;


        public string PIC49
        {
            get { return _PIC49; }
            set { _PIC49 = value; }
        }
        private string _PIC50;


        public string PIC50
        {
            get { return _PIC50; }
            set { _PIC50 = value; }
        }


        private string _PICLOC21;

        public string PICLOC21
        {
            get { return _PICLOC21; }
            set { _PICLOC21 = value; }
        }
        private string _PICLOC22;

        public string PICLOC22
        {
            get { return _PICLOC22; }
            set { _PICLOC22 = value; }
        }
        private string _PICLOC23;

        public string PICLOC23
        {
            get { return _PICLOC23; }
            set { _PICLOC23 = value; }
        }
        private string _PICLOC24;

        public string PICLOC24
        {
            get { return _PICLOC24; }
            set { _PICLOC24 = value; }
        }
        private string _PICLOC25;

        public string PICLOC25
        {
            get { return _PICLOC25; }
            set { _PICLOC25 = value; }
        }
        private string _PICLOC26;

        public string PICLOC26
        {
            get { return _PICLOC26; }
            set { _PICLOC26 = value; }
        }
        private string _PICLOC27;

        public string PICLOC27
        {
            get { return _PICLOC27; }
            set { _PICLOC27 = value; }
        }
        private string _PICLOC28;

        public string PICLOC28
        {
            get { return _PICLOC28; }
            set { _PICLOC28 = value; }
        }
        private string _PICLOC29;

        public string PICLOC29
        {
            get { return _PICLOC29; }
            set { _PICLOC29 = value; }
        }
        private string _PICLOC30;

        public string PICLOC30
        {
            get { return _PICLOC30; }
            set { _PICLOC30 = value; }
        }

        private string _PICLOC31;

        public string PICLOC31
        {
            get { return _PICLOC31; }
            set { _PICLOC31 = value; }
        }
        private string _PICLOC32;

        public string PICLOC32
        {
            get { return _PICLOC32; }
            set { _PICLOC32 = value; }
        }
        private string _PICLOC33;

        public string PICLOC33
        {
            get { return _PICLOC33; }
            set { _PICLOC33 = value; }
        }
        private string _PICLOC34;

        public string PICLOC34
        {
            get { return _PICLOC34; }
            set { _PICLOC34 = value; }
        }
        private string _PICLOC35;

        public string PICLOC35
        {
            get { return _PICLOC35; }
            set { _PICLOC35 = value; }
        }
        private string _PICLOC36;

        public string PICLOC36
        {
            get { return _PICLOC36; }
            set { _PICLOC36 = value; }
        }
        private string _PICLOC37;

        public string PICLOC37
        {
            get { return _PICLOC37; }
            set { _PICLOC37 = value; }
        }
        private string _PICLOC38;

        public string PICLOC38
        {
            get { return _PICLOC38; }
            set { _PICLOC38 = value; }
        }
        private string _PICLOC39;

        public string PICLOC39
        {
            get { return _PICLOC39; }
            set { _PICLOC39 = value; }
        }
        private string _PICLOC40;

        public string PICLOC40
        {
            get { return _PICLOC40; }
            set { _PICLOC40 = value; }
        }


        private string _PICLOC41;

        public string PICLOC41
        {
            get { return _PICLOC41; }
            set { _PICLOC41 = value; }
        }
        private string _PICLOC42;

        public string PICLOC42
        {
            get { return _PICLOC42; }
            set { _PICLOC42 = value; }
        }
        private string _PICLOC43;

        public string PICLOC43
        {
            get { return _PICLOC43; }
            set { _PICLOC43 = value; }
        }
        private string _PICLOC44;

        public string PICLOC44
        {
            get { return _PICLOC44; }
            set { _PICLOC44 = value; }
        }
        private string _PICLOC45;

        public string PICLOC45
        {
            get { return _PICLOC45; }
            set { _PICLOC45 = value; }
        }
        private string _PICLOC46;

        public string PICLOC46
        {
            get { return _PICLOC46; }
            set { _PICLOC46 = value; }
        }
        private string _PICLOC47;

        public string PICLOC47
        {
            get { return _PICLOC47; }
            set { _PICLOC47 = value; }
        }
        private string _PICLOC48;

        public string PICLOC48
        {
            get { return _PICLOC48; }
            set { _PICLOC48 = value; }
        }
        private string _PICLOC49;

        public string PICLOC49
        {
            get { return _PICLOC49; }
            set { _PICLOC49 = value; }
        }
        private string _PICLOC50;

        public string PICLOC50
        {
            get { return _PICLOC50; }
            set { _PICLOC50 = value; }
        }


        private string _TotalRecords;

        public string TotalRecords
        {
            get { return _TotalRecords; }
            set { _TotalRecords = value; }
        }
        private string _RowNumber;

        public string RowNumber
        {
            get { return _RowNumber; }
            set { _RowNumber = value; }
        }
        private string _PageCount;

        public string PageCount
        {
            get { return _PageCount; }
            set { _PageCount = value; }
        }
        private string _ConditionDescription;

        public string ConditionDescription
        {
            get { return _ConditionDescription; }
            set { _ConditionDescription = value; }
        }
        private string _DriveTrain;

        public string DriveTrain
        {
            get { return _DriveTrain; }
            set { _DriveTrain = value; }
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

        private string _TypeName;

        public string TypeName
        {
            get { return _TypeName; }
            set { _TypeName = value; }
        }

        private string _TypeID;

        public string TypeID
        {
            get { return _TypeID; }
            set { _TypeID = value; }
        }

        private string _AirConditioners;

        public string AirConditioners
        {
            get { return _AirConditioners; }
            set { _AirConditioners = value; }
        }
        private string _Length;

        public string Length
        {
            get { return _Length; }
            set { _Length = value; }
        }
        private string _WaterCapacity;

        public string WaterCapacity
        {
            get { return _WaterCapacity; }
            set { _WaterCapacity = value; }
        }
        private string _Towing_Capacity;

        public string Towing_Capacity
        {
            get { return _Towing_Capacity; }
            set { _Towing_Capacity = value; }
        }
        private string _Dry_Weight;

        public string Dry_Weight
        {
            get { return _Dry_Weight; }
            set { _Dry_Weight = value; }
        }
        private string _SleepingCapacity;

        public string SleepingCapacity
        {
            get { return _SleepingCapacity; }
            set { _SleepingCapacity = value; }
        }
        private string _SlideOuts;

        public string SlideOuts
        {
            get { return _SlideOuts; }
            set { _SlideOuts = value; }
        }
        private string _EngineManufacturer;

        public string EngineManufacturer
        {
            get { return _EngineManufacturer; }
            set { _EngineManufacturer = value; }
        }
        private string _EngineType;

        public string EngineType
        {
            get { return _EngineType; }
            set { _EngineType = value; }
        }
        private string _Title;


        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }
        private Int64 _CarUniqueID;


        public Int64 CarUniqueID
        {
            get { return _CarUniqueID; }
            set { _CarUniqueID = value; }
        }
    }

}
