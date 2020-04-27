using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class EnemyBase : BaseObject, ICollision {

        protected float speed;

        private Vector2 velocity;

        protected int hp;
        public int damage = 1;

        private Vector2 Oldpos = Vector2.Zero;
        private Vector2 direction;

        Random r;

        private BaseObject target;

        protected Healthbar hpbar;

        public EnemyBase(int seed) {

             r = new Random(seed);

            target = ObjectManager.player;

                switch (r.Next(0, 5)) {
                case 1:
                    pos = new Vector2(50, 50);
                    break;
                case 2:
                    pos = new Vector2(700, 50);
                    break;
                case 3:
                    pos = new Vector2(700, 700);
                    break;
                case 4:
                    pos = new Vector2(50, 700);
                    break;
                }

            //Fixa random spawn.
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);
            direction = (Vector2.Normalize(Vector2.Subtract(pos, target.pos)));
        }

        public Rectangle CollisionBox {
            get {
                return rectangle;
            }
            set { rectangle = value; }
        }

        public void Collision(BaseObject col) {
            
        }

        public void TakeDamage(int damage) {
            hp -= damage;
            if (hp <= 0)
                dead = true;
        }

        public override void Update(GameTime gameTime) {
            //movement
            direction = (Vector2.Normalize(Vector2.Subtract(pos, target.pos)));
            pos -= direction * speed;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 40, 40);

            hpbar.Update(hp, new Vector2(pos.X, pos.Y));
        }

        public override void Draw(SpriteBatch spriteBatch) {
            hpbar.Draw(spriteBatch);
            base.Draw(spriteBatch);
        }
    }
}
