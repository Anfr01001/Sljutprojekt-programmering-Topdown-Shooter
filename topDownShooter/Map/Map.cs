using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    static class Map {


        //Antal block per riktning
        static int size = 15;

        static Random r = new Random();

        static Vector2 tempvector;

        public static void BuildMap() {
            //rita först ut gräs överallt för att sedan lägga på annat
            for (int x = 0; x < size; x++) {
                for (int y = 0; y < size; y++) {
                    ObjectManager.AddObject(new MapBlock(new Vector2(x * 50, y * 50), Assets.Grass));
                }
            }

            //börja med kanterna 
            for (int y = 0; y < size; y++) {
                ObjectManager.AddObject(new MapBlockColission(new Vector2(0, y * 50), Assets.Rock));

                ObjectManager.AddObject(new MapBlockColission(new Vector2(size * 50, y * 50), Assets.Rock));
            }

            for (int x = 0; x < size; x++) {
                ObjectManager.AddObject(new MapBlockColission(new Vector2(x * 50, 0), Assets.Rock));

                ObjectManager.AddObject(new MapBlockColission(new Vector2(x * 50, 50 * size), Assets.Rock));
            }

            //hur många formationer av stenar ska finnas
            for (int i = 0; i < 15; i++) {
                //välj en av de förbestämda formationerna
                switch (r.Next(0, 5)) {
                    case 1:
                        //Som ett kors med berg
                        //vart ska det vara ?
                        tempvector = new Vector2(r.Next(2, 14), r.Next(2, 14));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2(tempvector.X * 50, tempvector.Y * 50), Assets.Rock)); // mitten
                        ObjectManager.AddObject(new MapBlockColission(new Vector2((tempvector.X + 1) * 50, tempvector.Y * 50), Assets.Rock)); // höger
                        ObjectManager.AddObject(new MapBlockColission(new Vector2((tempvector.X - 1) * 50, tempvector.Y * 50), Assets.Rock)); // vänster
                        ObjectManager.AddObject(new MapBlockColission(new Vector2(tempvector.X * 50, (tempvector.Y - 1) * 50), Assets.Rock)); // uppe 
                        ObjectManager.AddObject(new MapBlockColission(new Vector2(tempvector.X * 50, (tempvector.Y + 1) * 50), Assets.Rock));//nere
                        break;

                    case 2:
                        //En rak bergskjedja
                        tempvector = new Vector2(r.Next(2, 14), r.Next(2, 14));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2(tempvector.X * 50, tempvector.Y * 50), Assets.Rock));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2((tempvector.X + 1) * 50, tempvector.Y * 50), Assets.Rock));
                        break;
                    case 3:
                        //vertikalt rak
                        tempvector = new Vector2(r.Next(2, 14), r.Next(2, 14));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2(tempvector.X * 50, tempvector.Y * 50), Assets.Rock));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2(tempvector.X * 50, (tempvector.Y - 1) * 50), Assets.Rock));
                        break;
                    case 4:
                        //En krok med bergskjedja
                        tempvector = new Vector2(r.Next(2, 14), r.Next(2, 14));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2(tempvector.X * 50, tempvector.Y * 50), Assets.Rock));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2((tempvector.X + 1) * 50, tempvector.Y * 50), Assets.Rock));
                        ObjectManager.AddObject(new MapBlockColission(new Vector2((tempvector.X + 1) * 50, (tempvector.Y - 1) * 50), Assets.Rock));
                        break;
                }
            }
            //Lägg till enemy spawn points i hörnen.
            ObjectManager.AddObject(new MapBlock(new Vector2(1 * 50, 1 * 50), Assets.TombStone)); // vänster uppe
            ObjectManager.AddObject(new MapBlock(new Vector2(14 * 50, 1 * 50), Assets.TombStone)); // höger uppe
            ObjectManager.AddObject(new MapBlock(new Vector2(14 * 50, 14 * 50), Assets.TombStone)); // höger nere
            ObjectManager.AddObject(new MapBlock(new Vector2(1 * 50, 14 * 50), Assets.TombStone)); // vänster nere
        }
        
    }
}
