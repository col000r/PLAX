using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaxControlMouse : MonoBehaviour {
    [SerializeField] private Transform m_PlaxTransform;
	[SerializeField] private Vector2 m_LimitHorizontal = new Vector2(-0.1f, 0.1f);
	[SerializeField] private Vector2 m_LimitVertical = new Vector2(-0.1f, 0.1f);
    void Update() {
	    m_PlaxTransform.position = new Vector3(
		    Mathf.Lerp( m_LimitHorizontal[0], m_LimitHorizontal[1], Mathf.InverseLerp( 0f, Screen.width, Input.mousePosition.x ) ),
		    Mathf.Lerp(  m_LimitVertical[0], m_LimitVertical[1], Mathf.InverseLerp( 0f, Screen.height, Input.mousePosition.y ) ),
		    0f );
    }
}
