using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace topDownShooter {
    class BaseObject {

        public Vector2 pos = new Vector2(60, 60);
        protected Rectangle rectangle;
        protected Color color = Color.White;
        protected int size = 50;
        protected Texture2D texture = Assets.Pixel;
        public Vector2 center;
        public bool dead = false;

        public virtual void Update(GameTime gameTime) {
            center = new Vector2(pos.X + (size / 2), pos.Y + (size / 2));
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, rectangle, color);
        }

    }
}
