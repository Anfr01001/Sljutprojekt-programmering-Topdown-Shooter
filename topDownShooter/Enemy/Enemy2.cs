using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class Enemy2 : EnemyBase {

        //Med frame menas vilken frame animationen är på exempelvis har denna flyg animation bara 2 bilder. 2st "frames"
        private float timeperframe = 0.2f; //s
        private float lastftametime = 0f;

        public Enemy2(int seed) : base(seed) {
            texture = Assets.Enemyfly2;
            speed = 5;
            hp = 50;
            hpbar = new Healthbar(hp, size);
        }

        //Override Update fast kör base ändå och sedan lägg till animations biten.
        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            Animation(gameTime);
        }

        public void Animation(GameTime gameTime) {
            if (gameTime.TotalGameTime.TotalSeconds > lastftametime + timeperframe) {
                lastftametime = (float)gameTime.TotalGameTime.TotalSeconds;
                //byt bild.
                if (texture == Assets.Enemyfly3) {
                    texture = Assets.Enemyfly2;
                } else {
                    texture = Assets.Enemyfly3;
                }
            }
        }
    }
}