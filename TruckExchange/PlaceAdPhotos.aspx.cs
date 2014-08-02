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
using CarsInfo;
using System.Collections.Generic;
using CarsBL.Masters;
using System.Web.UI.MobileControls;
using System.Drawing.Imaging;
using System.Drawing;
using System.Drawing.Drawing2D;

public partial class PlaceAdPhotos : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();
    BankDetailsBL objBankDetailsBL = new BankDetailsBL();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session[Constants.NAME] == null)
        {
            Response.Redirect("Default.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                Session["CurrentPage"] = "Home";
                Session["PageName"] = "";
                Session["CurrentPageConfig"] = null;


                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScript.js";

                scrptmgr.Services.Add(objServiceReference);
                scrptmgr.Scripts.Add(objScriptReference);


                int getPackageID = Convert.ToInt32(Session["PackageID"].ToString());
                DataSet dsImages = objdropdownBL.USP_GetImages(Convert.ToInt32(Session["CarID"].ToString()), getPackageID);
                Session["GetImages"] = dsImages;
                Session["MaxPhotos"] = dsImages.Tables[1].Rows[0]["Maxphotos"].ToString();
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "success", "maxPhotos();", true);
                btnContinue.Text = "Add Photos Later";
                //lblUserName.Text = Session[Constants.NAME].ToString();

                DisplayImages(dsImages);
            }
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
                string ColumnDescription = "Pic" + i.ToString() + "Description";
                string Description = "txtFlupDesc" + i.ToString();
                System.Web.UI.WebControls.TextBox txtDescription = (System.Web.UI.WebControls.TextBox)form1.FindControl(Description);
                System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                string SelMakeDis = Session["SelCategory"].ToString();
                SelMakeDis = SelMakeDis.Replace("/", "@");
                //CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                if (dsImages.Tables[0].Rows[0][ColumnPic].ToString() != "0" && dsImages.Tables[0].Rows[0][ColumnPic].ToString() != "")
                {

                    ImageName.Visible = true;
                    ImageName.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelType"].ToString() + "/" + SelMakeDis.ToString() + "/" + dsImages.Tables[0].Rows[0][ColumnPicName].ToString();
                }
                else
                {
                    ImageName.Visible = false;
                }
                if ((dsImages.Tables[0].Rows[0][ColumnDescription].ToString() == "") || (dsImages.Tables[0].Rows[0][ColumnDescription].ToString() == "Photo Description"))
                {
                    txtDescription.Text = "Photo Description";
                }
                else
                {
                    txtDescription.Text = dsImages.Tables[0].Rows[0][ColumnDescription].ToString();
                }
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {

            btnContinue.Text = "Continue";
            string sFilePath = string.Empty;
            string Directorypath = string.Empty;
            Directorypath = "CarImages";
            Directorypath = Server.MapPath(Directorypath);
            if (System.IO.Directory.Exists(Directorypath))
            {
                string SelMake = Session["SelCategory"].ToString();
                SelMake = SelMake.Replace("/", "@");

                sFilePath = "CarImages" + "/" + Session["SelYear"].ToString();
                string sFilePathDir = Server.MapPath(sFilePath);
                if (System.IO.Directory.Exists(sFilePathDir) == false)
                {
                    System.IO.Directory.CreateDirectory(sFilePathDir);
                }
                string sFilePath2 = sFilePath + "/" + Session["SelType"].ToString();
                string sFilePath2Dir = Server.MapPath(sFilePath2);
                if (System.IO.Directory.Exists(sFilePath2Dir) == false)
                {
                    System.IO.Directory.CreateDirectory(sFilePath2Dir);
                }
                string sFilePath3 = sFilePath2 + "/" + SelMake + "/";
                string sFilePath3Dir = Server.MapPath(sFilePath3);
                if (System.IO.Directory.Exists(sFilePath3Dir) == false)
                {
                    System.IO.Directory.CreateDirectory(sFilePath3Dir);
                }
                //flupImage.PostedFile.SaveAs(sFilePath + "/" + FILENAME1);
                SaveImages(sFilePath3);
                // Response.Redirect("PlaceAdbankdetails.aspx");
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "Photo(s) uploaded successfully";

            }
            else
            {
                string SelMake = Session["SelCategory"].ToString();
                SelMake = SelMake.Replace("/", "@");
                sFilePath = "CarImages";
                //sFilePath = Server.MapPath(sFilePath);
                if (System.IO.Directory.Exists(Directorypath) == false)
                {
                    System.IO.Directory.CreateDirectory(Directorypath);
                }
                string sFilePath1 = sFilePath + "/" + Session["SelYear"].ToString();
                string sFilePath1Dir = Server.MapPath(sFilePath1);
                if (System.IO.Directory.Exists(sFilePath1Dir) == false)
                {
                    System.IO.Directory.CreateDirectory(sFilePath1Dir);
                }
                string sFilePath2 = sFilePath1 + "/" + Session["SelType"].ToString();
                string sFilePath2Dir = Server.MapPath(sFilePath2);
                if (System.IO.Directory.Exists(sFilePath2Dir) == false)
                {
                    System.IO.Directory.CreateDirectory(sFilePath2Dir);
                }
                string sFilePath3 = sFilePath2 + "/" + SelMake + "/";
                string sFilePath3Dir = Server.MapPath(sFilePath3);
                if (System.IO.Directory.Exists(sFilePath3Dir) == false)
                {
                    System.IO.Directory.CreateDirectory(sFilePath3Dir);
                }
                SaveImages(sFilePath3);
                //Response.Redirect("PlaceAdbankdetails.aspx");
                mpealteruser.Show();
                lblErr.Visible = true;
                lblErr.Text = "Photo(s) uploaded successfully";
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    private void SaveImages(string sFilePath3)
    {
        try
        {
            DataSet dsImagesData = Session["GetImages"] as DataSet;
            string picID0 = dsImagesData.Tables[0].Rows[0]["pic0"].ToString();
            string picID1 = dsImagesData.Tables[0].Rows[0]["pic1"].ToString();
            string picID2 = dsImagesData.Tables[0].Rows[0]["pic2"].ToString();
            string picID3 = dsImagesData.Tables[0].Rows[0]["pic3"].ToString();
            string picID4 = dsImagesData.Tables[0].Rows[0]["pic4"].ToString();
            string picID5 = dsImagesData.Tables[0].Rows[0]["pic5"].ToString();
            string picID6 = dsImagesData.Tables[0].Rows[0]["pic6"].ToString();
            string picID7 = dsImagesData.Tables[0].Rows[0]["pic7"].ToString();
            string picID8 = dsImagesData.Tables[0].Rows[0]["pic8"].ToString();
            string picID9 = dsImagesData.Tables[0].Rows[0]["pic9"].ToString();
            string picID10 = dsImagesData.Tables[0].Rows[0]["pic10"].ToString();
            string picID11 = dsImagesData.Tables[0].Rows[0]["pic11"].ToString();
            string picID12 = dsImagesData.Tables[0].Rows[0]["pic12"].ToString();
            string picID13 = dsImagesData.Tables[0].Rows[0]["pic13"].ToString();
            string picID14 = dsImagesData.Tables[0].Rows[0]["pic14"].ToString();
            string picID15 = dsImagesData.Tables[0].Rows[0]["pic15"].ToString();
            string picID16 = dsImagesData.Tables[0].Rows[0]["pic16"].ToString();
            string picID17 = dsImagesData.Tables[0].Rows[0]["pic17"].ToString();
            string picID18 = dsImagesData.Tables[0].Rows[0]["pic18"].ToString();
            string picID19 = dsImagesData.Tables[0].Rows[0]["pic19"].ToString();
            string picID20 = dsImagesData.Tables[0].Rows[0]["pic20"].ToString();
            string picID21 = dsImagesData.Tables[0].Rows[0]["pic21"].ToString();
            string picID22 = dsImagesData.Tables[0].Rows[0]["pic22"].ToString();
            string picID23 = dsImagesData.Tables[0].Rows[0]["pic23"].ToString();
            string picID24 = dsImagesData.Tables[0].Rows[0]["pic24"].ToString();
            string picID25 = dsImagesData.Tables[0].Rows[0]["pic25"].ToString();
            string picID26 = dsImagesData.Tables[0].Rows[0]["pic26"].ToString();
            string picID27 = dsImagesData.Tables[0].Rows[0]["pic27"].ToString();
            string picID28 = dsImagesData.Tables[0].Rows[0]["pic28"].ToString();
            string picID29 = dsImagesData.Tables[0].Rows[0]["pic29"].ToString();
            string picID30 = dsImagesData.Tables[0].Rows[0]["pic30"].ToString();
            string picID31 = dsImagesData.Tables[0].Rows[0]["pic31"].ToString();
            string picID32 = dsImagesData.Tables[0].Rows[0]["pic32"].ToString();
            string picID33 = dsImagesData.Tables[0].Rows[0]["pic33"].ToString();
            string picID34 = dsImagesData.Tables[0].Rows[0]["pic34"].ToString();
            string picID35 = dsImagesData.Tables[0].Rows[0]["pic35"].ToString();
            string picID36 = dsImagesData.Tables[0].Rows[0]["pic36"].ToString();
            string picID37 = dsImagesData.Tables[0].Rows[0]["pic37"].ToString();
            string picID38 = dsImagesData.Tables[0].Rows[0]["pic38"].ToString();
            string picID39 = dsImagesData.Tables[0].Rows[0]["pic39"].ToString();
            string picID40 = dsImagesData.Tables[0].Rows[0]["pic40"].ToString();
            string picID41 = dsImagesData.Tables[0].Rows[0]["pic41"].ToString();
            string picID42 = dsImagesData.Tables[0].Rows[0]["pic42"].ToString();
            string picID43 = dsImagesData.Tables[0].Rows[0]["pic43"].ToString();
            string picID44 = dsImagesData.Tables[0].Rows[0]["pic44"].ToString();
            string picID45 = dsImagesData.Tables[0].Rows[0]["pic45"].ToString();
            string picID46 = dsImagesData.Tables[0].Rows[0]["pic46"].ToString();
            string picID47 = dsImagesData.Tables[0].Rows[0]["pic47"].ToString();
            string picID48 = dsImagesData.Tables[0].Rows[0]["pic48"].ToString();
            string picID49 = dsImagesData.Tables[0].Rows[0]["pic49"].ToString();
            string picID50 = dsImagesData.Tables[0].Rows[0]["pic50"].ToString();
            int UID = Convert.ToInt32(Session[Constants.USER_ID].ToString());


            if (flupImage1.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image1.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                //flupImage1.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                double FlSize = flupImage1.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage1.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img1 = System.Drawing.Image.FromStream(flupImage1.PostedFile.InputStream);
                    compress(Img1, path, ext);
                }
                else
                {
                    flupImage1.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }

                ////PicImg1 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc1.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc1.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID1 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage2.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image2.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage2.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage2.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img2 = System.Drawing.Image.FromStream(flupImage2.PostedFile.InputStream);
                    compress(Img2, path, ext);
                }
                else
                {
                    flupImage2.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg2 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc2.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc2.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID2 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage3.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image3.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage3.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage3.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img3 = System.Drawing.Image.FromStream(flupImage3.PostedFile.InputStream);
                    compress(Img3, path, ext);
                }
                else
                {
                    flupImage3.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg3 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc3.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc3.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID3 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage4.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image4.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage4.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage4.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img4 = System.Drawing.Image.FromStream(flupImage4.PostedFile.InputStream);
                    compress(Img4, path, ext);
                }
                else
                {
                    flupImage4.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg4 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc4.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc4.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID4 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage5.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image5.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage5.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage5.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img5 = System.Drawing.Image.FromStream(flupImage5.PostedFile.InputStream);
                    compress(Img5, path, ext);
                }
                else
                {
                    flupImage5.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg5 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc5.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc5.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID5 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage6.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image6.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage6.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage6.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img6 = System.Drawing.Image.FromStream(flupImage6.PostedFile.InputStream);
                    compress(Img6, path, ext);
                }
                else
                {
                    flupImage6.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg6 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc6.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc6.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID6 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage7.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image7.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage7.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage7.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img7 = System.Drawing.Image.FromStream(flupImage7.PostedFile.InputStream);
                    compress(Img7, path, ext);
                }
                else
                {
                    flupImage7.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg7 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc7.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc7.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID7 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage8.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image8.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage8.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage8.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img8 = System.Drawing.Image.FromStream(flupImage8.PostedFile.InputStream);
                    compress(Img8, path, ext);
                }
                else
                {
                    flupImage8.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg8 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc8.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc8.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID8 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage9.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image9.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage9.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage9.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img9 = System.Drawing.Image.FromStream(flupImage9.PostedFile.InputStream);
                    compress(Img9, path, ext);
                }
                else
                {
                    flupImage9.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg9 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc9.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc9.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID9 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage10.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image10.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage10.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage10.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img10 = System.Drawing.Image.FromStream(flupImage10.PostedFile.InputStream);
                    compress(Img10, path, ext);
                }
                else
                {
                    flupImage10.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg10 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc10.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc10.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID10 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }

            if (flupImage11.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image11.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage11.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage11.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img11 = System.Drawing.Image.FromStream(flupImage11.PostedFile.InputStream);
                    compress(Img11, path, ext);
                }
                else
                {
                    flupImage11.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg1 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc11.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc11.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID11 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage12.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image12.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage12.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage12.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img12 = System.Drawing.Image.FromStream(flupImage12.PostedFile.InputStream);
                    compress(Img12, path, ext);
                }
                else
                {
                    flupImage12.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg2 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc12.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc12.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID12 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage13.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image13.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage13.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage13.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img13 = System.Drawing.Image.FromStream(flupImage13.PostedFile.InputStream);
                    compress(Img13, path, ext);
                }
                else
                {
                    flupImage13.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg3 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc13.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc13.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID13 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage14.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image14.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage14.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage14.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img14 = System.Drawing.Image.FromStream(flupImage14.PostedFile.InputStream);
                    compress(Img14, path, ext);
                }
                else
                {
                    flupImage14.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg4 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc14.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc14.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID14 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage15.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image15.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage15.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage15.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img15 = System.Drawing.Image.FromStream(flupImage15.PostedFile.InputStream);
                    compress(Img15, path, ext);
                }
                else
                {
                    flupImage15.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg5 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc15.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc15.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID15 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage16.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image16.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage16.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage16.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img16 = System.Drawing.Image.FromStream(flupImage16.PostedFile.InputStream);
                    compress(Img16, path, ext);
                }
                else
                {
                    flupImage16.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg6 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc16.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc16.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID16 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage17.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image17.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage17.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage17.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img17 = System.Drawing.Image.FromStream(flupImage17.PostedFile.InputStream);
                    compress(Img17, path, ext);
                }
                else
                {
                    flupImage17.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg7 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc17.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc17.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID17 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage18.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image18.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage18.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage18.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img18 = System.Drawing.Image.FromStream(flupImage18.PostedFile.InputStream);
                    compress(Img18, path, ext);
                }
                else
                {
                    flupImage18.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg8 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc18.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc18.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID18 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage19.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image19.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage19.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage19.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img19 = System.Drawing.Image.FromStream(flupImage19.PostedFile.InputStream);
                    compress(Img19, path, ext);
                }
                else
                {
                    flupImage19.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg9 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc19.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc19.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID19 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage20.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image20.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage20.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage20.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img20 = System.Drawing.Image.FromStream(flupImage20.PostedFile.InputStream);
                    compress(Img20, path, ext);
                }
                else
                {
                    flupImage20.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg10 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc20.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc20.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID20 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage21.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image21.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                //flupImage1.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                double FlSize = flupImage21.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage21.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img21 = System.Drawing.Image.FromStream(flupImage21.PostedFile.InputStream);
                    compress(Img21, path, ext);
                }
                else
                {
                    flupImage21.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }

                ////PicImg1 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc21.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc21.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID21 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage22.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image22.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage22.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage22.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img22 = System.Drawing.Image.FromStream(flupImage22.PostedFile.InputStream);
                    compress(Img22, path, ext);
                }
                else
                {
                    flupImage22.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg2 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc22.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc22.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID22 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage23.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image23.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage23.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage23.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img23 = System.Drawing.Image.FromStream(flupImage23.PostedFile.InputStream);
                    compress(Img23, path, ext);
                }
                else
                {
                    flupImage23.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg3 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc23.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc23.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID23 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage24.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image24.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage24.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage24.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img24 = System.Drawing.Image.FromStream(flupImage42.PostedFile.InputStream);
                    compress(Img24, path, ext);
                }
                else
                {
                    flupImage24.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg4 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc24.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc24.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID24 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage25.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image25.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage25.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage25.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img25 = System.Drawing.Image.FromStream(flupImage25.PostedFile.InputStream);
                    compress(Img25, path, ext);
                }
                else
                {
                    flupImage25.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg5 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc25.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc25.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID25 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage26.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image26.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage26.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage26.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img26 = System.Drawing.Image.FromStream(flupImage26.PostedFile.InputStream);
                    compress(Img26, path, ext);
                }
                else
                {
                    flupImage26.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg6 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc26.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc26.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID26 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage27.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image27.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage27.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage27.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img27 = System.Drawing.Image.FromStream(flupImage27.PostedFile.InputStream);
                    compress(Img27, path, ext);
                }
                else
                {
                    flupImage27.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg7 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc27.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc27.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID27 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage28.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image28.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage28.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage28.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img28 = System.Drawing.Image.FromStream(flupImage28.PostedFile.InputStream);
                    compress(Img28, path, ext);
                }
                else
                {
                    flupImage28.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg8 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc28.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc28.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID28 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage29.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image29.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage29.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage29.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img29 = System.Drawing.Image.FromStream(flupImage29.PostedFile.InputStream);
                    compress(Img29, path, ext);
                }
                else
                {
                    flupImage29.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg9 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc29.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc29.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID29 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage30.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image30.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage30.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage30.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img30 = System.Drawing.Image.FromStream(flupImage30.PostedFile.InputStream);
                    compress(Img30, path, ext);
                }
                else
                {
                    flupImage30.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg10 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc30.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc30.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID30 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }

            if (flupImage31.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image31.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage31.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage31.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img31 = System.Drawing.Image.FromStream(flupImage31.PostedFile.InputStream);
                    compress(Img31, path, ext);
                }
                else
                {
                    flupImage31.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg1 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc31.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc31.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID31 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage32.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image32.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage32.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage32.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img32 = System.Drawing.Image.FromStream(flupImage32.PostedFile.InputStream);
                    compress(Img32, path, ext);
                }
                else
                {
                    flupImage32.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg2 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc32.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc32.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID32 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage33.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image33.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage33.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage33.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img33 = System.Drawing.Image.FromStream(flupImage33.PostedFile.InputStream);
                    compress(Img33, path, ext);
                }
                else
                {
                    flupImage33.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg3 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc33.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc33.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID33 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage34.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image34.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage34.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage34.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img34 = System.Drawing.Image.FromStream(flupImage34.PostedFile.InputStream);
                    compress(Img34, path, ext);
                }
                else
                {
                    flupImage34.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg4 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc34.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc34.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID34 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage35.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image35.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage35.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage35.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img35 = System.Drawing.Image.FromStream(flupImage35.PostedFile.InputStream);
                    compress(Img35, path, ext);
                }
                else
                {
                    flupImage35.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg5 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc35.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc35.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID35 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage36.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image36.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage36.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage36.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img36 = System.Drawing.Image.FromStream(flupImage36.PostedFile.InputStream);
                    compress(Img36, path, ext);
                }
                else
                {
                    flupImage36.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg6 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc36.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc36.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID36 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage37.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image37.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage37.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage37.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img37 = System.Drawing.Image.FromStream(flupImage37.PostedFile.InputStream);
                    compress(Img37, path, ext);
                }
                else
                {
                    flupImage37.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg7 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc37.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc37.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID37 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage38.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image38.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage38.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage38.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img38 = System.Drawing.Image.FromStream(flupImage38.PostedFile.InputStream);
                    compress(Img38, path, ext);
                }
                else
                {
                    flupImage38.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg8 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc38.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc38.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID38 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage39.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image39.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage39.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage39.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img39 = System.Drawing.Image.FromStream(flupImage39.PostedFile.InputStream);
                    compress(Img39, path, ext);
                }
                else
                {
                    flupImage39.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg9 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc39.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc39.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID39 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage40.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image40.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage40.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage40.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img40 = System.Drawing.Image.FromStream(flupImage40.PostedFile.InputStream);
                    compress(Img40, path, ext);
                }
                else
                {
                    flupImage40.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg10 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc40.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc40.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID40 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage41.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image41.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                //flupImage1.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                double FlSize = flupImage41.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage41.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img41 = System.Drawing.Image.FromStream(flupImage41.PostedFile.InputStream);
                    compress(Img41, path, ext);
                }
                else
                {
                    flupImage41.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }

                ////PicImg1 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc41.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc41.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID41 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage42.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image42.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage42.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage42.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img42 = System.Drawing.Image.FromStream(flupImage42.PostedFile.InputStream);
                    compress(Img42, path, ext);
                }
                else
                {
                    flupImage42.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg2 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc42.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc42.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID42 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage43.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image43.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage43.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage43.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img43 = System.Drawing.Image.FromStream(flupImage43.PostedFile.InputStream);
                    compress(Img43, path, ext);
                }
                else
                {
                    flupImage43.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg3 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc43.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc43.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID43 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage44.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image44.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage44.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage44.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img44 = System.Drawing.Image.FromStream(flupImage44.PostedFile.InputStream);
                    compress(Img44, path, ext);
                }
                else
                {
                    flupImage44.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg4 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc44.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc44.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID44 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage45.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image45.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage45.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage45.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img45 = System.Drawing.Image.FromStream(flupImage45.PostedFile.InputStream);
                    compress(Img45, path, ext);
                }
                else
                {
                    flupImage45.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg5 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc45.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc45.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID45 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage46.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image46.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage46.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage46.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img46 = System.Drawing.Image.FromStream(flupImage46.PostedFile.InputStream);
                    compress(Img46, path, ext);
                }
                else
                {
                    flupImage46.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg6 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc46.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc46.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID46 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage47.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image47.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage47.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage47.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img47 = System.Drawing.Image.FromStream(flupImage47.PostedFile.InputStream);
                    compress(Img47, path, ext);
                }
                else
                {
                    flupImage47.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg7 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc47.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc47.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID47 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage48.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image48.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage48.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage48.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img48 = System.Drawing.Image.FromStream(flupImage48.PostedFile.InputStream);
                    compress(Img48, path, ext);
                }
                else
                {
                    flupImage48.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg8 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc48.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc48.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID48 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage49.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image49.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage49.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage49.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img49 = System.Drawing.Image.FromStream(flupImage49.PostedFile.InputStream);
                    compress(Img49, path, ext);
                }
                else
                {
                    flupImage49.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg9 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc49.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc49.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID49 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage50.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "_Image50.jpg";
                string FileNameFull = Server.MapPath(sFilePath3);
                double FlSize = flupImage50.PostedFile.ContentLength;
                double FlSize2 = FlSize / 1024;
                double FlSize3 = FlSize2 / 1024;
                double limit = 0.5;
                if (FlSize3 > limit)
                {
                    string path = FileNameFull + FileName;
                    string ext = System.IO.Path.GetExtension(this.flupImage50.PostedFile.FileName);
                    ext = ext.ToLower();
                    System.Drawing.Image Img50 = System.Drawing.Image.FromStream(flupImage50.PostedFile.InputStream);
                    compress(Img50, path, ext);
                }
                else
                {
                    flupImage50.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                }
                //PicImg10 = FileNameFull + "/" + FileName;
                FileNameFull = sFilePath3;
                string PhotoDescription = string.Empty;
                if (txtFlupDesc50.Text.Trim() == "Photo Description")
                {
                    PhotoDescription = "";
                }
                else
                {
                    PhotoDescription = txtFlupDesc50.Text.Trim();
                }
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", PhotoDescription, UID);
                picID50 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }






            ArrayList str = new ArrayList();
            str.Add(picID1);
            str.Add(picID2);
            str.Add(picID3);
            str.Add(picID4);
            str.Add(picID5);
            str.Add(picID6);
            str.Add(picID7);
            str.Add(picID8);
            str.Add(picID9);
            str.Add(picID10);
            str.Add(picID11);
            str.Add(picID12);
            str.Add(picID13);
            str.Add(picID14);
            str.Add(picID15);
            str.Add(picID16);
            str.Add(picID17);
            str.Add(picID18);
            str.Add(picID19);
            str.Add(picID20);
            str.Add(picID21);
            str.Add(picID22);
            str.Add(picID23);
            str.Add(picID24);
            str.Add(picID25);
            str.Add(picID26);
            str.Add(picID27);
            str.Add(picID28);
            str.Add(picID29);
            str.Add(picID30);
            str.Add(picID31);
            str.Add(picID32);
            str.Add(picID33);
            str.Add(picID34);
            str.Add(picID35);
            str.Add(picID36);
            str.Add(picID37);
            str.Add(picID38);
            str.Add(picID39);
            str.Add(picID40);
            str.Add(picID41);
            str.Add(picID42);
            str.Add(picID43);
            str.Add(picID44);
            str.Add(picID45);
            str.Add(picID46);
            str.Add(picID47);
            str.Add(picID48);
            str.Add(picID49);
            str.Add(picID50);


            for (int j = 0; j < str.Count; j++)
            {
                if (str[j].ToString() != "" && str[j].ToString() != "0" && str[j].ToString() != " ")
                {
                    if (objcarsInfo.Pic1 == null)
                    {
                        objcarsInfo.Pic1 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic2 == null)
                    {
                        objcarsInfo.Pic2 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic3 == null)
                    {
                        objcarsInfo.Pic3 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic4 == null)
                    {
                        objcarsInfo.Pic4 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic5 == null)
                    {
                        objcarsInfo.Pic5 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic6 == null)
                    {
                        objcarsInfo.Pic6 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic7 == null)
                    {
                        objcarsInfo.Pic7 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic8 == null)
                    {
                        objcarsInfo.Pic8 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic9 == null)
                    {
                        objcarsInfo.Pic9 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic10 == null)
                    {
                        objcarsInfo.Pic10 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic11 == null)
                    {
                        objcarsInfo.Pic11 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic12 == null)
                    {
                        objcarsInfo.Pic12 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic13 == null)
                    {
                        objcarsInfo.Pic13 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic14 == null)
                    {
                        objcarsInfo.Pic14 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic15 == null)
                    {
                        objcarsInfo.Pic15 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic16 == null)
                    {
                        objcarsInfo.Pic16 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic17 == null)
                    {
                        objcarsInfo.Pic17 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic18 == null)
                    {
                        objcarsInfo.Pic18 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic19 == null)
                    {
                        objcarsInfo.Pic19 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic20 == null)
                    {
                        objcarsInfo.Pic20 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic21 == null)
                    {
                        objcarsInfo.Pic21 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic22 == null)
                    {
                        objcarsInfo.Pic22 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic23 == null)
                    {
                        objcarsInfo.Pic23 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic24 == null)
                    {
                        objcarsInfo.Pic24 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic25 == null)
                    {
                        objcarsInfo.Pic25 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic26 == null)
                    {
                        objcarsInfo.Pic26 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic27 == null)
                    {
                        objcarsInfo.Pic27 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic28 == null)
                    {
                        objcarsInfo.Pic28 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic29 == null)
                    {
                        objcarsInfo.Pic29 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic30 == null)
                    {
                        objcarsInfo.Pic30 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic31 == null)
                    {
                        objcarsInfo.Pic31 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic32 == null)
                    {
                        objcarsInfo.Pic32 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic33 == null)
                    {
                        objcarsInfo.Pic33 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic34 == null)
                    {
                        objcarsInfo.Pic34 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic35 == null)
                    {
                        objcarsInfo.Pic35 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic36 == null)
                    {
                        objcarsInfo.Pic36 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic37 == null)
                    {
                        objcarsInfo.Pic37 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic38 == null)
                    {
                        objcarsInfo.Pic38 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic39 == null)
                    {
                        objcarsInfo.Pic39 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic40 == null)
                    {
                        objcarsInfo.Pic40 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic41 == null)
                    {
                        objcarsInfo.Pic41 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic42 == null)
                    {
                        objcarsInfo.Pic42 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic43 == null)
                    {
                        objcarsInfo.Pic43 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic44 == null)
                    {
                        objcarsInfo.Pic44 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic45 == null)
                    {
                        objcarsInfo.Pic45 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic46 == null)
                    {
                        objcarsInfo.Pic46 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic47 == null)
                    {
                        objcarsInfo.Pic47 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic48 == null)
                    {
                        objcarsInfo.Pic48 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic49 == null)
                    {
                        objcarsInfo.Pic49 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic50 == null)
                    {
                        objcarsInfo.Pic50 = str[j].ToString();
                    }

                }

            }
            int Thumb = 0;
            for (int k = 0; k < str.Count; k++)
            {
                if (str[k].ToString() == picID1)
                {
                    Thumb = k + 1;
                    break;
                }
            }

            string ThumbIDFile = "flupImage" + Thumb.ToString();
            FileUpload FileForThumb = (FileUpload)form1.FindControl(ThumbIDFile);
            if (FileForThumb.HasFile)
            {
                string SelMakeName = Session["SelCategory"].ToString();
                SelMakeName = SelMakeName.Replace("/", "@");
                string FileNameThumb = Session["SelYear"].ToString() + "_" + Session["SelType"].ToString() + "_" + SelMakeName + "_" + Session["CarID"].ToString() + "Thumb.jpg";
                string FileNameFullThumb = Server.MapPath(sFilePath3);
                Bitmap originalBMP = new Bitmap(FileForThumb.FileContent);

                // Calculate the new image dimensions
                int origWidth = originalBMP.Width;
                int origHeight = originalBMP.Height;
                int sngRatio = origWidth / origHeight;
                int newWidth = 200;
                int newHeight = 122;
                // Create a new bitmap which will hold the previous resized bitmap
                Bitmap newBMP = new Bitmap(originalBMP, newWidth, newHeight);
                // Create a graphic based on the new bitmap
                Graphics oGraphics = Graphics.FromImage(newBMP);
                // Set the properties for the new graphic file
                oGraphics.SmoothingMode = SmoothingMode.AntiAlias; oGraphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                // Draw the new graphic based on the resized bitmap
                oGraphics.DrawImage(originalBMP, 0, 0, newWidth, newHeight);
                //flupImage20.PostedFile.SaveAs(FileNameFull + "/" + FileName);
                // Save the new graphic file to the server
                newBMP.Save(FileNameFullThumb + "/" + FileNameThumb);

                // Once finished with the bitmap objects, we deallocate them.
                originalBMP.Dispose();
                newBMP.Dispose();
                oGraphics.Dispose();
                FileNameFullThumb = sFilePath3;
                string PhotoDescription = "Thumb Image";
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFullThumb, FileNameThumb, "jpg", PhotoDescription, UID);
                picID0 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }

            objcarsInfo.Pic0 = picID0;


            objcarsInfo.CarID = Convert.ToInt32(Session["CarID"].ToString());
            bool bnew = objdropdownBL.USP_UpdatePicturesById(objcarsInfo);
            DataSet dsImages = objdropdownBL.USP_GetImages(Convert.ToInt32(Session["CarID"].ToString()), Convert.ToInt32(Session["PackageID"].ToString()));
            Session["GetImages"] = dsImages;
            DisplayImages(dsImages);
        }
        catch (Exception ex)
        {
        }
    }
    private void compress(System.Drawing.Image img, string path, string Extension)
    {
        try
        {
            EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 60L);

            ImageCodecInfo jpegCodec = null;
            if (Extension == ".jpeg")
            {
                jpegCodec = GetEncoderInfo("image/jpeg");
            }
            if (Extension == ".bmp")
            {
                jpegCodec = GetEncoderInfo("image/bmp");
            }
            if (Extension == ".gif")
            {
                jpegCodec = GetEncoderInfo("image/gif");
            }
            if (Extension == ".png")
            {
                jpegCodec = GetEncoderInfo("image/png");
            }
            if (Extension == ".jpg")
            {
                jpegCodec = GetEncoderInfo("image/jpeg");
            }
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = qualityParam;

            img.Save(path, jpegCodec, encoderParams);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
        // Get image codecs for all image formats 
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();

        // Find the correct image codec 
        for (int i = 0; i < codecs.Length; i++)
            if (codecs[i].MimeType == mimeType)
                return codecs[i];
        return null;
    }
    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            mdepEditSuccess.Show();

        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    protected void btnSuccessGO_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Account.aspx");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
    protected void btnGo_Click(object sender, EventArgs e)
    {
        try
        {
            Response.Redirect("Account.aspx");
        }
        catch (Exception ex)
        {
        }
    }
}
