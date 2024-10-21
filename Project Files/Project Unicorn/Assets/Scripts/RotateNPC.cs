using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Movement;

public class RotateNPC : MonoBehaviour
{
    [SerializeField]
    private Transform player;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player != null)
        {
            if (player.transform.position.x < transform.position.x)
            {
                setSpriteDirection(Direction.right);
            }
            else
            {
                setSpriteDirection(Direction.left);
            }
        }
    }

    public void setSpriteDirection(Direction direction)
    {
        Vector3 newScale = gameObject.transform.localScale;

        if (direction == Direction.right)
        {
            newScale.x = Mathf.Abs(newScale.x);
        }
        else if (direction == Direction.left)
        {
            newScale.x = -Mathf.Abs(newScale.x);
        }

        gameObject.transform.localScale = newScale;
    }
}
