using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingNewScene : MonoBehaviour {
    public static void StartNewScene(string SceneName) {

        SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
    }
}
