using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class buyRiflebtn : button {
        public buyRiflebtn(Point size, Point pos, string text, Color color) : base(size, pos, text, color) {

        }

        public override void KlickOn() {
            buyMeny.active = false;
            (ObjectManager.player as player).weapon = "Rifle";
        }
    }
}