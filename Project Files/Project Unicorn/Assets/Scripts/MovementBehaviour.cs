using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovementBehaviour : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator animator;

    [SerializeField] public float speedMove = 6.0f;
    [SerializeField] public float speedAnimation = 2.0f;
    [SerializeField] public float intervalFootsteps = 0.5f;

    private bool isFootstepActive = false;

    public enum Direction {
        right,
        left
    }

    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>(true);
        animator.speed = speedAnimation;
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.RightArrow)) {
            Progress.setFlag(Progress.State.playerMovingActive, true);

            if (!isFootstepActive) {
                isFootstepActive = true;
                StartCoroutine(playFootsteps());
            }

            setVelocity(speedMove);
            setSpriteDirection(Direction.right);
            animator.Play("Billy Walking");
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            Progress.setFlag(Progress.State.playerMovingActive, true);

            if (!isFootstepActive) {
                isFootstepActive = true;
                StartCoroutine(playFootsteps());
            }

            setVelocity(-speedMove);
            setSpriteDirection(Direction.left);
            animator.Play("Billy Walking");
        }
        else {
            stop();
            animator.Play("Billy idle");

            Progress.setFlag(Progress.State.playerMovingActive, false);
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

    IEnumerator playFootsteps() {
        SendMessage("playSoundStep");
        yield return new WaitForSeconds(intervalFootsteps);
        isFootstepActive = false;
    }
}
