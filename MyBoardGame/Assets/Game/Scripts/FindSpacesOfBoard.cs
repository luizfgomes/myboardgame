using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindSpacesOfBoard : MonoBehaviour {

    public GameObject[] spaces;

    private void Start() {
        StartCoroutine(DelayToFindGameObjects());
        
    }

    IEnumerator DelayToFindGameObjects() {
        yield return new WaitForSeconds(0.1f);
        spaces=GameObject.FindGameObjectsWithTag("Space");
    }

    public Vector3 FindSpacesPosition(int value) {
        return spaces[value].transform.position;
    }
}
