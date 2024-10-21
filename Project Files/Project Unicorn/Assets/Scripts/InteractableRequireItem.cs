using ProjectUnicorn.InteractionSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEditor.PackageManager;
using UnityEngine;

public class InteractableRequireItem : MonoBehaviour, Interactable {
    [SerializeField] GameObject requiringObject;
    [SerializeField] Item.ID requiredItem;

    // Start is called before the first frame update
    void Start() {
        if(requiringObject != null) {
            try {
                requiringObject.GetComponent<Collider2D>().enabled = false;
            }
            catch (NullReferenceException e) {
                Debug.LogError(e.Message);
            }
        }

    }

    // Update is called once per frame
    void Update() {
    }

    public void Interact() {
        Inventory.inventoryCurrent.setVisible(true);
    }
    public void Interact(Item.ID item) {
        if (item == requiredItem) {
            try {
                if (Inventory.inventoryCurrent.containsItem(requiredItem) || requiredItem == Item.ID.none) {
                    Inventory.inventoryCurrent.removeItem(requiredItem);
                    if (requiringObject != null) {
                        requiringObject.GetComponent<Collider2D>().enabled = true;
                    }
                    requiringObject.SendMessage("Interact");
                    gameObject.SetActive(false);
                    Inventory.inventoryCurrent.setVisible(false);
                }
            }
            catch (NullReferenceException e) {
                Debug.LogError(e.Message);
            }
        }
    }

    public void SetLabelActive(bool isActive) {
        LabelInteract thisLabel = Labels.getLabel(Labels.ID.locked);
        try{
            if (isActive) {
                thisLabel.setPosition(transform.position);
            }
            thisLabel.setActive(isActive);
        }
        catch(NullReferenceException e) {
            Debug.LogError(e);
        }
    }
}
