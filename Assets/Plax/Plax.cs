using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plax : MonoBehaviour {
    [SerializeField] private Transform m_Control;
    [SerializeField] private List<PlaxElement> m_PlaxElements = new List<PlaxElement>();

    private void Start() {
        foreach (var plaxElement in m_PlaxElements) {
            plaxElement.Offset = plaxElement.Trans.localPosition;
        }
    }

    void Update() {
        Vector3 ctrlPos = m_Control.localPosition;
        foreach (var plaxElement in m_PlaxElements) {
            float val = plaxElement.GetVal(ctrlPos.x);
            plaxElement.Trans.localPosition = new Vector3(ctrlPos.x * val, ctrlPos.y * val,
                                                  plaxElement.Trans.localPosition.z) + plaxElement.Offset;
        }
    }
}

[Serializable]
public class PlaxElement {
    public Transform Trans;
    public float Val;
    public bool UseCurve;
    public AnimationCurve XValCurve;
    public Vector3 Offset;

    public float GetVal(float x) {
        if (UseCurve) {
            return XValCurve.Evaluate(x);
        }

        return Val;
    }
    
    //TODO: move behind mid point when reaching a certain spot
    //TODO: switch sprites when reaching certain values?
}
