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
    internal class Sphere
    {
        public Matrix world = Matrix.Identity;
        public float x = 0;
        public float z = 0;
        public Sphere() 
        { 
            world = Matrix.CreateTranslation(new Vector3(0, 0, 0)); 
        }
    }
}
