using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Xml;
using System.Xml.Serialization;

/// <summary>
/// Summary description for ConvertirXML
/// </summary>
public class ConvertirXML
{
    public static string XmlSerializar(object o)
    {
        StringWriter sw = new StringWriter();
        XmlTextWriter tw = null;
        try
        {
            XmlSerializer serializer = new XmlSerializer(o.GetType());
            tw = new XmlTextWriter(sw);
            serializer.Serialize(tw, o);
        }
        catch (Exception ex)
        {
            Console.WriteLine("El errror se debe a: "+ex.ToString());
            //Handle Exception Code
        }
        finally
        {
            sw.Close();
            if (tw != null)
            {
                tw.Close();
            }
        }
        return sw.ToString();
    }

    public static Object XmlDeserealizar(string xml, Type objectType)
    {
        StringReader strReader = null;
        XmlSerializer serializer = null;
        XmlTextReader xmlReader = null;
        Object obj = null;
        try
        {
            strReader = new StringReader(xml);
            serializer = new XmlSerializer(objectType);
            xmlReader = new XmlTextReader(strReader);
            obj = serializer.Deserialize(xmlReader);
        }
        catch (Exception exp)
        {
            Console.WriteLine("El errror se debe a: " + exp.ToString());
            //Handle Exception Code
        }
        finally
        {
            if (xmlReader != null)
            {
                xmlReader.Close();
            }
            if (strReader != null)
            {
                strReader.Close();
            }
        }
        return obj;
    }
}