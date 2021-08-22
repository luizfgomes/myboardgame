using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TableSize : MonoBehaviour {

    [SerializeField] private GameManager gameManager;
    [SerializeField] private InputField width;
    [SerializeField] private InputField depht;
    [SerializeField] private TMP_Text feedback;

    private MenuController menuController;
    public void Start() {

        feedback.text = "";
        menuController=GetComponent<MenuController>();
    }
    public void SetGameManagerValues() {

        if (width.text==""&&depht.text=="") {
            
            StartCoroutine(FeedBackMsg(5f));
            return;
        }
           

        if (int.Parse(width.text) >= 8 && int.Parse(width.text) <= 30 &&
            int.Parse(depht.text) >= 8 && int.Parse(depht.text) < 30 ) {

            gameManager.TabelWidth = int.Parse(width.text);
            gameManager.TabelDepht = int.Parse(depht.text);
            menuController.MenuName("PlayerSelect");
        }
        else {

            StartCoroutine(FeedBackMsg(5f));
        }

    }

    IEnumerator FeedBackMsg(float timer) {
        feedback.text = "Width or depth out of range";
        yield return new WaitForSeconds(timer);
        feedback.text = "";
    }
}
