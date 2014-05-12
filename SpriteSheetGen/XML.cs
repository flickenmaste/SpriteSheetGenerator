using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;

namespace SpriteSheetGen
{
    public class XML
    {
        public XDocument AtlasXML;

        public void GenXML(string[] filename, BitmapFrame[] frames, int width, int height, Vector[] xy)
        {
            // Declatation
            XDeclaration XMLdec = new XDeclaration("1.0", "UTF-8", "yes");

            Object[] XMLelem = new Object[frames.Length];

            for (int i = 0; i < frames.Length; i++)
            {
                XElement node = new XElement("SubTexture");

                BitmapFrame eek = frames[i];

                node.SetAttributeValue("name", filename[i]);
                node.SetAttributeValue("x", xy[i].X);
                node.SetAttributeValue("y", xy[i].Y);
                node.SetAttributeValue("width", frames[i].PixelWidth);
                node.SetAttributeValue("height", frames[i].PixelHeight);

                XMLelem[i] = node;
            }

            XElement XMLRootNode = new XElement("TextureAtlas", XMLelem);
            XMLRootNode.SetAttributeValue("imagePath", "Naw");

            XDocument XMLdoc = new XDocument(XMLdec, XMLRootNode);

            AtlasXML = XMLdoc;

            Microsoft.Win32.SaveFileDialog saveDiag = new Microsoft.Win32.SaveFileDialog();
            Nullable<bool> diagResult = saveDiag.ShowDialog();

            // User select
            if (diagResult == true)
            {
                FileStream xmlstream = new FileStream(saveDiag.FileName, FileMode.Create);
                XMLdoc.Save(xmlstream);
                xmlstream.Close();
            }
            else
            {
                return;
            }

        }
    }
}
