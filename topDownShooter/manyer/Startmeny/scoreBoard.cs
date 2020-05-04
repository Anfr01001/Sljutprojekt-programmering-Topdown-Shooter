using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    static class scoreBoard {

        static string tempScoreboard;
        static List<int> BestScore = new List<int>();
        static int StartIndex, EndIndex;
        static string tempscore;
        static int ScoreTO;

        public static void UpdateraScoreLista(string NewScore) {
            // Scoreboard sparas som en textfil för att kunna används även efter det att spelat startats om.

            // kopierar filen in i en string
            tempScoreboard = File.ReadAllText("Scoreboard.txt");
            //Lägger till nytt score separerat med | för att göra det lättare att hitta senare
            tempScoreboard = tempScoreboard + NewScore + "|";
            //Skriver över texten i filen igen.
            File.WriteAllText("Scoreboard.txt", tempScoreboard);
        }

        public static void getScoreLista() {
            //nollställer listan och index samt läser av scoreboardfilen.
            StartIndex = 0;
            EndIndex = 0;
            BestScore.Clear(); // Ränsa listan.
            tempScoreboard = File.ReadAllText("Scoreboard.txt");

            while (EndIndex < tempScoreboard.Length - 1) {

                // Leta upp första | efter var senaste sökning avslutades.
                StartIndex = tempScoreboard.IndexOf('|', EndIndex);
                // Hitta | efter den förra för då vet vi att "scoren" står där emellan.
                EndIndex = tempScoreboard.IndexOf('|', StartIndex + 1);
                // börja från start (senaste |) och eftersom Substring vill ha längen blir den slutet minus början (-1 pga att vi inte vill ha med den senaste "|")
                tempscore = tempScoreboard.Substring(StartIndex + 1, EndIndex - StartIndex - 1);

                if (tempscore != null && int.Parse(tempscore) != 0)
                    BestScore.Add(int.Parse(tempscore));

            }

            //Sortera listan med alla scores och vänd sedan på den så störst blir först.
            BestScore.Sort();
            BestScore.Reverse();

        }

        public static void Draw(SpriteBatch spriteBatch) {
            if ((ObjectManager.player as player).score > 0) {
                spriteBatch.DrawString(Assets.textfont, "Topplista (Kills) du fick " + (ObjectManager.player as player).score + " kills" , new Vector2(250, 300), Color.Black);
            } else {
                spriteBatch.DrawString(Assets.textfont, "Topplista (Kills)", new Vector2(250, 300), Color.Black);
            }

            if (BestScore.Count >= 9) {
                ScoreTO = 9;
            } else {
                ScoreTO = BestScore.Count;
            }


            for (int i = 0; i < ScoreTO; i++) {
                spriteBatch.DrawString(Assets.textfont, (i+1) + ": " + BestScore[i], new Vector2(250, 330 + (i *30)), Color.Black);
            }

        }
    }
}
