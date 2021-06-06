using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ����� ��� ����������� ���������
public class VisibleCenterObj : MonoBehaviour
{
    [Tooltip("Transform �������� � �������� ����� ���������� ��������� �� ������")]
    public Transform perentObj;

    public static bool visible;

    void Start()
    {
        transform.position = perentObj.position;
        visible = false;
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
