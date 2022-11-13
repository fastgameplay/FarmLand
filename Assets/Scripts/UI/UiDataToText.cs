using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiDataToText : MonoBehaviour{
    [SerializeField] Text expText;
    [SerializeField] Text carrotText;
    float _expirience{ set{expText.text = value.ToString();}}
    int _carrot{ set{carrotText.text = value.ToString();}}

    CropStorage _cropStorage;
    ExpStorage _expStorage;

    void Awake(){
        _cropStorage = CropStorage.Instance;
        _expStorage = ExpStorage.Instance;
    }
    void Update()
    {
        _expirience = _expStorage.Expiriance;
        _carrot = _cropStorage.GetCrop(CropEnum.Carrot);
    }
}
