using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class PistolBullet : bulletBase {

        int damage = 10;
        float speed = 10;
        Vector2 target;
        Vector2 direction = Vector2.Zero;
        

        public PistolBullet(Vector2 target, Vector2 orgpos) : base(target) {
            this.target = target;
            pos = orgpos;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);
        }

        public override void Update(GameTime gameTime) {
            direction = (Vector2.Normalize(Vector2.Subtract(pos, target)));
            pos += direction * speed;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, 10, 10);
        }

    }
}
