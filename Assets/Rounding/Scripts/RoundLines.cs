using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Rounding
{

    public class Rounder
    {
        public Vector2 move { get; set; }
        public Vector2 orgion { get; set; }
        public List<Vector2> points { get; private set; } = new List<Vector2>();
        public List<Box> obstacle { get; private set; } = new List<Box>();
        private List<Vector2> _points = new List<Vector2>();
        public Rounder()
        {
            Clear();
        }
        public void Clear()
        {
            points.Clear();
            points.Add(orgion);
        }

        public void Update()
        {
            foreach (var item in obstacle)
            {
                AddBoxPoints(item);
            }
        }

        private void AddBoxPoints(Box box)
        {
            int last = lastIndex;
            int preLast = last - 1;
            if (box.isRound(move, points[last], out var p))
            {
                points.Add(p);
            }
            else
            {
                if (preLast >= 0 && !box.isRound(move, points[preLast], out p))
                {
                    points.RemoveAt(lastIndex);
                }
            }
        }

        private int lastIndex => points.Count - 1;

        public List<Vector2> GetPoints()
        {
            _points.Clear();
            _points.AddRange(points);
            _points.Add(move);
            return _points;
        }
    }
}
