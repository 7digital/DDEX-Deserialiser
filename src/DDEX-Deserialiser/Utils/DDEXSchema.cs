using System.Runtime.CompilerServices;
using System.Xml.Schema;

namespace DDEX_Deserialiser.Utils
{
	public static class DDEXSchema
	{
		private static XmlSchemaSet _ddex_schema;

		[MethodImpl(MethodImplOptions.Synchronized)]
		public static XmlSchemaSet GetDdexSchema()
		{
			return _ddex_schema ?? (_ddex_schema = CreateSchema());
		}

		private static XmlSchemaSet CreateSchema()
		{
			var schemas = new XmlSchemaSet { XmlResolver = new ResourceXmlResolver() };
			schemas.Add(DDEXSchemaLoader.LoadSchema("release-notification.xsd"));
			schemas.Compile();
			return schemas;
		}
	}
}
