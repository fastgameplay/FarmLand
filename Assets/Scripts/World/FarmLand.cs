using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CropGrower))]
public class FarmLand : MonoBehaviour{
    public bool IsCropPlanted{get{return _crop != null;}}
    public CropTypeEnum CropType {
        get {
            if(_crop != null){
                return _crop.Type;
            }
            return CropTypeEnum.Empty;
        }
    }
    CropScriptable _crop;
    CropGrower _grower;
    bool isActionReady {get{return _grower.Progress == 1;}}
    void Awake()
    {
        _grower = GetComponent<CropGrower>();
    }
    
    public void Plant(CropScriptable crop){
        if(_crop != null) return;

        _grower.PlantCrop(crop);
        _crop = crop;
    }
    public void Harvest(){
        if(_crop == null) return;
        if(isActionReady){
            switch(_crop.Type){
                case CropTypeEnum.Harvestable:
                    CropStorage.Instance.AddCrop(_crop.Crop,1);
                    ExpStorage.Instance.AddExp(_crop.Exp);
                    _grower.DestoryCrop();
                    _crop = null;
                    break;
                case CropTypeEnum.destructible:
                    _grower.DestoryCrop();
                    ExpStorage.Instance.AddExp(_crop.Exp);
                    _crop = null;
                    break;
                default:
                    break;
            }
        }
    }
}
