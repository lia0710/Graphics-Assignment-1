using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_1
{
    internal class Cube
    {

        public Matrix world = Matrix.Identity;
        public float x = 0;
        public float z = 0;
        float speed = 0.05f;
        public bool tagged = false;

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
            z = (float)zdistance;
            world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            world *= Matrix.CreateTranslation((float)xdistance, 0, (float)zdistance);
        }

        public float getDistance(Sphere sphere)
        {
            //find how close this cube is to a sphere to determine how to move
            //sqrt ([x2 - x1]^2 + [y2 - y1]^2)
            float distance = (float)Math.Sqrt( ((sphere.x - x) * (sphere.x - x)) + ((sphere.z - z) * (sphere.z - z)) );
            return distance;
        }

        public void checkMove(Sphere sphere)
        {
            if (getDistance(sphere) > 11)
            {
                //move closer
                if (z > sphere.z) 
                { 
                    world *= Matrix.CreateTranslation(0, 0, -speed); z -= speed;
                    //checkAngle(sphere);
                }
                else 
                { 
                    world *= Matrix.CreateTranslation(0, 0, speed); z += speed;
                    //checkAngle(sphere);
                }

                if (x > sphere.x) 
                { 
                    world *= Matrix.CreateTranslation(-speed, 0, 0); x -= speed;
                    //checkAngle(sphere);
                }
                else 
                { 
                    world *= Matrix.CreateTranslation(speed, 0, 0); x += speed;
                    //checkAngle(sphere);
                }
            }
            else if (getDistance(sphere) < 10)
            {
                //move away
                if (z > sphere.z) { world *= Matrix.CreateTranslation(0, 0, speed); z += speed; }
                if (z < sphere.z) { world *= Matrix.CreateTranslation(0, 0, -speed); z -= speed; }

                if (x > sphere.x) { world *= Matrix.CreateTranslation(speed, 0, 0); x += speed; }
                if (x < sphere.x) { world *= Matrix.CreateTranslation(-speed, 0, 0); x -= speed; }
            }
        }

        public void checkAngle(Sphere sphere)
        {
            //tan-1 (sphere.y - cube.y) / (sphere.x - cube.y)
            double angle = Math.Atan((double)((z - sphere.z) / (x- sphere.x)));
            float radians = (float)angle * (float)Math.PI/180;
            world *= Matrix.CreateRotationY(radians);
        }

        public bool checkTagged(Sphere sphere)
        {
            if (getDistance(sphere) < 1 && tagged != true) { tagged = true; return true; }
            return false;
        }
    }
}
