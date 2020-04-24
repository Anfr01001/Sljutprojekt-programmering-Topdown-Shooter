using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class button {

        Point size; // = new Point(300, 100);
        Color color;// = Color.Green;
        Point pos;// = new Point(200, 200);
        string text;// = "123123";
        public Rectangle rectangle;

        public button(Point size, Point pos, string text, Color color) {
            rectangle = new Rectangle(pos, size);
            this.size = size;
            this.pos = pos;
            this.text = text;
            this.color = color;
        }

        public void draw(SpriteBatch spriteBatch) {
            //Rita ut bakgrund 
            spriteBatch.Draw(Assets.Pixel, rectangle, color);
            //Rita ut text
            spriteBatch.DrawString(Assets.textfont, text, new Vector2(pos.X + (size.X / 2), pos.Y + (size.Y / 2)), Color.Black);
        }

        public virtual void KlickOn() {
            
        }
    }
}
