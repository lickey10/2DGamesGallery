﻿/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/



using UnityEngine;
using System.Collections;

namespace AppAdvisory.SpringPong
{
	/// <summary>
	/// In Charge of the inputs in the game.
	/// </summary>
	public class InputTouch : MonoBehaviour 
	{
		public delegate void OnTouch(TouchDirection td);
		public static event OnTouch OnTouched;

		void Update()
		{

			#if UNITY_TVOS && !UNITY_EDITOR

			float h = Input.GetAxis("Horizontal");

			if(h < 0)
			{
			if(OnTouched!=null)
			OnTouched(TouchDirection.left);
			}
			else if(h > 0)
			{
			if(OnTouched!=null)
			OnTouched(TouchDirection.right);
			}

			#endif

			#if (UNITY_ANDROID || UNITY_IOS) && !UNITY_TVOS && !UNITY_EDITOR
			if (Application.isMobilePlatform || Application.isEditor) 
			{
			int nbTouches = Input.touchCount;

			if (nbTouches > 0) 
			{
			Touch touch = Input.GetTouch (0);

			TouchPhase phase = touch.phase;

			if (phase == TouchPhase.Began) 
			{
			if (touch.position.x < Screen.width / 2f)
			{
			if(OnTouched!=null)
			OnTouched(TouchDirection.left);
			}
			else
			{
			if(OnTouched!=null)
			OnTouched(TouchDirection.right);
			}
			}

			if (phase == TouchPhase.Ended)
			{
			if(OnTouched!=null)
			OnTouched(TouchDirection.none);
			}
			}
			}
			#endif

			#if (!UNITY_ANDROID && !UNITY_IOS && !UNITY_TVOS) || UNITY_EDITOR

			if (Input.GetKeyDown (KeyCode.LeftArrow))
			{
				if(OnTouched!=null)
					OnTouched(TouchDirection.left);

				return;
			}

			if (Input.GetKeyDown (KeyCode.RightArrow))
			{
				if(OnTouched!=null)
					OnTouched(TouchDirection.right);

				return;
			}

			if (Input.GetKeyUp (KeyCode.LeftArrow))
			{
				if(OnTouched!=null)
					OnTouched(TouchDirection.none);

				return;
			}

			if (Input.GetKeyUp (KeyCode.RightArrow))
			{
				if(OnTouched!=null)
					OnTouched(TouchDirection.none);

				return;
			}

			if(Input.anyKeyDown)
			{
				if(OnTouched!=null)
					OnTouched(TouchDirection.none);
			}

			#endif
		}
	}

	/// <summary>
	/// Touch direction: left or right.
	/// </summary>
	public enum TouchDirection
	{
		none,
		left,
		right
	}
}