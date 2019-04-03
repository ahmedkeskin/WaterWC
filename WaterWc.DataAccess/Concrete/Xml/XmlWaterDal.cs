using System;
using System.Collections.Generic;
using System.Globalization;
using WaterWc.DataAccess.Abstract;
using WaterWc.Entities.Concrete;
using System.Linq;
using System.Xml.Linq;


namespace WaterWc.DataAccess.Concrete.Xml
{   
    public class XmlWaterDal:IWaterDal
    {
        private readonly string _databaseFile;

        public XmlWaterDal()
        {
            _databaseFile = "database.xml";
        }

        public List<Water> GetAll()
        {
            XDocument xDocument = XDocument.Load(_databaseFile); //PROBLEM
            
            IEnumerable<Water> records =
                from database in xDocument.Descendants("WaterRecord")
                select new Water
                (
                    Convert.ToDateTime(database.Element("Time")?.Value, CultureInfo.InvariantCulture),
                    Convert.ToDouble((database.Element("Amount")?.Value), new CultureInfo("en-US"))
                );
            return records.ToList(); //List<Water> waterList = new List<Water>();
        }

        public void Add(Water water)
        {
            XDocument xDocument = XDocument.Load(_databaseFile);
            XElement node = new XElement("WaterRecord",
                new XElement("Time", water.Time.ToString(CultureInfo.InvariantCulture)),
                new XElement("Amount", water.Amount));
            xDocument.Element("Database")?.Element("WaterList")?.Add(node);
            xDocument.Save(_databaseFile);
        }
        public void Delete(Water water)
        {
            XDocument xDocument = XDocument.Load(_databaseFile);
            XElement node= xDocument.Descendants("WaterRecord").FirstOrDefault(q => q.Element("Time")?.Value == water.Time.ToString(CultureInfo.InvariantCulture));
           
            if (node != null)
            {
                node.Remove();
                xDocument.Save(_databaseFile);
            }
        }

        public void Update(Water water)
        {
            XDocument xDocument = XDocument.Load(_databaseFile);
            XElement node = xDocument.Descendants("WaterRecord").FirstOrDefault(waterRecord => waterRecord.Element("Time")?.Value == water.Time.ToString(CultureInfo.InvariantCulture));
            if (node != null)
            {
                node.SetElementValue("Amount", water.Amount);
                xDocument.Save(_databaseFile);
            }

        }
    }
}
