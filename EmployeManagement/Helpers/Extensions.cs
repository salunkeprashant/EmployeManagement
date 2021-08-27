using System.Xml;
using System.Xml.Linq;

namespace EmployeManagement.Helpers
{
    public static class Extensions
    {
        public static XmlElement ToXmlElement(this XElement el)
        {
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());

            return doc.DocumentElement;
        }
    }
}
