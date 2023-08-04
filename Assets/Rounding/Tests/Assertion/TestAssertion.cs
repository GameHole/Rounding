using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UnitTest
{
    internal class TestAssertion
    {
        [Test]
        public void testAreEqualVec2()
        {
            Assert.DoesNotThrow(() =>
            {
                AssertEx.AreEqualVec2(new Vector2(), new Vector2());
            });
            var ex = Assert.Throws<AssertionException>(() =>
            {
                AssertEx.AreEqualVec2(new Vector2(0.99f,0), new Vector2());
            });
            Assert.AreEqual("except (0.99,0) but was (0,0)", ex.Message);
            ex = Assert.Throws<AssertionException>(() =>
            {
                AssertEx.AreEqualVec2(new Vector2(0, 0.99f), new Vector2());
            });
            Assert.AreEqual("except (0,0.99) but was (0,0)", ex.Message);
            Assert.DoesNotThrow(() =>
            {
                AssertEx.AreEqualVec2(new Vector2(1, 0), new Vector2(0.999991f,0), 1e-5f);
                AssertEx.AreEqualVec2(new Vector2(0,1), new Vector2(0,0.999991f),1e-5f);
            });
        }
    }
}
