using UnityEngine;
using System.Collections;

public class RotateLeftSimple : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(0, -10*Time.deltaTime, 0, Space.World);
	}
}
