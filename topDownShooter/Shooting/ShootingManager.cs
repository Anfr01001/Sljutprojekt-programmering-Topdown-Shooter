using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    static class ShootingManager {

        static List<bulletBase> bulletList = new List<bulletBase>();

        public static void newPistolBullet(Vector2 target, Vector2 orgpos) {
            bulletList.Add(new PistolBullet(target, orgpos));
        }

        public static void Update(GameTime gameTime) {
            foreach (bulletBase bullet in bulletList) {
                bullet.update(gameTime);
            }
        }

        //De har egen draw från baseobject

    }
}
