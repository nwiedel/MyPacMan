using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Steuerung der Button aus dem Hauptmenu
/// </summary>
public class MainMenu : MonoBehaviour
{
    /// <summary>
    /// Startet ein neues Spiel in einem neuen Level
    /// </summary>
    public void ChangeLevel(string sceneName)
    {
        Debug.Log("Level wird geladen!");
        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// Beendet das Spiel
    /// </summary>
    public void QuitGame()
    {
        Debug.Log("Spiel wird beendet!");
        Application.Quit();
    }
}
