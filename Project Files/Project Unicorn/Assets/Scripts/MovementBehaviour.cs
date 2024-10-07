using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    Rigidbody2D body;
    const float MAX_VELOCITY = 9.0f;
    // Start is called before the first frame update
    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {

        if (Input.GetKey(KeyCode.RightArrow)) {
            setVelocity(MAX_VELOCITY);
        }
        else if (Input.GetKey(KeyCode.LeftArrow)) {
            setVelocity(-MAX_VELOCITY);
        }
        else {
            stop();
        }
    }

    void setVelocity(float velocity) {
        body.velocity = velocity * Vector2.right;
    }
    public void stop() {
        body.velocity = Vector2.zero;
    }
}
