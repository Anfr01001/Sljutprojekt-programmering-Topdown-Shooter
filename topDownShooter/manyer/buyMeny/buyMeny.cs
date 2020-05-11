using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class buyMeny {
        static public bool active = false;
        static Rectangle temp;

        static List<button> buttonList = new List<button>() {
            new buyHpbtn(new Point(300, 100), new Point(200, 200), "Buy 1 hp (20)"),     
            new buyRiflebtn(new Point(300, 100), new Point(200, 400), "Buy Rifle (50)"),
            new buyMachineGunbtn(new Point(300, 100), new Point(200, 600), "Buy MachineGun (80)")
        };

        public static void draw(SpriteBatch spriteBatch) {
            foreach (button btn in buttonList) {
                btn.draw(spriteBatch);
            }
        }

        /// <summary>
        /// Om ett klick registreras kollar denna om den är inom rektanglen för knappen 
        /// Den skapar en liten rektangel runk pekaren som kollar om den är inom knappen
        /// </summary>
        /// <param name="gameTime"></param>
        public static void klickCheck(Point klickpos) {
            temp = new Rectangle(klickpos, new Point(5, 5));
            foreach (button btn in buttonList) {
                if (temp.Intersects(btn.rectangle)) {
                    btn.KlickOn();
                }
            }
        }
    }
}
