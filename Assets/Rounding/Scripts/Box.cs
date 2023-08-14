using System;
using UnityEngine;

namespace Rounding
{
    public class Box
    {
        public int w;
        public int h;
        public Vector2 center;

        public Box(int w, int h, Vector2 center)
        {
            this.w = w;
            this.h = h;
            this.center = center;
            points = new Vector2[4];
            for (int i = 0; i < 4; i++)
            {
                points[i] = GetPoint(dirs[i]);
            }
        }
        private Vector2[] dirs = new Vector2[]
        {
            new Vector2(1, -1),
            new Vector2(1, 1),
            new Vector2(-1, 1),
            new Vector2(-1, -1)
        };
        private Vector2[] points;
        public bool isRound(Vector2 move, Vector2 lastPoint, out Vector2 p)
        {
            p = default;
            var line = move - lastPoint;
            Vector2 pre;
            for (int i = 0; i < points.Length; i++)
            {
                pre = points[i];
                if (lastPoint == pre)
                {
                    p = points[getCycleIndex(i + 1)];
                    var side = p - pre;
                    if (isOnLeft(line, side))
                        return true;
                    p = points[getCycleIndex(i - 1)];
                    side = p - pre;
                    if (isOnRight(line,side))
                        return true;
                    return false;
                }
            }
            for (int i = 0; i < points.Length; i++)
            {
                p = points[i];
                var side = p - lastPoint;
                if (isOnLeft(line, side))
                {
                    return true;
                }
            }
            return false;
        }

        private int getCycleIndex(int i)
        {
            if (i >= dirs.Length)
                return i - 4;
            if (i < 0)
                return 4 + i;
            return i;
        }

        private bool isOnLeft(Vector2 line, Vector2 side)
        {
            float dot = Vector2.Dot(line, side.normalized);
            float cross = Vector3.Cross(line, side).z;
            return dot >= side.magnitude && cross <= 0;
        }
        private bool isOnRight(Vector2 line, Vector2 side)
        {
            float dot = Vector2.Dot(line, side.normalized);
            float cross = Vector3.Cross(line, side).z;
            return dot >= side.magnitude && cross >= 0;
        }
        private Vector2 GetPoint(Vector2 dir)
        {
            return center + new Vector2(w, h) * 0.5f * dir;
        }
    }
}
