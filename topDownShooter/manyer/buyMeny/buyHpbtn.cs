﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class buyHpbtn : button{
        public buyHpbtn(Point size, Point pos, string text, Color color) : base(size, pos, text, color) {

        }

        public override void KlickOn() {
            buyMeny.active = false;
            (ObjectManager.player as player).hp++;
        }
    }
}