using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RadialProgressBar : MonoBehaviour{
    public float Progress{
        set{
            _image.fillAmount = value;
            _image.color = Color.Lerp(_startColor,_endColor,value);
            transform.localPosition = new Vector3(_targetPosition.x, _targetPosition.y + value, _targetPosition.z);
            if(_destroyAfterEnd){
                if (value == 1){
                    IsActive = false;
                }
            }
        }
    }
    public bool IsActive{set{_image.enabled = value;}}
    [SerializeField] Vector3 _offset = Vector3.zero;
    [SerializeField] Color _startColor;
    [SerializeField] Color _endColor;
    Vector3 _targetPosition;
    Image _image;
    bool _destroyAfterEnd;
    void Awake(){
        _image = GetComponent<Image>();
        transform.SetParent( GameObject.Find("WorldCanvas").transform);
    }
    
    public RadialProgressBar SetTarget(Vector3 targetWorldPosition){
        _targetPosition = targetWorldPosition + _offset;
        transform.localPosition = targetWorldPosition;
        return this;
    }
    public void DestroyAfterEnd(){
        _destroyAfterEnd = true;
    }
}
