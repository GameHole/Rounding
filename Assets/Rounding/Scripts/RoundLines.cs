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

        public void Update()
        {
            points.Clear();
            points.Add(orgion);
            if (orgion != move)
                points.Add(move);
        }
    }
}
