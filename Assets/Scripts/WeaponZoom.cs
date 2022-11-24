using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
	[SerializeField] Camera playerCamera;
	[SerializeField] float zoomedInFOV = 30;
	[SerializeField] float zoomedInMouseSense = 0.5f;
	[SerializeField] float zoomedOutFOV = 60;
	[SerializeField] float zoomedOutMouseSense = 2;
	bool isZoomingIn = false;
	RigidbodyFirstPersonController fpsController;
	
	protected void Start()
	{
		fpsController = FindObjectOfType<RigidbodyFirstPersonController>();
	}
 
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
			fpsController.mouseLook.XSensitivity = zoomedInMouseSense;
			fpsController.mouseLook.YSensitivity = zoomedInMouseSense;
			playerCamera.fieldOfView = zoomedInFOV;
		}
		else if (isZoomingIn)
		{
			isZoomingIn = false;
			fpsController.mouseLook.XSensitivity = zoomedOutMouseSense;
			fpsController.mouseLook.YSensitivity = zoomedOutMouseSense;
			playerCamera.fieldOfView = zoomedOutFOV;
		}
	}
}
