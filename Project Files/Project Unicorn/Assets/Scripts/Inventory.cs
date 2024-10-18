using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory inventoryCurrent;

    List<Item.ID> items = new List<Item.ID>();

    [SerializeField] bool areDefaultSpritesHidden = true;
    [SerializeField] List<GameObject> spritesDisplay = new List<GameObject>();
    [SerializeField] GameObject itemsUsedObject;

    // Start is called before the first frame update
    void Start() {
        if (areDefaultSpritesHidden) {
            for (int i = 0; i < spritesDisplay.Count; i++) {
                spritesDisplay[i].GetComponent<Renderer>().enabled = false;
            }
        }
    }

    // Update is called once per frame
    void Update() {
    }

    public void addItem(Item.ID item, GameObject obj) {
        int i;

        items.Add(item);

        i = items.FindLastIndex((Item.ID arg) => arg == item);
        if (i < spritesDisplay.Count) {
            obj.transform.parent = spritesDisplay[i].transform;
            obj.transform.position = spritesDisplay[i].transform.position;
            obj.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 2;
        }

    }

    public void removeItem(Item.ID item) {
        int i;
        GameObject child;

        i = items.FindLastIndex((Item.ID arg) => arg == item);
        if(i >= 0 && i < spritesDisplay.Count) {
            child = spritesDisplay[i].GetComponentsInChildren<Transform>()[1].gameObject;
            child.SetActive(false);
            if (itemsUsedObject != null) {
                child.transform.parent = itemsUsedObject.transform;
            }
            else {
                child.transform.parent = null;
            }
        }
        items.Remove(item);
    }
}
