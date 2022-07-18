using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entity; 
using System.Data;

namespace BLL
{
    
    public class InstituteBLL
    {
        InstituteDAL objInsDAL = new InstituteDAL();

        public int InsertUpdateDelete_InstituteInfo(EInstitute objEIns)
        {
            int ret = 0;
            ret = objInsDAL.InsertUpdateDelete_Institute(objEIns);
            return ret;
        }
        public DataTable SetupSp_GetInstituteInfo()
        {
            DataTable dt = new DataTable();
            dt = objInsDAL.SetupSp_GetInstitute();
            return dt;
        }
    }
}
 