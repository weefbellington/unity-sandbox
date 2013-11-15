using UnityEngine;
using System.Collections;

public class RotateLeftComplex : MonoBehaviour
{
	
	Vector3 initialRotation;
	
	void Start() {
		initialRotation = transform.forward;
	}
	// Update is called once per frame
	void Update () {
		Vector3.RotateTowards(transform.forward, new Vector3(0, Mathf.Deg2Rad*179, 0), Time.deltaTime, 0f);
	}
}

