using UnityEngine;
using System.Collections;

public class GameSystem : MonoBehaviour 
{
	// Use this for initialization
	void Awake () 
    {
        DontDestroyOnLoad(gameObject); //doesn't destroy the game object when loads the next scene
	}

    /// <summary>
    /// Loads a level
    /// </summary>
    /// <param name="_level"></param>
    public void LoadLevel(int _level)
    {
        Application.LoadLevel(_level);
    }
}
