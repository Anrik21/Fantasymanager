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

        public Filepeon()
        {
           Directory.CreateDirectory(SaveFolder);
            
        }

        public void SaveToXML(List<CalendarEntity> objToSave, string filename)
        {
            PeonsXmlSerializer = new XmlSerializer(typeof(List<CalendarEntity>), new Type[] { typeof(CalendarYear) });
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