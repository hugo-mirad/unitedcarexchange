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

public partial class UserControl_LoginName : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session[Constants.NAME] == null)
            {
                lnkLogin.Visible = true;
                lnkBtnLogout.Visible = false;
                lblUserName.Visible = false;
                lblWelcome.Visible = false;
                myaccDiv.Style["visibility"] = "hidden";

                if (Session["PageName"] != null)
                {

                    if (Session["PageName"].ToString() == "PromotionbyStatecity")
                    {
                        lblLang.Visible = false;
                        lnbtnLang.Visible = false;
                    }
                }
            }
            else
            {
                lnkLogin.Visible = false;
                lnkBtnLogout.Visible = true;
                lblUserName.Visible = true;
                lblWelcome.Visible = true;
                string LogUsername = Session[Constants.NAME].ToString();
                if (Session["CurrentPage"].ToString() == "Account")
                {
                    lnkMyaccount.Enabled = false;
                }
                else
                {
                    lnkMyaccount.Enabled = true;
                }
                if (LogUsername.Length > 10)
                {
                    lblUserName.Text = LogUsername.ToString().Substring(0, 10);
                }
                else
                {
                    lblUserName.Text = LogUsername;
                }

                if (Session["PageName"] != null)
                {

                    if (Session["PageName"].ToString() == "PromotionbyStatecity")
                    {
                        lblLang.Visible = false;
                        lnbtnLang.Visible = false;
                    }
                }

                myaccDiv.Style["visibility"] = "visible";
            }
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
}
