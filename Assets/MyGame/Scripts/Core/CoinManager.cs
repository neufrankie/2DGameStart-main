using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/CoinManager")]
public class CoinManager : MonoBehaviour
{
    public int addCoin = 1;
    public AudioClip coinClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.Instance.coinEvent?.Invoke(addCoin);
            AudioManager.Instance.PlaySfx(coinClip);
            Destroy(gameObject);
        }
    }
}
