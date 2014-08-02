using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using CarsBL.Dealer;
using CarsInfo;
using CarsBL.Transactions;

public partial class FileUploads : System.Web.UI.Page
{
    DropdownBL objdropdownBL = new DropdownBL();
    CarsInfo.CarsInfo objcarsInfo = new CarsInfo.CarsInfo();
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (Session[Constants.NAME] == null)
        //{
        //    Response.Redirect("../login.aspx");
        //}        
        HttpPostedFile uploads = Request.Files["FileData"];
        //HttpContext.Current.Request["RequireUploadifySessionSync"]

        string FileExt = System.IO.Path.GetExtension(uploads.FileName);
        //Get The Ext of File 
        //FileName = Server.MapPath(".") + fuAttachments.PostedFile.FileName;

        /*
        if (FileExt != ".jpg" || FileExt != ".png"||FileExt != ".jpeg")
        {   

            //return "You have not selected a Excel File.Kindly select Excel File"; 
        }
         */

        string file = System.IO.Path.GetFileName(uploads.FileName);

        try
        {

            string[] Query1 = Request.QueryString[0].Split('*');

            string Make = Query1[0];
            if (Make == "undefined")
                Make = Session["SelMake"].ToString();
            string Model = Query1[1];
            Model = Model.Replace("/", "@");
            Model = Model.Replace("&", "@");
            if (Model == "undefined") Model = Session["SelModel"].ToString();
            string Year = Query1[2];
            if (Year == "undefined") Year = Session["SelYear"].ToString();
            string CarID = Query1[3];
            if (CarID == "undefined") CarID = Session["CarID"].ToString();

            int k = 0;

            if (Session["k"] == null)
            {
                k = 0;
            }
            else
            {
                k = Convert.ToInt32(Session["k"].ToString()) + 1;
            }



            ////------------ Server in local test ----------------//


            string Filepath = "CarImages/" + Year + "/" + Make + "/" + Model + "/" + CarID + "/";
            string FileNameFullPath = @"C:/Inetpub/wwwroot/COMMONIMAGES/CarImages/" + Year + "/" + Make + "/" + Model + "/" + CarID;

            //string Filepath = "CarImages/" + Year + "/" + Make + "/" + Model + "/" + CarID + "/";
            //string FileNameFullPath = Server.MapPath("CarImages/" + Year + "/" + Make + "/" + Model + "/" + CarID);
            //////------------ Server in local test ----------------//



            //string ipaddress = "C:/Inetpub/vhosts/http://66.23.236.151/";
            //string a = ipaddress + Filepath;
            //Uri test = new Uri(a);
            //DirectoryInfo mydir = new DirectoryInfo(a);
            //if (Directory.Exists(mydir.ToString()))
            //{
            //    uploads.SaveAs(a + "\\" + a);
            //}
            //else
            //{
            //    Directory.CreateDirectory(a);
            //    uploads.SaveAs(a + a);
            //}


            Session["k"] = k;
            string SelModel = Model.Replace(" ", "-");
            string sNewFileName = Year + "_" + Make + "_" + SelModel + "_" + CarID + k + ".jpg";
            string sNewFileName1 = Year + "_" + Make + "_" + SelModel + "_" + CarID + k + "Thumb.jpg";


            string FileNameSaveData = FileNameFullPath + "/" + sNewFileName;
            string FileNameSaveData1 = FileNameFullPath + "/" + sNewFileName1;

            if (System.IO.Directory.Exists(FileNameFullPath) == false)
            {
                System.IO.Directory.CreateDirectory(FileNameFullPath);
            }

            uploads.SaveAs(FileNameSaveData);
           
            Bitmap oBitmap = default(Bitmap);

            oBitmap = new Bitmap(FileNameSaveData);
            Graphics oGraphic = default(Graphics);

            int newwidthimg = 600;
            // Here create a new bitmap object of the same height and width of the image.
            float AspectRatio = (float)oBitmap.Size.Width / (float)oBitmap.Size.Height;

            int newHeight = Convert.ToInt32(newwidthimg / AspectRatio);

            Bitmap bmpNew = new Bitmap(newwidthimg, newHeight);
            oGraphic = Graphics.FromImage(bmpNew);

            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;


            oGraphic.DrawImage(oBitmap, new Rectangle(0, 0, bmpNew.Width, bmpNew.Height), 0, 0, oBitmap.Width, oBitmap.Height, GraphicsUnit.Pixel);
            // Release the lock on the image file. Of course,
            // image from the image file is existing in Graphics object
            oBitmap.Dispose();
            oBitmap = bmpNew;

            //SolidBrush oBrush = new SolidBrush(Color.Black);
            //Font ofont = new Font("Arial", 8);
            //oGraphic.DrawString("Some text to write", ofont, oBrush, 10, 10);
            //oGraphic.Dispose();
            //ofont.Dispose();
            //oBrush.Dispose();
            oBitmap.Save(FileNameSaveData, ImageFormat.Jpeg);

            oBitmap.Dispose();

            if (Session["RegUSER_ID"]!=null )
            {
                Session[Constants.USER_ID]=Session["RegUSER_ID"].ToString();
            }

            DataSet dsImgID = objdropdownBL.USP_SavePictures(Filepath, sNewFileName, "jpg", Convert.ToInt32(Session[Constants.USER_ID].ToString()));

            ArrayList str = new ArrayList();

            str.Add(dsImgID.Tables[0].Rows[0]["picID"].ToString());

            DataSet dsImagesData = objdropdownBL.USP_GetImages(Convert.ToInt32(CarID), 7);


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


            for (int j = 0; j < str.Count; j++)
            {

                if (str[j].ToString() != "" && str[j].ToString() != "0" && str[j].ToString() != " ")
                {

                    if (objcarsInfo.Pic1 == null || objcarsInfo.Pic1 == "" || objcarsInfo.Pic1 == "0")
                    {
                        objcarsInfo.Pic1 = str[j].ToString();
                        uploads.SaveAs(FileNameSaveData1);

                        Bitmap oBitmap1 = default(Bitmap);
                        oBitmap1 = new Bitmap(FileNameSaveData1);
                        Graphics oGraphic1 = default(Graphics);

                        int newwidthimg1 = 250;
                        // Here create a new bitmap object of the same height and width of the image.
                        float AspectRatio1 = (float)oBitmap1.Size.Width / (float)oBitmap1.Size.Height;

                        int newHeight1 = Convert.ToInt32(newwidthimg1 / AspectRatio);

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
                        oBitmap1.Save(FileNameSaveData1, ImageFormat.Jpeg);

                        oBitmap.Dispose();




                        DataSet dsImgID1 = objdropdownBL.USP_SavePictures(Filepath, sNewFileName, "jpg", Convert.ToInt32(Session[Constants.USER_ID].ToString()));
                       

                        objcarsInfo.Pic0 = dsImgID1.Tables[0].Rows[0]["picID"].ToString();
                    }
                    else if (objcarsInfo.Pic2 == null || objcarsInfo.Pic2 == "" || objcarsInfo.Pic2 == "0")
                    {
                        objcarsInfo.Pic2 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic3 == null || objcarsInfo.Pic3 == "" || objcarsInfo.Pic3 == "0")
                    {
                        objcarsInfo.Pic3 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic4 == null || objcarsInfo.Pic4 == "" || objcarsInfo.Pic4 == "0")
                    {
                        objcarsInfo.Pic4 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic5 == null || objcarsInfo.Pic5 == "" || objcarsInfo.Pic5 == "0")
                    {
                        objcarsInfo.Pic5 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic6 == null || objcarsInfo.Pic6 == "" || objcarsInfo.Pic6 == "0")
                    {
                        objcarsInfo.Pic6 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic7 == null || objcarsInfo.Pic7 == "" || objcarsInfo.Pic7 == "0")
                    {
                        objcarsInfo.Pic7 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic8 == null || objcarsInfo.Pic8 == "" || objcarsInfo.Pic8 == "0")
                    {
                        objcarsInfo.Pic8 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic9 == null || objcarsInfo.Pic9 == "" || objcarsInfo.Pic9 == "0")
                    {
                        objcarsInfo.Pic9 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic10 == null || objcarsInfo.Pic10 == "" || objcarsInfo.Pic10 == "0")
                    {
                        objcarsInfo.Pic10 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic11 == null || objcarsInfo.Pic11 == "" || objcarsInfo.Pic11 == "0")
                    {
                        objcarsInfo.Pic11 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic12 == null || objcarsInfo.Pic12 == "" || objcarsInfo.Pic12 == "0")
                    {
                        objcarsInfo.Pic12 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic13 == null || objcarsInfo.Pic13 == "" || objcarsInfo.Pic13 == "0")
                    {
                        objcarsInfo.Pic13 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic14 == null || objcarsInfo.Pic14 == "" || objcarsInfo.Pic14 == "0")
                    {
                        objcarsInfo.Pic14 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic15 == null || objcarsInfo.Pic15 == "" || objcarsInfo.Pic15 == "0")
                    {
                        objcarsInfo.Pic15 = str[j].ToString();
                    }

                    else if (objcarsInfo.Pic16 == null || objcarsInfo.Pic16 == "" || objcarsInfo.Pic16 == "0")
                    {
                        objcarsInfo.Pic16 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic17 == null || objcarsInfo.Pic17 == "" || objcarsInfo.Pic17 == "0")
                    {
                        objcarsInfo.Pic17 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic18 == null || objcarsInfo.Pic18 == "" || objcarsInfo.Pic18 == "0")
                    {
                        objcarsInfo.Pic18 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic19 == null || objcarsInfo.Pic19 == "" || objcarsInfo.Pic19 == "0")
                    {
                        objcarsInfo.Pic19 = str[j].ToString();
                    }
                    else if (objcarsInfo.Pic20 == null || objcarsInfo.Pic20 == "" || objcarsInfo.Pic20 == "0")
                    {
                        objcarsInfo.Pic20 = str[j].ToString();
                    }
                }
                objcarsInfo.CarID = Convert.ToInt32(CarID);
            }

            bool bnew = objdropdownBL.USP_UpdatePicturesById(objcarsInfo, Convert.ToInt32(Session[Constants.USER_ID].ToString()));

         }
        catch(Exception ex)
        {

        }
        //Session["TextBoxName"] = "Continue";
    }

  
    

}
