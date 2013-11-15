using UnityEngine;
using System.Collections;
using System.Linq;

public class TrackballRotation : MonoBehaviour {
	
	public float rotationSpeed = 5;
	
	int screenMidpointX;
	int screenMidpointY;
	
	Vector3? handle;
	
	void Start() {
		screenMidpointX = Screen.width / 2;
		screenMidpointY = Screen.height / 2;
		string msg = string.Format("Screen midpoint:({0},{1})", screenMidpointX, screenMidpointY);
		Debug.Log(msg, gameObject);
	}
	
	void OnGUI () {
		Rect position = new Rect(0,0, Screen.width, Screen.height);
		
		Texture2D transparentTexture = new Texture2D(1, 1);
		transparentTexture.SetPixel(0, 0, Color.clear);
		transparentTexture.wrapMode = TextureWrapMode.Repeat;
		
		GUI.Box(position, transparentTexture);
	}
	
    void Update() {
		
        if (!Input.GetMouseButton(0)) {
			handle = null;
            return;
		} else if (!handle.HasValue) {
			handle = transform.position + (transform.forward * 1);
		}
		
		Vector3 clickPosition = Input.mousePosition;
		//string msg = string.Format("Click position:({0},{1},{2})", clickPosition.x, clickPosition.y, clickPosition.z);
		//Debug.Log(msg, gameObject);		
		
		float magnitudeX = (clickPosition.y / screenMidpointY) - 1;
		float magnitudeY = (clickPosition.x / screenMidpointX) - 1;
		
		float angleX = Mathf.Clamp(90*magnitudeX,-90,90);
		float angleY = Mathf.Clamp(180*magnitudeY,-180,180);
		
		Vector3 lookPosition = RotateAroundPoint(handle.Value, transform.position, Quaternion.Euler(angleX, angleY, 0));
		//calculate the rotation needed
				
		Quaternion targetRotation = Quaternion.LookRotation(lookPosition - transform.position, transform.up);
		//use spherical interpollation over time
		Quaternion interpolatedRotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2);
		transform.rotation = interpolatedRotation;

    }
	
	Vector3 RotateAroundPoint(Vector3 point, Vector3 pivot, Quaternion angle) {
    	return angle * ( point - pivot) + pivot;
	}
}