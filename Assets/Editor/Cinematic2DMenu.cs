using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


public class Cinematic2DMenu:MonoBehaviour {

	//////
	/// The Cinematic2D Menu Just creates and links the prefabs in the scene

	[MenuItem ("Tools/Cinematic 2D/Add Cinematic 2D to Main Camera")]

	private static void AddCinematic2DToMainCamera ()

	{


		//check main camera exists
		if (Camera.main != null) {
			//add prefab to camera
			//Debug.Log("Camera found. Now looking for prefab in "+Application.dataPath +"/Cinematic2D/Prefabs/");
			//check prefab exists at filepath???
			//
			GameObject objPrefab = Resources.Load ("Cinematic2D") as GameObject;
			//Check prefab isnt already on camera???

			//Instantiate prefab into scene and keep link to prefab
			//EditorUtility.InstantiatePrefab (objPrefab);

			//Intantiate into scene as clone but rename
			var cine2D = Instantiate (objPrefab, Camera.main.transform);
			cine2D.name = "Cinematic2D";

		} else {
			//no camera, so create one at a request?

			if (EditorUtility.DisplayDialog("No Main Camera found.", "Do you want to create a main camera with Cinematic2D setup?", "Create Camera", "Do Not Create Camera")){
				//???
				//Create a camera, tag it MainCamera, setup Cinematic2D
			}
		}

	}




	[MenuItem ("Tools/Cinematic 2D/Add Cinematic 2D to Sprite")]

	private static void AddCinematic2DToSprite ()

	{
		
	}



	[AddComponentMenu ("Cinematic2D/Cinematic2DSprite")]
	public class Cinematic2DSprite : MonoBehaviour
	{
	}

	[AddComponentMenu("Transform/Follow Transform")]
	public class FollowTransform : MonoBehaviour
	{
	}
}
