﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PrisonBreak
{
    public abstract class BaseComponent : IComponent
    {
        protected GameObject par;

        public BaseComponent(GameObject parent)
        {
            par = parent;
        }

        public abstract void Update();
    }
}