using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DAL;
using BEL;
namespace BAL
{
    public class BAL_Phieumuon
    {
        public DataTable DocDSPhieuMuon()
        {
            DAL_Phieumuon xuly = new DAL_Phieumuon();
            return xuly.DocDSPhieuMuon();

        }
    }
}
