using UnityEngine;
using NUnit.Framework;
using MoreMountains.CorgiEngine;

public class UtilitiesTest
{

	public class DecimalPlaceTest {
		[Test]
		public void testSingleDecimalPlace()
		{
			Utilities util = new Utilities();
			string actual = util.getAfterDecimalPoint("1.2");
			string expected = "2";

			Assert.AreEqual(actual, expected, "The Get After Decimal Point Method with an input of 1.2 expected + " + expected + ", but the actual output was  : " + actual);
		}

		[Test]
		public void testTwoDecimalPlaces()
		{
			Utilities util = new Utilities();
			string actual = util.getAfterDecimalPoint("1.19");
			string expected = "19";

			Assert.AreEqual(actual, expected, "The Get After Decimal Point Method with an input of 1.19 expected + " + expected + ", but the actual output was  : " + actual);
		}
	}


}
