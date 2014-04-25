using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Xml.Linq;

namespace urle
{
    public class Global : System.Web.HttpApplication
    {

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {
            try
            {
                //string originalURL = Request.Url.ToString().ToLower();
                //if (originalURL.IndexOf("/mobicarz/") > 0)
                //{
                //    string productid = originalURL.Substring(originalURL.IndexOf("/mobicarz/") + "/mobicarz/".Length).Split(new char[] { '/' })[0];
                //    string rewriteURL = Request.Url.AbsolutePath.Substring(0, Request.Url.AbsolutePath.IndexOf("/mobicarz/")) + "/displayproductdetails.aspx?productid=" + productid;
                //    Context.RewritePath(rewriteURL);
                //}

            }
            catch
            {

            }
        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}