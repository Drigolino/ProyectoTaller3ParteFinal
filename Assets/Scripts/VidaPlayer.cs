using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class VidaPlayer : MonoBehaviour
{
    public PlayerMovement Player;
    public float lives;
    public Image Vida;
    void Start()
    {
    }
    void Update()
    {
        lives = Mathf.Clamp(lives, 0, 100);
        Vida.fillAmount = lives / 100;
    }
    public void UpdateLives(float totalvidas)
    {
        lives = totalvidas;
    }
}
