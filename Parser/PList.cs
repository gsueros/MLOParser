using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Windows.Storage;
using Windows.Storage.Streams;
using System.IO;
using Windows.Foundation.Collections;

namespace PListLoader
{
    sealed class PList : Dictionary<string, dynamic> 
    {
        public PList()
        {
        }

        public PList(string file)
        {
            Load(file);
        }

        public void Load(string file)
        {
            Clear();

            StorageFile storagefile = StorageFile.GetFileFromApplicationUriAsync(new Uri(file)).AsTask().Result;
            Stream stream = storagefile.OpenStreamForReadAsync().Result;
            XDocument doc = XDocument.Load(stream);

            XElement plist = doc.Element("plist");
            XElement dict = plist.Element("dict");
            if (dict == null)
            {
                dict = plist.Element("array");

                var dictElements = dict.Elements();
                List<dynamic> list = new List<dynamic>();
                foreach (XElement e in dictElements)
                {
                    dynamic one = ParseValue(e);
                    list.Add(one);
                }
                this["array"] = list;

            }
            else
            {
                var dictElements = dict.Elements();
                Parse(this, dictElements);
            }
        }

        private void Parse(PList dict, IEnumerable<XElement> elements)
        {
            for (int i = 0; i < elements.Count(); i += 2)
            {
                XElement key = elements.ElementAt(i);
                XElement val = elements.ElementAt(i + 1);

                dict[key.Value] = ParseValue(val);
            }
        }

        private List<dynamic> ParseArray(IEnumerable<XElement> elements)
        {
            List<dynamic> list = new List<dynamic>();
            foreach (XElement e in elements)
            {
                dynamic one = ParseValue(e);
                list.Add(one);
            }

            return list;
        }

        private dynamic ParseValue(XElement val)
        {
            switch (val.Name.ToString())
            {
                case "string":
                    return val.Value;
                case "integer":
                    return int.Parse(val.Value);
                case "real":
                    return float.Parse(val.Value);
                case "true":
                    return true;
                case "false":
                    return false;
                case "dict":
                    PList plist = new PList();
                    Parse(plist, val.Elements());
                    return plist;
                case "array":
                    List<dynamic> list = ParseArray(val.Elements());
                    return list;
                default:
                    throw new ArgumentException("Unsupported");
            }
        }
      
    }
}
