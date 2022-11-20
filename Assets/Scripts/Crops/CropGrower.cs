using System.Collections;
using UnityEngine;

public class CropGrower : MonoBehaviour{
    // [SerializeField] RadialProgressBar _radialBarPrefab;
    public float Progress { 
        get{return _progress;} 
        
        private set{
            _progress = value;
            _cropObj.transform.localScale = Vector3.Lerp(_startScale,_finalScale,value);
            _currentProgressBar.Progress = value;

        } 
    }
    private float _progress;
    GameObject _cropObj;
    Vector3 _finalScale = Vector3.one;
    Vector3 _startScale = Vector3.zero;

    RadialProgressBar _currentProgressBar;


    public void GrowCrop(GameObject cropObj, float duration, RadialProgressBar progressBar){
        _cropObj = gameObject;
        _currentProgressBar = progressBar;

        _finalScale = cropObj.transform.localScale;
        StartCoroutine(IEGrowCrop(duration));
    }

    IEnumerator IEGrowCrop(float time){
        _currentProgressBar.IsActive = true;

        Progress = 0;
        float rate = 1 / time;

        while(Progress < 1){
            Progress += Time.deltaTime * rate;
            yield return 0;
        }
        Progress = 1;

    }   
}
