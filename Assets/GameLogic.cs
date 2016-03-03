using UnityEngine;
using System.Collections;

public class GameLogic : MonoBehaviour {
	public Transform Controller;

	public Transform Aircraft;

	public bool IsPlaying = true;

	public float Speed = 10;

	public float RayLength = 20;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if(!IsPlaying)
		{
			return;
		}

		Ray ray = new Ray(Controller.position, Controller.forward);
		RaycastHit hit;
		if (Physics.Raycast(ray,out hit,RayLength))
		{
			var p = hit.point;
			FlyTo(p);
		}
#if UNITY_EDITOR
		if (Input.GetKeyDown(KeyCode.W))
		{
		}
#endif


	}

	void FlyTo(Vector3 p)
	{
		var tp = Aircraft.InverseTransformPoint(p);

		var diff = tp - Aircraft.localPosition;
		var dir = new Vector3(diff.x, 0, diff.z);
		dir.Normalize();
		//Aircraft.forward = Vector3.Lerp(Aircraft.forward, dir, Time.deltaTime);
		var des = Aircraft.localPosition + dir * Speed * Time.deltaTime;
		Aircraft.localPosition = des;
	}

}
