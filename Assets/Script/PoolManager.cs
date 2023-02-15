using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    //프리팹을 넣을 배열
    public GameObject[] prefabs;
    //오브젝트풀링에 사용할 리스트
    List<GameObject>[] pools; 
    void Awake() {
        pools = new List<GameObject>[prefabs.Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            pools[i] = new List<GameObject>();
        }
    }
    public GameObject Get(int index){
        GameObject select = null;

        //선택한 풀의 놀고 있는 ( 비활성화 된 ) 있는 게임오브젝터 접근
        foreach(GameObject item in pools[index]){
            // 발견하면 select변수에 할당
            if(!item.activeSelf){
                select = item;
                select.SetActive(true);
                break;
            }
        }

        // 못찾았으면 
        if(!select){
        // 새롭게 생성하고 select 변수에 할당
            select = Instantiate(prefabs[index], transform);
            pools[index].Add(select);
        }

        return select;
    }
}
