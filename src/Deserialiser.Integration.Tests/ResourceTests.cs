﻿using NUnit.Framework;

namespace Deserialiser.Unit.Tests
{
	[TestFixture]
	public class ResourceTests : BigDdexXml
	{
		[Test]
		public void Resources_should_have_2_sound_recordings()
		{
			ddex.Root.ResourceList.SoundRecordings.Count.should_be_equal_to(2);
		}

		[Test]
		public void Resources_should_have_1_image()
		{
			ddex.Root.ResourceList.Images.Count.should_be_equal_to(1);
		}

		[Test]
		public void Resources_should_have_no_videos()
		{
			ddex.Root.ResourceList.Videos.Count.should_be_equal_to(0);
		}
	}
}
