using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Layers;

public class LayerOtherBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Layers.layerAlternate = this.gameObject;
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
