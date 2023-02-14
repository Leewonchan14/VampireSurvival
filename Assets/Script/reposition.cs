using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reposition : MonoBehaviour
{
  void OnTriggerExit2D(Collider2D other)
  {
    if (!other.CompareTag("Area")) return;
    Debug.Log("exit!");

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
        Debug.Log("이동함");
        transform.position = myPos + reposition_Dir * 40;
        break;
      case "Enemy":

        break;
    }
  }
}
