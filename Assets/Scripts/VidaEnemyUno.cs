using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VidaEnemyUno : MonoBehaviour
{
    public Boss boss;
    public float lives;
    public Image VidaBoss;      
    // Update is called once per frame
    void Update()
    {
        VidaBoss.fillAmount = Mathf.Clamp(lives / 100, 0, 1);
    }
    public void UpdateLivesBossUno(float totalvidas)
    {
        lives = totalvidas;
    }
}
