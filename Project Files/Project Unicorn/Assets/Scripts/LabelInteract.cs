using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelInteract : MonoBehaviour {

    [SerializeField] float timeAnimate = 0.5f;
    [SerializeField] float distanceAnimate = 0.5f;
    [SerializeField] Vector3 offset = Vector3.zero;

    private bool isDown = true;
    private bool isWaiting = false;
    private SpriteRenderer spriteRenderer;
    private Vector3 positionStart;
    private Vector3 positionDown;

    private void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        positionStart = transform.position;
        positionDown = positionStart;
        positionDown.y -= distanceAnimate;
    }

    void Update() {
        if (!isWaiting) {
            if (!isDown) {
                StartCoroutine(setToPosition(positionDown));
                isDown = true;
            }
            else {
                StartCoroutine(setToPosition(positionStart));
                isDown = false;
            }
        }

    }

    public void setPosition(Vector3 position) {
        transform.position = position + offset;
        positionStart = transform.position;
        positionDown = transform.position;
        positionDown.y -= distanceAnimate;
    }

    public void setOffset(Vector3 position) {
        offset = position;
    }

    public void setActive(bool isActive) {
        if(isActive == false) {
            isDown = true;
            isWaiting = false;
            transform.position = positionStart;
        }
        gameObject.SetActive(isActive);
    }

    private IEnumerator setToPosition(Vector3 position) {
        isWaiting = true;
        transform.position = position;
        yield return new WaitForSeconds(timeAnimate);
        isWaiting = false;
    }
}
