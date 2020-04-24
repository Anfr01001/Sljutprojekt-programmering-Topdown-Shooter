using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace topDownShooter
{

    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            Assets.LoadContent(Content);
            StartMeny.active = true;
            base.Initialize();
        }


        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Assets.CreatePixel(GraphicsDevice);
            Map.BuildMap();
            ObjectManager.AddObject(new player());
        }


        protected override void UnloadContent()
        {

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                ObjectManager.AddObject(new EnemyFly(100));

            if (StartMeny.active) {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                StartMeny.klickCheck(Mouse.GetState().Position);
            } else if (false) { // För köpmeny

            } else {
                ObjectManager.Update(gameTime);
                RoundController.Update(gameTime);
            }

                

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (StartMeny.active) {
                StartMeny.draw(spriteBatch);
            } else if (false) { // För köpmeny

            } else {
                ObjectManager.Draw(spriteBatch);
                RoundController.Draw(spriteBatch);
            }
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
