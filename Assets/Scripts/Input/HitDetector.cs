using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetector : MonoBehaviour{
    void Update() {  
        if (Input.GetMouseButtonDown(0)) {  
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);  
            RaycastHit hit;  
            if (Physics.Raycast(ray, out hit)) {  
                Debug.Log("Hitted at:" + hit.transform.tag);
                
                if (hit.transform.tag == "FarmLand") {  
                    Debug.Log("Hit Field position: " + hit.transform.position);
                }  
            }  
        }
    }
}
