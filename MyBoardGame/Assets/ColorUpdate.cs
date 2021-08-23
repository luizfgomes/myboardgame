using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorUpdate : MonoBehaviour
{
    public Material render;
    private void Start() {
        StartCoroutine(SwitchColor());
        render=GetComponent<Renderer>().material;
    }

    IEnumerator SwitchColor() {

        yield return new WaitForSeconds(0.5f);

        render.color = Color.white;
    }
}
