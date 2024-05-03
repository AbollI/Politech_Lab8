using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsLab7
{
    class SDerializator
    {
        public void ReadBin(ref object obj, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
            IFormatter formater = new BinaryFormatter();
            object output = (object)formater.Deserialize(fs);

            //return output;
            obj = output;
        }

        public void WriteBin(object obj, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create,FileAccess.Write);
            IFormatter formatter = new BinaryFormatter();

            formatter.Serialize(fs, obj);
            fs.Close();
        }

        public void ReadXML()
        { }

        public void WriteXML(Ratings obj, string path)
        {
            FileStream fs = new FileStream(path, FileMode.Create);
            //XmlObjectSerializer _xmlwriter = new XmlObjectSerializer();
            //_xmlwriter.WriteObject(fs, obj);


        }

    }

}
