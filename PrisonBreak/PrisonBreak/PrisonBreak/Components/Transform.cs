﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Xna.Framework;

namespace PrisonBreak.Components
{
	public class Transform : BaseComponent
	{
		private List<Transform> children;

		private Transform parent;
		private Vector2 position;
        private float z;
		private Vector2 offset;
		private Quaternion rotation;
		private float scale;

		//Properties
        // TODO: Implement parent flipping
		public Transform Parent
		{
			get { return parent; }
			set { parent = value; }
		}

		public Transform(GameObject parent)
			: base(parent)
		{
			position = Vector2.Zero;
			z = 0f;
			offset = Vector2.Zero;
			rotation = Quaternion.Identity;
			scale = 1f;
		}

		public Vector2 Position
		{
			get { return position; }
			set { position = value; }
		}

        public float Z
        {
            get { return z; }
            set { z = value; }
        }

		public Vector2 Offset
		{
			get { return offset; }
			set { offset = value; }
		}

		public Quaternion Rotation
		{
			get { return rotation; }
			set { rotation = value; }
		}

		public float RotationZ
		{
			set { rotation = Quaternion.CreateFromYawPitchRoll(0f, 0f, value); }
		}

		public float Scale
		{
			get { return scale; }
			set { scale = value; }
		}

		public void Translate(Vector2 delta)
		{
			position += delta;
			if (RigidBody != null)
			{
				RigidBody.Body.Position += delta / RigidBody.MInPx;
			}
		}

		public void Translate(Vector3 delta)
		{
			position += new Vector2(delta.X, delta.Y);
			z += delta.Z;
			if (RigidBody != null)
			{
				RigidBody.Body.Position += new Vector2(delta.X, delta.Y) / RigidBody.MInPx;
			}
		}

		public void Rotate(float delta)
		{
			rotation += Quaternion.CreateFromYawPitchRoll(0f, 0f, delta);
		}

		// TODO : Fix scale
		public void LocalScale(float delta)
		{
			scale += delta;
		}

		public Matrix WorldMatrix
		{
			get
			{
				Matrix world = Matrix.CreateScale(scale) *
				Matrix.CreateTranslation(new Vector3(offset, z)) *
				Matrix.CreateFromQuaternion(rotation) *
				Matrix.CreateTranslation(new Vector3(position, z));

				if (parent != null)
					world *= parent.WorldMatrix;

				return world;
			}
		}

		public override void Update()
		{
		}
	}
}
