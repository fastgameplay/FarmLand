using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Crop", menuName = "ScriptableObjects/Crop", order = 1)]
public class CropScriptable : ScriptableObject{
    public string Name;
    public float HarvestTime;
    [SerializeField] float XPMultiplier = 1;
    public float XP{get {return HarvestTime * XPMultiplier;} }
    public CropTypeEnum Type;
    public CropEnum Crop;
    
    public GameObject Prefab;

    public Sprite CropImage;


}
