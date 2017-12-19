﻿using UnityEngine;
using NUnit.Framework;
using MoreMountains.CorgiEngine;

[TestFixture]
public class UtilitiesTest
{
	[TestFixture]
	public class DecimalPlaceTest {

		[Test, Category("DecimalPlaceTest")]
		public void testSingleDecimalPlace()
		{
			Utilities util = new Utilities();
			string actual = util.getAfterDecimalPoint("1.2");
			string expected = "2";
			Assert.AreEqual(actual, expected, "The Get After Decimal Point Method with an input of 1.2 expected :  " + expected +  ", but the actual output was  : " + actual);
		}

		[Test, Category("DecimalPlaceTest")]
		public void testTwoDecimalPlaces()
		{
			Utilities util = new Utilities();
			string actual = util.getAfterDecimalPoint("1.19");
			string expected = "19";
			Assert.AreEqual(actual, expected, "The Get After Decimal Point Method with an input of 1.19 expected : " + expected +  ", but the actual output was  : " + actual);
		}

		[Test, Category("DecimalPlaceTest")]
        public void testThreeDecimalPlaces() {
			Utilities util = new Utilities();
			string actual = util.getAfterDecimalPoint("1.234");
			string expected = "234";
			Assert.AreEqual(actual, expected, "The Get After Decimal Point Method with an input of 1.234 expected : " + expected +  ", but the actual output was  : " + actual);
		}


		[Test, Category("DecimalPlaceTest")]
		public void testWholeNumber()
		{
			Utilities util = new Utilities();
			string actual = util.getAfterDecimalPoint("1");
			string expected = "";
			Assert.AreEqual(actual, expected, "The Get After Decimal Point Method with an input of 1 expected : " + expected +  ", but the actual output was  : " + actual);
		}
	}


	[TestFixture]
	public class WholeNumberTest {

		[Test, Category("WholeNumberTest")]
		public void testSingleDecimalPlace()
		{
			Utilities util = new Utilities();
			bool actual = util.isWholeNumber(1.2);
			bool expected = false;
			Assert.AreEqual(actual, expected, "The Test Single Decimal Place Method with an input of 1.2 expected : " + expected +  ", but the actual output was  : " + actual);
		}

		[Test, Category("WholeNumberTest")]
		public void testTwoDecimalPlaces()
		{
			Utilities util = new Utilities();
			bool actual = util.isWholeNumber(1.45);
			bool expected = false;
			Assert.AreEqual(actual, expected, "The Test Single Decimal Place Method with an input of 1.45 expected : " + expected +  ", but the actual output was  : " + actual);
		}


		[Test, Category("WholeNumberTest")]
		public void testThreeDecimalPlaces()
		{
			Utilities util = new Utilities();
			bool actual = util.isWholeNumber(1.987);
			bool expected = false;
			Assert.AreEqual(actual, expected, "The Test Single Decimal Place Method with an input of 1.987 expected : " + expected +  ", but the actual output was  : " + actual);
		}

		[Test, Category("WholeNumberTest")]
		public void testOne()
		{
			Utilities util = new Utilities();
			bool actual = util.isWholeNumber(1);
			bool expected = true;
			Assert.AreEqual(actual, expected, "The Test Single Decimal Place Method with an input of 1 expected : " + expected +  ", but the actual output was  : " + actual);
		}


		[Test, Category("WholeNumberTest")]
		public void testTwelve()
		{
			Utilities util = new Utilities();
			bool actual = util.isWholeNumber(12);
			bool expected = true;
			Assert.AreEqual(actual, expected, "The Test Single Decimal Place Method with an input of 12 expected : " + expected +  ", but the actual output was  : " + actual);
		}

		[Test, Category("WholeNumberTest")]
		public void testNineHundredAndThirtySeven()
		{
			Utilities util = new Utilities();
			bool actual = util.isWholeNumber(937);
			bool expected = true;
			Assert.AreEqual(actual, expected, "The Test Single Decimal Place Method with an input of 937 expected : " + expected +  ", but the actual output was  : " + actual);
		}

		[Test, Category("WholeNumberTest")]
		public void testZero()
		{
			Utilities util = new Utilities();
			bool actual = util.isWholeNumber(0);
			bool expected = true;
			Assert.AreEqual(actual, expected, "The Test Single Decimal Place Method with an input of 0 expected : " + expected + ", but the actual output was  : " + actual);
		}
	}
}
