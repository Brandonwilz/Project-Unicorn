using ProjectUnicorn.InteractionSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactable {

    public enum ID {
        none,
        key0,
        key1,
    }

    [SerializeField] ID id;

    // Start is called before the first frame update
    void Start() { 
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void Interact() {
        if (Inventory.inventoryCurrent != null) {
            Inventory.inventoryCurrent.addItem(id, gameObject);
        }
    }

    public void Interact(Item.ID item) {
    }

    public ID getID() {
        return id;
    }

    public void SetLabelActive(bool isActive) {
        LabelInteract thisLabel = Labels.getLabel(Labels.ID.space);
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
