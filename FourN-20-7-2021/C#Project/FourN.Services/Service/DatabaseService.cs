using FourN.Services.IService;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.IO.Directory;

namespace FourN.Services.Service
{
    public class DatabaseService : IDatabaseService
    {
        public async Task<bool> CreateBackup(string path)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand sqlcmd = new SqlCommand();
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            con.ConnectionString = "Data Source=MSI\\SQLEXPRESS;Initial Catalog=FourN6;Integrated Security=true;";

            //string backupDIR = "C:\\BackupDB";
            string backupDIR = path;
            if (!Exists(backupDIR))
            {
                return false;
            }
            try
            {
                con.Open();
                sqlcmd = new SqlCommand("backup database FourN6 to disk='" + backupDIR + "\\" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", con);
                sqlcmd.ExecuteNonQuery();
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
