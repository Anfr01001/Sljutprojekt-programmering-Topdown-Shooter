using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class PistolBullet : bulletBase{

        float speed = 10;
        Vector2 target;
        Vector2 direction = Vector2.Zero;
        Random r = new Random();

        public PistolBullet(Vector2 target, Vector2 orgpos, BaseObject shooter, int inacurrasy, int speed){
            this.target = target;
            pos = orgpos;
            this.shooter = shooter;

            this.speed = speed;
            target.X += r.Next(0, inacurrasy);
            target.Y += r.Next(0, inacurrasy);

            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 7, 7);
            direction = (Vector2.Normalize(Vector2.Subtract(pos, target)));
            damage = 10;
        }

        public override void Update(GameTime gameTime) {
            
            pos -= direction * speed;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 7, 7);
        }

    }
}
