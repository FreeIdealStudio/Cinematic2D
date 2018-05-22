using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Cinematic2D : MonoBehaviour {

	/// <summary>
	/// The Cinematic2D Script just holds the data to test against (pulled from the controller)
	/// </summary>

    public Camera mainCamera;
    public float distanceFromCamera;
    public float updateTimer;

	//Camera control objects
	public GameObject furthestBackgroundObject;
	public GameObject cameraFocalPoint;

    //DoF
	public bool _____________________;
	public float dofStrength; //fstop? 
	private float distanceToFurthestObject;
    public float[] nearMidFarDistance;



	// Use this for initialization
	void Start () {
		//get camera if empty
		if (!mainCamera) {
			//check parent first
			if (GetComponentInParent<Camera> () != null) {
				mainCamera = GetComponentInParent<Camera> ();
			} else if (Camera.main != null) {
				//if not attached to a camera then check for main default camera (tagged MainCamera)
				mainCamera = Camera.main;
			} else {
				//No camera (tagged MainCamera) found in scene
				Debug.LogError("No Camera found in scene for Cinematic2D. \nPlease either add one to the Cinematic2D gameobject, make sure the prefab is attached to camera, or tag a camer 'MainCamera'");
			}

			//Set tag of this object
			//TODO add this tag in editor if not already there
			this.gameObject.tag = "Cinematic2D";

		}






		distanceFromCamera = Vector3.Distance(mainCamera.transform.position, transform.position);
		//Debug.Log("Distance to camera: " + distanceFromCamera);

		distanceToFurthestObject = Vector3.Distance(mainCamera.transform.position, furthestBackgroundObject.transform.position);

        if (nearMidFarDistance.Length <= 0)
        {
            nearMidFarDistance = new float[3];
            //Debug.Log(nearMidFarDistance.Length + " is Length");
			nearMidFarDistance[0] = 0.0f;
			nearMidFarDistance[1] = cameraFocalPoint.transform.localPosition.z;
			nearMidFarDistance[2] = distanceToFurthestObject;
            

		}

    }
	
	// Update is called once per frame
	void Update () {
       // Debug.Log("Playing");
	}
}
