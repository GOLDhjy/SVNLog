using System;
using System.Xml.Serialization;
namespace Datas
{
    [Serializable]
    struct log
    {
        [XmlAttribute(AttributeName = "logentry")]
        public logentry[] Logentrie;
    }
    [Serializable]
    struct logentry
    {
        private string revision;

        [XmlAttribute("author")]
        public string Author;
        [XmlAttribute("date")]
        public string Date;
        [XmlAttribute(AttributeName = "paths")]
        public path[] Paths;
        [XmlAttribute("msg")]
        public string Msg;
        [XmlAttribute("revision")]
        public string Revision { get => revision; set => revision = value; }
    }
    [Serializable]
    struct path
    {
        private string textmods;
        private string kind;
        private string action;
        private string propmods;

        [XmlAttribute("text-mods")]
        public string Textmods { get => this.textmods; set => this.textmods = value; }
        [XmlAttribute("kind")]
        public string Kind { get => this.tind; set => this.tind = value; }
        [XmlAttribute("action")]
        public string Action { get => this.tction; set => this.tction = value; }
        [XmlAttribute("prop-mods")]
        public string Propmods { get => this.tropmods; set => this.tropmods = value; }
    }

}
XmlSerialization serializer = new XmlSerialization(typeof(Mydata));