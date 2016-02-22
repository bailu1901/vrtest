using UnityEngine;
using System.Collections;

public class VrUIButtonExt : MonoBehaviour {

	public float ScaleRate = 1.1f;
	public float DeltaTimeScale = 20.0f;
	public Transform BtnText;

	protected RectTransform mRect;

	protected Rect mBackRect;
	protected bool mFocused = false;

	void Awake()
	{
		mRect = gameObject.GetComponent<RectTransform>();
	}

	// Use this for initialization
	void Start () {
		mBackRect = mRect.rect;
	}
	
	// Update is called once per frame
	void Update () {
		if (mFocused) 
		{
			mRect.sizeDelta = Vector2.Lerp (mRect.sizeDelta,mBackRect.size*ScaleRate,Time.deltaTime*DeltaTimeScale);
		}
		else 
		{
			mRect.sizeDelta = Vector2.Lerp (mRect.sizeDelta,mBackRect.size,Time.deltaTime*DeltaTimeScale);
		}
	}

	public void OnFocusOn()
	{
		BtnText.gameObject.SetActive (true);
		mFocused = true;
	}

	public void OnFocusLeave()
	{
		BtnText.gameObject.SetActive (false);
		mFocused = false;
	}
}
