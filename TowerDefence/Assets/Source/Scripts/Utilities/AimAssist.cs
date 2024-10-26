using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Source.Scripts.Utilities
{
	public static class AimAssist
	{
		public static Vector3 FirstOrderIntercept(Vector3 shooterPosition, Vector3 shooterVelocity, float shotSpeed, Vector3 targetPosition, Vector3 targetVelocity)
		{
			Vector3 targetRelativePosition = targetPosition - shooterPosition;
			Vector3 targetRelativeVelocity = targetVelocity - shooterVelocity;
			float t = FirstOrderInterceptTime(shotSpeed, targetRelativePosition, targetRelativeVelocity);
			return targetPosition + t * (targetRelativeVelocity);
		}

		public static float FirstOrderInterceptTime(float shotSpeed, Vector3 targetRelativePosition, Vector3 targetRelativeVelocity)
		{
			float velocitySquared = targetRelativeVelocity.sqrMagnitude;
			if (velocitySquared < 0.001f)
				return 0f;

			float a = velocitySquared - shotSpeed * shotSpeed;


			if (Mathf.Abs(a) < 0.001f)
			{
				float t = -targetRelativePosition.sqrMagnitude /
				(
					2f * Vector3.Dot
					(
						targetRelativeVelocity,
						targetRelativePosition
					)
				);
				return Mathf.Max(t, 0f);
			}

			float b = 2f * Vector3.Dot(targetRelativeVelocity, targetRelativePosition);
			float c = targetRelativePosition.sqrMagnitude;
			float determinant = b * b - 4f * a * c;

			if (determinant > 0f)
			{ 
				float t1 = (-b + Mathf.Sqrt(determinant)) / (2f * a),
						t2 = (-b - Mathf.Sqrt(determinant)) / (2f * a);
				if (t1 > 0f)
				{
					if (t2 > 0f)
						return Mathf.Min(t1, t2);
					else
						return t1;
				}
				else
					return Mathf.Max(t2, 0f);
			}
			else if (determinant < 0f)
				return 0f;
			else
				return Mathf.Max(-b / (2f * a), 0f);
		}

		public static bool CalculateTrajectory(float TargetDistance, float ProjectileVelocity, out float CalculatedAngle)
		{
			CalculatedAngle = 0.5f * (Mathf.Asin((-Physics.gravity.y * TargetDistance) / (ProjectileVelocity * ProjectileVelocity)) * Mathf.Rad2Deg);
			if (float.IsNaN(CalculatedAngle))
			{
				CalculatedAngle = 0;
				return false;
			}
			return true;
		}
	}
}
