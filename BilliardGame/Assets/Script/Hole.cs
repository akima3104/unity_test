using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("�������{�[���̖��O : " + other.gameObject.name);
        // ���ɗ������{�[�����A�N�e�B�u�ɂ���.
        other.gameObject.SetActive(false);
    }
}