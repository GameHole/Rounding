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
            if (isRound(box,out var p))
            {
                points.Add(p);
            }
            else
            {
                if (points.Count > 1)
                    points.RemoveAt(points.Count - 1);
            }
        }
        private Vector2[] dirs = new Vector2[]
        {
            new Vector2(1, -1),
            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(-1, -1)
        };
        private bool isRound(Box box, out Vector2 p)
        {
            var line = move - points[points.Count - 1];
            p = box.center + new Vector2(box.w, box.h) * 0.5f * dirs[0];//(1,0)
            var pre = box.center + new Vector2(box.w, box.h) * 0.5f * new Vector2(-1, -1);//(0,0)
            var dot = Vector2.Dot(line, p - pre);
            if (points[points.Count - 1] == pre && dot >= 1)
                return true;
            p = box.center + new Vector2(box.w, box.h) * 0.5f * dirs[1];//(1,1)
            pre = box.center + new Vector2(box.w, box.h) * 0.5f * new Vector2(1, -1);//(1, 0)
            dot = Vector2.Dot(line, p - pre);
            if (points[points.Count - 1] == pre && dot >= 1/* line.x <= 0 && line.y >= 1*/)
                return true;
            p = box.center + new Vector2(box.w, box.h) * 0.5f * dirs[2];//(0,1)
            pre = box.center + new Vector2(box.w, box.h) * 0.5f * new Vector2(1, 1);//(1, 1)
            dot = Vector2.Dot(line, p - pre);
            if (points[points.Count - 1] == pre && dot >= 1 /*line.x <= 0 && line.y <= 0*/)
                return true;
            p = box.center + new Vector2(box.w, box.h) * 0.5f * dirs[3];//(0,0)
            pre = box.center + new Vector2(box.w, box.h) * 0.5f * new Vector2(-1, 1);//(0,1)
            dot = Vector2.Dot(line, p - pre);
            if (points[points.Count - 1] == pre && dot >= 1/*line.x >= 0 && line.y <= -1*/)
                return true;
            return false;
        }

        public List<Vector2> GetPoints()
        {
            _points.Clear();
            _points.AddRange(points);
            _points.Add(move);
            return _points;
        }
    }
}
