using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerationTable : MonoBehaviour {

    [SerializeField] private GameObject space;
    [SerializeField] private GameObject board;
    private GameManager gameManager;
    float xPosition = 0;
    float zPosition = 0;
    private void Start() {

        gameManager=GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();


        for (int i = 1; i <= gameManager.TabelDepht; i++) {

            for(int a = 1; a <= gameManager.TabelWidth; a++) {

                GameObject instance = Instantiate(space);
                instance.name="Instance"+i+" / "+a;
                instance.transform.position = new Vector3(xPosition, 0, zPosition);
                instance.transform.SetParent(board.transform);
                xPosition+= 2.2f;
            }
            xPosition= 0;
            zPosition+=2.2f;
        }
    }
}
