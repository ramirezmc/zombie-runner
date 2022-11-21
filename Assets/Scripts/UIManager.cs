using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField]Canvas PlayerHUD;
	[SerializeField]Canvas GameOverScreen;
	PlayerHealth playerHealth;
	
	protected void Start()
	{
		playerHealth = FindObjectOfType<PlayerHealth>();
	}
	
	protected void Update()
	{
		ManageScenes();
	}
	
	void ManageScenes()
	{
		int currentPlayerHealth = playerHealth.ReturnCurrentHealth();
		if (currentPlayerHealth < 1)
		{
			Cursor.lockState = CursorLockMode.None;
			Cursor.visible = true;
			Time.timeScale = 0;
			PlayerHUD.gameObject.SetActive(false);
			GameOverScreen.gameObject.SetActive(true);
		}
		else
		{
			Time.timeScale = 1;
			PlayerHUD.gameObject.SetActive(true);
			GameOverScreen.gameObject.SetActive(false);
		}
	}
}
