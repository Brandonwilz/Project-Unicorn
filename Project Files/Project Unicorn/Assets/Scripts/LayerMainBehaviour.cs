using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

using static Layers;
using static Progress;

public class LayerMainBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Layers.layerCurrent = this.gameObject;
        Progress.setFlag(State.layerMainActive, true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
