using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using static Layers;

public class LayerMainBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Layers.layerCurrent = this.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
