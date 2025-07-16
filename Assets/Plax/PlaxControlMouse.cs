using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaxControlMouse : MonoBehaviour {
    [SerializeField] private Transform m_PlaxTransform;
	[SerializeField] private Vector2 m_LimitHorizontal = new Vector2(-0.1f, 0.1f);
	[SerializeField] private Vector2 m_LimitVertical = new Vector2(-0.1f, 0.1f);
    
    private Vector3 m_CachedPosition;
    private Vector3 m_LastMousePosition;
    private float m_ScreenWidth;
    private float m_ScreenHeight;
    
    void Start() {
        m_ScreenWidth = Screen.width;
        m_ScreenHeight = Screen.height;
        m_LastMousePosition = Input.mousePosition;
        UpdatePosition();
    }
    
    void Update() {
        Vector3 currentMousePos = Input.mousePosition;
        if (currentMousePos != m_LastMousePosition) {
            m_LastMousePosition = currentMousePos;
            UpdatePosition();
        }
    }
    
    private void UpdatePosition() {
        m_CachedPosition.x = Mathf.Lerp(m_LimitHorizontal[0], m_LimitHorizontal[1], 
            Mathf.InverseLerp(0f, m_ScreenWidth, m_LastMousePosition.x));
        m_CachedPosition.y = Mathf.Lerp(m_LimitVertical[0], m_LimitVertical[1], 
            Mathf.InverseLerp(0f, m_ScreenHeight, m_LastMousePosition.y));
        m_CachedPosition.z = 0f;
        m_PlaxTransform.position = m_CachedPosition;
    }
}
