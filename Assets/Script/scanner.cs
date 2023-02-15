using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scanner : MonoBehaviour
{
    public float scan_range;
    public LayerMask target_layer;
    public RaycastHit2D[] targets;
    public Transform nearestTarget;
    void FixedUpdate() {
        targets = Physics2D.CircleCastAll(transform.position,scan_range,Vector2.zero,0,target_layer);
        nearestTarget = Get_Nearest();
    }
    Transform Get_Nearest(){
        Transform result=null;

        float diff = 100;
        foreach (RaycastHit2D target in targets)
        {
            Vector3 myPos = transform.position;
            Vector3 targetPos = target.transform.position;
            float curDiff = Vector3.Distance(myPos,targetPos);
            if(curDiff<diff){
                diff = curDiff;
                result = target.transform;
            }
        }
        return result;
    }
    
}
