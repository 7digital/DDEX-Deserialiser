using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DDEX_Deserialiser;
using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
	[TestFixture]
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
