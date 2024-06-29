using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
[AddComponentMenu("DangSon/GameManager")]
public class GameManager : MonoBehaviour
{
    public static GameManager Instance
    {
        get => instance;
    }
    private static GameManager instance;
    private int coin;
    //
    public UnityEvent<int> coinEvent;
    public UnityEvent<int> coinEventUpdate;

    private void Awake()
    {
        if(instance != null)
        {
            DestroyImmediate(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        if (coinEvent == null)
        {
            coinEvent = new UnityEvent<int>();
        }
        if (coinEventUpdate == null)
        {
            coinEventUpdate = new UnityEvent<int>();
        }
    }
    private void Start()
    {
        this.coin = DataManager.DataCoin;
        coinEvent.AddListener(AddCoin);
    }
    public void AddCoin(int coin)
    {
        this.coin += coin;
        DataManager.DataCoin = this.coin;
        coinEventUpdate?.Invoke(this.coin);
    }
}
