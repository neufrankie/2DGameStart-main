using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour,ICanTakeDamage
{
    #region Public Variable
    [Header("FX")]
    public GameObject hurEfect;
    [HideInInspector]
    public bool isDead = false;
    [Header("MaxHealth")]
    public float MaxHealth = 100f;
    public float nextTime = 0;
    public float rateTime = 0.5f;
    public int damageToGive = 20;
    public Vector2 force;
    #endregion
    #region Private Variable
    private float curruntHealth;
    private int isDeadId;
    private int isAttackID;
    private Animator anim;
    private Player player;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        curruntHealth = MaxHealth;
        isDeadId = Animator.StringToHash("IsDead");
        isAttackID = Animator.StringToHash("isAttack");
        anim = GetComponentInChildren<Animator>();
        player = GameObject.FindObjectOfType<Player>();
    }
    public void TakeDamage(int damage, Vector2 force, GameObject instigattor)
    {
        if (isDead) return;
        curruntHealth -= damage;
        if (hurEfect != null)
        {
            Instantiate(hurEfect, instigattor.transform.position, Quaternion.identity);
        }
        if (curruntHealth <= 0)
        {
            curruntHealth = 0;
            isDead = true;
            anim.SetTrigger(isDeadId);
            Destroy(gameObject, 3f);
        }
        Debug.Log("Enemy bi chem");
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (player.isDead) return;
        if (player == null) return;
        if (collision.CompareTag("Player"))
        {
            if(Time.time>nextTime)
            {
                nextTime = Time.time+rateTime;
                anim.SetTrigger(isAttackID);
                player.TakeDamage(damageToGive, force, gameObject);
            }
        }
    }
}
