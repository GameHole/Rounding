using UnityEngine;

namespace Rounding
{
    public class Box
    {
        private int w;
        private int h;
        private Vector2 center;

        public Box(int w, int h, Vector2 center)
        {
            this.w = w;
            this.h = h;
            this.center = center;
        }
    }
}
