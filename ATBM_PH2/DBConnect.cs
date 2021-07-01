using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OracleClient;


namespace ATBM_PH2
{
    class DBConnect
    {
        public static String userName = "";
        public static String passWords = "";
        public static String ConString = String.Format("Data Source = (DESCRIPTION = (ADDRESS_LIST = (ADDRESS = (PROTOCOL = TCP)(HOST = localhost)(PORT = 1521)))(CONNECT_DATA = (SERVER = DEDICATED)(SERVICE_NAME = xe))); User Id ={0}; Password ={1}", userName, passWords);
    } 
}
