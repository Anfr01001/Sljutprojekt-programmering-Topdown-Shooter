﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    interface ICollision {

        Rectangle CollisionBox {
            get;
            set;
        }

        void Collision(BaseObject obj);
    }
}
