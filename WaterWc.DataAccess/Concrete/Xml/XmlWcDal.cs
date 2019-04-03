using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using WaterWc.DataAccess.Abstract;
using WaterWc.Entities.Concrete;

namespace WaterWc.DataAccess.Concrete.Xml
{
    public class XmlWcDal : IWcDal
    {
        private readonly string _databaseFile;
        public XmlWcDal()
        {
            _databaseFile = "database.xml";
        }
        public void Add(Wc entity)
        {
            XDocument xDocument = XDocument.Load(_databaseFile);
            XElement node = new XElement("WcRecord",
                new XElement("Time", entity.Time.ToString(CultureInfo.InvariantCulture)));
            xDocument.Element("Database")?.Element("WcList")?.Add(node);
            xDocument.Save(_databaseFile);
        }

        public void Delete(Wc entity)
        {
            XDocument xDocument = XDocument.Load(_databaseFile);
            XElement node = xDocument.Descendants("WcRecord").FirstOrDefault(wcRecord => wcRecord.Element("Time")?.Value == entity.Time.ToString(CultureInfo.InvariantCulture));
            if (node != null)
            {
                node.Remove();
                xDocument.Save(_databaseFile);
            }
        }

        public List<Wc> GetAll()
        {
            XDocument xDocument = XDocument.Load(_databaseFile); //PROBLEM

            IEnumerable<Wc> records =
                from database in xDocument.Descendants("WcRecord")
                select new Wc
                (
                    Convert.ToDateTime(database.Element("Time")?.Value,CultureInfo.InvariantCulture)
                );
            return records.ToList(); //List<Water> waterList = new List<Water>();
        }

        public void Update(Wc entity)
        {
            
        }
    }
}
