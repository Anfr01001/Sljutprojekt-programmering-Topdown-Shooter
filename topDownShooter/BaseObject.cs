using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace topDownShooter {
    class BaseObject {

        protected Vector2 pos = new Vector2(60, 60);
        protected Rectangle rectangle;
        protected Color color = Color.White;
        protected int size = 50;
        protected Texture2D texture = Assets.Pixel;

        public virtual void Update() {
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, rectangle, color);
        }

    }
}
