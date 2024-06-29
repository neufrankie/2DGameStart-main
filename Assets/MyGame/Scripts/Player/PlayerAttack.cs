using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/PlayerAttack")]
public class PlayerAttack : MonoBehaviour
{
    public float radiusAttack = 2f;
    public Transform pointAttack;
    public float atackRate = 0.2f;
    public float nextAttack = 0;
    public float timerDelay = 0.2f;
    public LayerMask enemyLayer;
    public int damageToGive = 50;
    public Vector2 force;
    private Animator anim;
    private int isAttackAnimationId;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        isAttackAnimationId = Animator.StringToHash("isAttack");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
           anim.SetTrigger(isAttackAnimationId);
            GetkeyR();
        }

    }
    private bool GetkeyR()
    {
        if(Time.time > nextAttack)
        {
            nextAttack = Time.time + atackRate;
            StartCoroutine(Attack(timerDelay));
            return true;
        }
        else
            return false;

    }
    IEnumerator Attack(float delay)
    {
        yield return new WaitForSeconds(delay);
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(pointAttack.position, radiusAttack,enemyLayer);
        foreach (var enemy in hitEnemys)
        {
            var canTake = enemy.GetComponent<ICanTakeDamage>();
            if (canTake != null)
            { 
            canTake.TakeDamage(damageToGive, force, gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if(pointAttack!=null)
        {
            Gizmos.DrawWireSphere(pointAttack.position, radiusAttack);
        }
    }
}
