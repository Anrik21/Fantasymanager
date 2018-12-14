using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fantasymanager
{
    class Filepeon
    {
        private string SaveFolder = String.Format("{0}/FantasyData/", AppDomain.CurrentDomain.BaseDirectory); 

        public Filepeon()
        {
            System.IO.Directory.CreateDirectory(SaveFolder);
        }

        public bool FileCreate(string filename)
        {


        }
    }
}
