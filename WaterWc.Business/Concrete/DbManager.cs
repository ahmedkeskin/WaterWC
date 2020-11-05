using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterWc.Business.Abstract;

namespace WaterWc.Business.Concrete
{
    public class DbManager : IDbService
    {
        private void GenerateDbFromTemp()
        {
            var tempDbFile = $@"{Environment.CurrentDirectory}\dbTemp.imp";
            var newDbFile = $@"{Environment.CurrentDirectory}\database.xml";
            if (!File.Exists(tempDbFile))
            {
                throw new Exception("Db Template file could not found!");
            }
            else
            {
                File.Copy(tempDbFile, newDbFile);
            }
        }
        public bool CheckDbExist()
        {
            var dbFile = $@"{Environment.CurrentDirectory}\database.xml";
            if (!File.Exists(dbFile))
            {
                GenerateDbFromTemp();
            }
            return true;
        }

        public void GetNewDay()
        {
            var dbFile = $@"{Environment.CurrentDirectory}\database.xml";
            var dbNewFile = $@"{Environment.CurrentDirectory}\database{DateTime.Now.AddDays(-1).ToString("yyyyMMdd")}.xml";
            if (File.Exists(dbFile) && !File.Exists(dbNewFile))
            {
                File.Move(dbFile, dbNewFile);
            }
        }
    }
}
