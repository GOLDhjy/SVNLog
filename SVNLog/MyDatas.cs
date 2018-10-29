using System;
using System.Text;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SVNLog
{
    [Serializable]
    public struct log
    {

        [XmlElement("logentry")]
        public List<logentry> Logentrie;
        //public log(Int32 i)
        //{
        //    Logentrie = new[] {
        //           new logentry("abc"),
        //           new logentry("xyz")
        //       };
        //}
    }
    [Serializable]
    public class logentry
    {
        private string revision;
        private string author;  
        private string date;
        private paths paths;
        //public path[] Paths;
        private string msg;
        [XmlAttribute("revision")]
        public string Revision { get => revision; set => revision = value; }
        [XmlElement("author")]
        public string Author { get => author; set => author = value; }
        [XmlElement("date")]
        public string Date { get => date; set => date = value; }
        [XmlElement("paths")]
        public paths Paths { get => paths; set => paths = value; }
        [XmlElement("msg")]
        public string Msg { get => msg; set => msg = value; }

        //public logentry(string str)
        //{
        //    Author = str;
        //    Date = str;
        //    Msg = str;
        //    revision = str;
        //    Paths = new[] {
        //        new path("def"),
        //        new path("eee")
        //    };
        //}
    }
    [Serializable]
    public struct paths
    {
        
        private List<path> path;
        [XmlElement("path")]
        public List<path> Path { get => path; set => path = value; }
    }
    [Serializable]
    public struct path
    {
        private string textmods;
        private string kind;
        private string action;
        private string propmods;
        private string value;
        [XmlAttribute("text-mods")]
        public string Textmods { get => this.textmods; set => this.textmods = value; }
        [XmlAttribute("kind")]
        public string Kind { get => this.kind; set => this.kind = value; }
        [XmlAttribute("action")]
        public string Action { get => this.action; set => this.action = value; }
        [XmlAttribute("prop-mods")]
        public string Propmods { get => this.propmods; set => this.propmods = value; }
        [XmlText]
        public string Value { get => value; set => this.value = value; }
        //public path(string str)
        //{
        //    textmods = str;
        //    kind = str;
        //    action = str;
        //    propmods = str;
        //    value = str;
        //}
    }


    public struct DataGridLog
    {
        private string revision;
        private string author;
        private string date;
        private string paths;
        //public path[] Paths;
        private string msg;

        public string Revision { get => revision; set => revision = value; }

        public string Author { get => author; set => author = value; }

        public string Date { get => date; set => date = value; }

        public string Paths { get => paths; set => paths = value; }

        public string Msg { get => msg; set => msg = value; }

        //public logentry(string str)
        //{
        //    Author = str;
        //    Date = str;
        //    Msg = str;
        //    revision = str;
        //    Paths = new[] {
        //        new path("def"),
        //        new path("eee")
        //    };
        //}
    }

}