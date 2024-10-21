using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    public static Inventory inventoryCurrent;

    List<Item.ID> items = new List<Item.ID>();

    private Vector3 positionVisible;
    private Vector3 positionHidden;

    private bool isVisible = false;
    private bool isTransitioning = false;

    [SerializeField] bool areDefaultSpritesHidden = true;
    [SerializeField] List<GameObject> spritesDisplay = new List<GameObject>();
    [SerializeField] GameObject itemsUsedObject;
    [SerializeField] Vector3 offsetHidden;
    [SerializeField] float timeTransition = 0.5f;

    // Start is called before the first frame update
    void Start() {
        if (areDefaultSpritesHidden) {
            for (int i = 0; i < spritesDisplay.Count; i++) {
                spritesDisplay[i].GetComponent<Renderer>().enabled = false;
            }
        }

        positionVisible = transform.position;
        positionHidden = positionVisible + offsetHidden;

        transform.position = positionHidden;
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
    }

    public bool getVisible() {
        return isVisible;
    }

    public void setVisible(bool isToBecomeVisible) {
        if (!isTransitioning) {
            isTransitioning = true;
            if (!(isVisible == isToBecomeVisible)) {
                gameObject.SetActive(true);
                StartCoroutine(moveAndSetVisibility(isToBecomeVisible));
            }
            else {
                isTransitioning = false;
            }
        }
    }

    private IEnumerator moveAndSetVisibility(bool isBecomingVisible) {
        Functions.Bool isComplete = new Functions.Bool();

        if (isBecomingVisible) {
            transform.position = positionHidden;
            StartCoroutine(Functions.MoveOverSeconds(gameObject, positionVisible, timeTransition, isComplete));
            yield return new WaitUntil(() => isComplete.value);
            isVisible = true;
            isTransitioning = false;
        }
        else {
            transform.position = positionVisible;
            StartCoroutine(Functions.MoveOverSeconds(gameObject, positionHidden, timeTransition, isComplete));
            yield return new WaitUntil(() => isComplete.value);
            isVisible = false;
            isTransitioning = false;
            gameObject.SetActive(false);
        }
    }

    public void addItem(Item.ID item, GameObject obj) {
        int i;

        items.Add(item);

        i = items.FindLastIndex((Item.ID arg) => arg == item);
        if (i < spritesDisplay.Count) {
            obj.transform.parent = spritesDisplay[i].transform;
            obj.transform.position = spritesDisplay[i].transform.position;
            obj.GetComponent<SpriteRenderer>().sortingOrder = GetComponent<SpriteRenderer>().sortingOrder + 2;
            obj.GetComponent<Collider2D>().enabled = false;
        }

    }

    public void removeItem(Item.ID item) {
        int i;
        GameObject child;

        if (item != Item.ID.none) {
            i = items.FindLastIndex((Item.ID arg) => arg == item);
            if (i >= 0 && i < spritesDisplay.Count) {
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

    public bool containsItem(Item.ID id) {
        return items.Contains(id);
    }
}
