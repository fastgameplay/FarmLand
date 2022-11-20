using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : CropAction{
    public Destroyable(CropEnum type, float exp) : base(type, exp) {}
    public override bool Run()
    {
        CropStorage.Instance.AddCrop(_cropType,1);
        ExpStorage.Instance.AddExp(_exp);
        return true;
    }
}
