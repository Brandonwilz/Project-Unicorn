using ProjectUnicorn.InteractionSystem;
using ProjectUnicorn.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InteractableItemUse : MonoBehaviour, Interactable {
    void OnMouseOver() {
        if (Input.GetMouseButtonDown(0)) {
            Interact();
        }
    }

    public void Interact() {
        Item item;
        try {
            item = GetComponentInChildren<Item>();
            if (item != null) {
                PlayerInteractor.playerInteractorCurrent._currentInteractableObject.GetComponent<Interactable>().Interact(item.getID());
            }
        }
        catch(System.NullReferenceException e) {
            Debug.LogError(e.Message);
        }
    }

    public void Interact(Item.ID item) {
    }
}
