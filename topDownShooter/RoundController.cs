using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    static class RoundController {

        /*
         *  Speler är baserat kring rundor där det blir svårare och svårare
         * med tanke på att det finns olika svåra fiender finns har alla fienden ett värde 
         * värje runda blir värdet av de totala antalet fiender mer vilket jag kallar spawnpoints
         */

            //gör en lista för att dra ut på när de spawnar gör en lista med enemybase för att sedan spawna in dem över tid. när en grej dör så skickas hit för att ta bort från listan. 
            //Håll koll på rundorna samt öka spawnpoints med ex 1.3
            //ge tid mellan rundorna för det man ska göra där.

        static int round = 0;
        static bool playing = false;
        static int spawnpoints = 5;
        static float tidmellanrunda = 5f;

        static Random r = new Random();
        public static void Update(GameTime gameTime) {
            //gör en if else för att kolla vilka av fienden jag kan sapwna (byt ut 1an i next) fienden måste vara sorterade i "pris ordning"

            switch (r.Next(0,1)) {

                case 1: // kostar 1
                    ObjectManager.AddObject(new EnemyFly());
                    spawnpoints -= 1;
                    break;

                default:
                    break;
            }
        }
    }
}
