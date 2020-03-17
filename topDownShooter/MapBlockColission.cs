﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class MapBlockColission : BaseObject, ICollision {
        public MapBlockColission(Vector2 pos, Texture2D texture) {
            this.pos = pos;
            this.texture = texture;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);
        }

        public Rectangle CollisionBox {
            
            get {
                return rectangle;
            }
            set { rectangle = value; }
    }

        public void Collision(BaseObject obj) {
            
        }
    }
}