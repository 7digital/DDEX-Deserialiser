using DDEX_Deserialiser;
using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
	public class BigDdexXml
	{
		public DDEX ddex;

		[SetUp]
		public void Setup()
		{
			ddex = new DDEX("artifacts/ddex-sample.xml");
		}
	}
}
