using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
namespace CSharpAnimationTest1
{
    [XmlRoot("dictionary")]
    public class MyDictionary<TKey, TValue>

         : Dictionary<TKey, TValue>, IXmlSerializable

    {

        #region IXmlSerializable Members

        public System.Xml.Schema.XmlSchema GetSchema()

        {

            return null;

        }



        public void ReadXml(System.Xml.XmlReader reader)

        {
            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));
            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            bool wasEmpty = reader.IsEmptyElement;
            reader.Read();
            if (wasEmpty)
            {
                Console.WriteLine("wasEmpty");
                return;
            }
            Console.WriteLine("wasNotEmpty");
            while (reader.NodeType != System.Xml.XmlNodeType.EndElement)

            {
                reader.ReadStartElement("item");
                reader.ReadStartElement("key");
                TKey key = (TKey)keySerializer.Deserialize(reader);
                reader.ReadEndElement();
                reader.ReadStartElement("value");
                TValue value = (TValue)valueSerializer.Deserialize(reader);
                this[key] = value;
                reader.ReadEndElement();
                reader.ReadEndElement();
                reader.MoveToContent();
            }
            reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)

        {

            XmlSerializer keySerializer = new XmlSerializer(typeof(TKey));

            XmlSerializer valueSerializer = new XmlSerializer(typeof(TValue));
            foreach (TKey key in this.Keys)

            {

                writer.WriteStartElement("item");



                writer.WriteStartElement("key");

                keySerializer.Serialize(writer, key);

                writer.WriteEndElement();



                writer.WriteStartElement("value");

                TValue value = this[key];

                valueSerializer.Serialize(writer, value);

                writer.WriteEndElement();



                writer.WriteEndElement();

            }

        }
        #endregion
    }
    [Serializable]
    public class OrderItem
    {
        public OrderItem() { }
        public MyDictionary<String, String> dic = new MyDictionary<string, string>();
        public OrderItem(MyDictionary<string, string> d)
        {
            dic = d;
        }

        public override bool Equals(object obj)
        {
            var item = obj as OrderItem;
            return item != null &&
                   EqualityComparer<MyDictionary<string, string>>.Default.Equals(dic, item.dic);
        }

        public IEnumerator<string> GetEnumerator()
        {
            foreach (string key in dic.Keys)
            {
                yield return key;
            }
        }

        public override int GetHashCode()
        {
            return 149728143 + EqualityComparer<MyDictionary<string, string>>.Default.GetHashCode(dic);
        }

        public string GetValue(string key)
        {
            return dic[key];
        }

        public override string ToString()
        {
            String res = "";
            foreach (string key in dic.Keys)
            {
                res += $"{{ {key}:{dic[key]}}},";
            }
            return res;
        }
    }
}
