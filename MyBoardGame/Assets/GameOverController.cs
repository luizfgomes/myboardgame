using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour {

    public void LoadNewScene(string a) {

        SceneManager.LoadScene(a, LoadSceneMode.Single);
    }
}
