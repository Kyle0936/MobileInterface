using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateCondition : MonoBehaviour
{
    public GameObject behavList;
    public GameObject robot;

    public GameObject dropDown;

    void Start()
    {
        // behavList = GameObject.Find("BehavList");
        // robot = GameObject.Find("Robot");
    }

    public void ClearList(){
        foreach (Transform child in behavList.transform) {
            GameObject.Destroy(child.gameObject);
        }
    }

    public void UpdateCond() {

        Dropdown temp = dropDown.GetComponent<Dropdown>();
        string behav = temp.options[temp.value].text;
        Debug.Log(temp);
        Debug.Log("behav: " + behav);
        Program pro = null;
        switch (behav)
        {
            case "remindcalls":
                pro = GameObject.Find("PhoneCallProgram").gameObject.GetComponent<PhoneCallProgram>();
                break;
            case "vacuum":
                pro = GameObject.Find("VacuumProgram").gameObject.GetComponent<VacuumProgram>();
                break;
            case "pickuppackage":
                pro = GameObject.Find("RetrievePackageProgram").gameObject.GetComponent<RetrievePackageProgram>();
                break;
            case "makefood":
                pro = GameObject.Find("MakeFoodProgram").gameObject.GetComponent<MakeFoodProgram>();
                break;
        }

        foreach (Transform child in behavList.transform) {
            if(child != null) {
                Dropdown boolDropdown = child.GetChild(6).gameObject.GetComponent<Dropdown>();
                string tmptxt = boolDropdown.options[boolDropdown.value].text;
                Debug.Log(tmptxt);
                bool boo = true;

                // Program pro = null;
                switch (tmptxt)
                {
                    case "When I am":
                        boo = true;
                        break;
                    case "When I am not":
                        boo = false;
                        break;
                }
                string input = child.GetChild(0).GetComponent<InputField>().text;
                Debug.Log("input: " + input + ", program: " + pro + ", bool: " + boo);
                Conditional cond = new Conditional();
                cond.RegisterCondition(input.Contains("_") ? input.Split('_')[0] : "", input.Contains("_") ? input.Split('_')[1] : "", boo == true ? false : true);
                robot.GetComponent<RobotController>().triggers.RegisterActionWithConditional(pro, cond);


                // foreach (Transform gradChild in child.GetChild(4)){
                //     string input = gradChild.GetChild(1).gameObject.GetComponent<Text>().text;
                //     Debug.Log("input: " + input + ", program: " + pro + ", bool: " + boo);
                //     Conditional cond = new Conditional();
                //     cond.RegisterCondition(input.Contains("_") ? input.Split('_')[0] : "", input.Contains("_") ? input.Split('_')[1] : "", boo == true ? false : true);
                //     robot.GetComponent<RobotController>().triggers.RegisterActionWithConditional(pro, cond);
                // }
            }
        }
    }
}
