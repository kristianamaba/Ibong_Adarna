using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public Transform[] views;
    public float tSpeed = 0.125f;
    public Transform cView;


    public int CTarget = 1, LTarget = 0;

    void Start() {
        int n = PlayerPrefs.GetInt("level", 1);
        CTarget = (n >= 10 ? 10 : n);
    }

    void Update()
    {
        if (LTarget == 0 || CTarget != LTarget)
        {
            LTarget = CTarget;
            cView = views[CTarget - 1];
        }
    }

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, cView.position, Time.deltaTime * tSpeed);
    }


}
