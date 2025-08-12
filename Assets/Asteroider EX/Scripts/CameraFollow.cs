using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform alvo; // geralmente o Player
    public float suavidade = 0.125f;
    public Vector3 offset;

    void LateUpdate()
    {
        if (alvo == null) return;

        Vector3 posDesejada = alvo.position + offset;
        Vector3 posSuave = Vector3.Lerp(transform.position, posDesejada, suavidade);
        transform.position = new Vector3(posSuave.x, posSuave.y, transform.position.z);
    }
}