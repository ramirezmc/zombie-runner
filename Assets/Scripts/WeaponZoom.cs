using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
	[SerializeField] Camera playerCamera;
	[SerializeField] Object cameraController;
	[SerializeField] float zoomedInFOV = 30;
	[SerializeField] float zoomedInMouseSense = 0.5f;
	[SerializeField] float zoomedOutFOV = 60;
	[SerializeField] float zoomedOutMouseSense = 2;
	bool isZoomingIn = false;
	
 
    void Update()
    {
	    if (Input.GetButtonDown("Fire2"))
	    {
	    	ZoomFOV();
	    }
    }
	void ZoomFOV()
	{
		if (!isZoomingIn)
		{
			isZoomingIn = true;
			playerCamera.fieldOfView = zoomedInFOV;
		}
		else if (isZoomingIn)
		{
			isZoomingIn = false;
			playerCamera.fieldOfView = zoomedOutFOV;
		}
	}
}
