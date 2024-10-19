using ProjectUnicorn.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] PlayerInteractor playerInteractor;
    [SerializeField] Inventory inventory;

    // Start is called before the first frame update
    void Start() {
        Player.playerCurrent = player;
        if (player != null) {
            player.SetActive(true);
        }

        PlayerInteractor.playerInteractorCurrent = playerInteractor;

        Inventory.inventoryCurrent = inventory;
        if (inventory != null) {
            inventory.gameObject.SetActive(false);
        }
    }
}
