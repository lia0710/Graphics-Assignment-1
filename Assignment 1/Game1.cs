using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager device;
        private Model spheremodel;
        private Model cubemodel;
        private SpriteBatch spriteBatch;
        private SpriteFont Arial12;

        private Texture green;

        private Matrix view = Matrix.Identity;
        private Matrix projection = Matrix.Identity;

        Sphere sphere;

        Cube[] cubes = new Cube[10];
        int tagged = 0;

        public Game1()
        {
            device = new GraphicsDeviceManager(this);
            device.PreferredBackBufferHeight = 700;
            device.PreferredBackBufferWidth = 700;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Arial12 = Content.Load<SpriteFont>("Arial12");

            spheremodel = Content.Load<Model>("Sphere");
            cubemodel = Content.Load<Model>("Assignment1Cube");

            view = Matrix.CreateLookAt(new Vector3(0, 40, 10), new Vector3(0, 0, 0), Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), device.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100f);

            sphere = new Sphere();

            for(int i = 0; i < 10; i++) 
            { 
                Cube newCube = new Cube();
                cubes[i] = newCube;
            }

            base.Initialize();
        }

        protected override void LoadContent()
        {

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            string teststr = "Tagged: " + tagged;

            spriteBatch.Begin();
            spriteBatch.DrawString(Arial12, teststr, new Vector2(10, 10), Color.Orange);
            spriteBatch.End();

            #region ControlSphere
            /*if(Keyboard.GetState().IsKeyDown(Keys.W)) { world *= Matrix.CreateTranslation(0, 0, -10f) * gameTime.; }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) { world *= Matrix.CreateTranslation(-10f, 0, 0); }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) { world *= Matrix.CreateTranslation(0, 0, 10f); }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) { world *= Matrix.CreateTranslation(10f, 0, 0); }*/

            if (Keyboard.GetState().IsKeyDown(Keys.W)) { sphere.world *= Matrix.CreateTranslation(0, 0, -0.1f); sphere.z -= 0.1f; }
            if (Keyboard.GetState().IsKeyDown(Keys.A)) { sphere.world *= Matrix.CreateTranslation(-0.1f, 0, 0); sphere.x -= 0.1f; }
            if (Keyboard.GetState().IsKeyDown(Keys.S)) { sphere.world *= Matrix.CreateTranslation(0, 0, 0.1f); sphere.z += 0.1f; }
            if (Keyboard.GetState().IsKeyDown(Keys.D)) { sphere.world *= Matrix.CreateTranslation(0.1f, 0, 0); sphere.x += 0.1f; }
            #endregion

            foreach (var mesh in spheremodel.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = sphere.world; 
                    effect.View = view;
                    effect.Projection = projection;
                }
                mesh.Draw();
            }

            for (int i = 0; i < 10; i++)
            {
                cubes[i].checkMove(sphere);
                if (cubes[i].checkTagged(sphere)) { tagged += 1; }
                foreach (var mesh in cubemodel.Meshes)
                {
                    foreach (BasicEffect effect in mesh.Effects)
                    {
                        //import texture and set it to the cube here
                        //effect.Texture =
                        effect.World = cubes[i].world;
                        effect.View = view;
                        effect.Projection = projection;
                    }
                    mesh.Draw();
                }
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}