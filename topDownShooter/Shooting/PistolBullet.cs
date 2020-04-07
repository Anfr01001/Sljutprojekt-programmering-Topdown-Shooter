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

        public PistolBullet(Vector2 target, Vector2 orgpos, BaseObject shooter){
            this.target = target;
            pos = orgpos;
            this.shooter = shooter;
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
