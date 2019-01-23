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
            PeonsXmlSerializer = new XmlSerializer(typeof(CalendarEntity));
            TextWriter writer = new StreamWriter(filename);

            foreach (CalendarEntity entity in objToSave)
                PeonsXmlSerializer.Serialize(writer, entity);

            writer.Close();
        }

       
    }
}