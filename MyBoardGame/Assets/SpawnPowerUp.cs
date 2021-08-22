using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPowerUp : MonoBehaviour {

    public GameObject[] spawnsGameObjects;
    public bool isCharSpawn;

    private void Start() {

        StartCoroutine(InstanceNewPowerUp());
    }

    IEnumerator InstanceNewPowerUp() {

        yield return new WaitForSeconds(0.2f);
        int randomSpawn = Random.Range(0, spawnsGameObjects.Length);

        var instance = Instantiate(spawnsGameObjects[randomSpawn]);

        instance.transform.SetParent(gameObject.transform);
        instance.transform.localPosition=new Vector3(0, 0, -7);
    }
}
