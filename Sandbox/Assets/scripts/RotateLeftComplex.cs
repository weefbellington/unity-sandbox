using UnityEngine;
using System.Collections;

public class RotateLeftComplex : MonoBehaviour
{
	
	Vector3 target;
	
	void Start() {
		target = transform.position + transform.forward * 1;
		target = RotateAroundPoint(target, transform.position, Quaternion.Euler(0,180,0));
	}
	
	// Update is called once per frame
	void Update () {
		//calculate the rotation needed
		Quaternion targetRotation = Quaternion.LookRotation(target - transform.position);
		//use spherical interpollation over time
		Quaternion interpolatedRotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
		transform.rotation = interpolatedRotation;
	}
	
	Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle) {
    	return angle * ( point - pivot) + pivot;
	}
}



