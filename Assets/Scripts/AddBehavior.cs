using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddBehavior : MonoBehaviour
{
    public GameObject UIBehavPrefab;
    public GameObject canvasParent;
    private int cnt = 0;
	
    public void AddBehav() {
		GameObject sample = Instantiate(UIBehavPrefab);	
		
		cnt = this.transform.childCount;
		float y = 0;
        if (cnt != 0){
			foreach (Transform child in this.transform) {
				int tmpcnt = child.GetChild(4).transform.childCount;
				if(tmpcnt != 0) {
					y += 50 + tmpcnt * 30;
				} else {
					y += 50;
				}
			}
        }
		sample.transform.SetParent(canvasParent.transform, false);
		sample.transform.position -= new Vector3(0,y,0);
    }
}
