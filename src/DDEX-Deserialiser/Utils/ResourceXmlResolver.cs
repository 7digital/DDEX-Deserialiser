using System;
using System.IO;
using System.Net;
using System.Xml;

namespace DDEX_Deserialiser.Utils
{
	internal class ResourceXmlResolver : XmlResolver
	{
		public override object GetEntity(Uri absoluteUri, string role, Type ofObjectToReturn)
		{
			string file = Path.GetFileName(absoluteUri.AbsolutePath);
			return DDEXSchemaLoader.GetSchemaStream(file);
		}

		public override ICredentials Credentials
		{
			set { throw new NotImplementedException(); }
		}
	}
}