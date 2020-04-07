using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    static class Assets {

        public static Texture2D Pixel;

        public static Texture2D Rock;
        public static Texture2D Grass;

        public static Texture2D PlayerFront;
        public static Texture2D PlayerBack;
        public static Texture2D PlayerRight;
        public static Texture2D PlayerLeft;
        public static Texture2D PlayerDead;

        public static Texture2D TombStone;

        public static Texture2D Fly1;

        public static SpriteFont textfont;

        public static void CreatePixel(GraphicsDevice device) {
            //Standrad texture för test
            Pixel = new Texture2D(device, 1, 1);
            Pixel.SetData(new Color[] { Color.White });
        }

        public static void LoadContent(ContentManager content) {
            textfont = content.Load<SpriteFont>("Text");
            Rock = content.Load<Texture2D>("Rock");
            Grass = content.Load<Texture2D>("Grass");
            TombStone = content.Load<Texture2D>("TombStone");

            Fly1 = content.Load<Texture2D>("Enemy1.1");

            PlayerFront = content.Load<Texture2D>("Player Front");
            PlayerBack = content.Load<Texture2D>("Player Back");
            PlayerRight = content.Load<Texture2D>("Player Right");
            PlayerLeft = content.Load<Texture2D>("Player Left");
            PlayerDead = content.Load<Texture2D>("Player dead");

        }
    }
}
