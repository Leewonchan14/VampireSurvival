using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public enum infoType {Exp,Level,Kill,Time, health}
    public infoType type;

    Text myText;
    Slider mySlider;

    void Awake(){
        myText = GetComponent<Text>();
        mySlider = GetComponent<Slider>();
    }
    void LateUpdate() {
        switch(type){
            case infoType.Exp:{
                float curExp = GameManager.instance.exp;
                float maxExp = GameManager.instance.nextExp[GameManager.instance.level];
                mySlider.value = curExp/maxExp;
                break;
            }
            case infoType.Level:{
                myText.text = string.Format("Lv.{0:F0}",GameManager.instance.level);
                break;
            }
            case infoType.Kill:{
                myText.text = string.Format("{0:F0}",GameManager.instance.kill);
                break;
            }
            case infoType.Time:{
                float remainTime = GameManager.instance.max_Game_Time - GameManager.instance.gameTime;
                int min = Mathf.FloorToInt(remainTime/60);
                int sec = Mathf.FloorToInt(remainTime%60);
                myText.text = string.Format("{0:D2}:{1:D2}",min,sec);
                break;
            }
            case infoType.health:{
                float curHealth = GameManager.instance.Health;
                float maxHealth = GameManager.instance.Max_Health;
                mySlider.value = curHealth/maxHealth;
                break;
            }
        }
    }
}
