using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
	[SerializeField]GameObject M1911Pistol;
	[SerializeField]GameObject M4AR;
	[SerializeField]GameObject BennelliShotgun;
	
	protected void Start()
	{
		M1911Pistol.gameObject.SetActive(false);
		M4AR.gameObject.SetActive(true);
		BennelliShotgun.gameObject.SetActive(false);
	}
    void Update()
    {
	    ManageCurrentGun();
    }
    
	void ManageCurrentGun()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			M1911Pistol.gameObject.SetActive(true);
			M4AR.gameObject.SetActive(false);
			BennelliShotgun.gameObject.SetActive(false);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			M1911Pistol.gameObject.SetActive(false);
			M4AR.gameObject.SetActive(true);
			BennelliShotgun.gameObject.SetActive(false);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			M1911Pistol.gameObject.SetActive(false);
			M4AR.gameObject.SetActive(false);
			BennelliShotgun.gameObject.SetActive(true);
		}
	}
}
