using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MousePositionForMovePlayer : MonoBehaviour
{
    [SerializeField] private Camera camera;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private LayerMask layerPlayer;

    public bool isSwitchCheckValues = false;

    public GameObject[] players;

    void Start() {
        StartCoroutine(FindPlayers());    
    }

    IEnumerator FindPlayers() {

        yield return new WaitForSeconds(1.5f);
        players=GameObject.FindGameObjectsWithTag("Player");
        camera=GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
    }

    private void FixedUpdate() {

        if (camera!=null)
            camera=players[TurnController.playerTurn].GetComponentInChildren<Camera>();
        
        
    }

    private void Update() {


        Debug.Log(TurnController.playerTurn);
        Debug.Log(players.Length);
        Debug.Log(TurnController.playerTurn<players.Length);
        Ray ray = camera.ScreenPointToRay(Input.mousePosition);


        if (Physics.Raycast(ray, out RaycastHit raycastHitPlayer, layerPlayer)) {

            if (raycastHitPlayer.collider.gameObject.tag == "Player" && Input.GetMouseButtonDown(0)) {

                isSwitchCheckValues=!isSwitchCheckValues;

                RaycastController.isMove=isSwitchCheckValues;
            }

        } 
        if (Physics.Raycast(ray, out RaycastHit raycastHit, layerMask)) {

            transform.position=raycastHit.point;
            if (raycastHit.collider.gameObject.tag=="Space") {

                if (raycastHit.collider.GetComponent<SpaceStatusController>().isEnabledToMove) {

                    if (Input.GetMouseButtonDown(0)) {

                        RaycastController.isMove=false;

                        for (int i = 0; i<players.Length; i++) {

                            if (TurnController.playerTurn==i) {

                                players[i].transform.DOMove(new Vector3(raycastHit.collider.transform.position.x, 1.4f, raycastHit.collider.transform.position.z), 1);
                                players[i].GetComponent<Status>().tempMoves--;
                            } 
                        }
                    }
                }
            }
        }

        for (int i = 0; i<players.Length; i++) {

            if (TurnController.playerTurn==i) {

                players[i].GetComponentInChildren<Camera>().enabled=true;
                if (players[i].GetComponent<Status>().tempMoves==0)
                    StartCoroutine(SetNewTurn(i));

            } else {

                players[i].GetComponentInChildren<Camera>().enabled=false;
            }
        }
    }

    IEnumerator SetNewTurn(int value) {
        players[value].GetComponent<Status>().ResetMovesValue();

        yield return new WaitForSeconds(1.2f);

        if (TurnController.playerTurn<(players.Length-1)) {
            TurnController.playerTurn++;

        } else {
            TurnController.playerTurn=0;

        }
    }
}
