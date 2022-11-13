using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObjects/Crop", order = 1)]
public class CropScriptable : ScriptableObject{
    public string Name;
    public float GrowthDuration;
    [SerializeField] float XPMultiplier = 1;
    public float Exp{get {return GrowthDuration * XPMultiplier;} }
    public CropTypeEnum Type;
    public CropEnum Crop;
    
    [SerializeField] GameObject[] prefabs;
    public GameObject Prefab{get {return prefabs[Random.Range(0,prefabs.Length)];}}

    

    public Sprite CropImage;


}
