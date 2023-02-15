using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reposition : MonoBehaviour
{
  Collider2D coll;
  void Awake() {
    coll = GetComponent<Collider2D>();
  }
  void OnTriggerExit2D(Collider2D other)
  {
    if (!other.CompareTag("Area")) return;

    Vector3 playerPos = GameManager.instance.player.transform.position;
    Vector3 myPos = transform.position;

    float diffX = playerPos.x - myPos.x;
    float diffY = playerPos.y - myPos.y;

    Vector3 reposition_Dir;
    if (Mathf.Abs(diffX) < Mathf.Abs(diffY))
      reposition_Dir = diffY < 0 ? Vector3.down : Vector3.up;
    else reposition_Dir = diffX < 0 ? Vector3.left : Vector3.right;

    switch (transform.tag)
    {
      case "Ground":
        transform.position = myPos + reposition_Dir * 40;
        break;
      case "Enemy":
        if(coll.enabled){
          transform.position = myPos + reposition_Dir * 25 + new Vector3(Random.Range(-3f,3f),Random.Range(-3f,3f));
        }
        break;
    }
  }
}
