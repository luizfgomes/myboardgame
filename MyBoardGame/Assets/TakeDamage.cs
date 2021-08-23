using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour {

    public GameObject[] players;

    public void TakeADamagePlayer() {

        players=GameObject.FindGameObjectsWithTag("Player");

        if (BattleLogic.result[0].champion ==0) {

            players[1].GetComponent<Status>().health=players[1].GetComponent<Status>().health -  players[0].GetComponent<Status>().attack+BattleLogic.result[0].damage;
        } else {

            players[0].GetComponent<Status>().health=players[0].GetComponent<Status>().health-(players[1].GetComponent<Status>().attack+BattleLogic.result[0].damage* -1);
        }
    }
}
