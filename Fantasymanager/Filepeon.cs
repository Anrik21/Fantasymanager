using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using System.IO;


namespace Fantasymanager
{
    class Filepeon
    {
        private string SaveFolder = String.Format("{0}/FantasyData/", AppDomain.CurrentDomain.BaseDirectory);
        XmlSerializer PeonsXmlSerializer;
        XmlAttributes attributes;
        XmlElementAttribute yearAttribute, monthAttribute, dayAttribute,eventAttribute;
        XmlAttributeOverrides xmlOverrides;

        /// <summary>
        /// On creation of this object a directory is created called savedfolder in the currentdomain.basedirectory
        /// It also generates attributes necessary for serialization
        /// </summary>
        public Filepeon()
        {
            Directory.CreateDirectory(SaveFolder);
            attributes = new XmlAttributes();
            xmlOverrides = new XmlAttributeOverrides();

            yearAttribute = new XmlElementAttribute();
            yearAttribute.ElementName = "Years";
            yearAttribute.Type = typeof(CalendarYear);
            monthAttribute = new XmlElementAttribute();
            monthAttribute.ElementName = "Months";
            monthAttribute.Type = typeof(CalendarMonth);
            dayAttribute = new XmlElementAttribute();
            dayAttribute.ElementName = "Days";
            dayAttribute.Type = typeof(CalendarDay);
            eventAttribute = new XmlElementAttribute();
            eventAttribute.ElementName = "Events";
            eventAttribute.Type = typeof(CalendarEvent);
            
            attributes.XmlElements.Add(monthAttribute);

            xmlOverrides.Add(typeof(CalendarYear), "Months", attributes);
            attributes.XmlElements.Add(dayAttribute);

            xmlOverrides.Add(typeof(CalendarMonth), "Months", attributes);
            attributes.XmlElements.Add(eventAttribute);

            xmlOverrides.Add(typeof(CalendarDay), "Months", attributes);
            attributes.XmlElements.Add(yearAttribute);

            xmlOverrides.Add(typeof(CalendarEvent), "Months", attributes);
        }

        public void SaveToXML(List<CalendarEntity> objToSave, string filename)
        {
            PeonsXmlSerializer = new XmlSerializer(typeof(List<CalendarEntity>), new Type[] { typeof(CalendarYear), typeof(CalendarDay), typeof(List<CalendarMonth>),typeof(List<CalendarEvent>)});
            TextWriter writer = new StreamWriter(filename);

            // Removed this looping because it created XML headers between every object which was like 40% overhead. 
            //    foreach (CalendarEntity entity in objToSave)
            //  {
            //    PeonsXmlSerializer.Serialize(writer, entity);
            //  }

            PeonsXmlSerializer.Serialize(writer, objToSave);
            writer.Close();
        }       
    }
}