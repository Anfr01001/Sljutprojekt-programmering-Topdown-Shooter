using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class MapBlock {
        private int size = 50; //Antal pixlar stor
        private Vector2 pos;
        public Rectangle rectangle { get; }

        public Texture2D texture;

        public MapBlock(Vector2 pos, Texture2D texture) {
            this.pos = pos;
            this.texture = texture;
            rectangle = new Rectangle((int)pos.X, (int)pos.Y, size, size);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, rectangle, Color.White);
        }
    }
}
