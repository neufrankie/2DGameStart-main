using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[AddComponentMenu("DangSon/AutoDestroy")]
public class AutoDestroy : MonoBehaviour
{
   public float timeDelay = 2f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,timeDelay);
    }
}
