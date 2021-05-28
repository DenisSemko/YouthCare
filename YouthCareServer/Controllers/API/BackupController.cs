using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using System.Data;
using Microsoft.IdentityModel.Protocols;
using Newtonsoft.Json.Serialization;

namespace YouthCareServer.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class BackupController : ControllerBase
    {
        private IConfiguration configuration { get; set; }

        public BackupController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> GenerateBackupFile()
        {
            try
            {
                await Task.Run(() =>
                {
                    string dbConnectionString = configuration.GetConnectionString("DefaultConnection");
                    string backupDestination = "C:\\SQLBackUpFolder\\";

                    if (!System.IO.Directory.Exists(backupDestination))
                    {
                        System.IO.Directory.CreateDirectory("D:\\SQLBackUpFolder");
                    }
                    SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder(dbConnectionString);
                    var backupFileName = $"{backupDestination}{sqlConnectionStringBuilder.InitialCatalog}-{DateTime.Now.ToString("yyyy-MM-dd")}.bak";
                    if (System.IO.File.Exists(backupFileName))
                        System.IO.File.Delete(backupFileName);
                    using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ConnectionString))
                    {
                        string backupQuery = $"BACKUP DATABASE {sqlConnectionStringBuilder.InitialCatalog} TO DISK='{backupFileName}'";
                        using (SqlCommand command = new SqlCommand(backupQuery, connection))
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                        }
                    }
                });
                return StatusCode(200);
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        /* public void GetBackup()
         {
             SqlConnection sqlconn = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
             SqlCommand sqlcmd = new SqlCommand();
             SqlDataAdapter da = new SqlDataAdapter();
             DataTable dt = new DataTable();
             string backupDestination = "C:\\SQLBackUpFolder";

             if (!System.IO.Directory.Exists(backupDestination))
             {
                 System.IO.Directory.CreateDirectory("D:\\SQLBackUpFolder");
             }
             try
             {
                 sqlconn.Open();
                 sqlcmd = new SqlCommand("backup database YouthCareMainDb to disk='" + backupDestination + "\'" + DateTime.Now.ToString("ddMMyyyy_HHmmss") + ".Bak'", sqlconn);
                 sqlcmd.ExecuteNonQuery();
                 //Close connection
                 sqlconn.Close();
             }
             catch (Exception ex)
             {
             }
         }*/
    }
}
