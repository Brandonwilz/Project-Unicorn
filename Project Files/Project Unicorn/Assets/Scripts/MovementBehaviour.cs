using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementBehaviour : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    const float MAX_VELOCITY = 5.0f;

    public enum Direction {
        right,
        left
    }

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        print(animator.GetInstanceID());
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            setSpriteDirection(Direction.right);
            animator.Play("Billy Walking");
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            setSpriteDirection(Direction.left);
            animator.Play("Billy Walking");
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            setVelocity(MAX_VELOCITY);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            setVelocity(-MAX_VELOCITY);
        }
        else {
            animator.Play("Billy idle");
            stop();
        }
    }

    void setVelocity(float velocity) {
        body.velocity = velocity * Vector2.right;
    }
    public void stop() {
        body.velocity = Vector2.zero;
    }

    public void setSpriteDirection(Direction direction) {
        Vector3 newScale = gameObject.transform.localScale;

        if (direction == Direction.right) {
            newScale.x = Mathf.Abs(newScale.x);
        }
        else if (direction == Direction.left) {
            newScale.x = -Mathf.Abs(newScale.x);
        }

        gameObject.transform.localScale = newScale;
    }
}
