using System.IO;
using System.Xml.Schema;

namespace DDEX_Deserialiser.Utils
{
	internal class DDEXSchemaLoader
	{
		public static Stream GetSchemaStream(string fileName)
		{
			return typeof(DDEX).Assembly.GetManifestResourceStream("DDEX_Deserialiser.xsds." + fileName);
		}

		public static XmlSchema LoadSchema(string fileName)
		{
			return XmlSchema.Read(GetSchemaStream(fileName), (o, e) => { });
		}
	}
}