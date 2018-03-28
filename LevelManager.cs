using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    Scene currentScene;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene(); 
    }

    public void LoadLevel(string name)
    {
		Debug.Log ("New Level load: " + name);
        SceneManager.LoadScene(name);
	}

	public void QuitRequest()
    {
		Debug.Log ("Quit requested");
		Application.Quit ();
	}

    public void LoadNextLvl()
    {
        Block.breakableCount = 0;
        SceneManager.LoadScene(currentScene.buildIndex + 1);
    }

    public void DestroyedBricks()
    {
        if(Block.breakableCount <= 0)
        {
            LoadNextLvl();
        }
    }
}
