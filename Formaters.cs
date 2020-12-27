using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PrettifyIt
{
    public static class Formaters
    {
        public static string Format(string text)
        {
            if (String.IsNullOrWhiteSpace(text)) return text;
            var tText = text.Trim();
            if (tText.StartsWith("<"))
            {
                return FormatXml(tText);
            }
            else if (tText.StartsWith("{"))
            {
                return FormatJson(tText);
            }
            else
            {
                return text;
            }
        }

        public static string FormatXml(string xml)
        {
            try
            {
                var doc = XDocument.Parse(xml);
                return doc.Declaration != null
                    ? doc.Declaration.ToString() + "\r\n" + doc.ToString()
                    : doc.ToString();
            }
            catch (Exception)
            {
                return xml;
            }
        }

        public static string FormatJson(string json)
        {
            try
            {
                var doc = JsonSerializer.Deserialize<dynamic>(json);
                return JsonSerializer.Serialize(doc, new JsonSerializerOptions
                {
                    WriteIndented = true
                });
            }
            catch (Exception)
            {
                return json;
            }
        }
    }
}
