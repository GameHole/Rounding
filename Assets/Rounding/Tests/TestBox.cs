using NUnit.Framework;
using Rounding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnitTest.Rounding
{
    internal class TestBox
    {
        private Box box;

        [SetUp]
        public void set()
        {
            box = new Box(1, 1, new Vector2(0.5f, 0.5f));
        }
        [Test]
        public void testPoints()
        {
            AssertIsRound(new Vector2(2, 1), new Vector2(), new Vector2(1, 0));
            AssertIsRound(new Vector2(0.5f, 2), new Vector2(1, 0), new Vector2(1, 1));
            AssertIsRound(new Vector2(-1, 0.5f), new Vector2(1,1), new Vector2(0, 1));
            AssertIsRound(new Vector2(0.5f, -0.5f), new Vector2(0,1), new Vector2(0, 0));
            Assert.IsTrue(box.isRound(new Vector2(2, 0f), new Vector2(), out var p));
        }
        [Test]
        public void testNotRound()
        {
            Assert.IsFalse(box.isRound(new Vector2(2, -0.001f), new Vector2(), out var p));
            Assert.IsFalse(box.isRound(new Vector2(2, -0.001f), new Vector2(1,0), out p));
            Assert.IsFalse(box.isRound(new Vector2(2, 1), new Vector2(1, 0), out p));
            Assert.IsFalse(box.isRound(new Vector2(2, 1), new Vector2(1, 1), out p));
            Assert.IsFalse(box.isRound(new Vector2(0.5f, 2), new Vector2(1, 1), out p));
            Assert.IsFalse(box.isRound(new Vector2(0.5f, 2), new Vector2(0, 1), out p));
            Assert.IsFalse(box.isRound(new Vector2(-1, 0.5f), new Vector2(0, 1), out p));
            Assert.IsFalse(box.isRound(new Vector2(-1, 0.5f), new Vector2(0, 0), out p));
            Assert.IsFalse(box.isRound(new Vector2(0.5f, -0.5f), new Vector2(0, 0), out p));
            Assert.IsFalse(box.isRound(new Vector2(0.5f, -0.5f), new Vector2(1, 0), out p));
        }
        private void AssertIsRound(Vector2 move, Vector2 last, Vector2 exp)
        {
            Assert.IsTrue(box.isRound(move, last, out var p));
            AssertEx.AreEqualVec2(exp, p);
        }
        [Test]
        public void testStartPointIsNotOnBox()
        {
            AssertIsRound(new Vector2(2, 1f), new Vector2(-1, -1), new Vector2(1, 0));
        }
    }
}
