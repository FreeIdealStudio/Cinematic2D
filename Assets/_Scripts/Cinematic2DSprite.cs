using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cinematic2DSprite : MonoBehaviour {

	/// <summary>
	/// The Cinematic2d Sprite just checks with the Cinematic 2D Script to see if it needs to alter itself
	/// </summary>

	public Texture2D objectSprite; 

	//Cinematic2D flags
	public bool dofEnabled = false;

	// Use this for initialization
	void Start () {
		objectSprite = GetComponent<SpriteRenderer> ().sprite.texture;


	}
	
	//DoF
    public void SetDoF(float value)
    {
        //Set mimap blur if positive
        if (objectSprite.mipmapCount >= 1)
        {
            objectSprite.mipMapBias = value;
        }

    }
}
