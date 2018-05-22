using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cinematic2DController : EditorWindow {

	/// <summary>
	/// The Cinematic 2D Controller just controls the gizmos of the editor window
	/// </summary>

	static float scale = 0.0f;
	static float focalPoint = 0.0f;

	public Vector3 cameraPosn;
	public Vector3 backplatePosn;

	[MenuItem("Tools/Cinematic 2D/Cinematic 2D Editor")]
	static void Init()
	{
		EditorWindow window = GetWindow(typeof(Cinematic2DController));
		window.Show();
	}

	void OnGUI()
	{
		EditorGUILayout.LabelField ("Scale: ");
		scale = EditorGUILayout.Slider(scale, 1, 100);
		//get normalized focal point distance from camera to background plate
		//???
		EditorGUILayout.LabelField ("Focal Point: ");
		focalPoint = EditorGUILayout.Slider(focalPoint, 0, 1);

		EditorGUILayout.LabelField ("Cam Posn is: "+cameraPosn.z);
		EditorGUILayout.LabelField ("Backplate Posn is: "+backplatePosn.z);

		if (GUILayout.Button ("Update Camera and Backplate positions")) {
			//Debug.Log ("Clicked Button");
			RecheckPlateAndCamPosn ();
		}
	}

	void OnInspectorUpdate()
	{
		//if (Selection.activeTransform)
		Camera.main.transform.GetChild(0).gameObject.transform.GetChild(0).localScale = new Vector3(scale, scale, scale);

		// Move focal point (min camera position, max is backplate position)
		Camera.main.transform.GetChild(0).gameObject.transform.GetChild(0).localPosition = new Vector3(0.0f,0.0f, focalPoint *backplatePosn.z);
	}

	private void RecheckPlateAndCamPosn(){
		//Get Current Camera Position and current backplate position
		cameraPosn = new Vector3(Camera.main.transform.localPosition.x ,Camera.main.transform.localPosition.y, 0.0f) ; //min slider position in Z
		backplatePosn = Camera.main.transform.GetChild(0).gameObject.transform.GetChild(1).localPosition; 
		//reset focal point to match (will trigger inspectorupdate)
		Camera.main.transform.GetChild(0).gameObject.transform.GetChild(0).localPosition = new Vector3(0.0f,0.0f, cameraPosn.z);
	}

	private void UpdateCinematic2DFocalPoint(){
		//TODO send message to Cinematic2D tagged GO to update array?
		//

	}
}
