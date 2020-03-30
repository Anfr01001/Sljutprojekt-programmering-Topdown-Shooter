using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class bulletBase : BaseObject, ICollision {

        protected BaseObject shooter;

        public bulletBase() {

        }

        public Rectangle CollisionBox {
            get {
                return rectangle;
            }
            set { rectangle = value; }
        }

        public void Collision(BaseObject obj) {
            if(obj != shooter && !(obj is bulletBase)) {
                dead = true;
                //Om object kan ta damage gör det
            }
        }

        public void update(GameTime gameTime) {
        }

    }
}
