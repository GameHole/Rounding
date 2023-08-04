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
        }
    }
}
