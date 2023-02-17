using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    RectTransform rect;
    void Awake() {
        rect = GetComponent<RectTransform>();
    }
    void Start()
    {
        
    }
    void FixedUpdate() {
        rect.position = Camera.main.WorldToScreenPoint(GameManager.instance.player.transform.position);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
