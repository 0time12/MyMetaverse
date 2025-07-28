using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 10f; // 이동 속도

    private bool isPinned = false;
    private bool isLaunched = false;

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isPinned == false && isLaunched == true)
        {
            transform.position += Vector3.up * movespeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        isPinned = true;
        if (other.gameObject.tag == "Target")
        {
            GameObject childObject = transform.GetChild(0).gameObject;
            childObject.SetActive(true);

            SpriteRenderer childSprite = childObject.GetComponent<SpriteRenderer>();
            childSprite.enabled = true;

            transform.SetParent(other.gameObject.transform);

            MiniGame2_GameManager.instance.Decreasegoal();
        }
        else if (other.gameObject.tag == "Pin")
        {
            MiniGame2_GameManager.instance.SetGameOver(false);
        }

    }

    public void Launch()
    {
        isLaunched = true;

    }
}
