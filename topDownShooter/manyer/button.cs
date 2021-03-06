﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class button {

        Point size; // = new Point(300, 100);
        public Color color;// = Color.Green;
        Point pos;// = new Point(200, 200);
        public string text;// = "123123";
        public Rectangle rectangle;

        public button(Point size, Point pos, string text, Color color) {
            rectangle = new Rectangle(pos, size);
            this.size = size;
            this.pos = pos;
            this.text = text;
            this.color = color;
        }

        //konstruktor utan färg
        public button(Point size, Point pos, string text) {
            rectangle = new Rectangle(pos, size);
            this.size = size;
            this.pos = pos;
            this.text = text;
        }

        public void draw(SpriteBatch spriteBatch) {

            ColorChange();

            //Rita ut bakgrund 
            spriteBatch.Draw(Assets.Pixel, rectangle, color);
            //Rita ut text
            spriteBatch.DrawString(Assets.textfont, text, new Vector2(pos.X + (size.X / 2), pos.Y + (size.Y / 2)), Color.Black);
        }

        public virtual void ColorChange() {
            //inget händer om inte tillämpad till specefik knapp
        }

        public virtual void KlickOn() {
            
        }
    }
}
