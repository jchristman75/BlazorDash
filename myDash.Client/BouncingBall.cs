using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace myDash.Client
{
    public class BouncingBall
    {
        public string color { get; set; }
        public long X { get; set; }
        public long Y { get; set; }
        public long maxX { get; set; }
        public long maxY { get; set; }
        public int radius { get; set; }
        private int dirX;
        private int  dirY;
        private readonly Random rnd;

        public void Move()
        {
            X+= + dirX;
            Y+= + dirY;

            Func<int> dirSpeed = () => rnd.Next(5, 20);

            var margin = radius * 2;
            if (X < margin) dirX = dirSpeed();
            if (Y < margin) dirY = dirSpeed();
            if (X > maxX - margin) dirX = dirSpeed() * -1;
            if (Y > maxY - margin) dirY = dirSpeed() * -1;
        }

        public BouncingBall(string color, long width, long height,  Random randomizer)
        {
            this.color = color;
            rnd = randomizer;
            maxX = width;
            maxY = height;
            radius = rnd.Next(5, 15);
            var margin = radius * 5;
            X = rnd.Next(margin, (int)(width - margin));
            Y = rnd.Next(margin, (int)(height - margin));
            dirX = rnd.Next(5, 20) * Math.Sign(X - (width / 2)) * -1;
            dirY = rnd.Next(5, 20) * Math.Sign(Y - (width / 2)) * -1;
        }
    }
}
