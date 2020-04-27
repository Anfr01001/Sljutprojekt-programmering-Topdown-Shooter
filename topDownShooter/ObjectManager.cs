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
        static List<BaseObject> ObjectsToAdd = new List<BaseObject>();
        static List<BaseObject> ObjectsToRemove = new List<BaseObject>();

        static List<bulletBase> bulletList = new List<bulletBase>();

        static public BaseObject player;

        public static void Update(GameTime gameTime) {
            foreach (BaseObject obj in Allobjects) {
                if (!obj.dead)
                    obj.Update(gameTime);
                else
                    ObjectsToRemove.Add(obj);
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

            foreach (BaseObject obj in ObjectsToAdd) {
                Allobjects.Add(obj);
                if (obj is ICollision)
                    collidableObjects.Add(obj as ICollision);
            }

            ObjectsToAdd.Clear();

            foreach (BaseObject obj in ObjectsToRemove) {
                Allobjects.Remove(obj);
                if (obj is ICollision)
                    collidableObjects.Remove(obj as ICollision);
            }

            ObjectsToRemove.Clear();

        }

        public static void AddObject(BaseObject obj) {

            ObjectsToAdd.Add(obj);
            if (obj is player)
                player = obj as BaseObject;
        }

        public static void Draw(SpriteBatch spriteBatch) {

            foreach (BaseObject obj in Allobjects) {
                obj.Draw(spriteBatch);
                spriteBatch.DrawString(Assets.textfont, "Objects colide:  " + collidableObjects.Count, new Vector2(0, 60), Color.Black);
            }
        }

    }
}
