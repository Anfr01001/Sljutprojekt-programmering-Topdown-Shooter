using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class buyRiflebtn : button {

        player user = (ObjectManager.player as player);
        int cost = 50;

        public buyRiflebtn(Point size, Point pos, string text) : base(size, pos, text) {
            if (user.Money < cost) {
                color = Color.Red;
            } else {
                color = Color.Green;
            }
        }

        public override void KlickOn() {
            if (user.Money >= cost) {
                buyMeny.active = false;
                user.weapon = "Rifle";
                user.Money -= cost;
            }
        }

        public override void ColorChange() {
            if (user.Money < cost) {
                color = Color.Red;
            } else {
                color = Color.Green;
            }
        }
    }
}