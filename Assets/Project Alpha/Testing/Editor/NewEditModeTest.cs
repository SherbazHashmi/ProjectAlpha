using UnityEngine;
using UnityEditor;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using MoreMountains.CorgiEngine;


    public class NewEditModeTest
    {

        [Test]
        public void testSingleDecimalPlace()
        {
            Debug.Log("Ran Test");
            Utilities util = new Utilities();
            string actual = util.getAfterDecimalPoint("1.2");
            string expected = "0.2";

            Assert.AreEqual(actual, expected, "The Get After Decimal Point Method with an input of 1.2 expected + " + expected + ", but the actual output was  : " + actual);
        }
    }




