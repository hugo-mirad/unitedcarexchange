using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using CarsBL.Transactions;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using CarsBL;
using CarsBL.Masters;
using CarsInfo;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System.Data.SqlClient;

public partial class SearchCarDetails : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    int p = 0;

    int rowcount = 0;
    string rawURL = HttpContext.Current.Request.RawUrl;
    VisitSiteLog vstlog = new VisitSiteLog();
    CarFeatures objCarFeatures = new CarFeatures();
    protected void Page_Load(object sender, EventArgs e)
    {

      //  mdlPDetalerts.Show();
        if (Session[Constants.NAME] != null)
        {

            logoutLi.Visible = true;
            accountLi.Visible = true;
            reviewLi.Visible = false;

            loginLi.Visible = false;
            newCarsLi.Visible = false;
        }
        else
        {
            logoutLi.Visible = false;
            accountLi.Visible = false;
            reviewLi.Visible = false;

            loginLi.Visible = true;
            newCarsLi.Visible = true;
        }

        if (!IsPostBack)
        {
            HdnSubScribeValue.Text = Constants.SubsribeExpTime.ToString();
            FillMakes();
            FillModels();
            FillWithin();

            Session["CurrentPage"] = "Home";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;


            GeneralFunc.SaveSiteVisit();

            GeneralFunc.SetPageDefaults(Page);


            string Make = Request.QueryString[Request.QueryString.Count - 1];

            //string Name = Request.Cookies.Get("UserSettings").Values.Get("Name");
            //string Phone = Request.Cookies.Get("UserSettings").Values.Get("Phone");


            if (Make != null)
            {

                string[] strCarid = Make.Split('-');
                if (strCarid.Length >= 4)
                    Hadd.Value = strCarid[3].ToString();

                CarsService obj = new CarsService();

                List<CarsInfo.UsedCarsInfo> objCarInfo = new List<CarsInfo.UsedCarsInfo>();

                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                //objServiceReference.Path = "http://cars.hugomirad.com/CarsService.asmx";

                //objScriptReference.Path = "http://cars.hugomirad.com/Static/JS/CarsJScriptNew.js";

                //objServiceReference.Path = "http://localhost:1460/Cars/CarsService.asmx";

                //objScriptReference.Path = "http://localhost:1460/Cars/Static/JS/CarsJScriptNew.js";


                objServiceReference.Path = "../CarsService.asmx";

                objScriptReference.Path = "../Static/Js/CarsJScriptNew.js";

                scrptmgr.Services.Add(objServiceReference);
                scrptmgr.Scripts.Add(objScriptReference);

                if (p == 0)
                {
                    if (strCarid.Length > 1)
                    {
                        string sCarid = strCarid[strCarid.Length - 1];
                        Session["carid"] = sCarid.ToString();

                        if (GeneralFunc.IsNumeric(sCarid))
                        {

                            if (Request.Cookies.Get("UserSettings") == null)
                            {
                                // ClientScript.RegisterStartupScript(typeof(Page), "KyAUIDFCS", "<script language='javascript' type='text/javascript'>Subscribe();</script>");

                            }


                            objCarInfo = obj.FindCarIDNew(sCarid);

                            FillCarDetails(objCarInfo, sCarid);


                            //Answer reviews
                            try
                            {
                                string carids = Session["carid"].ToString();
                                DataSet rptAnswerQuestions = new DataSet();
                                rptAnswerQuestions = objCarFeatures.GetFinalAnswers(carids);
                                Session["DeleteDiscus"] = rptAnswerQuestions;
                                Session["Discusins"] = rptAnswerQuestions;
                                rptquestion.DataSource = rptAnswerQuestions;
                                rptquestion.DataBind();
                            }
                            catch { }
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("errorpage.aspx");
            }
        }

        //Cookie creation
        // **************** New Code **************************** //

        String strHostName = Request.UserHostAddress.ToString();
        string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

        if (Request.Cookies["IpCookie"] == null)
        {
            HttpCookie statusCookie = new HttpCookie("IpCookie");
            Response.Cookies["IpCookie"].Value = strIp;
        }
        else
        {




        }
        if (Request.Cookies["Zipcookie"] == null)
        {
            HttpCookie zipCookie = new HttpCookie("Zipcookie");
            Response.Cookies["Zipcookie"].Value = "Zipcode";

        }
        else
        {
        }
        if (Request.Cookies["Statuscookie"] == null)
        {
            HttpCookie statusCookie = new HttpCookie("Statuscookie");
            Response.Cookies["Statuscookie"].Value = "false";
        }
        else
        {


            if (Convert.ToString(Request.Cookies["Statuscookie"].Value) != "false")
            {
                //Session[Constants.NAME] = "test";
                DataSet dsPerformLogin = new DataSet();
                string LogStatusDetails = Request.Cookies["Statuscookie"].Value;
                string[] splitString = LogStatusDetails.Split(',');

                //string LodSta = splitString[0].Trim();
                //string Loduserid = splitString[1].Trim();
                //string Lodpwd = splitString[2].Trim();
                //Loduserid = DecryptPassword(Loduserid);
                //Lodpwd = DecryptPassword(Lodpwd);

                //dsPerformLogin = objUserregBL.PerformLogin(Loduserid, Lodpwd);
                //Session[Constants.USER_ID] = dsPerformLogin.Tables[0].Rows[0]["UId"];
                //Session[Constants.USER_NAME] = dsPerformLogin.Tables[0].Rows[0]["UserName"];
                //Session[Constants.NAME] = dsPerformLogin.Tables[0].Rows[0]["Name"];
                //Session[Constants.PhoneNumber] = dsPerformLogin.Tables[0].Rows[0]["PhoneNumber"];

                //Session["PackageID"] = dsPerformLogin.Tables[0].Rows[0]["PackageID"];

                //Response.Redirect("Account.aspx");
            }
        }

        if (Request.Cookies["SearchCookie"] == null)
        {
            HttpCookie statusCookie = new HttpCookie("SearchCookie");
            Response.Cookies["SearchCookie"].Value = "make-model-year";
        }
        else
        {
        }
        if (Request.Cookies["PrefCookie"] == null)
        {
            HttpCookie statusCookie = new HttpCookie("PrefCookie");
            Response.Cookies["PrefCookie"].Value = "Pref";
            GeneralFunc.SaveCookieData("Zipcode", strIp, DateTime.Now, DateTime.Now, false, "General", null, "Zipcode");
        }
        else
        {
        }


        // string Make1 = Request.QueryString[Request.QueryString.Count - 1];
        // string[] strCarid1 = Make1.Split('-');


        // string urlscity = Session["urlcity"].ToString();
        // string urlstate = Session["urlstate"].ToString();
        // if (urlscity.Contains(" "))
        //     urlscity = urlscity.Replace(" ", "");

        // if (urlstate.Contains(" "))
        //     urlstate = urlstate.Replace(" ", "");

        //// Session["url"] = "url";


        // string str = "usedcars/" + strCarid1[0].ToString() + "-" + strCarid1[1].ToString() + "-" + strCarid1[2].ToString() + "-" + urlscity.Trim() + "-" + urlstate.Trim() + "-" + strCarid1[3].ToString();


        //  string str = "mobicarz/" + 3 + "/Product-details-of-" + 3 + ".aspx";
        //  Response.Redirect(str);
    }


    private void SimialarCars(string MakeId, string ModelID, string zipcode, string Price)
    {

        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();


        var obj = new List<CarsInfo.UsedCarsInfo>();


        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SimialarCars(MakeId, ModelID, zipcode, Price);


        //dlSimilarResults.DataSource = obj;

        //Session["SimilarResults"] = obj;


        //dlSimilarResults.DataBind();


    }

    public DataSet GetCarFeatures(string sCarId)
    {
        DataSet ds = new DataSet();
        CarFeatures objCarFeatures = new CarFeatures();
        ArrayList arr = new ArrayList();
        DataSet dsNewFeatures = new DataSet();

        dsNewFeatures.Tables.Add();
        dsNewFeatures.Tables[0].Columns.Add("FeatureTypeName");
        dsNewFeatures.Tables[0].Columns.Add("FeatureName");

        ds = objCarFeatures.GetCarFeatures_New(sCarId);


        if (ds.Tables[0].Rows.Count > 0)
        {


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {


                    dsNewFeatures.Tables[0].Rows.Add();
                    dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][0] = ds.Tables[0].Rows[i]["FeatureTypeName"].ToString();
                    dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][1] = ds.Tables[0].Rows[i]["FeatureName"].ToString();
                }
                else
                {
                    if (ds.Tables[0].Rows[i - 1]["FeatureTypeName"].ToString().Trim() != ds.Tables[0].Rows[i]["FeatureTypeName"].ToString().Trim())
                    {
                        dsNewFeatures.Tables[0].Rows.Add();
                        dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][0] = ds.Tables[0].Rows[i]["FeatureTypeName"].ToString();
                        dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][1] = ds.Tables[0].Rows[i]["FeatureName"].ToString();
                    }
                    else if (ds.Tables[0].Rows[i - 1]["FeatureTypeName"].ToString().Trim() == ds.Tables[0].Rows[i]["FeatureTypeName"].ToString().Trim())
                    {

                        dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][1] = dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][1] + ", " + ds.Tables[0].Rows[i]["FeatureName"].ToString();

                    }
                }

            }
        }
        return dsNewFeatures;
    }


    private string EmptyCheck(string sEmp)
    {
        if (sEmp == "Emp" || sEmp == "emp")
        {
            sEmp = "";
        }
        return sEmp;
    }

    public DataSet GetCarDiscussions(string sCarId)
    {
        DataSet ds = new DataSet();
        CarFeatures objCarFeatures = new CarFeatures();
        ArrayList arr = new ArrayList();
        DataSet dsNewFeatures = new DataSet();

        dsNewFeatures.Tables.Add();
        dsNewFeatures.Tables[0].Columns.Add("DiscQuestion");
        dsNewFeatures.Tables[0].Columns.Add("DiscAnswer");

        ds = objCarFeatures.GetCarDiscussions(sCarId);


        if (ds.Tables[0].Rows.Count > 0)
        {


            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                if (i == 0)
                {








                    dsNewFeatures.Tables[0].Rows.Add();
                    dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][0] = ds.Tables[0].Rows[i]["DiscQuestion"].ToString();
                    dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][1] = ds.Tables[0].Rows[i]["DiscAnswer"].ToString();
                }
                else
                {
                    if (ds.Tables[0].Rows[i - 1]["DiscQuestion"].ToString().Trim() != ds.Tables[0].Rows[i]["DiscQuestion"].ToString().Trim())
                    {
                        dsNewFeatures.Tables[0].Rows.Add();
                        dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][0] = ds.Tables[0].Rows[i]["DiscQuestion"].ToString();
                        dsNewFeatures.Tables[0].Rows[dsNewFeatures.Tables[0].Rows.Count - 1][1] = ds.Tables[0].Rows[i]["DiscAnswer"].ToString();
                    }

                }

            }
        }
        return dsNewFeatures;
    }

    public void GetCarPictures(string carid)
    {

        CarsBL.Transactions.CarsPictures objCarsPictures = new CarsBL.Transactions.CarsPictures();

        //var obj = new List<CarsInfo.CarPicturesInfo>();
        DataSet dsPics = new DataSet();
        DataSet dsPicsNew = new DataSet();
        //    DataSet dsPicsNew = new DataSet();

        dsPicsNew.Tables.Add();

        dsPicsNew.Tables[0].Columns.Add("PIC");
        dsPicsNew.Tables[0].Columns.Add("PICLOC");
        dsPicsNew.Tables[0].Columns.Add("PICPATH");


        dsPics = objCarsPictures.GetCarPictures(carid);
        if (dsPics.Tables[0].Rows.Count > 0)
        {

            for (int i = 0; i < 21; i++)
            {
                if (i == 0)
                {


                    string StockUrl = string.Empty;
                    if (dsPics.Tables[0].Rows[0]["PIC" + i].ToString().Trim() == "" && dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString().Trim() == "")
                    {
                        string StockMake = dsPics.Tables[0].Rows[0]["make"].ToString();
                        StockMake = StockMake.Replace(" ", "-");
                        StockMake = StockMake.Replace("/", "@");
                        StockMake = StockMake.Replace("&", "@");
                        string StockType = dsPics.Tables[0].Rows[0]["Model"].ToString().Replace('&', '@');
                        StockType = StockType.Replace("/", "@");
                        StockType = StockType.Replace(" ", "-");
                        //StockUrl = "http://www.mobicarz.com//images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";
                        StockUrl = "http://unitedcarexchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";

                        try
                        {
                            dsPicsNew.Tables[0].Rows.Add();
                            dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = "";
                            dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = "";
                            dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICPATH"] = StockUrl;
                        }
                        catch { }
                    }

                    else
                    {
                        //dsPicsNew.Tables[0].Rows.Add();
                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = dsPics.Tables[0].Rows[0]["PIC" + i].ToString();
                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString();

                        var path = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString() + "/" + dsPics.Tables[0].Rows[0]["PIC" + i].ToString();


                        path = path.Replace("//", "/");
                        //StockUrl = "http://www.mobicarz.com/" + path;
                        StockUrl = "http://images.mobicarz.com/" + path;

                       
                    }
                    img.ImageUrl = StockUrl;

                }
                else
                {
                    var path = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString() + "/" + dsPics.Tables[0].Rows[0]["PIC" + i].ToString();


                    path = path.Replace("//", "/");
                    //path = "http://www.mobicarz.com/" + path;
                    path = "http://images.mobicarz.com/" + path;

                    //if (path != "http://www.mobicarz.com//")
                    if (path != "http://images.mobicarz.com/")
                    {

                        dsPicsNew.Tables[0].Rows.Add();

                        dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = "";
                        //dsPics.Tables[0].Rows[0]["Make"] + "_" + dsPics.Tables[0].Rows[0]["Model"].ToString().ToUpper() + " Car" + "_" + dsPics.Tables[0].Rows[0]["PIC" + i].ToString();
                        dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString();



                        dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICPATH"] = path;
                    }
                }
            }
            Repeater2.DataSource = dsPicsNew;
            Repeater2.DataBind();
        }
    }
    protected void zipValBut_Click(object sender, EventArgs e)
    {

        //string Name = GeneralFunc.ToProper(txtContcname.Text).Trim();
        //string Phone = txtphone.Text;
        //string Email = txtemail.Text;
        clsMailFormats format = new clsMailFormats();
        MailMessage msg = new MailMessage();
        if (Session["CustEmail"] != null)
        {
            if (Session["CustEmail"].ToString() != "")
            {
                msg.From = new MailAddress(txtcemail.Text);
                msg.To.Add(Session["CustEmail"].ToString());
                msg.CC.Add("info@mobicarz.com");
               // msg.Bcc.Add("padma@datumglobal.net");
                msg.Subject = "Regarding Buyer requestbu";
                msg.IsBodyHtml = true;
                string text = string.Empty;

                string Comments = string.Empty;
                if (txtComments.Text == "Enter your message here")
                {
                    Comments = "";
                }
                else
                {
                    Comments = txtComments.Text;
                }



                text = format.SendContactSellar(lblSellerName.Text, zipCode1.Text, txtPhone.Text, txtcemail.Text, GeneralFunc.ToProper(txtfirstName.Text), txtlastName.Text,
                    Comments, ref text, lblYear.Text, lblMake.Text, lblModel.Text, lblPrice.Text);

                msg.Body = text.ToString();

                SmtpClient smtp = new SmtpClient();

                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.Credentials = new System.Net.NetworkCredential("padma@datumglobal.net", "myhampy21");
                //smtp.EnableSsl = true;
                //smtp.Send(msg);

                smtp.Host = "127.0.0.1";
                smtp.Port = 25;
                smtp.Send(msg);

                MpeEmail.Hide();

                lblAlertMsg.Text = "Email request sent to seller.";

                mpealert.Show();

                //Page.ClientScript.RegisterStartupScript(typeof(Page), "KyRST", "<script type='text/javascript' language='javascript'>alert('');</script>");

                Page.ClientScript.RegisterStartupScript(typeof(Page), "KyRST", "<script type='text/javascript' language='javascript'>hide();</script>");

                Page.ClientScript.RegisterStartupScript(typeof(Page), "KyRST", "<script type='text/javascript' language='javascript'>pageLoad();</script>");

                BuyerTranBL objBuyerTranBL = new BuyerTranBL();

                bool bSuccess = true;
                String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();
                string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();


                bSuccess = objBuyerTranBL.SaveBuyerRequest(txtcemail.Text, zipCode1.Text, txtPhone.Text, GeneralFunc.ToProper(txtfirstName.Text),
                    txtlastName.Text, Comments, strIp, lblphone.Text, lblPrice.Text, hdnCarid.Value, "0");

                zipCode1.Text = "Zip or City";

                txtPhone.Text = "my phone number";

                txtcemail.Text = "my email address";

                txtfirstName.Text = "First Name";

                txtlastName.Text = "Last Name";

                txtComments.Text = "Enter your message here";


            }
            else
            {
                Page.ClientScript.RegisterStartupScript(typeof(Page), "KyRST", "<script type='text/javascript' language='javascript'>alert('Seller Email id doesnot exists');</script>");
            }
        }


    }
    protected void btnOk1_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }





    private void FillCarDetails(List<CarsInfo.UsedCarsInfo> objCarInfo, string sCarid)
    {

        if (objCarInfo.Count > 0)
        {
            //------p--------//

            Hmake.Value = objCarInfo[0].MakeID.ToString();
            Hmodel.Value = objCarInfo[0].MakeModelID.ToString();
            HZip.Value = objCarInfo[0].Zip.ToString();
            HPrice.Value = objCarInfo[0].Price.ToString();
            //------------end-------//
            try
            {
                Session["urlcity"] = objCarInfo[0].City.ToString();
                Session["urlstate"] = objCarInfo[0].State.ToString();

            }
            catch
            {
            }

            if (objCarInfo[0].IsActive == false)
            {
                soldCar.Visible = true;

                if (objCarInfo[0].AdStatus == "Active")
                {
                    lblCarsoldStatus.Text = "This car is in Inactive status!";
                    mailsend.Visible = false;

                    //return;
                }

                else if (objCarInfo[0].AdStatus != "Active")
                {

                     soldcarid.Visible = false;
                     soldcarid2.Attributes["class"] = "col-sm-12";
                    lblCarsoldStatus.Text = "This car is in " + objCarInfo[0].AdStatus + " status!";
                    mailsend.Visible = false;
                    //return;
                }



                Session["zipId"] = objCarInfo[0].Zip;

                //Used 2005 BMW X3 Car for Sale ($7,000) at Patton, MO – United Car Exchange
                // Title = "Buy Sell Used Cars " + (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper() + " in  " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper();

                Title = "Used " + objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper() + " Car for Sale ($" + objCarInfo[0].Price.ToString().ToUpper() + ")  at " + objCarInfo[0].City.ToString().ToUpper().Trim() + "," + objCarInfo[0].State.ToString().ToUpper() + " - MobiCarz.";

                if (objCarInfo[0].Title != "Emp")
                {

                    lblTitle.Text = EmptyCheck(objCarInfo[0].Title);
                }
                else
                {
                    lblTitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
                }
            }
            else
            {
                if (objCarInfo[0].AdStatus != "Active")
                {
                    soldCar.Visible = true;
                    sold.Visible = false;

                    lblCarsoldStatus.Text = "This car is in " + objCarInfo[0].AdStatus + " status!";
                }
                else
                {
                    soldCar.Visible = false;
                    sold.Visible = false;
                }


                Session["zipId"] = objCarInfo[0].Zip;

                // Title = "Buy Sell Used Cars " + (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper() + " in  " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper();
                Title = "Used " + objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper() + " Car for Sale ($" + objCarInfo[0].Price.ToString().ToUpper() + ")  at " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper() + " - MobiCarz.";

                if (objCarInfo[0].Title != "Emp")
                {

                    lblTitle.Text = EmptyCheck(objCarInfo[0].Title);
                }
                else
                {
                    lblTitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
                }
            }




            Session["zipId"] = objCarInfo[0].Zip;

            //  Title = "Buy Sell Used Cars " + (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper() + " in  " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper();
            Title = "Used " + objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper() + " Car for Sale ($" + objCarInfo[0].Price.ToString().ToUpper() + ")  at " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper() + " - MobiCarz.";

            if (objCarInfo[0].Title != "Emp")
            {

                lblTitle.Text = EmptyCheck(objCarInfo[0].Title);
                LabelSubtitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
            }
            else
            {
                //Main Title
                lblTitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
                LabelSubtitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);



            }

            if (objCarInfo[0].Price.ToString() != "0")
            {
                lblPrice1.Text = "-$" + (EmptyCheck(objCarInfo[0].Price.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Price.ToString()));

                lblPrice.Text = "$" + (EmptyCheck(objCarInfo[0].Price.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Price.ToString()));
                lblPrice2.Text = "$" + (EmptyCheck(objCarInfo[0].Price.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Price.ToString()));
            }

            string city = GeneralFunc.ToProper(EmptyCheck(objCarInfo[0].City));

            string address = EmptyCheck(objCarInfo[0].Address1.ToLower()).Trim();

            address = GeneralFunc.ToProper(address);

            string state;
            if (objCarInfo[0].State.ToLower() != "unspecified")
            {
                state = EmptyCheck(objCarInfo[0].State.ToLower()).Trim();
            }
            else
            {
                state = "";
            }

            hdnCarid.Value = objCarInfo[0].Carid.ToString();
            if (address != "" && address != " " && address != "  " && (city != "" || state != ""))
            {
                address = (address).Trim();
                address += "";
            }
            else
            {
                address = "";
            }

            HtmlMeta tag = new HtmlMeta();

            tag.Name = "keywords";


            // Used Car for Sale, Used <Make> <Model> for Sale, Used <Make> for Sale in <State>
            tag.Content = "Used Car for Sale, Used " + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper() + " for Sale, Used "
                + objCarInfo[0].Make + " for Sale in " + objCarInfo[0].State.ToString().ToUpper() + "";
            //", Sell Cars in " + objCarInfo[0].City + ' ' + objCarInfo[0].State.ToString().ToUpper() + "";
            Header.Controls.Add(tag);


            HtmlMeta tag1 = new HtmlMeta();
            tag1.Name = "description";

            tag1.Content = "Sell Your Used Car " + objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper() + " in " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper() + " for Price - $" + objCarInfo[0].Price.ToString().ToUpper() + " Call to " + objCarInfo[0].Phone.ToString() + " for more details.";
            Header.Controls.Add(tag1);




            if (city != "" && state != "")
            {
                city = (city).Trim();
                city += ", ";
            }
            else
            {
                city = "";
            }

            if (state == "UN" || state == "0")
            {
                state = "";
            }



            //address + ", " + 
            if (Hadd.Value != "true")
            {
                yourZip.Value = EmptyCheck(objCarInfo[0].Zip.ToString());
            }
            lblSellerAddress.Text = EmptyCheck(city + "" + state.ToUpper() + "" + EmptyCheck(objCarInfo[0].Zip.ToString()) + "");
            lblSellerAddress2.Text = EmptyCheck(objCarInfo[0].Address2);
            if (EmptyCheck(objCarInfo[0].Phone.ToString()) != "")
            {
                lblSellerNo.Text = GeneralFunc.FormatUsTelephoneNo(Convert.ToInt64(EmptyCheck(objCarInfo[0].Phone)));
                lblSellerNo2.Text = GeneralFunc.FormatUsTelephoneNo(Convert.ToInt64(EmptyCheck(objCarInfo[0].Phone)));

            }

            Session["CustEmail"] = EmptyCheck(objCarInfo[0].Email);

            lblSellerType.Text = EmptyCheck(objCarInfo[0].SellerType);

            if (objCarInfo[0].Fueltype != "Unspecified")
            {
                lblFuelType.Text = EmptyCheck(objCarInfo[0].Fueltype);

            }
            lblSellerName.Text = EmptyCheck(objCarInfo[0].SellerName);
            zipcode.Value = EmptyCheck(objCarInfo[0].Zip.ToString());




            lblMake.Text = EmptyCheck(objCarInfo[0].Make);
            lblModel.Text = EmptyCheck(objCarInfo[0].Model);

            lblSubTitle.Text = EmptyCheck(objCarInfo[0].Make) + " " + EmptyCheck(objCarInfo[0].Model);

            lblYear.Text = EmptyCheck(objCarInfo[0].YearOfMake.ToString());

            if (objCarInfo[0].Mileage.ToString() != "0")
            {
                lblMileage.Text = EmptyCheck(objCarInfo[0].Mileage.ToString());

            }


            //For inline Adds Displaying data
            try
            {
                bool yearValid = false; bool Sellertype = false;
                String Year = DateTime.Now.Year.ToString();
                if (Convert.ToInt32(Year) >= Convert.ToInt32(objCarInfo[0].YearOfMake.ToString()) && (Convert.ToInt32(Year) - 8) <= Convert.ToInt32(objCarInfo[0].YearOfMake.ToString()))
                {
                    yearValid = true;

                }
                string Seller = objCarInfo[0].SellerType.ToString();
                if (Seller == "Private Seller")
                {
                    Sellertype = true;

                }
                if (Convert.ToInt32(objCarInfo[0].Price.ToString()) < 10000 && yearValid == true && Sellertype == true)
                {
                    LinkAdd1.Visible = true;
                    linkAdd2.Visible = false;
                    LinkAdd3.Visible = false;

                }
                else if (Convert.ToInt32(objCarInfo[0].Price.ToString()) > 10000 && yearValid == true && Sellertype == true)
                {
                    LinkAdd1.Visible = false;
                    linkAdd2.Visible = true;
                    LinkAdd3.Visible = true;

                }
                else
                {
                    LinkAdd1.Visible = false;
                    linkAdd2.Visible = false;
                    LinkAdd3.Visible = false;

                }
            }
            catch { }



            if (objCarInfo[0].ExteriorColor != "Unspecified")
            {
                lblExteriorColor.Text = EmptyCheck(objCarInfo[0].ExteriorColor);
            }
            if (objCarInfo[0].NumberOfCylinder != "Unspecified")
            {
                lblEngine.Text = EmptyCheck(objCarInfo[0].NumberOfCylinder);
            }
            if (objCarInfo[0].InteriorColor != "Unspecified")
            {
                lblInteriorColor.Text = EmptyCheck(objCarInfo[0].InteriorColor);
            }
            if (objCarInfo[0].ConditionDescription != "Unspecified")
            {
                lblVehicleCondition.Text = EmptyCheck(objCarInfo[0].ConditionDescription);
            }

            lblVin.Text = EmptyCheck(objCarInfo[0].VIN);
            if (objCarInfo[0].NumberOfDoors != "Unspecified")
            {
                lblDoors.Text = EmptyCheck(objCarInfo[0].NumberOfDoors);
            }
            if (objCarInfo[0].Bodytype != "Unspecified")
            {
                lblBodyStyle.Text = EmptyCheck(objCarInfo[0].Bodytype);
            }
            if (objCarInfo[0].Transmission != "Unspecified")
            {
                lblTransMission.Text = EmptyCheck(objCarInfo[0].Transmission);
            }

            string s11 = EmptyCheck(objCarInfo[0].Description.ToString());

            lblDescription.Text = Server.HtmlEncode(EmptyCheck(objCarInfo[0].Description));
            lblDescription.Text = lblDescription.Text.Replace("\n", "<br/>");
            if (objCarInfo[0].DriveTrain != "Unspecified")
            {
                lblDriveTrain.Text = EmptyCheck(objCarInfo[0].DriveTrain);
            }

            CarsBL.Transactions.NearZonesBL objNearZonesBL = new CarsBL.Transactions.NearZonesBL();

            DataSet dsCities = new DataSet();


            lblSellarname2.Text = EmptyCheck(objCarInfo[0].SellerName);


            if (EmptyCheck(objCarInfo[0].Phone.ToString()) != "")
            {
                lblphone.Text = GeneralFunc.FormatUsTelephoneNo(Convert.ToInt64(EmptyCheck(objCarInfo[0].Phone)));
            }

            lblPrice3.Text = "$" + (EmptyCheck(objCarInfo[0].Price.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Price.ToString()));

            lblCartitle.Text = objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make.ToString().ToUpper() + ' ' + objCarInfo[0].Model.ToString().ToUpper();

            lblSellarAddress.Text = EmptyCheck(city + "" + state.ToUpper() + "" + EmptyCheck(objCarInfo[0].Zip.ToString()) + "");



            dsCities = objNearZonesBL.GetNearStates(Session["zipId"].ToString());

            //allegan, Michigan (MI); caledonia
            if (dsCities.Tables[0].Rows.Count > 0)
            {
                for (int i = 0; i < dsCities.Tables[0].Rows.Count; i++)
                {
                    Literal Li = new Literal();
                    if (i == dsCities.Tables[0].Rows.Count - 1)
                    {
                        Li.Text = (dsCities.Tables[0].Rows[i][2].ToString()).Trim() + " " + ((dsCities.Tables[0].Rows[i][1].ToString()).Trim()) + "   " + "(" + (dsCities.Tables[0].Rows[i][3].ToString()) + "); ";
                    }
                    else
                    {
                        // Li.Text = (dsCities.Tables[0].Rows[i][2].ToString()).Trim() + "   " + ((dsCities.Tables[0].Rows[i][1].ToString()).Trim()) + "(" + (dsCities.Tables[0].Rows[i][3].ToString()) + "), ";


                        //---- starts 05-08-2013------------//
                        string s = dsCities.Tables[0].Rows[i][1].ToString();

                        s = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());

                        Li.Text = " " + (dsCities.Tables[0].Rows[i][2].ToString()) + "," + s + "  " + "(" + (dsCities.Tables[0].Rows[i][3].ToString()) + "); ";
                        //--------End-----------------------//
                        ///('ul.towns').append('<li class="st">'+$.trim(state[2])+', '+$.trim(state[1])+'('+$.trim(state[3])+');</li>');
                    }
                    ulTowns.Controls.Add(Li);
                }
            }
            GetCarPictures(sCarid);
            try
            {
                lblMileage.Text = lblMileage.Text; // +"mi";
            }
            catch { }
            // ClientScript.RegisterStartupScript(this.GetType(), "KyAUIDFCS", "<script language='javascript' type='text/javascript'>slidershow();</script>");

            CarFeatures objCarFeatures = new CarFeatures();

            DataSet ds = GetCarFeatures(sCarid);

            if (ds != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    dlFeature.DataSource = ds.Tables[0];

                    dlFeature.DataBind();

                }
            }
            //SimialarCars(Hmake.Value, Hmodel.Value, HZip.Value, HPrice.Value);
        }
        else
        {
            Response.Redirect("errorpage.aspx");
        }


    }

    protected void btnAskques_click(object sender, EventArgs e)
    {

        string DiscQuestion = txtAskQuest.Text; string DiscName = "";
        String strHostName = HttpContext.Current.Request.UserHostAddress.ToString();
        string IPAddress = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();
        DateTime DiscDateTime = DateTime.Now; string DiscAnswer = "", DiscAnswerderBy = ""; DateTime DiscAnswerDate = DateTime.Now;
        string sCarid = Session["carid"].ToString();
        string DisMake = lblMake.Text; string DiscModel = lblModel.Text; string DiscYear = lblYear.Text; bool DskDelete = false;
        if (DiscQuestion != null && DiscQuestion.Trim() != "" && DiscQuestion.Trim().Length != 0)
        {
            vstlog.SaveAskQuestion(DiscQuestion, DiscName, IPAddress, DiscDateTime, DiscAnswer, DiscAnswerderBy, DiscAnswerDate,
                sCarid, DisMake, DiscModel, DiscYear, DskDelete);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Your Question is submitted succesfully.');", true);
            txtAskQuest.Text = "";
            Response.Redirect(Request.RawUrl);
        }
        else
        {
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Your Question must be filled.');", true);
            txtAskQuest.Focus();
        }

    }

    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Session[Constants.NAME] = null;
            Response.Cookies["Statuscookie"].Value = "false";
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    public void btnsubscr_click(object sender, EventArgs e)
    {

        //string Pref = "";

        //if (Request.Cookies["PrefCookie"].ToString() != "Pref")
        //{
        //    VisitSiteLog objVisitSiteLog = new VisitSiteLog();
        //    DataSet dsPerformLogin = new DataSet();
        //    if (Request.Cookies["PrefCookie"] != null)
        //    {
        //        Pref = Request.Cookies["PrefCookie"].Value;
        //    }

        //    dsPerformLogin = objVisitSiteLog.RetriveSubInformation(Pref);
        //    if (dsPerformLogin.Tables[0].Rows.Count > 0)
        //    {
        //        FillMakes();
        //        FillWithin();
        //        ddlmakesp.SelectedIndex = 0;
        //        ddlmakesp.SelectedIndex = Convert.ToInt32(dsPerformLogin.Tables[0].Rows[0]["Makeid"].ToString());
        //        ddlmodelsp.Items.Clear();



        //        string[] result = Pref.Split('-');
        //        ddlmodelsp.Items.Insert(0, new ListItem(result[1], "1"));



        //        // ddlmodelsp.SelectedValue =dsPerformLogin.Tables[0].Rows[0]["ModelID"].ToString();
        //        ddlyearp.SelectedValue = dsPerformLogin.Tables[0].Rows[0]["Year"].ToString();
        //        txtfnamep.Text = dsPerformLogin.Tables[0].Rows[0]["FirstName"].ToString();
        //        txtlastnamep.Text = dsPerformLogin.Tables[0].Rows[0]["LastName"].ToString();
        //        txtemail.Text = dsPerformLogin.Tables[0].Rows[0]["Email"].ToString();
        //        //ddlmakesp.SelectedIndex = 0;
        //        //ddlmodelsp.SelectedIndex = 0;
        //        //txtemail.Text = ""; txtfnamep.Text = ""; txtlastnamep.Text = "";
        //        mpesubscribe111.Show();
        //    }
        //    else
        //    {
        //        try
        //        {
        //            ddlmakesp.SelectedIndex = 0;
        //            ddlmodelsp.Items.Clear();
        //            ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));
        //            ddlmodelsp.Enabled = false;
        //            ddlyearp.SelectedIndex = 0;
        //            txtemail.Text = ""; txtfnamep.Text = ""; txtlastnamep.Text = "";
        //        }
        //        catch { }
        //        mpesubscribe111.Show();

        //    }
        //}


        string Pref = "";

        if (Request.Cookies["PrefCookie"].ToString() != "Pref")
        {
            VisitSiteLog objVisitSiteLog = new VisitSiteLog();
            DataSet dsPerformLogin = new DataSet();
            if (Request.Cookies["PrefCookie"] != null)
            {
                Pref = Request.Cookies["PrefCookie"].Value;
            }

            string IsLogornot = "";
            try
            {
                IsLogornot = Session[Constants.USER_ID].ToString();

            }
            catch { }

            if (IsLogornot == "")
            {
                dsPerformLogin = objVisitSiteLog.RetriveSubInformation(Pref);
            }
            else
            {
                dsPerformLogin = objVisitSiteLog.RetriveSubInformation1(Convert.ToInt32(IsLogornot));
            }
            if (dsPerformLogin.Tables[0].Rows.Count > 0)
            {
                FillMakes();
                FillWithin();





                // ddlmodelsp.SelectedValue =dsPerformLogin.Tables[0].Rows[0]["ModelID"].ToString();
                ddlyearp.SelectedValue = dsPerformLogin.Tables[0].Rows[0]["Year"].ToString();
                txtfnamep.Text = dsPerformLogin.Tables[0].Rows[0]["FirstName"].ToString();
                txtlastnamep.Text = dsPerformLogin.Tables[0].Rows[0]["LastName"].ToString();
                txtemail.Text = dsPerformLogin.Tables[0].Rows[0]["Email"].ToString();

                ListItem listState = new ListItem();
                listState.Value = dsPerformLogin.Tables[0].Rows[0]["Makeid"].ToString();
                listState.Text = dsPerformLogin.Tables[0].Rows[0]["make"].ToString();
                ddlmakesp.SelectedIndex = ddlmakesp.Items.IndexOf(listState);

                GetModelsInfo(ddlmakesp.SelectedValue, ddlmodelsp);


                ListItem listState1 = new ListItem();
                listState1.Value = dsPerformLogin.Tables[0].Rows[0]["ModelID"].ToString();
                listState1.Text = dsPerformLogin.Tables[0].Rows[0]["model"].ToString();
                ddlmodelsp.SelectedIndex = ddlmodelsp.Items.IndexOf(listState1);


                ListItem listState2 = new ListItem();
                listState2.Value = dsPerformLogin.Tables[0].Rows[0]["Year"].ToString();
                listState2.Text = dsPerformLogin.Tables[0].Rows[0]["Year"].ToString();
                ddlyearp.SelectedIndex = ddlyearp.Items.IndexOf(listState2);



                //ddlmakesp.SelectedIndex = 0;
                //ddlmodelsp.SelectedIndex = 0;
                //txtemail.Text = ""; txtfnamep.Text = ""; txtlastnamep.Text = "";
                mpesubscribe111.Show();
            }
            else
            {
                try
                {
                    ddlmakesp.SelectedIndex = 0;
                    ddlmodelsp.Items.Clear();
                    ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));
                    ddlmodelsp.Enabled = false;
                    ddlyearp.SelectedIndex = 0;
                    txtemail.Text = ""; txtfnamep.Text = ""; txtlastnamep.Text = "";
                }
                catch { }
                mpesubscribe111.Show();

            }
        }

    }
    protected void ddlmakesp_SelectedIndexChanged1(object sender, EventArgs e)
    {
        string Pref = "";

        if (ddlmakesp.SelectedIndex > 0)
        {
            ddlmodelsp.Enabled = true;
            GetModelsInfo(ddlmakesp.SelectedValue, ddlmodelsp);
        }
        else
        {
            ddlmodelsp.Items.Clear();
            ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));
            ddlmodelsp.Enabled = false;

        }
    }
    private void FillWithin()
    {

        try
        {
            DataSet dsYears = new DataSet();
            if (Session["CarsYears"] == null)
            {
                dsYears = objdropdownBL.GetYears();
                Session["CarsYears"] = dsYears;
            }
            else
            {
                dsYears = Session["CarsYears"] as DataSet;
            }
            ddlyearp.DataSource = dsYears.Tables[0];
            ddlyearp.DataTextField = "Year";
            ddlyearp.DataValueField = "Year";
            ddlyearp.DataBind();
            ddlyearp.Items.Insert(0, new ListItem("Unspecified", "0"));
        }
        catch (Exception ex)
        {
        }
    }

    private void FillModels()
    {

        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Cache["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Cache["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Cache["Model"];
        }

    }
    public void FillMakes()
    {

        try
        {
            var obj = new List<MakesInfo>();


            MakesBL objMakesBL = new MakesBL();
            if (Cache["Makes"] == null)
            {
                obj = (List<MakesInfo>)objMakesBL.GetMakes1();
            }
            else
            {
                obj = (List<MakesInfo>)Cache["Makes"];
            }



            Session["Makes"] = obj;


            ddlmakesp.DataSource = obj;
            ddlmakesp.DataTextField = "Make";
            ddlmakesp.DataValueField = "MakeID";
            ddlmakesp.DataBind();
            ddlmakesp.Items.Insert(0, new ListItem("Select", "0"));



        }
        catch (Exception ex)
        {
        }
    }
    private void GetModelsInfo(string MakeID, DropDownList DdlModel)
    {
        ModelBL objModelBL = new ModelBL();

        var obj = new List<ModelsInfo>();

        if (Cache["Model"] == null)
        {
            obj = (List<ModelsInfo>)objModelBL.GetModels("0");
            Cache["Model"] = obj;
        }
        else
        {
            obj = (List<ModelsInfo>)Cache["Model"];
        }

        ddlmodelsp.Items.Clear();

        ddlmodelsp.Items.Insert(0, new ListItem("Select", "0"));

        ddlmodelsp.DataSource = obj.FindAll(p => p.MakeID == Convert.ToInt32(MakeID));
        ddlmodelsp.DataTextField = "Model";
        ddlmodelsp.DataValueField = "MakeModelID";
        ddlmodelsp.DataBind();


    }
    public void btnSubok_click(object sender, EventArgs e)
    {
        if (ddlmakesp.SelectedValue != "Select")
        {
            if (ddlyearp.SelectedValue != "Select")
            {

                String strHostName = Request.UserHostAddress.ToString();
                string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

                Response.Cookies["PrefCookie"].Value = ddlmakesp.SelectedItem + "- " + ddlmodelsp.SelectedItem + " -" + ddlyearp.Text;
                Session["Pref"] = Response.Cookies["PrefCookie"].Value;
                VisitSiteLog objVisitSiteLog = new VisitSiteLog();
                objVisitSiteLog.SaveSubInformation(Convert.ToInt32(ddlmakesp.SelectedValue), Convert.ToInt32(ddlmodelsp.SelectedValue),
                    Convert.ToInt32(ddlyearp.SelectedValue), txtfnamep.Text, txtlastnamep.Text, txtemail.Text, strIp, DateTime.Now, Session["Pref"].ToString());
                //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "EmailNAClick();", true);
                mpesubscribe111.Hide();
                System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('You are subscribed suceessfully for email alerts.');", true);

            }
        }

    }

    public void btncancelp_click(object sender, EventArgs e)
    {
        mpesubscribe111.Hide();
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "resetTimer();", true);
    }
    protected void rptquestion_DataBinding(object sender, EventArgs e)
    {

    }
    protected void rptquestion_ItemDataBound1(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            DataSet dsTasks3 = (DataSet)Session["Discusins"];
            Label lblPublishpostdate = (Label)e.Item.FindControl("lblPublishpostdate");
            lblPublishpostdate.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscAnswerDate"].ToString();
            if (dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["PublishedDate"].ToString() != null)
                lblPublishpostdate.Text += "  Published on: " + dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["PublishedDate"].ToString();

        }
    }
    public void btncancelpopclick_click(object sender, EventArgs e)
    {
        MdlBuyacar.Hide();
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "resetTimer();", true);
    }


    public void btnDetailClick_Click(object sender, EventArgs e)
    {
        try
        {
            txt_DEmail.Text = "";
            txt_DFrstName.Text = "";
            txt_Dlastname.Text = "";
            txt_DPhn.Text = "";
            String strHostName = Request.UserHostAddress.ToString();
            string strIp = System.Net.Dns.GetHostAddresses(strHostName).GetValue(0).ToString();

            Response.Cookies["PrefCookie"].Value = ddlmakesp.SelectedItem + "- " + ddlmodelsp.SelectedItem + " -" + ddlyearp.Text;
            Session["Pref"] = Response.Cookies["PrefCookie"].Value;
            VisitSiteLog objVisitSiteLog = new VisitSiteLog();
            string cat = Session["carid"].ToString();
            objVisitSiteLog.InsertSimlarCarPref(Session["carid"].ToString(), txt_DFrstName.Text, txt_Dlastname.Text, txt_DEmail.Text,
                txt_DPhn.Text, strIp, DateTime.Now);
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "EmailNAClick();", true);
            mdlPDetalerts.Hide();
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('You are subscribed suceessfully for email alerts.');", true);


        }
        catch { }
    }


    public void btnDetCancelClick_click(object sender, EventArgs e)
    {
        mdlPDetalerts.Hide();

    }
}
