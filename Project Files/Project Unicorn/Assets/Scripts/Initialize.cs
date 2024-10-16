using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {

    [SerializeField] GameObject player;

    // Start is called before the first frame update
    void Start() {
        Player.objectPlayer = player;

        player.SetActive(true);
    }
}
