using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerStatus : MonoBehaviour {

    public GameObject checks;

    private void Start() {

        SwtichChecksValues(false);
    }


    public void SwtichChecksValues(bool isCheck) {

        checks.SetActive(isCheck);
        Debug.Log(isCheck);
    }
}
