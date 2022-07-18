using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SetupDAL
    {
        public int Setup_InsertUpdateDelete(int Action,string Category, int UserId, int CategoryId=0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "Cetegory", DbType.String, Category);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "CategoryId", DbType.Int32, CategoryId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public int SetupSubcategory_InsertUpdateDelete(int Action, int CategoryId, string SubCategory, int UserId, int SubCategoryId = 0)
        {
            int ret = 0;
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSubCategorySp_insertUpdateDelete");

            db.AddInParameter(dbcmd, "Action", DbType.Int32, Action);
            db.AddInParameter(dbcmd, "CategoryId", DbType.Int32, CategoryId);
            db.AddInParameter(dbcmd, "SubCetegory", DbType.String, SubCategory);
            db.AddInParameter(dbcmd, "UserId", DbType.Int32, UserId);
            db.AddInParameter(dbcmd, "SubCategoryId", DbType.Int32, SubCategoryId);

            ret = db.ExecuteNonQuery(dbcmd);

            return ret;
        }

        public DataTable LoadCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetCategory");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }
        public DataTable LoadSubCategory()
        {
            DataTable dt = new DataTable();
            Database db;
            DbCommand dbcmd;
            db = DatabaseFactory.CreateDatabase("cnn");
            dbcmd = db.GetStoredProcCommand("SetupSp_GetSubCategory");
            dt = db.ExecuteDataSet(dbcmd).Tables[0];

            return dt;
        }


    }
}
