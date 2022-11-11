using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CropStorage : MonoBehaviour
{
    public static CropStorage Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CropStorage>();
                if (_instance == null)
                {
                    _instance = new GameObject("Spawned CropStorage", typeof(CropStorage)).GetComponent<CropStorage>();
                }
            }
            return _instance;
        }
    }
    private static CropStorage _instance;

    private Dictionary<CropEnum,int> _storage = new Dictionary<CropEnum, int>();

    public void AddCrop(CropEnum crop,int quantiy){
        if(!_storage.ContainsKey(crop)){
            _storage.Add(crop,0);
        }

        _storage[crop] += quantiy;
    }

    public int GetCrop(CropEnum crop){
        if(!_storage.ContainsKey(crop)) return 0;
        return _storage[crop];

    }
}
