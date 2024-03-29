﻿using System;
using System.Collections.Generic;
using System.Text;

namespace FastNoise
{
    public struct Vector2
    {
        public readonly double x, y;
        public Vector2(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public static Vector2 operator-(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x - b.x, a.y - b.y);
        }
        public static Vector2 operator+(Vector2 a, Vector2 b)
        {
            return new Vector2(a.x + b.x, a.y + b.y);
        }
 
    }
}
