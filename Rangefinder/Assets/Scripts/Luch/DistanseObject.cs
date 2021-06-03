using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class DistanseObject : MonoBehaviour
{
    public Transform player;
    public Text posBlock;
    public Text posPlayer;

    private bool visible = false;
    // private int count;
    private string curTime;

    void Update()
    {
        //posBlock.text = "������� �����: \n" + this.transform.position.ToString() + "\n";
        //posBlock.text += "����� = " + this.transform.localScale.x.ToString() + "\n";
        //posBlock.text += "������ = " + this.transform.localScale.y.ToString() + "\n";
        //posBlock.text += "������ = " + this.transform.localScale.z.ToString() + "\n";

        //posPlayer.text = "������� ������: \n" + player.position.ToString() + "\n";
        //posPlayer.text += "��������� �� ������: \n" + Vector3.Distance(player.position, transform.position) + " �\n";
        //posPlayer.text += visible ? "������ �����" : "������ �� �����";

        if (Input.GetKeyDown(KeyCode.R))
        {
            curTime = System.DateTime.Now.ToString("dd-mm-yyyy hh-mm-ss"); // ��������� ���� ��� ������ ����� ��� ���

            string text = "";
            text += visible ? "������ ����� \n" : "������ �� ����� \n";
            text += "������� �����: \n" + this.transform.position.ToString() + "\n";
            text += "����� ������� = " + this.transform.localScale.x.ToString() + "\n";
            text += "������ ������� = " + this.transform.localScale.y.ToString() + "\n";
            text += "������ ������� = " + this.transform.localScale.z.ToString() + "\n";

            File.WriteAllText("Data/obj_" + curTime + ".txt", text);
            // count++;
        }
    }

    private void OnBecameVisible()
    {
        visible = true;
    }

    private void OnBecameInvisible()
    {
        visible = false;
    }
}
