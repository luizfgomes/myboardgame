using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableSize : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private InputField width;
    [SerializeField] private InputField deph;
    [SerializeField] private TMP_Text feedback;


    public void Start() {

        feedback.text = "";
    }
    public void SetGameManagerValues() {

        if (int.Parse(width.text) >= 8 && int.Parse(width.text) <= 30 &&
            int.Parse(deph.text) >= 8&&int.Parse(deph.text) < 30) {

            gameManager.TabelWidth = int.Parse(width.text);
            gameManager.TabelDepht = int.Parse(deph.text);
            MenuController.ExternalAccessCodeMenuName("SelectChar");
            LoadingNewScene.StartNewScene("");
        } else {
            
            StartCoroutine(FeedBackMsg(5f));
        }

    }

    IEnumerator FeedBackMsg(float timer) {
        feedback.text = "Width or depth out of range";
        yield return new WaitForSeconds(timer);
        feedback.text = "";
    }
}
