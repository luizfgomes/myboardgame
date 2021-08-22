using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerSelectMenuController : MonoBehaviour {

    [SerializeField] private PlayerStats[] playerStats;

    [SerializeField] private TMP_Text characterRaceText;
    [SerializeField] private Image characterImgSprite;
    [SerializeField] private TMP_Text characterMoves;
    [SerializeField] private TMP_Text characterAttackPower;
    [SerializeField] private TMP_Text characterHealth;

    [SerializeField] private GameManager gameManager;
    private int valueCharIndex = 0;
    private bool isPlayer1Select;
    private void Start() {

        UpdateChar();
        isPlayer1Select=true;
    }

    void UpdateChar() {

        characterRaceText.text = playerStats[valueCharIndex].name.ToUpper();
        characterImgSprite.sprite=playerStats[valueCharIndex].sprite;
        characterMoves.text = playerStats[valueCharIndex].moves.ToString();
        characterAttackPower.text = playerStats[valueCharIndex].attack.ToString();
        characterHealth.text = playerStats[valueCharIndex].health.ToString();
    }

    void ResetValues() {
        valueCharIndex=0;
        UpdateChar();
    }

    public void Previous() {

        if (valueCharIndex<=0)
            return;

        valueCharIndex--;
        UpdateChar();
    }

    public void Next() {

        if (valueCharIndex==playerStats.Length-1)
            return;

        valueCharIndex++;
        UpdateChar();
    }

    public void SelectPlayer() {

        if (gameManager.isPvp && !isPlayer1Select) {

            gameManager.Player2=playerStats[valueCharIndex].name;
            LoadingNewScene.StartNewScene("Game");
        } else if (gameManager.isPvp) {

            gameManager.Player1=playerStats[valueCharIndex].name;
            isPlayer1Select = false;
            ResetValues();
        } else {

            gameManager.Player1=playerStats[valueCharIndex].name;
            LoadingNewScene.StartNewScene("Game");
        }
    }
}
