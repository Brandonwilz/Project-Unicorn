using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layers : MonoBehaviour {

    [SerializeField] private GameObject layerMask;
    [SerializeField] private GameObject layerMain;
    [SerializeField] private GameObject layerOther;
    [SerializeField] private GameObject layerShared;

    // Start is called before the first frame update
    void Start() {
        layerMask.SetActive(true);
        layerMain.SetActive(true);
        layerOther.SetActive(false);
        layerShared.SetActive(true);
    }

    // Update is called once per frame
    void Update() {
    }
}
