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
        float speed = 0.05f;

        public Cube() 
        {
            Random random = new Random();
            Random negative = new Random();
            double xdistance = Math.Floor(random.NextSingle()*6);
            if (negative.Next(2) == 0) { xdistance *= -1; }
            x = (float)xdistance;
            //x between -5 and 5
            //radius of 5 from the sphere
            double zdistance = Math.Sqrt(25-(xdistance*xdistance));
            if (negative.Next(2) == 0) { zdistance *= -1; }
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

        public void checkMove(Sphere sphere)
        {
            if (getDistance(sphere) > 11)
            {
                //move closer
                if (z > sphere.z) { world *= Matrix.CreateTranslation(0, 0, -speed); z -= speed; }
                else { world *= Matrix.CreateTranslation(0, 0, speed); z += speed; }

                if (x > sphere.x) { world *= Matrix.CreateTranslation(-speed, 0, 0); x -= speed; }
                else { world *= Matrix.CreateTranslation(speed, 0, 0); x += speed; }
            }
            else if (getDistance(sphere) < 10)
            {
                //move away
                if (z > sphere.z) { world *= Matrix.CreateTranslation(0, 0, speed); z += speed; }
                else { world *= Matrix.CreateTranslation(0, 0, -speed); z -= speed; }

                if (x > sphere.x) { world *= Matrix.CreateTranslation(speed, 0, 0); x += speed; }
                else { world *= Matrix.CreateTranslation(-speed, 0, 0); x -= speed; }
            }
        }
    }
}
