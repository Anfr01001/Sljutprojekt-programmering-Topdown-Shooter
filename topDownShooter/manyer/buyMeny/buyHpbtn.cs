﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class buyHpbtn : button{

        player user = (ObjectManager.player as player);
        int cost = 20;
        public buyHpbtn(Point size, Point pos, string text) : base(size, pos, text) {
            if (user.Money < cost) {
                color = Color.Red;
            } else {
                color = Color.Green;
            }
        }

        public override void KlickOn() {
            if (user.Money >= cost) {
                buyMeny.active = false;
                user.hp++;
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