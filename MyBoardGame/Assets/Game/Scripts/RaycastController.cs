using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastController : MonoBehaviour {

    public Color color;
    public bool isAttackMove;
    public static bool isMove;
    Renderer render;

    private void Start() {
        isMove=false;
    }

    void Update() {

        SetSpacesColorFeedback(color);
    }
    public void SetSpacesColorFeedback(Color col) {

        RaycastHit pointColision;
        Vector3 forward = transform.TransformDirection(Vector3.forward)*10;
        Debug.DrawLine(transform.position, transform.position+(transform.forward*10), Color.red, 2);

        if (Physics.Raycast(transform.position, transform.forward, out pointColision, 20)) {

            render=pointColision.transform.gameObject.GetComponent<Renderer>();
            bool isPlayerPositionToAttack;

            if (pointColision.transform.gameObject.tag == "Space" ) {
                isPlayerPositionToAttack = pointColision.transform.gameObject.GetComponent<SpaceStatusController>().isPlayerInThisPosition;
            } else {
                isPlayerPositionToAttack=false;
                //isEnabledToMove=false;
            }
            
            if (pointColision.transform.gameObject.tag=="Space") {
                if (!isMove) {

                    render.material.color=Color.white;
                    pointColision.transform.gameObject.GetComponent<SpaceStatusController>().isEnabledToMove=false;
                } else if (isMove&&!isPlayerPositionToAttack) {

                    render.material.color=col;
                    pointColision.transform.gameObject.GetComponent<SpaceStatusController>().isEnabledToMove=true;
                } else {

                    render.material.color=Color.red;
                    pointColision.transform.gameObject.GetComponent<SpaceStatusController>().isEnabledToMove=false;
                }
            }


            if (isAttackMove && !isPlayerPositionToAttack && isMove) {

                render.material.color=Color.white;
                pointColision.transform.gameObject.GetComponent<SpaceStatusController>().isEnabledToMove=false;
            } else if (isAttackMove && isPlayerPositionToAttack && isMove) {

                render.material.color=Color.red;
                pointColision.transform.gameObject.GetComponent<SpaceStatusController>().isEnabledToMove=false;
            }
        }
    }
}
