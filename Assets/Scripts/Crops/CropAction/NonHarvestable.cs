using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonHarvestable : CropAction{
    public NonHarvestable(CropEnum type, float exp) : base(type, exp) {}
    public override bool Run(){
        return false;
    }
}
