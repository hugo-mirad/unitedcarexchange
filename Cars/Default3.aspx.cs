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
using System.IO;
using CarsBL.Transactions;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        DataSet dsSiteMap = new DataSet();

        SiteMapBL objSiteMap = new SiteMapBL();
        string sPath = string.Empty;

        sPath = "XML/SiteMap.xml";

        sPath = Server.MapPath(sPath);

        FileStream fs = new FileStream(sPath, FileMode.Open);


        dsSiteMap.ReadXml(fs);

        fs.Close();

        DataSet SiteMapds = objSiteMap.SearchUsedCars();

        for (int k = 0; k < SiteMapds.Tables[0].Rows.Count; k++)
        {

            dsSiteMap.Tables[0].Rows.Add();
            //http://UnitedCarExchange.com/SearchCarDetails.aspx?Make=Toyota&Model=Sienna&ZipCode=0&WithinZip=5&C=zIgOMkOB46344
            //http://UnitedCarExchange.com//2010-Hyundai-Santa%20Fe-707638577695

            string sUrl = "http://www.UnitedCarExchange.com/Buy-Sell-UsedCar/" + SiteMapds.Tables[0].Rows[k]["YearofMake"].ToString() + "-" + SiteMapds.Tables[0].Rows[k]["Make"].ToString() + "-" + SiteMapds.Tables[0].Rows[k]["Model"].ToString() + "-" + SiteMapds.Tables[0].Rows[k]["Caruniqueid"].ToString() + "";

            //dsSiteMap.Tables[0].Rows[dsSiteMap.Tables["url"].Rows.Count - 1][0] = sUrl;
            dsSiteMap.Tables[0].Rows[dsSiteMap.Tables["url"].Rows.Count - 1][0] = sUrl.Replace('&', '-');

        }
        StreamWriter xmlDoc = new StreamWriter((sPath), false);

        dsSiteMap.WriteXml(xmlDoc);

        xmlDoc.Close();

    }
    protected void btnStateWiseURL_Click(object sender, EventArgs e)
    {

        DataSet dsSiteMap = new DataSet();

        SiteMapBL objSiteMap = new SiteMapBL();
        string sPath = string.Empty;

        sPath = "XML/XMLStateCityURLs.xml";

        sPath = Server.MapPath(sPath);

        FileStream fs = new FileStream(sPath, FileMode.Open);


        dsSiteMap.ReadXml(fs);

        fs.Close();

        DataSet SiteMapds = objSiteMap.XmlSiteMapbyCityState();

        for (int k = 0; k < SiteMapds.Tables[0].Rows.Count; k++)
        {

            dsSiteMap.Tables[0].Rows.Add();

            string sUrl = "http://www.UnitedCarExchange.com/SellUsedCars/" + SiteMapds.Tables[0].Rows[k]["state"].ToString() + "/" + SiteMapds.Tables[0].Rows[k]["city"].ToString().Replace("#", "");

            //dsSiteMap.Tables[0].Rows[dsSiteMap.Tables["url"].Rows.Count - 1][0] = sUrl;
            dsSiteMap.Tables[0].Rows[dsSiteMap.Tables["url"].Rows.Count - 1][0] = sUrl.Replace('&', '-');

        }
        StreamWriter xmlDoc = new StreamWriter((sPath), false);

        dsSiteMap.WriteXml(xmlDoc);

        xmlDoc.Close();


    }
}
