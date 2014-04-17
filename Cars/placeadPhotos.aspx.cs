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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;


public partial class placeadPhotos : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();

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


                GeneralFunc.SetPageDefaults(Page);

                ServiceReference objServiceReference = new ServiceReference();

                ScriptReference objScriptReference = new ScriptReference();

                objServiceReference.Path = "~/CarsService.asmx";

                objScriptReference.Path = "~/Static/Js/CarsJScriptNew.js";

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
                //string ButtonID = "btnRotate" + i.ToString();
                string ColumnPic = "pic" + i.ToString();
                string ColumnPicName = "pic" + i.ToString() + "Name";
                string ColumnPicLocation = "Pic" + i.ToString() + "Loc";
                System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
                //System.Web.UI.WebControls.Button ButtonName = (System.Web.UI.WebControls.Button)form1.FindControl(ButtonID);
                string SelModelDis = Session["SelModel"].ToString();
                SelModelDis = SelModelDis.Replace("/", "@");
                SelModelDis = SelModelDis.Replace("&", "@");
                //CheckBox ChkedBox = (CheckBox)form1.FindControl(ChkBoxID);
                if (dsImages.Tables[0].Rows[0][ColumnPic].ToString() != "0" && dsImages.Tables[0].Rows[0][ColumnPic].ToString() != "")
                {

                    ImageName.Visible = true;
                    //ButtonName.Visible = true;
                    ImageName.ImageUrl = "http://unitedcarexchange.com/" + dsImages.Tables[0].Rows[0][ColumnPicLocation].ToString() + dsImages.Tables[0].Rows[0][ColumnPicName].ToString();
                }
                else
                {
                    ImageName.Visible = false;
                    //ButtonName.Visible = false;
                }
            }


            //if (dsImages.Tables[0].Rows[0]["pic1"].ToString() != "0")
            //{
            //    Img1.Visible = true;
            //    Img1.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic1Name"].ToString();
            //}
            //else
            //{
            //    Img1.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic2"].ToString() != "0")
            //{
            //    Img2.Visible = true;
            //    Img2.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic2Name"].ToString();
            //}
            //else
            //{
            //    Img2.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic3"].ToString() != "0")
            //{
            //    Img3.Visible = true;
            //    Img3.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic3Name"].ToString();
            //}
            //else
            //{
            //    Img3.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic4"].ToString() != "0")
            //{
            //    Img4.Visible = true;
            //    Img4.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic4Name"].ToString();
            //}
            //else
            //{
            //    Img4.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic5"].ToString() != "0")
            //{
            //    Img5.Visible = true;
            //    Img5.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic5Name"].ToString();
            //}
            //else
            //{
            //    Img5.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic6"].ToString() != "0")
            //{
            //    Img6.Visible = true;
            //    Img6.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic6Name"].ToString();
            //}
            //else
            //{
            //    Img6.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic7"].ToString() != "0")
            //{
            //    Img7.Visible = true;
            //    Img7.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic7Name"].ToString();
            //}
            //else
            //{
            //    Img7.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic8"].ToString() != "0")
            //{
            //    Img8.Visible = true;
            //    Img8.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic8Name"].ToString();
            //}
            //else
            //{
            //    Img8.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic9"].ToString() != "0")
            //{
            //    Img9.Visible = true;
            //    Img9.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic9Name"].ToString();
            //}
            //else
            //{
            //    Img9.Visible = false;
            //}
            //if (dsImages.Tables[0].Rows[0]["pic10"].ToString() != "0")
            //{
            //    Img10.Visible = true;
            //    Img10.ImageUrl = "~/CarImages/" + Session["SelYear"].ToString() + "/" + Session["SelMake"].ToString() + "/" + Session["SelModel"].ToString() + "/" + dsImages.Tables[0].Rows[0]["Pic10Name"].ToString();
            //}
            //else
            //{
            //    Img10.Visible = false;
            //}

        }
        catch (Exception ex)
        {
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        btnContinue.Text = "Continue";
        string sFilePath = string.Empty;
        string Directorypath = string.Empty;
        Directorypath = "CarImages";
        Directorypath = Server.MapPath(Directorypath);
        if (System.IO.Directory.Exists(Directorypath))
        {
            string SelModel = Session["SelModel"].ToString().Trim();
            SelModel = SelModel.Replace("/", "@");
            SelModel = SelModel.Replace("&", "@");

            sFilePath = "CarImages" + "/" + Session["SelYear"].ToString();
            string sFilePathDir = Server.MapPath(sFilePath);
            if (System.IO.Directory.Exists(sFilePathDir) == false)
            {
                System.IO.Directory.CreateDirectory(sFilePathDir);
            }
            string sFilePath2 = sFilePath + "/" + Session["SelMake"].ToString().Trim() ;
            string sFilePath2Dir = Server.MapPath(sFilePath2);
            if (System.IO.Directory.Exists(sFilePath2Dir) == false)
            {
                System.IO.Directory.CreateDirectory(sFilePath2Dir);
            }
            string sFilePath3 = sFilePath2 + "/" + SelModel + "/";
            if (System.IO.Directory.Exists(sFilePath3) == false)
            {
                System.IO.Directory.CreateDirectory(sFilePath3);
            }
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
            string SelModel = Session["SelModel"].ToString();
            SelModel = SelModel.Replace("/", "@");
            SelModel = SelModel.Replace("&", "@");
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
            string sFilePath2 = sFilePath1 + "/" + Session["SelMake"].ToString();
            string sFilePath2Dir = Server.MapPath(sFilePath2);
            if (System.IO.Directory.Exists(sFilePath2Dir) == false)
            {
                System.IO.Directory.CreateDirectory(sFilePath2Dir);
            }
            string sFilePath3 = sFilePath2 + "/" + SelModel + "/";
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
            int UserID = Convert.ToInt32(Session[Constants.USER_ID].ToString());

            if (flupImage1.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace(" ", "-");
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image1.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID1 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage2.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace(" ", "-");
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image2.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID2 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage3.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image3.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID3 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage4.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image4.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID4 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage5.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image5.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID5 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage6.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image6.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID6 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage7.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image7.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID7 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage8.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image8.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID8 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage9.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image9.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID9 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage10.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image10.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID10 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }

            if (flupImage11.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image11.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID11 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage12.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image12.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID12 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage13.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image13.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID13 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage14.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image14.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID14 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage15.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image15.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID15 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage16.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image16.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID16 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage17.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image17.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID17 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage18.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image18.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID18 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage19.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image19.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID19 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }
            if (flupImage20.HasFile)
            {
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileName = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "_Image20.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFull, FileName, "jpg", UserID);
                picID20 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
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
                string SelModelName = Session["SelModel"].ToString();
                SelModelName = SelModelName.Replace("/", "@");
                SelModelName = SelModelName.Replace("&", "@");
                string FileNameThumb = Session["SelYear"].ToString() + "_" + Session["SelMake"].ToString() + "_" + SelModelName + "_" + Session["CarID"].ToString() + "Thumb.jpg";
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
                DataSet dsImgID = objdropdownBL.USP_SavePictures(FileNameFullThumb, FileNameThumb, "jpg", UserID);
                picID0 = dsImgID.Tables[0].Rows[0]["picID"].ToString();
            }

            objcarsInfo.Pic0 = picID0;

            //    System.Web.UI.WebControls.Image ImageName = (System.Web.UI.WebControls.Image)form1.FindControl(ImgID);
            //objcarsInfo.Pic1 = picID1;
            //objcarsInfo.Pic2 = picID2;
            //objcarsInfo.Pic3 = picID3;
            //objcarsInfo.Pic4 = picID4;
            //objcarsInfo.Pic5 = picID5;
            //objcarsInfo.Pic6 = picID6;
            //objcarsInfo.Pic7 = picID7;
            //objcarsInfo.Pic8 = picID8;
            //objcarsInfo.Pic9 = picID9;
            //objcarsInfo.Pic10 = picID10;
            //objcarsInfo.Pic11 = picID11;
            //objcarsInfo.Pic12 = picID12;
            //objcarsInfo.Pic13 = picID13;
            //objcarsInfo.Pic14 = picID14;
            //objcarsInfo.Pic15 = picID15;
            //objcarsInfo.Pic16 = picID16;
            //objcarsInfo.Pic17 = picID17;
            //objcarsInfo.Pic18 = picID18;
            //objcarsInfo.Pic19 = picID19;
            //objcarsInfo.Pic20 = picID20;
            objcarsInfo.CarID = Convert.ToInt32(Session["CarID"].ToString());
            bool bnew = objdropdownBL.USP_UpdatePicturesById(objcarsInfo, UserID);
            DataSet dsImages = objdropdownBL.USP_GetImages(Convert.ToInt32(Session["CarID"].ToString()), Convert.ToInt32(Session["PackageID"].ToString()));
            Session["GetImages"] = dsImages;
            DisplayImages(dsImages);
        }
        catch (Exception ex)
        {
        }
    }

    protected void lnkBtnLogout_Click(object sender, EventArgs e)
    {
        try
        {
            Session.Abandon();
            Response.Redirect("Default.aspx");
        }
        catch (Exception ex)
        {
        }
    }

    protected void btnContinue_Click(object sender, EventArgs e)
    {
        try
        {
            //mdepAlertForAsk.Show();
            //lblAlertForAsk.Visible = true;
            //lblAlertForAsk.Text = "Do you want to continue without adding photo(s)?";
            //Response.Redirect("PlaceAdbankdetails.aspx");
            mdepEditSuccess.Show();
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

    protected void btnRotate1_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img1");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate2_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img2");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate3_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img3");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate4_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img4");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate5_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img5");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate6_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img6");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate7_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img7");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate8_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img8");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate9_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img9");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate10_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img10");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate11_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img11");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate12_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img12");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate13_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img13");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate14_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img14");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate15_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img15");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate16_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img16");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate17_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img17");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate18_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img18");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate19_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img19");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");
    }
    protected void btnRotate20_Click(object sender, EventArgs e)
    {
        //get the path to the image
        System.Web.UI.WebControls.Image Image1 = (System.Web.UI.WebControls.Image)form1.FindControl("Img20");
        string path = Server.MapPath(Image1.ImageUrl);

        //create an image object from the image in that path
        System.Drawing.Image img = System.Drawing.Image.FromFile(path);

        //rotate the image
        img.RotateFlip(RotateFlipType.Rotate90FlipXY);

        //save the image out to the file
        img.Save(path);

        //release image file
        img.Dispose();
        //Response.Redirect("placeadPhotos.aspx");

    }
}
