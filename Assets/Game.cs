using UnityEngine;
using System.Collections;

public class Game : MonoBehaviour
{
	private Game mInstance = null;
	public Game Instance
	{
		get
		{
			if (null == mInstance)
			{
				mInstance = GameObject.FindObjectOfType<Game>();
			}

			if (null == mInstance)
			{
				var go = new GameObject();
				mInstance = go.AddComponent<Game>();
			}
			return mInstance;
		}
	}

	void Awake()
	{
		mInstance = this;
		GameObject.DontDestroyOnLoad(this);
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void EnterMenu()
	{
		Application.LoadLevel("Menu");
	}

	public void EnterGame()
	{
		Application.LoadLevel("Game");
	}
}
