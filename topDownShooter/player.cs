using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class player : BaseObject, ICollision {

        //String så att direction kan vara samma namn som spriten blir tydligare
        private string direction;

        private float speed = 2f;

        private Vector2 velocity;

        KeyboardState Kstate;

        MouseState OldmouseState;

        private Vector2 Oldpos = Vector2.Zero;

        public string weapon = "Pistol";

        public int hp = 5;

        Random r = new Random();

        public int score = 0;

        public int Money = 0;

        public player() {
            size = 45;
        }

        public Rectangle CollisionBox {
            get {
                return rectangle;
            }
            set { rectangle = value; }
        }

        public void Collision(BaseObject col) {
           if(col is MapBlockColission)
                pos = Oldpos;

            if (col is EnemyBase) {
                hp -= (col as EnemyBase).damage;
                if (hp <= 0)
                    dead = true;

                col.dead = true;
                scoreBoard.UpdateraScoreLista(score.ToString());
                StartMeny.OpenMenu(true);
            }
        }

        public override void Update(GameTime gameTime) {
            center = new Vector2(pos.X + (size / 2), pos.Y + (size / 2));


            texture = Assets.PlayerFront;
            if((Mouse.GetState().LeftButton == ButtonState.Pressed)){
                switch (weapon) {
                    case "Pistol":
                        if(OldmouseState.LeftButton == ButtonState.Released)
                            ObjectManager.AddObject(new PistolBullet(Mouse.GetState().Position.ToVector2(), center, this, 0, 8));
                        break;

                    case "Rifle":
                        if (OldmouseState.LeftButton == ButtonState.Released) {
                            for (int i = 0; i < 10; i++) {
                                ObjectManager.AddObject(new PistolBullet(Mouse.GetState().Position.ToVector2(), center, this, r.Next(5, 50), r.Next(7, 11)));
                            }
                        }
                        break;

                    case "MachineGun":
                        if (OldmouseState.LeftButton == ButtonState.Released) {
                            for (int i = 0; i < 15; i++) {
                                ObjectManager.AddObject(new PistolBullet(Mouse.GetState().Position.ToVector2(), center, this, r.Next(5, 30), i+5));
                            }
                        }
                        break;
                }
            }


            OldmouseState = Mouse.GetState();

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
