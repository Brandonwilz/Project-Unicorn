using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

using static Layers;

public class LayersBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() {
        StartCoroutine(AutoSwitchLayers());
    }

    // Update is called once per frame
    void Update() {
    }

    static IEnumerator AutoSwitchLayers() {
        while (true) {
            yield return new WaitForSeconds(2);
            Layers.switchLayers();
        }
    }
}
