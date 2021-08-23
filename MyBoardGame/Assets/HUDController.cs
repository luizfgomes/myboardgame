using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HUDController : MonoBehaviour {

    public GameObject[] players;
    public TMP_Text life;
    public TMP_Text moves;

    public TMP_Text dice1Player1, dice2Player1, dice3Player1, dice4Player1;
    public TMP_Text dice1Player2, dice2Player2, dice3Player2, dice4Player2;

    public TMP_Text textResul;

    public int[,,] dice1;
    public int[,,] dice2;

    public GameObject canvasResults;
    public GameObject enabledCanvasGameOver;
    public bool isEnabledCanvas;
    public bool isEnabledCanvasGameOver;
    private void Start() {

        StartCoroutine(FindPlayers());
        
    }

    private void FixedUpdate() {

        if(players.Length > 0) {

            life.text=players[TurnController.playerTurn].GetComponent<Status>().health.ToString();
            moves.text=players[TurnController.playerTurn].GetComponent<Status>().tempMoves.ToString();



            if (BattleLogic.result.Count > 0) {

                dice1=BattleLogic.result[0].player1dice;
                dice2=BattleLogic.result[0].player2dice;
                dice1Player1.text=dice1[0, 0, 0].ToString();
                dice2Player1.text=dice1[0, 0, 1].ToString();
                dice3Player1.text=dice1[0, 0, 2].ToString();
                dice4Player1.text=dice1[0, 0, 3].ToString();

                dice1Player2.text=dice2[0, 0, 0].ToString();
                dice2Player2.text=dice2[0, 0, 1].ToString();
                dice3Player2.text=dice2[0, 0, 2].ToString();
                dice4Player2.text=dice2[0, 0, 3].ToString();

                if (BattleLogic.result[0].champion==0)
                    textResul.text="Player 1 win, press button to deal damage";
                else
                    textResul.text="Player 2 win, press button to deal damage";
            }
        }
    }


    public void EnabledCanvas() {

        isEnabledCanvas= !isEnabledCanvas;
        canvasResults.SetActive(isEnabledCanvas);
    }

    public void EnabledGameOver() {

        isEnabledCanvasGameOver=!isEnabledCanvasGameOver;
        enabledCanvasGameOver.SetActive(isEnabledCanvasGameOver);
    }

    IEnumerator FindPlayers() {

        yield return new WaitForSeconds(1.5f);
        players=GameObject.FindGameObjectsWithTag("Player");
    }


}
