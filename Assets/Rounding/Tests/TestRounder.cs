using NUnit.Framework;
using Rounding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnitTest.Rounding
{
    public class TestRounder
    {
        private Rounder round;

        [SetUp]
        public void set()
        {
            round = new Rounder();
        }
        [Test]
        public void testStart()
        {
            round.move = new Vector2();
            round.orgion = new Vector2();
            round.Update();
            Assert.AreEqual(1,round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0,0), round.points[0]);
        }
        [Test]
        public void testMove()
        {
            round.move = new Vector2(1,0);
            round.orgion = new Vector2();
            round.Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            round.move = new Vector2(0, 1);
            round.Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(0, 1), round.points[1]);
        }
        [Test]
        public void testBox()
        {
            round.move = new Vector2(2, 1);
            round.orgion = new Vector2();
            round.obstacle.Add(new Box(1,1,new Vector2(0.5f,0.5f)));
            round.Update();
            Assert.AreEqual(3, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            AssertEx.AreEqualVec2(new Vector2(2, 1), round.points[2]);
            round.move = new Vector2(2, 0);
            round.Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(2, 0), round.points[1]);
            round.move = new Vector2(2, 1);
            round.Update();
            round.move = new Vector2(0.5f, 2);
            round.Update();
            Assert.AreEqual(4, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            AssertEx.AreEqualVec2(new Vector2(1, 1), round.points[2]);
            AssertEx.AreEqualVec2(new Vector2(0.5f, 2), round.points[3]);
            round.move = new Vector2(-1, 0.5f);
            round.Update();
            Assert.AreEqual(5, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            AssertEx.AreEqualVec2(new Vector2(1, 1), round.points[2]);
            AssertEx.AreEqualVec2(new Vector2(0, 1), round.points[3]);
            AssertEx.AreEqualVec2(new Vector2(-1, 0.5f), round.points[4]);
            round.move = new Vector2(0.5f, -0.5f);
            round.Update();
            Assert.AreEqual(6, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            AssertEx.AreEqualVec2(new Vector2(1, 1), round.points[2]);
            AssertEx.AreEqualVec2(new Vector2(0, 1), round.points[3]);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[4]);
            AssertEx.AreEqualVec2(new Vector2(0.5f, -0.5f), round.points[5]);
        }
    }
}

