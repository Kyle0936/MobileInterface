using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddState : MonoBehaviour
{
    public GameObject UIBehavPrefab;
    public GameObject canvasParent;
    private int cnt = 0;
	
    public void NewAdd() {
        
    }

    public void Add() {
		cnt = this.transform.childCount;
        float placement = 0;
        if (cnt != 0) {
            float y = this.transform.GetChild(cnt - 1).GetChild(0).GetComponent<RectTransform>().rect.height;
            placement = y * cnt;
        }
        
		GameObject sample = Instantiate(UIBehavPrefab);	
        sample.transform.GetChild(1).GetComponent<Text>().text = this.transform.parent.GetChild(0).GetComponent<InputField>().text;
		sample.transform.SetParent(canvasParent.transform, false);
		sample.transform.position -= new Vector3(0,placement,0);
        UpdateWholeList();
    }

    private void UpdateWholeList() {
        Transform wholeList = this.transform.parent.parent;
        float y = 0;
        float starting = 0;
        foreach (Transform child in wholeList) {
            if(child.GetSiblingIndex() != 0) {
                child.position = new Vector3(child.position.x, starting-y,child.position.z);
            } else {
                starting = child.position.y;
            }

            int tmpcnt = child.GetChild(4).transform.childCount;
            if(tmpcnt != 0) {
                y += 50 + tmpcnt * 30;
            } else {
                y += 50;
            }
        }
    }


}
