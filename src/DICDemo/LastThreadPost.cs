using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace DICDemo
{
    public class LastThreadPost
    {
        public string Date;
        public string URL;
        public User User;

        public LastThreadPost(XElement e)
        {
            this.Date = e.Element("date").Value.Trim();
            this.URL = e.Element("url").Value.Trim();
            this.User = new User(e.Element("user"));
        }
    }
}
