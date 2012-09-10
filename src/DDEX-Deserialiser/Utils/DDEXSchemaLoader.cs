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
			using (var stream = GetSchemaStream(fileName))
				return XmlSchema.Read(stream, (o, e) => { });
		}
	}
}