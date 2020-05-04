using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

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

        static int round = 1;
        static bool playing = false;
        static int spawnpoints = 1;
        static double tidmellanrunda = 10;
        static double RoundStartTime = 0;
        static double temp1;
        static List<EnemyBase> Enemylist = new List<EnemyBase>();

        static double tidmellanFiende = 1;
        static double senastefiende = 0;

        static bool RoundWaitning = false;
        static double timeleft;



        static Random r = new Random();
        public static void Update(GameTime gameTime) {
            //kolla om sp det inte finns mer fienden att spawna
            if (Enemylist.Count == 0){
                //Ge tid mellan rundorna
                if ((gameTime.TotalGameTime.TotalSeconds) > RoundStartTime + tidmellanrunda){
                    RoundStartTime = gameTime.TotalGameTime.TotalSeconds;
                    //Välj fienden
                    spawnpoints = (int)Math.Ceiling((double)round*1.2);
                    PickEnemyes();
                    round++;
                    RoundWaitning = false;
                }
                    RoundWaitning = true;
                    timeleft = (RoundStartTime + tidmellanrunda) - gameTime.TotalGameTime.TotalSeconds;
            } else {
                if( gameTime.TotalGameTime.TotalSeconds > senastefiende + tidmellanFiende) {
                    senastefiende = gameTime.TotalGameTime.TotalSeconds;
                    //Ok det finns fienden då spawnar vi dem
                    ObjectManager.AddObject(Enemylist[0]);
                    Enemylist.Remove(Enemylist[0]);
                }
                RoundStartTime = gameTime.TotalGameTime.TotalSeconds;
            }

            
                
        }  
        
        public static void PickEnemyes(){
            Enemylist.Clear();

            while (spawnpoints > 0) {

                if (spawnpoints > 4) {
                    Enemylist.Add(new Enemy2(r.Next(0, 1000)));
                    spawnpoints -= 2;
                } else {
                    Enemylist.Add(new EnemyFly(r.Next(0, 1000)));
                    spawnpoints--;
                }
            }
        }

       public static void Draw(SpriteBatch spriteBatch) {

             spriteBatch.DrawString(Assets.textfont, "Runda " + round , Vector2.Zero, Color.Black);
            if (RoundWaitning){
                spriteBatch.DrawString(Assets.textfont, "Time " + Math.Round(timeleft) , new Vector2(0, 20), Color.Black);
            }
             //spriteBatch.DrawString(Assets.textfont, "Time " + temp1 , new Vector2(0, 20), Color.Black);
             //spriteBatch.DrawString(Assets.textfont, "NextWave " + (RoundStartTime + tidmellanrunda) , new Vector2(0, 40), Color.Black);
       }

    }
}
