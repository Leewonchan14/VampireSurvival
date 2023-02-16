using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [Header("# Game Object")]
    public player player;
    public PoolManager poolManager;
    [Header("# Player info")]
    public int level;
    public int kill;
    public int exp;
    public int[] nextExp = {3,5,10,100,150,210,280,360,450,550};

    // Start is called before the first frame update
    
    void Awake() {
        instance = this;
    }
    void Update() {
        
    }
    public void GetExp(){
        exp++;
        if(exp==nextExp[level]){
            level++;
            exp = 0;
        }
    }
}
