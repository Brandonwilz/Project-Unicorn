using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpriteLayerOffset : MonoBehaviour
{
    public int offsetBy;

    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer[] sprites = GetComponentsInChildren<SpriteRenderer>();

        foreach (SpriteRenderer sprite in sprites)
        {
            sprite.sortingOrder += offsetBy;
        }
    }
}
