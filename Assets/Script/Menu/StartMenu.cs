using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
        SceneManager.sceneLoaded += GameManager.instance.LoadPlayerScene1;
        GameManager.instance.equippedWeapon = null;
        GameManager.instance.equippedWeaponState = null;
        GameManager.instance.pesos = 0;
        GameManager.instance.experience = 0;
        GameManager.instance.tempWeaponLevel = 0;
    }
}
