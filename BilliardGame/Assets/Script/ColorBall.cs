using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorBall : MonoBehaviour
{
    // ���Z�b�g�̂��߂̏����ʒu.
    Vector3 defaultPosition = new Vector3();
    // ���W�b�h�{�f�B.
    Rigidbody rigid = null;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        defaultPosition = this.transform.localPosition;
    }

    // ----------------------------------------------------------------------
    /// <summary>
    /// ���Z�b�g���̏���.
    /// </summary>
    // ----------------------------------------------------------------------
    public void Reset()
    {
        gameObject.SetActive(true);
        // ���W�b�h�{�f�B�̑��x�������I��0�ɂ���.
        rigid.velocity = Vector3.zero;
        // ���W�b�h�{�f�B�̉�]���x�������I��0�ɂ���.
        rigid.angularVelocity = Vector3.zero;
        // �����ʒu�ɖ߂�.
        this.transform.localPosition = defaultPosition;
    }
}