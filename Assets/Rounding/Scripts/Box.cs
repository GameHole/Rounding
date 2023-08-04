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
            var line = move - lastPoint;
            if (TryGetBoxPoint(lastPoint, out p, out var pre))
            {
                return isRoundSide(line, p - pre);
            }
            for (int i = 0; i < points.Length; i++)
            {
                p = points[i];
                if(Vector3.Dot(line,p - lastPoint) <= 0)
                {
                    return true;
                }
            }
            return false;
        }
        bool TryGetBoxPoint(Vector2 lastPoint, out Vector2 p, out Vector2 pre)
        {
            for (int i = 0; i < points.Length; i++)
            {
                pre = points[i];
                if (lastPoint == pre)
                {
                    p = points[(i + 1) % dirs.Length];
                    return true;
                }
            }
            p = pre = default;
            return false;
        }
        private bool isRoundSide(Vector2 line, Vector2 side)
        {
            return Vector2.Dot(line, side.normalized) >= side.magnitude
                && Vector3.Cross(line, side).z <= 0;
        }

        private Vector2 GetPoint(Vector2 dir)
        {
            return center + new Vector2(w, h) * 0.5f * dir;
        }
    }
}
