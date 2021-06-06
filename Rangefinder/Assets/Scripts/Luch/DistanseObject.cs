using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DistanseObject : MonoBehaviour
{
    [Tooltip("Transform ������")]
    public Transform player;
    [Tooltip("��� �������, �������� 'Cube'")]
    public string figureName;
    [Tooltip("������ ��������� ��� �� ������� ������� �� 0 �� 360")]
    [Range(0, 360)]
    public int startAngleObj;

    private bool visible = false;
    private int count;
    private string curTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && VisibleCenterObj.visible)
        {
            curTime = System.DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss");

            string text = "";
            text += this.transform.position.x.ToString() + " ";
            text += this.transform.position.y.ToString() + " ";
            text += this.transform.position.z.ToString() + " ";
            text += this.transform.localScale.x.ToString() + " ";
            text += this.transform.localScale.y.ToString() + " ";
            text += this.transform.localScale.z.ToString() + " ";
            text += figureName + " ";
            text += "u1 w1 u1 w2";
            text += getRotateObj();

            File.WriteAllText("Data/obj_" + count + ".txt", text);
            count++;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            print(getRotateObj());
        }
    }

    // ������� ���������� ���� ������� ������
    private string getRotateObj()
    {
        double rObj = transform.rotation.eulerAngles.y;

        // ���� ����� ��������� ���
        if (rObj + startAngleObj > 360)
        {
            rObj = (rObj + startAngleObj) % 360;
        }
        else
        {
            rObj += startAngleObj;
        }

        // ���������� ���� ������� ������
        if (rObj >= 45 && rObj < 135)
        {
            return "<-";
        }
        else if (rObj >= 135 && rObj <= 225)
        {
            return "^";
        }
        else if (rObj > 225 && rObj <= 315)
        {
            return ("->");
        }
        else
        {
            return ("�� ������");
        }
    }
}

// var rObj = Vector3.Angle(Vector3.forward, gameObject.transform.forward); // ������ ����