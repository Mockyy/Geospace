using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float startingHealth = 1;
    private float currentHealth;

    public GameObject bar;
    private Image barSprite;

    PlayerMovement player;

    // Start is called before the first frame update
    void Awake()
    {
        currentHealth = startingHealth;
        barSprite = bar.transform.GetChild(2).GetComponent<Image>();
        barSprite.fillAmount = startingHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= 0.1f;
        barSprite.fillAmount = currentHealth;
        print(barSprite.fillAmount);
    }
}
