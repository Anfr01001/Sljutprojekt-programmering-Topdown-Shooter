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

        public static void CreatePixel(GraphicsDevice device) {
            //Standrad texture för test
            Pixel = new Texture2D(device, 1, 1);
            Pixel.SetData(new Color[] { Color.White });
        }

        public static void LoadContent(ContentManager content) {
            Rock = content.Load<Texture2D>("Rock");
            Grass = content.Load<Texture2D>("Grass");

        }
    }
}
