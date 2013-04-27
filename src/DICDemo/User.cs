using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DICDemo
{
    public class User
    {
        public Int64 ID;
        public string Name;
        public string URL;

        public User(XElement e)
        {
            this.ID = Int64.Parse(e.Element("id").Value);
            this.Name = e.Element("name").Value.Trim();
            this.URL = e.Element("url").Value.Trim();
        }
    }
}
