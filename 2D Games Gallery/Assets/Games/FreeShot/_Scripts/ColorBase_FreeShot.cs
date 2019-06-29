using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/// <summary>
/// Base class for ColorBrightLogic and ColorDarkLogic
/// </summary>
public class ColorBase_FreeShot : MonoBehaviour 
{
	public SpriteRenderer sr;
	public Camera cam;
	public Image im;
	public Text txt;

	public float timeAnim = 0.3f;

	void Awake()
	{
		sr = GetComponent<SpriteRenderer>();
		cam = GetComponent<Camera>();
		im = GetComponent<Image>();
		txt = GetComponent<Text>();
	}

	void OnEnable()
	{
		GameManager_FreeShot.OnColorChanged += OnColorChanged;
	}

	void OnDisable()
	{
		GameManager_FreeShot.OnColorChanged -= OnColorChanged;
	}

	public virtual void OnColorChanged (AAColor_FreeShot c)
	{

	}

	public virtual void SetColor(Color c)
	{
		if(cam != null)
			cam.backgroundColor = c;

		if(sr != null)
			sr.color = c;

		if(im != null)
			im.color = c;

		if(txt != null)
			txt.color = c;
	}
}
