using ProjectUnicorn.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {

    [SerializeField] GameObject player;
    [SerializeField] PlayerInteractor playerInteractor;
    [SerializeField] Inventory inventory;

    [SerializeField] LabelInteract labelSpace;
    [SerializeField] LabelInteract labelLocked;

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

        Labels.labelSpace = labelSpace;
        if (labelSpace != null) {
            labelSpace.gameObject.SetActive(false);
        }

        Labels.labelLocked = labelLocked;
        if (labelLocked != null) {
            labelLocked.gameObject.SetActive(false);
        }
    }
}
