using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnChar : MonoBehaviour {
    public GameManager gameManager;
    public PlayerStats[] playerStatus;
    public FindSpacesOfBoard spacesOfBoard;
    public MousePositionForMovePlayer mouseForMove;

    void Start() {
        StartCoroutine(StartNewGame());

    }

    IEnumerator StartNewGame() {

        gameManager=GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();

        yield return new WaitForSeconds(1.0f);
        //spacesOfBoard.spaces[Random.Range(0, spacesOfBoard.spaces.Length/2)].transform.localPosition
        foreach (PlayerStats i in playerStatus) {
            if (i.name == gameManager.Player1) {

                var instantiate = Instantiate(i.charGO);
                int random = Random.Range(0, spacesOfBoard.spaces.Length / 4);
                instantiate.GetComponent<Status>().name=i.name;
                instantiate.GetComponent<Status>().moves=i.moves;
                instantiate.GetComponent<Status>().attack=i.attack;
                instantiate.GetComponent<Status>().health=i.health;
                instantiate.transform.localPosition = new Vector3(spacesOfBoard.FindSpacesPosition(random).x, 1.4f, spacesOfBoard.FindSpacesPosition(random).z);
            }

            if (i.name==gameManager.Player2) {
                var instantiate = Instantiate(i.charGO);
                instantiate.gameObject.GetComponentInChildren<Camera>().enabled=false;
                instantiate.GetComponent<Status>().name=i.name;
                instantiate.GetComponent<Status>().moves=i.moves;
                instantiate.GetComponent<Status>().attack=i.attack;
                instantiate.GetComponent<Status>().health=i.health;
                int random = Random.Range(spacesOfBoard.spaces.Length/2, spacesOfBoard.spaces.Length);

                instantiate.transform.localPosition=new Vector3(spacesOfBoard.FindSpacesPosition(random).x, 1.4f, spacesOfBoard.FindSpacesPosition(random).z);
            }
        }
    }
}
