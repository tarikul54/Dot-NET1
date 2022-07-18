using DAL;
using BLL;
using DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SchoolManagementSystem.Setup
{
    public partial class ConInstitute : System.Web.UI.Page
    {
        InstituteBLL ObjinsBLL = new InstituteBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CommonDAL.Fillddl(ddlDistrict, @"SELECT DistrictId, DistrictName FROM  Con_District
                    ORDER BY DistrictName", "DistrictName", "DistrictId");
                LoadGrid();

            }
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            CommonDAL.Fillddl(ddlUpazila, @"SELECT   UpazilaId, DistrictId, UpazilaName FROM   Con_Upazila
                WHERE(DistrictId = "+ddlDistrict.SelectedValue+") ORDER BY UpazilaName", "UpazilaName", "UpazilaId");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            if (CheckFieldValue()==false)
            {
                Save();
                LoadGrid();
            }
        }

        private void LoadGrid()
        {
            DataTable dt = new DataTable();
            dt = ObjinsBLL.SetupSp_GetInstituteInfo();
            if (dt.Rows.Count>0)
            {
                gvInstitute.DataSource = dt;
                gvInstitute.DataBind();
            }
            else
            {
                gvInstitute.DataSource = null;
                gvInstitute.DataBind();
            }
        }

        private void Save()
        {
            int save = 0;
            EInstitute objEIns = new EInstitute();

           
          
            objEIns.EIIN_RegistrationNo = txtEIIN.Text;
            objEIns.InstituteName = txtInstituteName.Text;
            objEIns.Email = txtEmail.Text;
            objEIns.Phone = txtPhone.Text;
            objEIns.Fax = txtFax.Text;
            objEIns.DistrictId = int.Parse(ddlDistrict.SelectedValue);
            objEIns.UpazilaId = int.Parse(ddlUpazila.SelectedValue);
            objEIns.Address = txtAddress.Text;
            objEIns.SchoolType = ddlInstituteType.SelectedValue;
            objEIns.EntryBy = int.Parse(Session["UserId"].ToString());

            if (btnSave.Text =="Save")
            {
                objEIns.Action = 1;
                objEIns.InstituteId = 0;
            }
            else if (btnSave.Text == "Update")
            {
                objEIns.Action = 2;
                objEIns.InstituteId = int.Parse(hdnUpdateInstituteId.Value);
            }
            save = ObjinsBLL.InsertUpdateDelete_InstituteInfo(objEIns);
            if (save>0)
            {
                rmIns.SuccessMessage = "Action Complete Successfully";
            }

        }

        private bool CheckFieldValue()
        {
            bool IsReq = false;

            if (txtEIIN.Text == "")
            {
                IsReq = true;
                rmIns.FailureMessage = "EIIN/ RegistrationNo can't be empty";
            }
            else if (txtInstituteName.Text == "")
            {
                IsReq = true;
                rmIns.SuccessMessage = "Institute Name can't be empty";
            }

            else if (txtEmail.Text == "")
            {
                IsReq = true;
                rmIns.SuccessMessage = "Email can't be empty";
            }
            else if (txtPhone.Text == "")
            {
                IsReq = true;
                rmIns.SuccessMessage = "Phone can't be empty";
            }
            else if (ddlDistrict.SelectedValue == "0")
            {
                IsReq = true;
                rmIns.SuccessMessage = "Select District";
            }
            else if (ddlUpazila.SelectedValue == "0" || ddlUpazila.SelectedIndex == -1)
            {
                IsReq = true;
                rmIns.SuccessMessage = "Select Upazila";
            }
            else if (txtAddress.Text == "")
            {
                IsReq = true;
                rmIns.FailureMessage = "Address can't be empty";
            }


            return IsReq;
        }



    }
}