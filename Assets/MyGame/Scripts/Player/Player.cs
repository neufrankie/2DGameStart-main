using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/Player")]
public class Player : MonoBehaviour,ICanTakeDamage
{
  
    public float maxHealth = 100;
    private float currentHealth =0;
    public GameObject hurEfect;
    [HideInInspector]
    public  bool isDead=false;


    private void Start()
    {
        currentHealth = maxHealth;
    }
    public void TakeDamage(int damage, Vector2 force, GameObject instigattor)
    {
        if(isDead) return;
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            isDead = true; 
            Destroy(gameObject, 3f);
            //gameObject.SetActive(false);
            //load Canh khac
            //Load UI
        }
        Debug.Log("Player bi chem");
    }
}
