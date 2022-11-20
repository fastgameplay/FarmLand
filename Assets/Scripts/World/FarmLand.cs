using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FarmLand : MonoBehaviour{
    [SerializeField] RadialProgressBar _progressBarPrefab;
    public bool IsCropPlanted{get{return (_crop != null || _grower != null);}}
    public CropTypeEnum CropType {
        get {
            if(_crop != null){
                return _crop.Type;
            }
            return CropTypeEnum.Empty;
        }
    }
    Crop _crop;
    CropGrower _grower;
    RadialProgressBar _progressBar;
    bool isActionReady {get{return _grower.Progress == 1;}}

    void Awake()
    {
        _grower = GetComponent<CropGrower>();
        _progressBar = Instantiate(_progressBarPrefab);
        _progressBar.IsActive = false;
    }
    
    public void Plant(CropScriptable crop){

        if(IsCropPlanted) return;
        GameObject cropObj = Instantiate(crop.Prefab,transform.position,Quaternion.identity, transform);
        
        _crop = cropObj.AddComponent<Crop>();
        _crop.SetCrop(crop.Type, crop.Exp, crop.Action);
        _progressBar.SetTarget(cropObj.transform.position);
        if(crop.Action == CropTypeEnum.NonHarvestable) _progressBar.DestroyAfterEnd();
        
        _grower = cropObj.AddComponent<CropGrower>();
        _grower.GrowCrop(cropObj, crop.GrowthDuration, _progressBar);
        
        
    }


    public void Harvest(){
        if(_crop == null) return;

        if(isActionReady){
            if(_crop.Harvest()){
                Destroy(_crop.gameObject);
                _crop = null;
                _grower = null;
                _progressBar.IsActive = false;
            }
        }
    }
}
