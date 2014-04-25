<%@ Application Language="C#" %>


<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        //RouteTable.Routes.Add(new ServiceRoute("",new WebServiceHostFactory(), typeof(Service)));


    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs

    }
    

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }
    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

        try
        {
            //string IPAddress = Request.Cookies["IpCookie"].Value;
            CarsBL.Transactions.VisitSiteLog objVisitSiteLog = new CarsBL.Transactions.VisitSiteLog();
            objVisitSiteLog.UpdatetimeCookie1(DateTime.Now.AddMinutes(-1));

        }
        catch { }
    }

    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        // This check will ensure that we need to sync session only during uploadify upload!
        if (HttpContext.Current.Request["RequireUploadifySessionSync"] != null)
            UploadifySessionSync();


        try
        {


            //if (originalURL.IndexOf("/mobicarz/") > 0)
            //{
            //    string productid = originalURL.Substring(originalURL.IndexOf("/mobicarz/") + "/mobicarz/".Length).Split(new char[] { '/' })[0];
            //    string rewriteURL = Request.Url.AbsolutePath.Substring(0, Request.Url.AbsolutePath.IndexOf("/mobicarz/")) + "/displayproductdetails.aspx?productid=" + productid;
            //    Context.RewritePath(rewriteURL);
            //}

            //http://localhost:44251/cars/buy-sell-usedcar.aspx?url=2008-buick-enclave-397962022594
            string originalURL = Request.Url.ToString().ToLower();
            if (originalURL.IndexOf("/usedcars/") > 0)
            {
                string productid = originalURL.Substring(originalURL.IndexOf("/usedcars/") + "/usedcars/".Length).Split(new char[] { '/' })[0];
                string rewriteURL = Request.Url.AbsolutePath.Substring(0, Request.Url.AbsolutePath.IndexOf("/usedcars/")) + "/Buy-Sell-UsedCar1.aspx?productid=" + productid;
                    Context.RewritePath(rewriteURL);
            }

        }
        catch
        {

        }

    }

    /// <summary>
    /// Uploadify uses a Flash object to upload files. This method retrieves and hydrates Auth and Session objects when the Uploadify Flash is calling.
    /// </summary>
    /// <remarks>
    ///     Kudos: http://geekswithblogs.net/apopovsky/archive/2009/05/06/working-around-flash-cookie-bug-in-asp.net-mvc.aspx
    ///     More kudos: http://stackoverflow.com/questions/1729179/uploadify-session-and-authentication-with-asp-net-mvc
    /// </remarks>
    protected void UploadifySessionSync()
    {
        try
        {
            string session_param_name = "SessionId";
            string session_cookie_name = "ASP.NET_SessionId";

            if (HttpContext.Current.Request[session_param_name] != null)
                UploadifyUpdateCookie(session_cookie_name, HttpContext.Current.Request.Form[session_param_name]);
        }
        catch { }

        try
        {
            string auth_param_name = "SecurityToken";
            string auth_cookie_name = FormsAuthentication.FormsCookieName;

            if (HttpContext.Current.Request[auth_param_name] != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(HttpContext.Current.Request.Form[auth_param_name]);

                if (ticket != null)
                {
                    FormsIdentity identity = new FormsIdentity(ticket);
                    // This helped us to restore user details
                    string[] roles = System.Web.Security.Roles.GetRolesForUser(identity.Name);
                    System.Security.Principal.GenericPrincipal principal = new System.Security.Principal.GenericPrincipal(identity, roles);
                    HttpContext.Current.User = principal;
                }

                UploadifyUpdateCookie(auth_cookie_name, HttpContext.Current.Request.Form[auth_param_name]);
            }
        }
        catch { }
    }

    private void UploadifyUpdateCookie(string cookie_name, string cookie_value)
    {
        HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
        if (cookie == null)
            cookie = new HttpCookie(cookie_name);
        cookie.Value = cookie_value;
        HttpContext.Current.Request.Cookies.Set(cookie);
    }
</script>
