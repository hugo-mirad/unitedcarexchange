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

public partial class Reviews : System.Web.UI.Page
{
    CarFeatures objCarFeatures = new CarFeatures();
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

                GeneralFunc.SetPageDefaults(Page);
                Session["CurrentPage"] = "Reviews";


                string carid = Session["CaruniqueId"].ToString();


                //Questions
                DataSet DiscusinsQuestion = new DataSet();
                DiscusinsQuestion = objCarFeatures.GetCarDiscussions(carid);
                Session["Discusins"] = DiscusinsQuestion;
                rpt1.DataSource = DiscusinsQuestion.Tables[0];
                rpt1.DataBind();


                //Answer Questions
                DataSet DiscusinsAnswers = new DataSet();
                DiscusinsAnswers = objCarFeatures.GetCarDiscussionsAnswerdata(carid);
                Session["Discusins"] = DiscusinsAnswers;
                rptpublDisc.DataSource = DiscusinsAnswers.Tables[0];
                rptpublDisc.DataBind();



                //   rptpublDisc.DataSource = DiscusinsAnswers.Tables[0];
                //  rptpublDisc.DataBind();


                DataSet rptDelete = new DataSet();
                rptDelete = objCarFeatures.GetCarDiscussionsDelete(carid);
                Session["DeleteDiscus"] = rptDelete;
                rptDeleted.DataSource = rptDelete;
                rptDeleted.DataBind();
            }
        }

    }
    protected void rpt1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Delete")
        {
            int Carvalue = Convert.ToInt32(e.CommandArgument);
            DataSet dsCarDetailsInfo = new DataSet();
            DateTime dt = DateTime.Now;
            dsCarDetailsInfo = objCarFeatures.UpdateDeletetoQuestion(Carvalue, dt);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Your Answer is deleted successfully.');", true);
            Response.Redirect(Request.RawUrl);
        }
        else if (e.CommandName == "Answer")
        {
            int QuestionId = Convert.ToInt32(e.CommandArgument);
            Session["QuestionId"] = QuestionId;
            DataSet Discusins = new DataSet();
            Discusins = objCarFeatures.GetCarDiscussionsByQuestionId(QuestionId);
            lblQuestAn.Text = Discusins.Tables[0].Rows[0]["DiscQuestion"].ToString();
            MdlAnswer.Show();
           
        }
    }
    protected void rpt1_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            DataSet dsTasks3 = (DataSet)Session["Discusins"];
            if (dsTasks3 != null)
            {
                Label sTitle = (Label)e.Item.FindControl("NewQuestion");
                Label lblpostdate = (Label)e.Item.FindControl("lblpostdate");
                sTitle.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscQuestion"].ToString();
                try
                {
                    lblpostdate.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscAnswerDate"].ToString() + " carid:(" + Session["carid"].ToString() + ")";
                }
                catch { }
                //DskDeletedDate
            }
        }
    }

   // rptpublDisc
    protected void rptpublDisc_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "PubDelete")
        {
            int Carvalue = Convert.ToInt32(e.CommandArgument);
            DataSet dsCarDetailsInfo = new DataSet();
            DateTime dt = DateTime.Now;
            dsCarDetailsInfo = objCarFeatures.UpdateDeletetoQuestion(Carvalue, dt);
            System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Your Answer is deleted successfully.');", true);
            Response.Redirect(Request.RawUrl);

            //int Carvalue = Convert.ToInt32(e.CommandArgument);
            //DataSet dsCarDetailsInfo = new DataSet();
            //DateTime dt = DateTime.Now;
            //dsCarDetailsInfo = objCarFeatures.UpdateDeletetoQuestion(Carvalue, dt);
            //System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Your Answer is deleted successfully.');", true);
            //Response.Redirect(Request.RawUrl);

        }
    }
    protected void rptpublDisc_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            DataSet dsTasks3 = (DataSet)Session["Discusins"];
            Label NewPubQuestion = (Label)e.Item.FindControl("NewPubQuestion");
            Label NewPubAnswe = (Label)e.Item.FindControl("NewPubAnswe");
            Label lblPublishpostdate = (Label)e.Item.FindControl("lblPublishpostdate");
            NewPubQuestion.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscQuestion"].ToString();
            NewPubAnswe.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscAnswer"].ToString();
            lblPublishpostdate.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscAnswerDate"].ToString();
            if (dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["PublishedDate"].ToString() != null)
                lblPublishpostdate.Text += "  Published on: " + dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["PublishedDate"].ToString();

        }
    }
    protected void rptDeleted_ItemDataBound(Object Sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            DataSet dsTasks3 = (DataSet)Session["DeleteDiscus"];
            if (dsTasks3 != null)
            {
                Label NewdeleteQuestion = (Label)e.Item.FindControl("NewdeleteQuestion");
                Label NewdeleteAnswe = (Label)e.Item.FindControl("NewdeleteAnswe");
                Label lbldeletedpostdate = (Label)e.Item.FindControl("lbldeletedpostdate");
                NewdeleteQuestion.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscQuestion"].ToString();
                NewdeleteAnswe.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DiscAnswer"].ToString();
                try
                {
                    lbldeletedpostdate.Text = dsTasks3.Tables[0].Rows[e.Item.ItemIndex]["DskDeletedDate"].ToString();
                }
                catch { }
            }

        }
    }

    protected void btnApprove_Click(object sender, EventArgs e)
    {

    }
    protected void btnpublish_click(object sender, EventArgs e)
    {
        DataSet dsCarDetailsInfo = new DataSet();
        DateTime dt = DateTime.Now;
        dsCarDetailsInfo = objCarFeatures.UpdateQuestion(Convert.ToInt32(Session["QuestionId"].ToString()), lblanswerQyes.Text, dt);
        System.Web.UI.ScriptManager.RegisterClientScriptBlock(Page, typeof(Page), "Script", "alert('Your Answer is published successfully.');", true);
        lblanswerQyes.Text = "";
        MdlAnswer.Hide();

        Response.Redirect(Request.RawUrl);


    }
}
