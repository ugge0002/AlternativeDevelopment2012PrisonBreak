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


		public SpriteEffects flip = SpriteEffects.None;

		public Renderer(GameObject parent, SpriteBatch sb)
			: base(parent)
		{
			this.sb = sb;
		}
		public void Draw()
		{
			Vector2 FontOrigin = new Vector2(5, 5);
			sb.Draw(par.CAnimation.SpriteSheet, par.CTransform.Position, par.CAnimation.CurrentFrame, Color.White, par.CTransform.Rotation, Vector2.Zero, 1.0f, flip, 0.0f);
			sb.Draw(par.CDialogBox.BoxSprite, FontOrigin, Color.Red);
			sb.DrawString(par.CDialogBox.Font, par.CDialogBox.CurrentString, FontOrigin, Color.White);
	
		}

		public override void Update()
		{
			par.CDialogBox.Update();

		}

	}
}
