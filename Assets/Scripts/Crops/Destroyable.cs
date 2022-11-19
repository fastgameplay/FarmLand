using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : CropAction{
    public override void Run(){
        CropStorage.Instance.AddCrop(_cropType);
        ExpStorage.Instance.AddExp(_exp);
    }
}
