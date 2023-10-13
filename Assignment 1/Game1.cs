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

        private Matrix world = Matrix.Identity;
        private Matrix view = Matrix.Identity;
        private Matrix projection = Matrix.Identity;

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
            spheremodel = Content.Load<Model>("Sphere");
            cubemodel = Content.Load<Model>("Assignment1Cube");

            world = Matrix.CreateTranslation(new Vector3(0, 0, 0));
            view = Matrix.CreateLookAt(new Vector3(0, 40, 10), new Vector3(0, 0, 0), Vector3.Up);
            projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), device.GraphicsDevice.Viewport.AspectRatio, 0.1f, 100f);

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
            foreach (var mesh in spheremodel.Meshes)
            {
                mesh.Draw();
            }

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}