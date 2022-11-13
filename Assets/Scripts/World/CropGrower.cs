using System.Collections;
using UnityEngine;

public class CropGrower : MonoBehaviour{
    [SerializeField] RadialProgressBar _radialBarPrefab;
    public float Progress { 
        get{return _progress;} 
        
        private set{
            _progress = value;
            _cropObject.transform.localScale = Vector3.Lerp(_startScale,_finalScale,value);
            currentProgressBar.Progress = value;

        } 
    }
    private float _progress;
    GameObject _cropObject;
    Vector3 _finalScale = Vector3.one;
    Vector3 _startScale = Vector3.zero;

    RadialProgressBar currentProgressBar;

    public void DestoryCrop(){
        if(_cropObject != null){
            StopAllCoroutines();
            Destroy(_cropObject);
            currentProgressBar.IsActive = false;
        }
    }
    public void PlantCrop(CropScriptable crop){
        if (currentProgressBar == null) currentProgressBar = Instantiate(_radialBarPrefab).SetTarget(transform.position);
        if (crop.Type == CropTypeEnum.NonHarvestable) currentProgressBar.DestroyAfterEnd();
        _cropObject = Instantiate(crop.Prefab, transform.position, Quaternion.identity, transform);
        _finalScale = _cropObject.transform.localScale;
        StartCoroutine(IEGrowCrop(crop.GrowthDuration));
    }

    IEnumerator IEGrowCrop(float time){
        currentProgressBar.IsActive = true;

        Progress = 0;
        float rate = 1 / time;

        while(Progress < 1){
            Progress += Time.deltaTime * rate;
            yield return 0;
        }
        Progress = 1;

    }   
}
