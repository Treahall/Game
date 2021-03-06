﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.HelperClasses;
using Point = System.Drawing.Point;

namespace Game.Entities
{
    class BrokenWindow : Obstacle
    {
        public BrokenWindow(Player U, int speed) : base(U, speed)
        {
            //Initial position
            Position = new Point(1440, EntityAnimations.Floor - GetSpriteSize().Height); //Magic numbers for start pos.

            //Custom Initial velocity
            Speed = speed - 2;
            Velocity = new Point(-Speed, 0); //Magic value for velocity.
        }

        public override void LoadAnimations()
        {
            CurrentAnimation = EntityAnimations.BrokenWindow;
        }

        public override void CollisionEvents()
        {
            User.dead = true;
        }
    }
}
