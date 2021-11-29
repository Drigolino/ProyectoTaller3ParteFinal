using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemy : MonoBehaviour
{
    public Boss2 Boss;
    public float lives;
    public Image VidaBoss;
    void Start()
    {
    }
    void Update()
    {
        //    lives = Mathf.Clamp(lives, 0, 1000);
        //   VidaBoss.fillAmount = lives / 100;
        VidaBoss.fillAmount = Mathf.Clamp(lives/800,0,1);
    }
    public void UpdateLivesBoss(float totalvidas)
    {
        lives = totalvidas;
    }
}
