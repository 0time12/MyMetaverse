using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCircle : MonoBehaviour
{
    [SerializeField]

    private float rotationSpeed = -30f; //시계방향 음수

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (MiniGame2_GameManager.instance.isGameOver == false)
        {
            transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
        }
        
    }
}
