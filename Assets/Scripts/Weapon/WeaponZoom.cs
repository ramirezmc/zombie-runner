using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
public class WeaponZoom : MonoBehaviour
{
	[SerializeField] Camera playerCamera;
	[SerializeField] bool canZoom = false;
	
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
 
	protected void OnDisable()
	{
		ZoomOut();
	}
	
    void Update()
    {
	    if (Input.GetMouseButtonDown(1))
	    {
	    	ZoomFOV();
	    }
    }
	void ZoomFOV()
	{
		if (canZoom)
		{
			if (!isZoomingIn)
			{
				ZoomIn();
			}
			else if (isZoomingIn)
			{
				ZoomOut();
			}
		}
	}
	
	void ZoomIn()
	{
		isZoomingIn = true;
		fpsController.mouseLook.XSensitivity = zoomedInMouseSense;
		fpsController.mouseLook.YSensitivity = zoomedInMouseSense;
		playerCamera.fieldOfView = zoomedInFOV;
	}
	public void ZoomOut()
	{
		isZoomingIn = false;
		fpsController.mouseLook.XSensitivity = zoomedOutMouseSense;
		fpsController.mouseLook.YSensitivity = zoomedOutMouseSense;
		playerCamera.fieldOfView = zoomedOutFOV;
	}
}
