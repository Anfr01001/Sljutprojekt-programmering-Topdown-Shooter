using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    static class ObjectManager {

        static List<BaseObject> Allobjects = new List<BaseObject>();
        static List<ICollision> collidableObjects = new List<ICollision>();

        static List<bulletBase> bulletList = new List<bulletBase>();


        public static void Update(GameTime gameTime) {
            foreach (BaseObject obj in Allobjects) {
                obj.Update(gameTime);
            }

            for (int i = 0; i < collidableObjects.Count; i++) {
                ICollision colObj1 = collidableObjects[i];

                for (int j = i + 1; j < collidableObjects.Count; j++) {
                    ICollision colObj2 = collidableObjects[j];
                    if (colObj1.CollisionBox.Intersects(colObj2.CollisionBox)) {
                        colObj1.Collision(colObj2 as BaseObject);
                        colObj2.Collision(colObj1 as BaseObject);
                    }
                }

            }

        }

        public static void AddObject(BaseObject obj) {
            Allobjects.Add(obj);
            if (obj is ICollision)
                collidableObjects.Add(obj as ICollision);
        }

        public static void Draw(SpriteBatch spriteBatch) {

            foreach (BaseObject obj in Allobjects) {
                obj.Draw(spriteBatch);
            }
        }

        public static void newPistolBullet(Vector2 target, Vector2 orgpos) {
            Allobjects.Add(new PistolBullet(target, orgpos));
        }

    }
}
