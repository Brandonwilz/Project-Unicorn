using ProjectUnicorn.InteractionSystem;
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
}
