using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorDash.Client
{
    public class BouncingBall
    {
        public string color { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long maxX { get; set; }
        public long maxY { get; set; }
        public int radius { get; set; }
        public int mass { get; set; }
        public int dirX;
        public int  dirY;
        private readonly Random rnd;

        public void Move()
        {
            Func<int, int> normalize = (v) =>
            {
                var a = Math.Abs(v);
                if (a >= MIN_V && a <= MAX_V) return v;
                if (a < MIN_V) return Math.Sign(v) * MIN_V;
                if (a > MAX_V) return Math.Sign(v) * MAX_V;
                return MIN_V;
            };

            dirX = normalize(dirX);
            dirY = normalize(dirY);

            X += + dirX;
            Y+= + dirY;

            Func<int> dirSpeed = () => rnd.Next(5, 20);

            var margin = radius * 2;

            if (X < margin)
            {
                X = margin;
                dirX = dirSpeed();
            }

            if (Y < margin)
            {
                Y = margin;
                dirY = dirSpeed();
            }

            if (X > maxX - margin)
            {
                X = maxX - margin;
                dirX = dirSpeed() * -1;
            }

            if (Y > maxY - margin)
            {
                Y = maxY - margin;
                dirY = dirSpeed() * -1;
            }

        }

        private const int MAX_V = 15;
        private const int MIN_V = 4;

        public BouncingBall(string color, long width, long height,  Random randomizer)
        {
            this.color = color;
            rnd = randomizer;
            maxX = width;
            maxY = height;

            radius = rnd.Next(7, 20);
            mass = 10 * radius;

            var margin = radius * 5;
            X = rnd.Next(margin, (int)(width - margin));
            Y = rnd.Next(margin, (int)(height - margin));
            dirX = rnd.Next(MIN_V, MAX_V) * Math.Sign(X - (width / 2)) * -1;
            dirY = rnd.Next(MIN_V, MAX_V) * Math.Sign(Y - (width / 2)) * -1;
        }
    }

    public static class BallExtensions
    {
        public static void AdjustPositions(this BouncingBall[] balls)
        {
            foreach (var ball in balls)
            {
                ball.Move();
            }

            var colliding = new List<(BouncingBall b1,BouncingBall b2, double dist)>();

            foreach (var b1 in balls)
            {
                foreach (var b2 in balls.Where(x => x != b1))
                {
                    if (!b1.isOverlapping(b2)) continue;

                    var dist = Math.Sqrt((b1.X - b2.X) * (b1.X - b2.X) + 
                                         (b1.Y - b2.Y) * (b1.Y - b2.Y));
                    if (!(dist > 0)) continue;
                    
                    colliding.Add((b1,b2,dist));

                    var overlap =  0.5* (dist - b1.radius - b2.radius);
                    var nx = (b1.X - b2.X) / dist;
                    var ny = (b1.Y - b2.Y) / dist;
                    var dx = nx * overlap;
                    var dy = ny * overlap;

                    b1.X -= (long)dx;
                    b1.Y -= (long)dy;
                    b2.X += (long)dx;
                    b2.Y += (long)dy;
                }
            }

            foreach (var x in colliding)
            {
                var nx = (x.b2.X - x.b1.X) / x.dist;
                var ny = (x.b2.Y - x.b1.Y) / x.dist;

                var kx = (x.b1.dirX - x.b2.dirX);
                var ky = (x.b1.dirY - x.b2.dirY);
                var p = 2.0 * (nx * kx + ny * ky) / (x.b1.mass + x.b2.mass);
                x.b1.dirX = (int)(x.b1.dirX - p * x.b2.mass * nx);
                x.b1.dirY = (int)(x.b1.dirY - p * x.b2.mass * ny);
                x.b2.dirX = (int)(x.b2.dirX + p * x.b1.mass * nx);
                x.b2.dirY = (int)(x.b2.dirY + p * x.b1.mass * ny);
            }
        }

        public static bool isOverlapping(this BouncingBall src, BouncingBall target)
        {
            var d = Math.Abs((src.X-target.X) * (src.X - target.X) + 
                             (src.Y-target.Y) * (src.Y - target.Y));
            var r = (src.radius + target.radius) * (src.radius + target.radius);
            return d <= r;
        }
    }
}
