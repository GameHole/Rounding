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
            round.move = new Vector2(1, 0);
            round.orgion = new Vector2();
            round.Update();
            AssertPoints(new Vector2(0, 0));
            round.orgion = new Vector2(1, 0);
            round.Clear();
            round.move = new Vector2(0, 1);
            round.Update();
            AssertPoints(new Vector2(1, 0));
        }

        private void AssertPoints(params Vector2[] exps)
        {
            Assert.AreEqual(exps.Length, round.points.Count);
            for (int i = 0; i < exps.Length; i++)
            {
                AssertEx.AreEqualVec2(exps[i], round.points[i]);
            }
        }

        [Test]
        public void testRemoveRounds()
        {
            round.obstacle.Add(new Box(1, 1, new Vector2(0.5f, 0.5f)));
            round.points.Add(new Vector2(1, 0));
            round.points.Add(new Vector2(1, 1));
            round.points.Add(new Vector2(0, 1));
            round.move = new Vector2(0.5f, 2);
            Update();
            AssertPoints(
                new Vector2(0, 0),
                new Vector2(1, 0),
                new Vector2(1, 1));
            round.move = new Vector2(2, 1);
            Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            round.move = new Vector2(2, -0.1f);
            Update();
            Assert.AreEqual(1, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
        }
        [Test]
        public void testRoundChange()
        {
            round.obstacle.Add(new Box(1, 1, new Vector2(0.5f, 0.5f)));

            round.move = new Vector2(2, 1);
            round.orgion = new Vector2();
            Update();
            Assert.AreEqual(2, round.points.Count);
            round.move = new Vector2(2, -0.1f);
            Update();
            round.move = new Vector2(0.5f, 2f);
            Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0,1), round.points[1]);
        }
        [Test]
        public void testBox()
        {
            round.obstacle.Add(new Box(1, 1, new Vector2(0.5f, 0.5f)));

            round.move = new Vector2(2, 1);
            round.orgion = new Vector2();
            Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);

            round.move = new Vector2(2, -0.1f);
            Update();
            Assert.AreEqual(1, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);

            round.move = new Vector2(2, 1);
            Update();
            round.move = new Vector2(0.5f, 2);
            Update();
            Assert.AreEqual(3, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            AssertEx.AreEqualVec2(new Vector2(1, 1), round.points[2]);

            round.move = new Vector2(2, 1);
            Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);

            round.move = new Vector2(0.5f, 2);
            Update(); 
            round.move = new Vector2(-1, 0.5f);
            Update();
            Assert.AreEqual(4, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            AssertEx.AreEqualVec2(new Vector2(1, 1), round.points[2]);
            AssertEx.AreEqualVec2(new Vector2(0, 1), round.points[3]);

            round.move = new Vector2(0.5f, 2);
            Update();
            Assert.AreEqual(3, round.points.Count);

            round.move = new Vector2(-1, 0.5f);
            Update();
            round.move = new Vector2(0.5f, -0.5f);
            Update();
            Assert.AreEqual(5, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(1, 0), round.points[1]);
            AssertEx.AreEqualVec2(new Vector2(1, 1), round.points[2]);
            AssertEx.AreEqualVec2(new Vector2(0, 1), round.points[3]);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[4]);

            round.move = new Vector2(-1, 0.5f);
            Update();
            Assert.AreEqual(4, round.points.Count);
        }

        private void Update()
        {
            for (int i = 0; i < 2; i++)
            {
                round.Update();
            }
        }

        [Test]
        public void testBoxInner()
        {
            round.obstacle.Add(new Box(1, 1, new Vector2(0.5f, 0.5f)));

            round.move = new Vector2(0.9f, 0.1f);
            round.orgion = new Vector2();
            round.Update();
            Assert.AreEqual(1, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);

        }
        [Test]
        public void testBoxSize()
        {
            round.obstacle.Add(new Box(2, 1, new Vector2(1, 0.5f)));
            round.orgion = new Vector2();

            round.move = new Vector2(2.1f, 0.1f);
            round.Update();
            Assert.AreEqual(2, round.points.Count);
            AssertEx.AreEqualVec2(new Vector2(0, 0), round.points[0]);
            AssertEx.AreEqualVec2(new Vector2(2, 0), round.points[1]);
            round.move = new Vector2(2.1f, -0.1f);
            round.Update();
            Assert.AreEqual(1, round.points.Count);
            round.move = new Vector2(1.9f, 0.1f);
            round.Update();
            Assert.AreEqual(1, round.points.Count);

            round.move = new Vector2(2, 0f);
            round.Update();
            round.move = new Vector2(2, 1f);
            round.Update();
            Assert.AreEqual(3, round.points.Count);
        }
        [Test]
        public void testGetPoints()
        {
            var points = round.GetPoints();
            Assert.AreEqual(2, points.Count);
            var points1= round.GetPoints();
            Assert.AreEqual(2,points1.Count);
            Assert.AreSame(points, points1);
        }
        [Test]
        public void testTwoBox()
        {
            round.obstacle.Add(new Box(1, 1, new Vector2(0.5f, 0.5f)));
            round.obstacle.Add(new Box(1, 1, new Vector2(2, 0.5f)));
            round.move = new Vector2(3.1f, 0.1f);
            round.Update();
            AssertPoints(new Vector2(), new Vector2(2, 0));
        }
    }
}

