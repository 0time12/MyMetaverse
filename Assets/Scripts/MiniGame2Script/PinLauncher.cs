using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinLauncher : MonoBehaviour
{
    [SerializeField]
    private GameObject pinObject;

    private Pin currPin;

    private MiniGame2_GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        PreparePin();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager != null && gameManager.isCountingDown)
        {
            return; // 카운트다운 중이면 여기서 함수 종료
        }

        if (Input.GetMouseButtonDown(0)
            && currPin != null
            && MiniGame2_GameManager.instance.isGameOver == false)
        {
            currPin.Launch();
            currPin = null;
            Invoke("PreparePin", 0.16f);
        }
    }

    void PreparePin()
    {
        
        if (MiniGame2_GameManager.instance.isGameOver == false)
        {
            GameObject pin = Instantiate(pinObject, transform.position, Quaternion.identity);
            currPin = pin.GetComponent<Pin>();
        }
        
    }
}
