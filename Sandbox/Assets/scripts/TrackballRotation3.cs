using UnityEngine;
using System.Collections;

public class TrackballRotation3 : MonoBehaviour
{

	Vector3? initialRotation;
	int screenMidpointX;
	int screenMidpointY;
	float aspectRatio;
	
	// Use this for initialization
	void Start() {
		screenMidpointX = Screen.width / 2;
		screenMidpointY = Screen.height / 2;
		aspectRatio = (float)screenMidpointX / (float)screenMidpointY;
		Debug.Log(aspectRatio);
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!Input.GetMouseButton(0)) {
			initialRotation = null;
            return;
		} else if (!initialRotation.HasValue) {
			initialRotation = transform.eulerAngles;
		}
		
		Vector3 clickPosition = Input.mousePosition;
		
		float clamp = 180;
		
		float magnitudeX = (clickPosition.y / screenMidpointY) - 1;
		float magnitudeY = (clickPosition.x / screenMidpointX) - 1;
		
		float magnitudeTotal = Mathf.Abs(magnitudeX) + Mathf.Abs(magnitudeY);
		float deltaX = magnitudeX / magnitudeTotal;
		float deltaY = magnitudeY / magnitudeTotal;
		
		float angleX = Mathf.Clamp(clamp*-magnitudeX,-clamp,clamp);
		float angleY = Mathf.Clamp(clamp*magnitudeY,-clamp,clamp);
		
		Vector3 eulerRotation = initialRotation.Value + new Vector3(angleX, angleY, 0);

		transform.rotation = Quaternion.Euler(eulerRotation);	
	}
}

