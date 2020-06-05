using System;
using System.IO;
using System.Xml.Serialization;
namespace BankerAlgorithm
{
    //xml文件的输入输出
    class OsManager
    {
        public static void Export(string path, MyDictionary<string, int> test)
        {
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                XmlSerializer xS = new XmlSerializer(typeof(MyDictionary<string, int>));
                xS.Serialize(fs, test);

            }
        }
        public static MyDictionary<string, int> Import(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                XmlSerializer xS = new XmlSerializer(typeof(MyDictionary<string, int>));
                MyDictionary<string, int> file_order = (MyDictionary<string, int>)xS.Deserialize(fs);
                foreach (var o in file_order)
                {
                    Console.WriteLine(o.Key);
                }
                return file_order;



            }
        }
    }
}
