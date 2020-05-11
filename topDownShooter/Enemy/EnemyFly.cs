﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class EnemyFly : EnemyBase {
        
        //Med frame menas vilken frame animationen är på exempelvis har denna flyg animation bara 2 bilder. 2st "frames"
        private float timeperframe = 0.2f; //s
        private float lastftametime = 0f;

        public EnemyFly(int seed) : base (seed) {
            texture = Assets.Fly1;
            speed = 5;
            hp = 30;
            hpbar = new Healthbar(hp, size);
        }

        //Override Update fast kör base ändå och sedan lägg till animations biten.
        public override void Update(GameTime gameTime) {
            base.Update(gameTime);
            Animation(gameTime);
        }

        /// <summary>
        /// Används för att byta sprite på fiende för att få den att se animerad ut (vingarna flaxar)
        /// </summary>
        /// <param name="gameTime"></param>
        public void Animation(GameTime gameTime) {
            if (gameTime.TotalGameTime.TotalSeconds > lastftametime + timeperframe) {
                lastftametime = (float)gameTime.TotalGameTime.TotalSeconds;
                //byt bild.
                if(texture == Assets.Fly1) {
                    texture = Assets.Fly2;
                } else {
                    texture = Assets.Fly1;
                }
            }
        }
    }
}
