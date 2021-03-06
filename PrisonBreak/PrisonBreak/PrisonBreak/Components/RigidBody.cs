﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

using FarseerPhysics;
using FarseerPhysics.DebugViews;
using FarseerPhysics.Dynamics;
using FarseerPhysics.Factories;

namespace PrisonBreak.Components
{
	public class CollisionCats
	{
		public static Category PlayerCategory { get { return Category.Cat2; } }
		public static Category WorldCategory { get { return Category.Cat3; } }
		public static Category EnemyCategory { get { return Category.Cat4; } }
		public static Category TriggerCategory { get { return Category.Cat5; } }
	}

	public class RigidBody : BaseComponent
	{
		private static World world = new World(new Vector2(0f, -9.82f));
		public const float MInPx = 16f;

		private static DebugViewXNA debugView = new DebugViewXNA(world);
		private static bool isDebugEnabled = false;
		private static Matrix debugViewMatrix;
		private static Matrix debugProjMatrix;

		public static bool IsDebugEnabled
		{
			get { return isDebugEnabled; }
			set { isDebugEnabled = value; }
		}

		public static World World
		{
			get { return world; }
		}

		private Body body;

		public Body Body
		{
			get { return body; }
		}

		public Category CollidesWith
		{
			set { body.CollidesWith = value; }
		}

		public Category CollisionCategory
		{
			set { body.CollisionCategories = value; }
		}

		static RigidBody()
		{
			debugView.AppendFlags(DebugViewFlags.DebugPanel);
			debugView.DefaultShapeColor = Color.White;
			debugView.SleepingShapeColor = Color.LightGray;
		}

		public static void DebugLoadContent(GraphicsDevice graphicsDevice, ContentManager content)
		{
			debugView.LoadContent(graphicsDevice, content);
		}

		public static void DebugRender()
		{
			Vector3 cameraPos = Camera.MainCamera.Transform.WorldPosition;
			debugViewMatrix = Matrix.CreateLookAt(cameraPos / MInPx, new Vector3(cameraPos.X / MInPx, cameraPos.Y / MInPx, (cameraPos.Z - 2000f) / MInPx), Vector3.Up);
			debugProjMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(60f), 16f / 9f, 0.5f, 5000f);
			debugView.RenderDebugData(ref debugProjMatrix, ref debugViewMatrix);
		}

		public RigidBody(GameObject parent, BodyType bodyType, Vector2 size, bool fixedRotation = true, float friction = 2f)
			: base(parent)
		{
			body = BodyFactory.CreateRectangle(world, size.X / MInPx, size.Y / MInPx, 1f, new Vector2(Transform.WorldPosition.X, Transform.WorldPosition.Y) / MInPx);
			body.BodyType = bodyType;
			body.FixedRotation = fixedRotation;
			body.Friction = friction;
		}

		public RigidBody(GameObject parent, Body body, bool fixedRotation = true, float friction = 2f)
			: base(parent)
		{
			this.body = body;
			this.body.BodyType = BodyType.Static;
			this.body.FixedRotation = fixedRotation;
			this.body.Friction = friction;
		}

		public override void Update()
		{
			if (body.BodyType == BodyType.Static)
				return;
			Transform.Position = body.Position * MInPx;
			Transform.RotationZ = body.Rotation;
		}

		public void ApplyImpulse(Vector2 impulse)
		{
			body.ApplyLinearImpulse(impulse);
		}

		public static void WorldStep()
		{
			world.Step(GameTimeGlobal.DeltaSec);
		}
	}
}
