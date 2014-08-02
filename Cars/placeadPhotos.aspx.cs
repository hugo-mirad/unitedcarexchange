﻿using System;
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
using CarsInfo;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

public partial class placeadPhotos : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session[Constants.NAME] == null) // if (Session[Constants.NAME] != null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            // if (!IsPostBack)
            // {

            hdnSubAlert.Value = "true";

            lblpackagename2.Text = Session["PackgeName"].ToString();
            lblpckgprice.Text = Session["PackgePrice"].ToString();

            lblSname.Text = Session["sName"].ToString();
            lblSmail.Text = Session["sEmail"].ToString();
            lblSphone.Text = Session["sPhone"].ToString();

            lblSyear.Text = Session["SelYear"].ToString();
            lblSmake.Text = Session["SelMake"].ToString();
            lblSmodel.Text = Session["SelModel"].ToString();
            lblSprice.Text = Session["SelPrice"].ToString();



            Session["CurrentPage"] = "";
            Session["PageName"] = "";
            Session["CurrentPageConfig"] = null;


            GeneralFunc.SetPageDefaults(Page);

            ServiceReference objServiceReference = new ServiceReference();

            ScriptReference objScriptReference = new ScriptReference();

            objServiceReference.Path = "~/CarsService.asmx";

            objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

            scrptmgr.Services.Add(objServiceReference);
            scrptmgr.Scripts.Add(objScriptReference);

            hdnYear.Value = Session["SelYear"].ToString();
            hdnMake.Value = Session["SelMake"].ToString();
            hdnModel.Value = Session["SelModel"].ToString();
            hdnId.Value = Session["CarID"].ToString();



            int getPackageID = Convert.ToInt32(Session["PackageID"].ToString());
            DataSet dsImages = objdropdownBL.USP_GetImages(Convert.ToInt32(Session["CarID"].ToString()), getPackageID);
            Session["GetImages"] = dsImages;
            Session["MaxPhotos"] = dsImages.Tables[1].Rows[0]["Maxphotos"].ToString();
            MaxPhotos.Value = dsImages.Tables[1].Rows[0]["Maxphotos"].ToString();

            //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "maxPhotos();", true);
            btnContinue.Text = "Add Photos Later >";
            //lblUserName.Text = Session[Constants.NAME].ToString();

            //  DisplayImages(dsImages);

            try
            {
                lblUserName.Text = Session[Constants.NAME].ToString();
            }
            catch { }




            //}
        }
    }


    private void DisplayImages(DataSet dsImages)
    {
        try
        {
            int TotalImgCount = Convert.ToInt32(Session["MaxPhotos"].ToString());

            for (int i = 1; i < TotalImgCount + 1; i++)
            {
                string RowIDName = "trImg" + i.ToString();
                System.Web.UI.HtmlControls.HtmlTableRow RowID = (System.Web.UI.HtmlControls.HtmlTableRow)form1.FindControl(RowIDName);
                RowID.Style["display"] = "block";
                string ImgID = "Img" + i.ToString();
                string ColumnPic = "pic" + i.ToString();
                string ColumnPicName = "pic" + i.ToString() + "Name";
                string ColumnPicLocation = "Pic" + i.ToString() + "Loc";
                System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                string SelModelDis = Session["SelModel"].ToString();
                SelModelDis = SelModelDis.Replace("/", "@");
                SelModelDis = SelModelDis.Replace("&", "@");
                if (dsImages.Tables[0].Rows[0][ColumnPic].ToString() != "0" && dsImages.Tables[0].Rows[0][ColumnPic].ToString() != "")
                {

                    ImageName.Visible = true;
                    ImageName.ImageUrl = "http://images.mobicarz.com/" + dsImages.Tables[0].Rows[0][ColumnPicLocation].ToString() + dsImages.Tables[0].Rows[0][ColumnPicName].ToString();
                }
                else
                {
                    ImageName.Visible = false;
                    //ButtonName.Visible = false;
                }
            }



        }
        catch (Exception ex)
        {
        }
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {

        // ScriptManager.RegisterStartupScript(this, GetType(), "showalert", "alert('Only alert Message');", true);
        mdepEditSuccess.Show();


    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            mdepEditSuccess.Show();
        }
        catch (Exception ex)
        {
        }
    }
    protected void imageOrder_Click(object sender, EventArgs e)
    {
        try
        {
            string CarID = hdnCarID.Value;
            string Make = hdnMake.Value;
            string Model = hdnModel.Value;
            string Year = hdnYear.Value;
            string Pic0 = hdnPic0.Value;
            string Pic1 = hdnPic1.Value;
            string Pic2 = hdnPic2.Value;
            string Pic3 = hdnPic3.Value;
            string Pic4 = hdnPic4.Value;
            string Pic5 = hdnPic5.Value;
            string Pic6 = hdnPic6.Value;
            string Pic7 = hdnPic7.Value;
            string Pic8 = hdnPic8.Value;
            string Pic9 = hdnPic9.Value;
            string Pic10 = hdnPic10.Value;
            string Pic11 = hdnPic11.Value;
            string Pic12 = hdnPic12.Value;
            string Pic13 = hdnPic13.Value;
            string Pic14 = hdnPic14.Value;
            string Pic15 = hdnPic15.Value;
            string Pic16 = hdnPic16.Value;
            string Pic17 = hdnPic17.Value;
            string Pic18 = hdnPic18.Value;
            string Pic19 = hdnPic19.Value;
            string Pic20 = hdnPic20.Value;

            DataSet dsImagesData = objdropdownBL.USP_GetImages(Convert.ToInt32(hdnId.Value), 7);

            //DataSet dsImagesData = Session["GetImages"] as DataSet;
            CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();

            objcarsInfo.Pic0 = dsImagesData.Tables[0].Rows[0]["pic0"].ToString();
            objcarsInfo.Pic1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            objcarsInfo.Pic2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            objcarsInfo.Pic3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            objcarsInfo.Pic4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            objcarsInfo.Pic5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            objcarsInfo.Pic6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            objcarsInfo.Pic7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            objcarsInfo.Pic8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            objcarsInfo.Pic9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            objcarsInfo.Pic10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            objcarsInfo.Pic11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            objcarsInfo.Pic12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            objcarsInfo.Pic13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            objcarsInfo.Pic14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            objcarsInfo.Pic15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            objcarsInfo.Pic16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            objcarsInfo.Pic17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            objcarsInfo.Pic18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            objcarsInfo.Pic19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            objcarsInfo.Pic20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();

            if ((Pic1 != null) && (Pic1 != "") && (Pic1 != "0"))
            {
                if (objcarsInfo.Pic1 != Pic1)
                {

                    // @"C:/Inetpub/wwwroot/COMMONIMAGES/CarImages/


                    DataSet dsdata = objdropdownBL.GetPictureLocationByID1(Pic1);
                    string FileNameSaveData1 = @"C:/Inetpub/wwwroot/COMMONIMAGES/" + dsdata.Tables[0].Rows[0]["picturelocation"].ToString() + dsdata.Tables[0].Rows[0]["picturename"].ToString();
                  //   string FileNameSaveData12 = Server.MapPath(dsdata.Tables[0].Rows[0]["picturelocation"].ToString() + dsdata.Tables[0].Rows[0]["picturename"].ToString());
                    string FileNameSaveData = dsdata.Tables[0].Rows[0]["picturelocation"].ToString() + dsdata.Tables[0].Rows[0]["picturename"].ToString();
                    System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img1");
                   // Image1.ImageUrl = "~/" + FileNameSaveData;
                    Image1.ImageUrl =  FileNameSaveData;
                    string SavePath = dsdata.Tables[0].Rows[0]["picturelocation"].ToString();
                    //string path = Server.MapPath(Image1.ImageUrl);
                    string path = @"C:/Inetpub/wwwroot/COMMONIMAGES/" + Image1.ImageUrl;
                    //string path = Server.MapPath(ImageName.ImageUrl);
                    string SelModelName = Model.ToString();
                    SelModelName = SelModelName.Replace("/", "@");
                    SelModelName = SelModelName.Replace("&", "@");
                    SelModelName = SelModelName.Replace(" ", "-");
                    string FileNameThumb = Year + "_" + Make + "_" + SelModelName + "_" + CarID + "_Thumb.jpg";
                   // string FileNameFullThumb = Server.MapPath("~/" + dsdata.Tables[0].Rows[0]["picturelocation"].ToString());
                    string FileNameFullThumb = @"C:/Inetpub/wwwroot/COMMONIMAGES/" + dsdata.Tables[0].Rows[0]["picturelocation"].ToString();
                     
                    System.Drawing.Image image = System.Drawing.Image.FromFile(path);
                    //int newwidthimg = 250;
                    //float AspectRatio = (float)image.Size.Width / (float)image.Size.Height;
                    //int newHeight = Convert.ToInt32(newwidthimg / AspectRatio);
                    //Bitmap thumbnailBitmap = new Bitmap(newwidthimg, newHeight);
                    //Graphics thumbnailGraph = Graphics.FromImage(thumbnailBitmap);
                    //thumbnailGraph.CompositingQuality = CompositingQuality.HighQuality;
                    //thumbnailGraph.SmoothingMode = SmoothingMode.HighQuality;
                    //thumbnailGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    //var imageRectangle = new Rectangle(0, 0, newwidthimg, newHeight);
                    //thumbnailGraph.DrawImage(image, imageRectangle);
                    //thumbnailBitmap.Save(SavePath, ImageFormat.Jpeg);
                    //thumbnailGraph.Dispose();
                    //thumbnailBitmap.Dispose();
                    //image.Dispose();
                    //if (System.IO.Directory.Exists(FileNameSaveData1) == false)
                    //{
                    //    System.IO.Directory.CreateDirectory(FileNameSaveData1);
                    //}

                    Bitmap oBitmap1 = default(Bitmap);
                    oBitmap1 = new Bitmap(path);
                    Graphics oGraphic1 = default(Graphics);

                    int newwidthimg1 = 250;
                    // Here create a new bitmap object of the same height and width of the image.
                    //float AspectRatio = (float)oBitmap.Size.Width / (float)oBitmap.Size.Height;
                    float AspectRatio1 = (float)oBitmap1.Size.Width / (float)oBitmap1.Size.Height;

                    int newHeight1 = Convert.ToInt32(newwidthimg1 / AspectRatio1);

                    Bitmap bmpNew1 = new Bitmap(newwidthimg1, newHeight1);
                    oGraphic1 = Graphics.FromImage(bmpNew1);

                    oGraphic1.CompositingQuality = CompositingQuality.HighQuality;
                    oGraphic1.SmoothingMode = SmoothingMode.HighQuality;
                    oGraphic1.InterpolationMode = InterpolationMode.HighQualityBicubic;


                    oGraphic1.DrawImage(oBitmap1, new Rectangle(0, 0, bmpNew1.Width, bmpNew1.Height), 0, 0, oBitmap1.Width, oBitmap1.Height, GraphicsUnit.Pixel);
                    // Release the lock on the image file. Of course,
                    // image from the image file is existing in Graphics object
                    oBitmap1.Dispose();
                    oBitmap1 = bmpNew1;

                    //SolidBrush oBrush = new SolidBrush(Color.Black);
                    //Font ofont = new Font("Arial", 8);
                    //oGraphic.DrawString("Some text to write", ofont, oBrush, 10, 10);
                    //oGraphic.Dispose();
                    //ofont.Dispose();
                    //oBrush.Dispose();
                    oBitmap1.Save(FileNameFullThumb + FileNameThumb, ImageFormat.Jpeg);

                    oBitmap1.Dispose();


                    DataSet dsImgID1 = objdropdownBL.USP_SavePictures(SavePath, FileNameThumb, "Jpeg", Convert.ToInt32(Session[Constants.USER_ID].ToString()));

                    objcarsInfo.Pic0 = dsImgID1.Tables[0].Rows[0]["picID"].ToString();

                }
                objcarsInfo.Pic1 = Pic1;
            }
            else
            {
                objcarsInfo.Pic0 = "";
                objcarsInfo.Pic1 = "";
            }
            if ((Pic2 != null) && (Pic2 != "") && (Pic2 != "0"))
            {
                objcarsInfo.Pic2 = Pic2;
            }
            else
            {
                objcarsInfo.Pic2 = "";
            }
            if ((Pic3 != null) && (Pic3 != "") && (Pic3 != "0"))
            {
                objcarsInfo.Pic3 = Pic3;
            }
            else
            {
                objcarsInfo.Pic3 = "";
            }
            if ((Pic4 != null) && (Pic4 != "") && (Pic4 != "0"))
            {
                objcarsInfo.Pic4 = Pic4;
            }
            else
            {
                objcarsInfo.Pic4 = "";
            }
            if ((Pic5 != null) && (Pic5 != "") && (Pic5 != "0"))
            {
                objcarsInfo.Pic5 = Pic5;
            }
            else
            {
                objcarsInfo.Pic5 = "";
            }
            if ((Pic6 != null) && (Pic6 != "") && (Pic6 != "0"))
            {
                objcarsInfo.Pic6 = Pic6;
            }
            else
            {
                objcarsInfo.Pic6 = "";
            }
            if ((Pic7 != null) && (Pic7 != "") && (Pic7 != "0"))
            {
                objcarsInfo.Pic7 = Pic7;
            }
            else
            {
                objcarsInfo.Pic7 = "";
            }
            if ((Pic8 != null) && (Pic8 != "") && (Pic8 != "0"))
            {
                objcarsInfo.Pic8 = Pic8;
            }
            else
            {
                objcarsInfo.Pic8 = "";
            }
            if ((Pic9 != null) && (Pic9 != "") && (Pic9 != "0"))
            {
                objcarsInfo.Pic9 = Pic9;
            }
            else
            {
                objcarsInfo.Pic9 = "";
            }
            if ((Pic10 != null) && (Pic10 != "") && (Pic10 != "0"))
            {
                objcarsInfo.Pic10 = Pic10;
            }
            else
            {
                objcarsInfo.Pic10 = "";
            }
            if ((Pic11 != null) && (Pic11 != "") && (Pic11 != "0"))
            {
                objcarsInfo.Pic11 = Pic11;
            }
            else
            {
                objcarsInfo.Pic11 = "";
            }
            if ((Pic12 != null) && (Pic12 != "") && (Pic12 != "0"))
            {
                objcarsInfo.Pic12 = Pic10;
            }
            else
            {
                objcarsInfo.Pic12 = "";
            }
            if ((Pic13 != null) && (Pic13 != "") && (Pic13 != "0"))
            {
                objcarsInfo.Pic13 = Pic13;
            }
            else
            {
                objcarsInfo.Pic13 = "";
            }
            if ((Pic14 != null) && (Pic14 != "") && (Pic14 != "0"))
            {
                objcarsInfo.Pic14 = Pic14;
            }
            else
            {
                objcarsInfo.Pic14 = "";
            }
            if ((Pic15 != null) && (Pic15 != "") && (Pic15 != "0"))
            {
                objcarsInfo.Pic15 = Pic15;
            }
            else
            {
                objcarsInfo.Pic15 = "";
            }
            if ((Pic16 != null) && (Pic16 != "") && (Pic16 != "0"))
            {
                objcarsInfo.Pic16 = Pic16;
            }
            else
            {
                objcarsInfo.Pic16 = "";
            }
            if ((Pic17 != null) && (Pic17 != "") && (Pic17 != "0"))
            {
                objcarsInfo.Pic17 = Pic17;
            }
            else
            {
                objcarsInfo.Pic17 = "";
            }
            if ((Pic18 != null) && (Pic18 != "") && (Pic18 != "0"))
            {
                objcarsInfo.Pic18 = Pic18;
            }
            else
            {
                objcarsInfo.Pic18 = "";
            }
            if ((Pic19 != null) && (Pic19 != "") && (Pic19 != "0"))
            {
                objcarsInfo.Pic19 = Pic19;
            }
            else
            {
                objcarsInfo.Pic19 = "";
            }
            if ((Pic20 != null) && (Pic20 != "") && (Pic20 != "0"))
            {
                objcarsInfo.Pic20 = Pic20;
            }
            else
            {
                objcarsInfo.Pic20 = "";
            }
            objcarsInfo.CarID = Convert.ToInt32(hdnId.Value);
            bool bnew = objdropdownBL.USP_UpdatePicturesById(objcarsInfo, Convert.ToInt32(Session[Constants.USER_ID].ToString()));
            btnContinue.Text = "Continue >";
        }
        catch (Exception ex)
        {

        }
    }
    protected void btnAskYes_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("PaymentMode.aspx");
            //Response.Redirect("PlaceAdbankdetails1.aspx");
        }
        catch (Exception ex)
        {
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("account.aspx");
        }
        catch (Exception ex)
        {

        }
    }
}