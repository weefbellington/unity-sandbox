using UnityEngine;
using System.Collections;

public class MouseYaw : MonoBehaviour
{
	
	public int speed = 1;
	
	int screenMidpointX;
		
	void Start() {
		screenMidpointX = Screen.width / 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		Vector3.RotateTowards(transform.forward, new Vector3(0, Mathf.Deg2Rad*179, 0), Time.deltaTime, 0f);
	}
}

