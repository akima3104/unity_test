using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    // ���C���{�[��.
    [SerializeField] GameObject mainBall = null;
    // �ł�.
    [SerializeField] float power = 0.5f;
    // �����\���p�I�u�W�F�N�g�̃g�����X�t�H�[��.
    [SerializeField] Transform arrow = null;
    // �{�[�����X�g.
    [SerializeField] List<ColorBall> ballList = new List<ColorBall>();

    // �}�E�X�ʒu�ۊǗp.
    Vector3 mousePosition = new Vector3();
    // ���C���{�[���̃��W�b�h�{�f�B.
    Rigidbody mainRigid = null;
    // ���Z�b�g���̂��߂Ƀ��C���{�[���̏����ʒu��ۊ�.
    Vector3 mainBallDefaultPosition = new Vector3();

    void Start()
    {
        mainRigid = mainBall.GetComponent<Rigidbody>();
        mainBallDefaultPosition = mainBall.transform.localPosition;
        arrow.gameObject.SetActive(false);
    }

    void Update()
    {
        // ���C���{�[�����A�N�e�B�u�ȂƂ�.
        if (mainBall.activeSelf == true)
        {
            // �}�E�X�N���b�N�J�n��.
            if (Input.GetMouseButtonDown(0) == true)
            {
                // �J�n�ʒu��ۊ�.
                mousePosition = Input.mousePosition;
                // ��������\��.
                arrow.gameObject.SetActive(true);
                Debug.Log("�N���b�N�J�n");
            }

            // �}�E�X�N���b�N��.
            if (Input.GetMouseButton(0) == true)
            {
                // ���݂̈ʒu�𐏎��ۊ�.
                Vector3 position = Input.mousePosition;

                // �p�x���Z�o.
                Vector3 def = mousePosition - position;
                float rad = Mathf.Atan2(def.x, def.y);
                float angle = rad * Mathf.Rad2Deg;
                Vector3 rot = new Vector3(0, angle, 0);
                Quaternion qua = Quaternion.Euler(rot);

                // �������̈ʒu�p�x��ݒ�.
                arrow.localRotation = qua;
                arrow.transform.position = mainBall.transform.position;
            }

            // �}�E�X�N���b�N�I����.
            if (Input.GetMouseButtonUp(0) == true)
            {
                // �I�����̈ʒu��ۊ�.
                Vector3 upPosition = Input.mousePosition;

                // �J�n�ʒu�ƏI���ʒu�̃x�N�g���v�Z����ł��o���������Z�o.
                Vector3 def = mousePosition - upPosition;
                Vector3 add = new Vector3(def.x, 0, def.y);

                // ���C���{�[���ɗ͂�������.
                mainRigid.AddForce(add * power);

                // ���������\����.
                arrow.gameObject.SetActive(false);

                Debug.Log("�N���b�N�I��");
            }
        }
    }

    // ---------------------------------------------------------------------
    /// <summary> 
    /// ���Z�b�g�{�^���N���b�N�R�[���o�b�N. 
    /// </summary> 
    // --------------------------------------------------------------------- 
    public void OnResetButtonClicked()
    {
        mainBall.SetActive(true);
        // ���C���{�[���̑��x�������I�Ƀ[����.
        mainRigid.velocity = Vector3.zero;
        // ���C���{�[���̉�]���x�������I�Ƀ[����.
        mainRigid.angularVelocity = Vector3.zero;
        // ���C���{�[���������ʒu�ɖ߂�.
        mainBall.transform.localPosition = mainBallDefaultPosition;

        foreach (ColorBall ball in ballList)
        {
            // �J���[�{�[���̃��Z�b�g.
            ball.Reset();
        }
    }
}