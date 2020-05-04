using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace topDownShooter {
    static class StartMeny{

        static public bool active = false;
        static Rectangle temp;

        static button btn = new Startbtn(new Point(300, 100), new Point(200, 200), "Start", Color.Yellow);

        static bool GameOver = false;

        public static void OpenMenu(bool Lost) {
            scoreBoard.getScoreLista();
            active = true;

            GameOver = Lost;

        }
            
        public static void draw(SpriteBatch spriteBatch) {
            if (!GameOver)
                btn.draw(spriteBatch);

            scoreBoard.Draw(spriteBatch);
        }

        public static void klickCheck(Point klickpos) {
            temp = new Rectangle(klickpos, new Point(5, 5));

            if (temp.Intersects(btn.rectangle) && !GameOver) {
                btn.KlickOn();
            }
        }
    }
}
