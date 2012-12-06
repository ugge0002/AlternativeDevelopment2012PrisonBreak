﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace PrisonBreak
{
    public class Renderer : BaseComponent
    {
        SpriteBatch sb;
		SpriteFont Text;
		DialogBox OutputText;
	
       public SpriteEffects flip = SpriteEffects.None;
	
        public Renderer(GameObject parent, SpriteBatch sb) 
            : base(parent)
        {
            this.sb = sb;
        }
        public void Draw()
        {
           Console.WriteLine(flip);
		   OutputText = new DialogBox(par);
		   string blah = OutputText.InputText();
		   

		   Vector2 FontOrigin = new Vector2(5, 5);
            sb.Draw(par.CAnimation.SpriteSheet, par.CTransform.Position, par.CAnimation.CurrentFrame, Color.White, par.CTransform.Rotation, Vector2.Zero, 1.0f, flip, 0.0f);
			
			sb.DrawString(par.CDialogBox.SpriteSheet, blah.Substring(0), FontOrigin, Color.White);
		}

        public override void Update()
        {

        }

    }
}