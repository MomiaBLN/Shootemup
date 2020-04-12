using System;
using UnityEngine;
using RuntimeCode.Waitings;

namespace RuntimeCode.Characters
{
	[RequireComponent(typeof(Refresher))]
	public class HeroDetector : TriggerDetector<Hero>
	{
		[SerializeField] protected Character user;
		[SerializeField] protected Refresher refresher;
		protected Hero detectedObject;

		public void OnEnable()
		{
			if (refresher == null && !TryGetComponent(out refresher))
				throw new NullReferenceException();
		}

		protected override void ReactToObjectDetection(Hero detectedObject)
		{
			this.detectedObject = detectedObject;

			refresher.Refresh += ActOnObjectDetected;
			refresher.enabled = true;
		}

		protected override void ReactToObjectExited(Hero detectedObject)
		{
			refresher.Refresh -= ActOnObjectDetected;
			refresher.enabled = false;
		}

		protected void ActOnObjectDetected()
		{
			user.Attack(detectedObject);
		}
	}
}