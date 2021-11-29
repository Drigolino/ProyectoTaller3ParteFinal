using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyTres : MonoBehaviour
{
    public Boss3 boss;
    public float lives;
    public Image VidaBoss;
    // Update is called once per frame
    void Update()
    {
        VidaBoss.fillAmount = Mathf.Clamp(lives / 100, 0, 1);
    }
    public void UpdateLivesBossTres(float totalvidas)
    {
        lives = totalvidas;
    }
}
