using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpStorage : MonoBehaviour
{
    public static ExpStorage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<ExpStorage>();
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned ExpStorage", typeof(ExpStorage)).GetComponent<ExpStorage>();
                }
            }
            return _instance;
        }
    }
    private static ExpStorage _instance;

    public float Expiriance{get; private set;}
   
    public void AddExp(float quantiy){
        Expiriance += quantiy;
    }
}
