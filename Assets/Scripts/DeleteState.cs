using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteState : MonoBehaviour
{
    public void DeleteThis(){
        // Debug.Log(this);
        // Debug.Log(this.transform.gameObject);
        // Debug.Log(this.transform.parent.gameObject);
        Destroy(this.transform.gameObject);
        UpdateWholeList();
    }


    private void UpdateWholeList() {
        Transform wholeList = this.transform.parent.parent.parent;
        float y = 0;
        float starting = 0;
        foreach (Transform child in wholeList) {
            if(child.GetSiblingIndex() != 0) {
                child.position = new Vector3(child.position.x, starting-y,child.position.z);
            } else {
                starting = child.position.y;
            }
            int tmpcnt = 0;
            if(child.GetSiblingIndex() == this.transform.parent.parent.GetSiblingIndex()) {// if matched the current behavior
                tmpcnt = child.GetChild(4).transform.childCount - 1; // haven't deleted yet so manually deduct 1
                foreach(Transform grand in child.GetChild(4).transform) {
                    Debug.Log("Current " + grand.GetSiblingIndex());
                    if (grand.GetSiblingIndex() > this.transform.GetSiblingIndex()) {// adjust states after the deleted one
                        grand.position += new Vector3(0, 27, 0);
                    }
                }
            } else {
                tmpcnt = child.GetChild(4).transform.childCount;
            }
            
            Debug.Log("test " + tmpcnt);
            if (tmpcnt > 0) {
                y += 50 + tmpcnt * 30;
            } else {
                y += 50;
            }
        }
    }
}
    