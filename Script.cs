using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace html_template_parser
{
    internal class Script
    {
        public static string CreatePageTemplate(string filename, string pageTemplateFilename, string pageTitle)
        {
            XDocument pageTemplate;
            //Load page template XDocument, return error message if it fails
            try
            {
                pageTemplate = XDocument.Load(pageTemplateFilename);
                if (pageTemplate == null)
                    return "Failed to load Page Template!";
            }
            catch (Exception ex)
            {
                return "Page Template Exception: " + ex.Message;
            }

            //Check if the document contains a <head> element
            if (!pageTemplate.Descendants("head").Any())
                return "No <head> found in page template file";

            //Set the <title> element in the <head> to the provided page title
            pageTemplate.Descendants("head").First().SetElementValue("title", pageTitle);
            using (XmlHtmlWriter xw = new XmlHtmlWriter(XmlWriter.Create(filename, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true })))
                pageTemplate.Save(xw);
            return "Created Page Template!";
        }
        public static string AddElementToPage(string pageFilename, string elementFilename, string elementName, string elementTagName)
        {
            XDocument page;
            //Load page XDocument, return error message if it fails
            try
            {
                page = XDocument.Load(pageFilename);
                if (page == null)
                    return "Failed to load Page!";
            }
            catch (Exception ex)
            {
                return "Page Exception: " + ex.Message;
            }
            XDocument header;
            //Load header XDocument, return error message if it fails
            try
            {
                header = XDocument.Load(elementFilename);
                if (header == null)
                    return "Failed to load " + elementName + "!";
            }
            catch (Exception ex)
            {
                return elementName + " Exception: " + ex.Message;
            }

            //Check if both documents contain a <header> element
            if (!page.Descendants(elementTagName).Any())
                return "No <" + elementTagName + "> found in destination file";
            if (!header.Descendants(elementTagName).Any())
                return "No <" + elementTagName + "> found in header file";

            //Replace the <header> element in the page with the one from the header file
            page.Descendants(elementTagName).First().ReplaceWith(header.Descendants(elementTagName).First());
            using (XmlHtmlWriter xw = new XmlHtmlWriter(XmlWriter.Create(pageFilename, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true })))
                page.Save(xw);
            return "Added " + elementName + "!";
        }
        public static string AddHeader(string filename, string headerFilename)
        {
            return AddElementToPage(filename, headerFilename, "Header", "header");
        }
        public static string AddFooter(string filename, string footerFilename)
        {
            return AddElementToPage(filename, footerFilename, "Footer", "footer");
        }
        public static string AddArticle(string filename, string articleFilename)
        {
            XDocument page;
            //Load page XDocument, return error message if it fails
            try
            {
                page = XDocument.Load(filename);
                if (page == null)
                    return "Failed to load Page!";
            }
            catch (Exception ex)
            {
                return "Page Exception: " + ex.Message;
            }
            //Check if the document contains an <article> element
            if (!page.Descendants("article").Any())
                return "No <article> found in page file";

            var articleLines = File.ReadAllLines(articleFilename);
            if (articleLines.Length == 0)
                return "Article file is empty!";
            if (articleLines.Length == 1)
                return "Article file only contains the title!";

            page.Descendants("article").First().SetElementValue("h2", articleLines.First());
            var p = new XElement("p");
            foreach (var line in articleLines.Skip(1))
                p.Add(new XText(line), new XElement("br"));
            page.Descendants("article").First().Add(p);
            using (XmlHtmlWriter xw = new XmlHtmlWriter(XmlWriter.Create(filename, new XmlWriterSettings { OmitXmlDeclaration = true, Indent = true })))
                page.Save(xw);
            return "Added Article!";
        }


        private class XmlHtmlWriter(XmlWriter writer) : XmlWriter
        {
            public override void WriteDocType(string name, string pubid, string sysid, string subset)
            {
                writer.WriteRaw("<!DOCTYPE HTML>\n");
            }
            public override void WriteStartDocument() => writer.WriteStartDocument();
            public override void WriteStartDocument(bool standalone) => writer.WriteStartDocument(standalone);
            public override void WriteEndDocument() => writer.WriteEndDocument();
            public override void WriteStartElement(string prefix, string localName, string ns) => writer.WriteStartElement(prefix, localName, ns);
            public override void WriteEndElement() => writer.WriteEndElement();
            public override void WriteFullEndElement() => writer.WriteFullEndElement();
            public override void WriteStartAttribute(string prefix, string localName, string ns) => writer.WriteStartAttribute(prefix, localName, ns);
            public override void WriteEndAttribute() => writer.WriteEndAttribute();
            public override void WriteCData(string text) => writer.WriteCData(text);
            public override void WriteComment(string text) => writer.WriteComment(text);
            public override void WriteProcessingInstruction(string name, string text) => writer.WriteProcessingInstruction(name, text);
            public override void WriteEntityRef(string name) => writer.WriteEntityRef(name);
            public override void WriteCharEntity(char ch) => writer.WriteCharEntity(ch);
            public override void WriteWhitespace(string ws) => writer.WriteWhitespace(ws);
            public override void WriteString(string text) => writer.WriteString(text);
            public override void WriteSurrogateCharEntity(char lowChar, char highChar) => writer.WriteSurrogateCharEntity(lowChar, highChar);
            public override void WriteChars(char[] buffer, int index, int count) => writer.WriteChars(buffer, index, count);
            public override void WriteRaw(char[] buffer, int index, int count) => writer.WriteRaw(buffer, index, count);
            public override void WriteRaw(string data) => writer.WriteRaw(data);
            public override void Close() => writer.Close();
            public override void Flush() => writer.Flush();
            public override string LookupPrefix(string ns) => writer.LookupPrefix(ns);
            public override void WriteBase64(byte[] buffer, int index, int count) => writer.WriteBase64(buffer, index, count);
            public override WriteState WriteState => writer.WriteState;
        }
    }
}
