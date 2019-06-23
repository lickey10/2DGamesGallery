﻿
/***********************************************************************************************************
 * Produced by App Advisory	- http://app-advisory.com													   *
 * Facebook: https://facebook.com/appadvisory															   *
 * Contact us: https://appadvisory.zendesk.com/hc/en-us/requests/new									   *
 * App Advisory Unity Asset Store catalog: http://u3d.as/9cs											   *
 * Developed by Gilbert Anthony Barouch - https://www.linkedin.com/in/ganbarouch                           *
 ***********************************************************************************************************/

using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;

namespace AppAdvisory.AA
{
	/// <summary>
	/// Class in charge to prompt a popup to ask the player to rate the game
	///
	/// Attached to the "RateUsManager" GameObject
	/// </summary>
	public class RateUsManager : MonoBehaviour 
	{
		/// <summary>
		/// The number of level played (each win or lose count for 1 play) to prompt the popup
		/// </summary>
		public int NumberOfLevelPlayedToShowRateUs = 30;
		public string iOSURL = "itms://itunes.apple.com/us/app/apple-store/id963781532?mt=8";
		public string ANDROIDURL = "http://app-advisory.com";

		public Button btnYes;
		public Button btnLater;
		public Button btnNever;

		public CanvasGroup popupCanvasGroup;

		void Awake()
		{
			popupCanvasGroup.alpha = 0;
			popupCanvasGroup.gameObject.SetActive(false);
		}

		void OnEnable()
		{
			GameManager_spinny.OnSuccessStart += CheckIfPromptRateDialogue;
			GameManager_spinny.OnFailStart += CheckIfPromptRateDialogue;
		}

		void OnDisable()
		{
			GameManager_spinny.OnSuccessStart -= CheckIfPromptRateDialogue;
			GameManager_spinny.OnFailStart -= CheckIfPromptRateDialogue;
		}

		void AddButtonListeners()
		{
			btnYes.onClick.AddListener(OnClickedYes);
			btnLater.onClick.AddListener(OnClickedLater);
			btnNever.onClick.AddListener(OnClickedNever);
		}

		void RemoveButtonListener()
		{
			btnYes.onClick.RemoveListener(OnClickedYes);
			btnLater.onClick.RemoveListener(OnClickedLater);
			btnNever.onClick.RemoveListener(OnClickedNever);
		}

		/// <summary>
		/// Method called if the player clicked on the YES button. If the player do that, we will never prompt again the popup
		/// </summary>
		void OnClickedYes()
		{
			#if UNITY_IPHONE
			Application.OpenURL(iOSURL);
			#endif

			#if UNITY_ANDROID
			Application.OpenURL(ANDROIDURL);
			#endif

			PlayerPrefs.SetInt("NUMOFLEVELPLAYED",-1);
			PlayerPrefs.Save();
			HidePopup();
		}

		/// <summary>
		/// Method called if the player clicked on the LATER button. If the player do that, we will ask again in "NumberOfLevelPlayedToShowRateUs"
		/// </summary>
		void OnClickedLater()
		{
			PlayerPrefs.SetInt("NUMOFLEVELPLAYED",0);
			PlayerPrefs.Save();
			HidePopup();
		}
		/// <summary>
		/// Method called if the player clicked on the NEVER button. If the player do that, we will never prompt again the popup
		/// </summary>
		void OnClickedNever()
		{
			PlayerPrefs.SetInt("NUMOFLEVELPLAYED",-1);
			PlayerPrefs.Save();
			HidePopup();
		}
		/// <summary>
		/// Check if we need to prompt the popup or not
		/// </summary>
		void CheckIfPromptRateDialogue()
		{
			int count = PlayerPrefs.GetInt("NUMOFLEVELPLAYED",0);

			if(count == -1)
				return;

			count ++;

			if(count > NumberOfLevelPlayedToShowRateUs)
			{
				PromptPopup();
			}
			else
			{
				PlayerPrefs.SetInt("NUMOFLEVELPLAYED",count);
			}

			PlayerPrefs.Save();
		}
		/// <summary>
		/// Method to prompt the popup
		/// </summary>
		public void PromptPopup()
		{
			FindObjectOfType<InputTouch>().BLOCK_INPUT = true;

			popupCanvasGroup.alpha = 0;
			popupCanvasGroup.gameObject.SetActive(true);

			StartCoroutine(DoLerpAlpha(popupCanvasGroup, 0, 1, 1, () => {
				AddButtonListeners();
			}));
		}
		/// <summary>
		/// Method to hide the popup
		/// </summary>
		void HidePopup()
		{
			StartCoroutine(DoLerpAlpha(popupCanvasGroup, 1, 0, 1, () => {
				popupCanvasGroup.gameObject.SetActive(false);
				RemoveButtonListener();
				FindObjectOfType<InputTouch>().BLOCK_INPUT = false;
			}));
		}

		public IEnumerator DoLerpAlpha(CanvasGroup c, float from, float to, float time, Action callback)
		{
			float timer = 0;

			c.alpha = from;

			while (timer <= time)
			{
				timer += Time.deltaTime;
				c.alpha = Mathf.Lerp(from, to, timer / time);
				yield return null;
			}

			c.alpha = to;

			if (callback != null)
				callback ();
		}
	}
}