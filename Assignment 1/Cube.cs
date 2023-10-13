using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_1
{
    internal class Cube
    {
        public Matrix world = Matrix.Identity;
        float x = 0;
        float z = 0;

        public Cube() 
        {
            Random random = new Random();
            Random negative = new Random();
            double xdistance = Math.Floor(random.NextSingle()*6);
            if (negative.Next(2) == 0) { xdistance *= -1; }
            x = (float)xdistance;
            double zdistance = Math.Floor(random.NextSingle() * 6);
            if (negative.Next(2) == 0) { zdistance *= -1; }
            z = (float)zdistance;
            world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            world *= Matrix.CreateTranslation((float)xdistance, 0, (float)zdistance);
        }

        public float getDistance(Sphere sphere)
        {
            //find how close this cube is to a sphere to determine how to move
            //sqrt ([x2 - x1]^2 + [y2 - y1]^2)
            float distance = (float)Math.Sqrt( ((x - sphere.x) * (x - sphere.x)) + ((z - sphere.z) * (z - sphere.z)));
            return distance;
        }
    }
}
