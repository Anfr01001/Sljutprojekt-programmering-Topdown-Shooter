using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace topDownShooter {
    class EnemyFly : EnemyBase {
        
        

        public EnemyFly() {
            texture = Assets.Fly1;
            speed = 5;
            hp = 10;
        }
        //Animate
    }
}
