using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = -30f; //�ð���� ����

    // Update is called once per frame
    void Update()
    {
        if (MiniGame2_GameManager.instance.isGameOver == false)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        
    }
}
