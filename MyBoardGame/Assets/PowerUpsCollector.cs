using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpsCollector : MonoBehaviour {
    
    public Status status;
    public AudioSource source;
    public AudioClip clip;

    private void Start() {
        status=GetComponent<Status>();
        source = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider other) {

        switch (other.gameObject.tag) {

            case "ExtraMove":
                status.tempMoves++;
                break;
            case "Health":
                status.health+=Random.Range(5, 15);
                break;
            case "ExtraDice":
                status.extraDice=true;
                break;
            case "ExtraAttack":
                status.extraAttack=true;
                break;
                source.clip=clip;
                source.Play();
        }


        if (other.gameObject.tag != "Space")
            Destroy(other.gameObject);
    }
}
