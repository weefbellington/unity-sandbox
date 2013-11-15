using UnityEngine;
using System.Collections;

public class MainWindowGUI : MonoBehaviour {

	void OnGUI () {
		Rect position = new Rect(0,0, Screen.width, Screen.height);
		
		Texture2D transparentTexture = new Texture2D(1, 1);
		transparentTexture.SetPixel(0, 0, Color.clear);
		transparentTexture.wrapMode = TextureWrapMode.Repeat;
		
		GUI.Box(position, transparentTexture);
	}
}
