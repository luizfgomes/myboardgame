using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectModeController : MonoBehaviour {
    [SerializeField] private GameManager gameManager;

    public void SetGameMode(bool value) {
        gameManager.isPvp = value;
    }
}
