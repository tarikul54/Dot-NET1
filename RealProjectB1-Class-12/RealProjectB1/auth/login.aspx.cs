using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectB1.auth
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMsg.Visible = false;
            }
           
        }

        protected void btnLogin1_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue()==false)
            {
                if (txtUsername.Text == "admin" && txtPassword.Text == "123")
                {
                    Session["UserId"] = "1";
                    Session["UserName"] = "Admin";
                    Response.Redirect("~/AdminHome.aspx");
                }
                else
                {
                    lblMsg.Text = "Incorrect Username or Password";
                    divMsg.Visible = true;
                }
            }
           
        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtUsername.Text=="")
            {
                IsReq = true;
                lblMsg.Text = "Username can't be empty";

            }
            else if (txtPassword.Text =="")
            {
                IsReq = true;
                lblMsg.Text = "Password can't be empty";
            }

            if (IsReq==true)
            {
                divMsg.Visible = true;
            }
            else
            {
                divMsg.Visible = false;
            }

            return IsReq;
        }


    }
}