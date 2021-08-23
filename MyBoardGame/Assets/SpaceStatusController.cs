using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceStatusController : MonoBehaviour
{
    public bool isPlayerInThisPosition;
    public bool isEnabledToMove;

    public string namePlayer;
    void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {

            isPlayerInThisPosition=true;

            namePlayer=other.gameObject.name;
        }
    }

    void OnTriggerExit(Collider other) {

        if (other.gameObject.tag=="Player") {

            isPlayerInThisPosition=false;
        }
    }
}
