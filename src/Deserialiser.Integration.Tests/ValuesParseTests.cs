using System;
using System.Linq;
using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
	[TestFixture]
	public class ValuesParseTests : BigDdexXml
	{
		[Test]
		public void Should_date_time_be_parsed_properly()
		{
			var release = ddex.Root.ReleaseList.Releases.First();
			var releaseDetailsByTerritory = release.ReleaseDetailsByTerritorys.First();
			releaseDetailsByTerritory.OriginalReleaseDate
				.Value.should_be_equal_to(new DateTime(2007, 08, 28));
		}
	}
}
