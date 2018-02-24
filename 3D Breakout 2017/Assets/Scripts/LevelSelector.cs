using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour {


	public SceneFader sceneFader;
	public string menuSceneName = "Menu";

	public void Select(string levelName)
	{
		sceneFader.FadeTo (levelName);
	}

	public void BackToMenu(){
		//		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
		sceneFader.FadeTo(menuSceneName);
	}
}
