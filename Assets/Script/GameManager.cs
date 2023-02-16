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
    public int level = 0;
    public int kill;
    public int exp;
    public int[] nextExp = {3,5,10,100,150,210,280,360,450,550};

    [Header("# Timeset")]
    public float gameTime = 0;
    public float max_Game_Time = 20;

    // Start is called before the first frame update
    
    void Awake() {
        instance = this;
    }
    void Update() {
        gameTime += Time.deltaTime;
        level = Mathf.Min(Mathf.FloorToInt(gameTime/max_Game_Time),poolManager.prefabs.Length-1);
    }
    public void GetExp(){
        exp++;
        if(exp==nextExp[level]){
            level++;
            exp = 0;
        }
    }
}
