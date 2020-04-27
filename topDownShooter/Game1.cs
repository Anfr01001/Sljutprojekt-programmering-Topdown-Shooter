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
                buyMeny.active = true;

            if (StartMeny.active) {
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                StartMeny.klickCheck(Mouse.GetState().Position);
            } else if (buyMeny.active) { // För köpmeny
                if (Mouse.GetState().LeftButton == ButtonState.Pressed)
                    buyMeny.klickCheck(Mouse.GetState().Position);
            } else {
                ObjectManager.Update(gameTime);
                RoundController.Update(gameTime);

                //Kolla efter klick om den är på shop ikonen öppna shop menyn
                if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                    if (new Rectangle(Mouse.GetState().Position, new Point(5)).Intersects(new Rectangle(new Point(750, 750), new Point(50)))) {
                        buyMeny.active = true;
                    }
                }
            }

                

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            if (StartMeny.active) {
                StartMeny.draw(spriteBatch);
            } else if (buyMeny.active) { // För köpmeny
                buyMeny.draw(spriteBatch);
            } else {
                ObjectManager.Draw(spriteBatch);
                RoundController.Draw(spriteBatch);
                spriteBatch.Draw(Assets.shoppcart, new Rectangle(new Point(750, 750), new Point(50)), Color.White);
                spriteBatch.DrawString(Assets.textfont, "HP: " + (ObjectManager.player as player).hp , new Vector2(0, 40), Color.Black);
            }

            

            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
