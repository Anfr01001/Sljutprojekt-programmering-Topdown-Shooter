using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class player: BaseObject, ICollision {

        //String så att direction kan vara samma namn som spriten blir tydligare
        private string direction;

        private float speed = 2f;

        private Vector2 velocity;

        KeyboardState Kstate;

        private Vector2 Oldpos = Vector2.Zero;

        //båda dessa är temp används bara i en funktion
        private float tempX;
        private float tempY;

        public void Player() {
            
        }

        public Rectangle CollisionBox {
            get {
                return rectangle;
            }
            set { rectangle = value; }
        }

        public void Collision(BaseObject col) {

            pos = Oldpos;
        }


        public override void Update(GameTime gameTime) {
            texture = Assets.PlayerFront;
            if (Mouse.GetState().LeftButton == ButtonState.Pressed) {
                ObjectManager.newPistolBullet(Mouse.GetState().Position.ToVector2(), pos);
            }
            Movement();
        }

        private void Movement() {

            Kstate = Keyboard.GetState();

            if (Kstate.IsKeyDown(Keys.W)) {
                velocity.Y -= speed;
                texture = Assets.PlayerBack;
            }

            if (Kstate.IsKeyDown(Keys.S)) {
                velocity.Y += speed;
                texture = Assets.PlayerFront;

            }

            if (Kstate.IsKeyDown(Keys.D)) {
                velocity.X += speed;
                texture = Assets.PlayerRight;
            }

            if (Kstate.IsKeyDown(Keys.A)) {
                velocity.X -= speed;
                texture = Assets.PlayerLeft;
            }

            //Sakta ner om ingen knapp är tryckt
            if(!Kstate.IsKeyDown(Keys.S) && !Kstate.IsKeyDown(Keys.W)) {
                velocity.Y *= 0.2f;
                
            }

            //Sakta ner om ingen knapp är tryckt
            if (!Kstate.IsKeyDown(Keys.A) && !Kstate.IsKeyDown(Keys.D)) {
                velocity.X *= 0.2f;
            }

            //begränsa hastigheten 
            if (velocity.X > 4) {
                velocity.X = 4;
            }

            if (velocity.Y > 4) {
                velocity.Y = 4;
            }

            if (velocity.X < -4) {
                velocity.X = -4;
            }

            if (velocity.Y < -4) {
                velocity.Y = -4;
            }

            Oldpos = pos;

            pos += velocity;

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);
        }

    }
}
