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
        private int preIndex=-1;

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
            var state = box.isRound(move, points[Index], out var p);
            if (state==add)
            {
                points.Add(p);
            }
            else if(state==remove)
            {
                points.RemoveAt(Index);
            }
        }

        private int Index => points.Count - 1;

        public List<Vector2> GetPoints()
        {
            _points.Clear();
            _points.AddRange(points);
            _points.Add(move);
            return _points;
        }
    }
}
