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
    public GeneralFunc objGeneralFunc = new GeneralFunc();
    int p = 0;

    int rowcount = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
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
                if(strCarid.Length >= 4)
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

                        if (GeneralFunc.IsNumeric(sCarid))
                        {

                            if (Request.Cookies.Get("UserSettings") == null)
                            {
                                // ClientScript.RegisterStartupScript(typeof(Page), "KyAUIDFCS", "<script language='javascript' type='text/javascript'>Subscribe();</script>");

                            }


                            objCarInfo = obj.FindCarIDNew(sCarid);

                            FillCarDetails(objCarInfo, sCarid);
                           
                        }
                    }
                }
            }
            else
            {
                Response.Redirect("errorpage.aspx");
            }
        }
    }



    private void SimialarCars(string MakeId, string ModelID, string zipcode, string Price)
    {

        CarsBL.UsedCarsSearch objCarsearch = new CarsBL.UsedCarsSearch();


        var obj = new List<CarsInfo.UsedCarsInfo>();


        obj = (List<CarsInfo.UsedCarsInfo>)objCarsearch.SimialarCars(MakeId, ModelID, zipcode, Price);


        dlSimilarResults.DataSource = obj;

        Session["SimilarResults"] = obj;


        dlSimilarResults.DataBind();


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
                        StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";


                        //dsPicsNew.Tables[0].Rows.Add();
                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = "";
                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = "";
                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICPATH"] = StockUrl;
                    }

                    else
                    {
                        //dsPicsNew.Tables[0].Rows.Add();
                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PIC"] = dsPics.Tables[0].Rows[0]["PIC" + i].ToString();
                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICLOC"] = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString();

                        var path = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString() + "/" + dsPics.Tables[0].Rows[0]["PIC" + i].ToString();


                        path = path.Replace("//", "/");
                        StockUrl = "http://www.UnitedCarExchange.com/" + path;

                        //dsPicsNew.Tables[0].Rows[dsPicsNew.Tables[0].Rows.Count - 1]["PICPATH"] = path;
                    }
                    img.ImageUrl = StockUrl;
                }
                else
                {
                    var path = dsPics.Tables[0].Rows[0]["PICLOC" + i].ToString() + "/" + dsPics.Tables[0].Rows[0]["PIC" + i].ToString();


                    path = path.Replace("//", "/");
                    path = "http://www.UnitedCarExchange.com/" + path;

                    if (path != "http://www.UnitedCarExchange.com//")
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
                msg.CC.Add("info@unitedcarexchange.com");
                msg.Bcc.Add(CommonVariable.ArchieveMail);
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
                //smtp.Credentials = new System.Net.NetworkCredential("satheesh.aakula@gmail.com", "hugomirad");
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
    protected void dlSimilarResults_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    protected void dlSimilarResults_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            var obj = new List<CarsInfo.UsedCarsInfo>();

            obj = (List<CarsInfo.UsedCarsInfo>)Session["SimilarResults"];

            Label sTitle = (Label)e.Item.FindControl("sTitle");
            LinkButton lnkTitle = (LinkButton)e.Item.FindControl("lnkTitle");


            if (obj[rowcount].Title != "Emp")
            {
                sTitle.Text = EmptyCheck(obj[rowcount].Title);
            }
            else
            {
                sTitle.Text = GeneralFunc.WrapTextByMaxCharacters((obj[rowcount].YearOfMake.ToString() + ' ' + obj[rowcount].Make + ' ' + obj[rowcount].Model).ToString().ToUpper(), 30);
            }



            lnkTitle.PostBackUrl = "http://UnitedCarExchange.com/Buy-Sell-UsedCar/" + obj[rowcount].YearOfMake.ToString() + "-" + obj[rowcount].Make + '-' + obj[rowcount].Model.Replace("&", "-") + '-' + obj[rowcount].CarUniqueID;


            string StockUrl = string.Empty;

            if (obj[rowcount].PIC0.ToString().Trim() == "" && obj[rowcount].PICLOC0.ToString().Trim() == "")
            {
                string StockMake = obj[rowcount].Make.ToString();
                StockMake = StockMake.Replace(" ", "-");
                StockMake = StockMake.Replace("/", "@");
                StockMake = StockMake.Replace("&", "@");
                string StockType = obj[rowcount].Model.ToString().Replace('&', '@');
                StockType = StockType.Replace("/", "@");
                StockType = StockType.Replace(" ", "-");
                StockUrl = "http://UnitedCarExchange.com/images/MakeModelThumbs/" + StockMake + "_" + StockType + ".jpg";
            }

            else
            {

                var path = obj[rowcount].PICLOC0.ToString() + "/" + obj[rowcount].PIC0.ToString();
                path = path.Replace("//", "/");
                StockUrl = "http://www.UnitedCarExchange.com/" + path;
            }
            Image imgSimliar = (Image)e.Item.FindControl("imgSimliar");

            imgSimliar.ImageUrl = StockUrl;

            imgSimliar.DescriptionUrl = "http://UnitedCarExchange.com/Buy-Sell-UsedCar/" + obj[rowcount].YearOfMake.ToString() + "-" + obj[rowcount].Make + '-' + obj[rowcount].Model.Replace("&", "-") + '-' + obj[rowcount].CarUniqueID;

            string m = string.Empty;

            string p = obj[rowcount].ExteriorColor;

            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].ExteriorColor;
                m += ", ";
            }
            p = obj[rowcount].NumberOfDoors;
            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].NumberOfDoors;
                m += ", ";
            }
            p = obj[rowcount].NumberOfSeats;
            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].NumberOfSeats;
                m += ", ";
            }
            p = obj[rowcount].NumberOfCylinder;
            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].NumberOfCylinder;
                m += ", ";
            }
            p = obj[rowcount].Transmission;

            if (p != "Emp" && p != "Unspecified")
            {
                m += obj[rowcount].Transmission;
            }

            rowcount += 1;
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

                    lblCarsoldStatus.Text = "This car is in " + objCarInfo[0].AdStatus + " status!";
                    mailsend.Visible = false;
                    //return;
                }



                Session["zipId"] = objCarInfo[0].Zip;
                //yourZip.Value = objCarInfo[0].Zip;

                Title = "Buy Sell Used Cars " + (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper() + " in  " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper();

                if (objCarInfo[0].Title != "Emp")
                {
                    //Title = "Buy " + lblTitle.Text.ToString() + " at UnitedCarExchange.com";
                    //lblTitle.Text = "Buy Sell Used " + EmptyCheck(objCarInfo[0].Title) + "in" + objCarInfo[0].City.ToString().ToUpper() + "," + objCarInfo[0].State.ToString().ToUpper();
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

                Title = "Buy Sell Used Cars " + (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper() + " in  " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper();

                if (objCarInfo[0].Title != "Emp")
                {
                    //Title = "Buy " + lblTitle.Text.ToString() + " at UnitedCarExchange.com";
                    //lblTitle.Text = "Buy Sell Used " + EmptyCheck(objCarInfo[0].Title) + "in" + objCarInfo[0].City.ToString().ToUpper() + "," + objCarInfo[0].State.ToString().ToUpper();
                    lblTitle.Text = EmptyCheck(objCarInfo[0].Title);
                }
                else
                {
                    lblTitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
                }
            }




            Session["zipId"] = objCarInfo[0].Zip;

            Title = "Buy Sell Used Cars " + (objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper() + " in  " + objCarInfo[0].City.ToString().ToUpper() + ", " + objCarInfo[0].State.ToString().ToUpper();

            if (objCarInfo[0].Title != "Emp")
            {
                //Title = "Buy " + lblTitle.Text.ToString() + " at UnitedCarExchange.com";
                //lblTitle.Text = "Buy Sell Used " + EmptyCheck(objCarInfo[0].Title) + "in" + objCarInfo[0].City.ToString().ToUpper() + "," + objCarInfo[0].State.ToString().ToUpper();
                lblTitle.Text = EmptyCheck(objCarInfo[0].Title);
                LabelSubtitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
            }
            else
            {
                //Main Title
                lblTitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
                LabelSubtitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);

                //try
                //{
                //    DbDataReader dr;
                //    string spNameString = string.Empty;
                //    Database dbDatabase = DatabaseFactory.CreateDatabase(Global.INSTANCE_NAME);
                //    spNameString = "[Usp_Caption]";
                //    DbCommand dbCommand = null;
                //    dbCommand = dbDatabase.GetStoredProcCommand(spNameString);

                  
                //    dbDatabase.AddInParameter(dbCommand, "@CarID", DbType.Int64, sCarid);
                //    IDataReader iDR = dbDatabase.ExecuteReader(dbCommand);
                //    dr = (SqlDataReader)iDR;

                //    if (dr.Read())
                //    {
                //        LabelSubtitle.Text = dr["Caption"].ToString();

                //    }
                //    else
                //    {
                //        lblTitle.Text = GeneralFunc.WrapTextByMaxCharacters((objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model).ToString().ToUpper(), 30);
                //    }
                //    dr.Close();
                //}
                //catch { }
               
            }

            if (objCarInfo[0].Price.ToString() != "0")
            {
                lblPrice1.Text = "-$" + (EmptyCheck(objCarInfo[0].Price.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Price.ToString()));

                lblPrice.Text = "$" + (EmptyCheck(objCarInfo[0].Price.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Price.ToString()));
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
            //tag.Content = "Buy " + lblTitle.Text.ToString() + " at UnitedCarExchange.com";
            tag.Content = "Buy Used Cars, Sell Used Cars, Buy Used " + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper() + " Car, Sell "
                + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper()
                + " Car, Buy Cars in " + objCarInfo[0].City + ' ' + objCarInfo[0].State.ToString().ToUpper() +
                ", Sell Cars in " + objCarInfo[0].City + ' ' + objCarInfo[0].State.ToString().ToUpper() + "";
            Header.Controls.Add(tag);


            HtmlMeta tag1 = new HtmlMeta();
            tag1.Name = "description";
            //tag1.Content = EmptyCheck(objCarInfo[0].Description);
            tag1.Content = "Buy or Sell Used Cars " + objCarInfo[0].YearOfMake.ToString() + ' ' + objCarInfo[0].Make + ' ' + objCarInfo[0].Model.ToString().ToUpper() + " in " + objCarInfo[0].City.ToString().ToUpper() + "," + objCarInfo[0].State.ToString().ToUpper() + " for Price - " + objCarInfo[0].Price.ToString().ToUpper() + " Buy or Sell Used Cars at UnitedCarExchange.com";
            Header.Controls.Add(tag1);


            // Page.Controls.Add(header); 

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
            if (Hadd.Value != "true") {
                yourZip.Value = EmptyCheck(objCarInfo[0].Zip.ToString());
            }
            lblSellerAddress.Text = EmptyCheck(city + "" + state.ToUpper() + "" + EmptyCheck(objCarInfo[0].Zip.ToString()) + "");
            lblSellerAddress2.Text = EmptyCheck(objCarInfo[0].Address2);
            if (EmptyCheck(objCarInfo[0].Phone.ToString()) != "")
            {
                lblSellerNo.Text = GeneralFunc.FormatUsTelephoneNo(Convert.ToInt64(EmptyCheck(objCarInfo[0].Phone)));
            }
            //lblSellerEmail.Value= EmptyCheck(objCarInfo[0].Email);

            Session["CustEmail"] = EmptyCheck(objCarInfo[0].Email);

            lblSellerType.Text = EmptyCheck(objCarInfo[0].SellerType);

            if (objCarInfo[0].Fueltype != "Unspecified")
            {
                lblFuelType.Text = EmptyCheck(objCarInfo[0].Fueltype);
            }

            lblSellerName.Text = EmptyCheck(objCarInfo[0].SellerName);

            zipcode.Value = EmptyCheck(objCarInfo[0].Zip.ToString());

            //lblSellerAddress.Text = EmptyCheck(objCarInfo[0].Address1);

            //lblAxle.Text = (EmptyCheck(objCarInfo[0].Axle.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Axle.ToString()));


            lblMake.Text = EmptyCheck(objCarInfo[0].Make);

            lblModel.Text = EmptyCheck(objCarInfo[0].Model);

            lblSubTitle.Text = EmptyCheck(objCarInfo[0].Make) + " " + EmptyCheck(objCarInfo[0].Model);

            lblYear.Text = EmptyCheck(objCarInfo[0].YearOfMake.ToString());

            if (objCarInfo[0].Mileage.ToString() != "0")
            {
                lblMileage.Text = EmptyCheck(objCarInfo[0].Mileage.ToString()) + " miles";
                
            }

            //SimialarCars(objCarInfo[0].MakeID.ToString(), objCarInfo[0].MakeModelID.ToString(), objCarInfo[0].Zipcode.ToString(), objCarInfo[0].Price.ToString());

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


            //lblAxle.Text = EmptyCheck(objCarInfo[0].Axle);

            //lblType.Text = EmptyCheck(objCarInfo[0].TypeName);

            //lblCategory.Text = EmptyCheck(objCarInfo[0].Category);
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

            //lblRear.Text = (EmptyCheck(objCarInfo[0].Rear.ToString()) == "" ? "0" : EmptyCheck(objCarInfo[0].Rear.ToString()));

            lblDescription.Text = Server.HtmlEncode(EmptyCheck(objCarInfo[0].Description));
            if (objCarInfo[0].DriveTrain != "Unspecified")
            {
                lblDriveTrain.Text = EmptyCheck(objCarInfo[0].DriveTrain);
            }

            CarsBL.Transactions.NearZonesBL objNearZonesBL = new CarsBL.Transactions.NearZonesBL();

            DataSet dsCities = new DataSet();

            //if (Session["zipId"] != null)
            //{
            //    dsCities = objNearZonesBL.GetNearCities(Session["zipId"].ToString());

            //    if (dsCities.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dsCities.Tables[0].Rows.Count; i++)
            //        {
            //            if (i == 0)
            //            {
            //                lblNearbyzipcodes.Text = dsCities.Tables[0].Rows[i][1].ToString();
            //            }
            //            else
            //            {
            //                lblNearbyzipcodes.Text = lblNearbyzipcodes.Text + ',' + dsCities.Tables[0].Rows[i][1].ToString();
            //            }
            //        }

            //    }
            //}
            //if (Session["zipId"] != null)
            //{
            //    dsCities = objNearZonesBL.GetNearCities(Session["zipId"].ToString());

            //    if (dsCities.Tables[0].Rows.Count > 0)
            //    {
            //        for (int i = 0; i < dsCities.Tables[0].Rows.Count; i++)
            //        {
            //            Literal Li = new Literal();
            //            if (i == 0)
            //            {
            //                lblNearbyzipcodes.Text = dsCities.Tables[0].Rows[i][1].ToString();


            //            }
            //            else
            //            {
            //                lblNearbyzipcodes.Text = lblNearbyzipcodes.Text + ", " + dsCities.Tables[0].Rows[i][1].ToString();


            //            }

            //        }

            //    }
            //}

            //lblsellerName1.Text = objCarInfo[0].SellerName;
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
                        Li.Text = (dsCities.Tables[0].Rows[i][2].ToString()).Trim() + " " + ((dsCities.Tables[0].Rows[i][1].ToString()).Trim()) +"   " +"(" + (dsCities.Tables[0].Rows[i][3].ToString()) + "); ";
                    }
                    else
                    {
                       // Li.Text = (dsCities.Tables[0].Rows[i][2].ToString()).Trim() + "   " + ((dsCities.Tables[0].Rows[i][1].ToString()).Trim()) + "(" + (dsCities.Tables[0].Rows[i][3].ToString()) + "), ";


                        //---- starts 05-08-2013------------//
                        string s = dsCities.Tables[0].Rows[i][1].ToString();

                        s = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());

                        Li.Text = " "+(dsCities.Tables[0].Rows[i][2].ToString()) + "," + s + "  "+"(" + (dsCities.Tables[0].Rows[i][3].ToString()) + "); ";
                        //--------End-----------------------//
                        ///('ul.towns').append('<li class="st">'+$.trim(state[2])+', '+$.trim(state[1])+'('+$.trim(state[3])+');</li>');
                    }
                    ulTowns.Controls.Add(Li);
                }
            }
            GetCarPictures(sCarid);
            try
            {
                lblMileage.Text = lblMileage.Text + "mi";
            }
            catch { }
            ClientScript.RegisterStartupScript(this.GetType(), "KyAUIDFCS", "<script language='javascript' type='text/javascript'>slidershow();</script>");

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


        }
        else
        {
            Response.Redirect("errorpage.aspx");
        }


    }

}


