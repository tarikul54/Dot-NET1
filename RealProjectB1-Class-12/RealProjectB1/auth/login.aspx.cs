using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealProjectB1.auth
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private object dtUserInfo;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                divMsg.Visible = false;
                RememberCookie();
                //if (Request.Cookies["UserName"].Text `!= null && Request.Cookies["Password"].Text != null)
                //{
                //    txtUsername.Text = Request.Cookies["UserName"].Value;
                //    txtPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                //}
            }
           
        }
        private void RememberCookie()
        {
            if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
            {
                txtUsername.Text = Request.Cookies["UserName"].Value;
                txtPassword.Attributes["Value"] = Request.Cookies["Password"].Value;
            }
        }
   
        private DataTable CheckLogin(string UserName,string Upass )
        {
            DataTable dt = new DataTable();
            string Connectionstr = @"Data Source = TEAMOS-PC/TARIKUL_SERVER;Initial Catalog = DOTNETB1;User ID =sa;Password =123";
            SqlConnection cnn;
            cnn = new SqlConnection(Connectionstr);
            SqlCommand cmd;
            string sqlStr = @"select UserAuth.UserId,
                (UserRegistration.FirstName+' '+ ISNULL(UserRegistration.MiddleName,'')+' '+UserRegistration.LastName) as FullName,
                  UserImage

                from UserAuth INNER JOIN
                UserRegistration
                ON UserAuth.UserId = UserRegistration.UserId
                where IsActive=1 and UserAuth.UserName='"+ UserName + "' and UserAuth.UserPassword = '"+ Upass + "'";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                cnn.Open();
                cmd = new SqlCommand(sqlStr,cnn);

                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
                cnn.Close();
            }
            catch (Exception)
            {

            }

                return dt;
        }
        protected void btnLogin1_Click(object sender, EventArgs e)
        {
            if (CheckFieldValue() == false)

            {
                DataTable dtUserInfo = CheckLogin(txtUsername.Text.Trim(), txtPassword.Text);
                if (dtUserInfo.Rows.Count>0)
                {
                    Session["UserId"] = dtUserInfo.Rows[0]["UserId"].ToString();
                    Session["UserName"] = dtUserInfo.Rows[0]["FullName"].ToString();
                    Session["UserImage"] = dtUserInfo.Rows[0]["UserImage"].ToString();
                    setcookie();
                    Response.Redirect("~/AdminHome.aspx");
                }
                else
                {
                    lblMsg.Text = "Incorrect Username or Password";
                    divMsg.Visible = true;
                }
            }
           
        }
        private void setcookie()
        {
            HttpCookie myCookie = new HttpCookie("mycookie");
            myCookie["UserName"] = txtUsername.Text.Trim();
            myCookie["Password"] = txtPassword.Text.Trim();
            Response.Cookies.Add(myCookie);
            if (ChkRememberMe .Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(3);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(3);

            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            }
            Response.Cookies["UserName"].Value = txtUsername.Text.Trim();
            Response.Cookies["Password"].Value = txtPassword.Text.Trim();
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