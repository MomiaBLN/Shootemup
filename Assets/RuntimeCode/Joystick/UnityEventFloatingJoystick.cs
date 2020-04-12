using UnityEngine.EventSystems;
using RuntimeCode.UnityEvents;
using RuntimeCode.Interfaces;
using RuntimeCode.Waitings;
using UnityEngine;
using System;

namespace RuntimeCode.Inputs
{
	public class UnityEventFloatingJoystick : FloatingJoystick, IInitializable
	{
		[SerializeField] protected Refresher refresher;
		[SerializeField] protected Vector3UnityEvent OnJoystickMoved;
		protected bool isBeingDragged = false;

		protected bool isInitialized;
		public bool IsInitialized => isInitialized;

		protected override void Start()
		{
			base.Start();

			Initialize();
		}

		public void Initialize()
		{
			if (refresher == null && !TryGetComponent(out refresher))
				throw new NullReferenceException();

			isInitialized = true;
		}

		public override void OnPointerDown(PointerEventData eventData)
		{
			refresher.Refresh += CallEvent;
			refresher.enabled = isBeingDragged = true;
			base.OnPointerDown(eventData);
		}

		public override void OnPointerUp(PointerEventData eventData)
		{
			refresher.Refresh -= CallEvent;
			refresher.enabled = isBeingDragged = false;
			base.OnPointerUp(eventData);
		}

		protected void CallEvent()
		{
			OnJoystickMoved?.Invoke(new Vector3(Horizontal, 0f, Vertical));
		}
	}
}