using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Assignment_1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager device;
        Model spheremodel;
        Model cubemodel;
        private SpriteBatch spriteBatch;

        private Matrix world = Matrix.Identity;
        private Matrix view = Matrix.Identity;
        private Matrix projection = Matrix.Identity;

        public Game1()
        {
            device = new GraphicsDeviceManager(this);
            device.PreferredBackBufferWidth = 700;
            device.PreferredBackBufferHeight = 700;
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            view = Matrix.CreateLookAt(new Vector3(0, 40, 10), new Vector3(0, 0, 0), Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), device.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100f);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spheremodel = Content.Load<Model>("Sphere");
            cubemodel = Content.Load<Model>("Assignment1Cube");
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

            foreach (var mesh in spheremodel.Meshes)
            {
                mesh.Draw();
            }

            base.Draw(gameTime);
        }
    }
}