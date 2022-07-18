using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class SetupBLL
    {
        SetupDAL objSetup = new SetupDAL();
        public int Setup_InsertUpdateDelete(int Action, string Category, int UserId, int CategoryId = 0)
        {
            int ret = 0;
            ret = objSetup.Setup_InsertUpdateDelete(Action,Category,UserId,CategoryId);
            return ret;
        }
        public int SetupSubcategory_InsertUpdateDelete(int Action, int CategoryId, string SubCategory, int UserId, int SubCategoryId = 0)
        {
            int ret = 0;
            ret = objSetup.SetupSubcategory_InsertUpdateDelete(Action, CategoryId, SubCategory, UserId, SubCategoryId);
            return ret;
        }
        public DataTable LoadCategory()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadCategory();
            return dt;
        }
        public DataTable LoadSubCategory()
        {
            DataTable dt = new DataTable();
            dt = objSetup.LoadSubCategory();
            return dt;
        }
    }
}
