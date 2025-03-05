using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduOne.Fr.Helpers
{
    public static class ReportsHelper
    {
        public static TableLogOnInfos GetLogOnInfos()
        {
            string server = DbHelpers.DbHost;
            string database = DbHelpers.DbName;
            string userID = DbHelpers.DbUser;
            string password = DbHelpers.DbUserPass;
            string table = DbHelpers.DbTableName;
            TableLogOnInfo logOnInfo = new TableLogOnInfo();

            logOnInfo.ConnectionInfo.ServerName = server;
            logOnInfo.ConnectionInfo.DatabaseName = database;
            logOnInfo.ConnectionInfo.UserID = userID;
            logOnInfo.ConnectionInfo.Password = password;
            logOnInfo.TableName = table;

            return new TableLogOnInfos
            {
                logOnInfo
            };
        }

    }
}
