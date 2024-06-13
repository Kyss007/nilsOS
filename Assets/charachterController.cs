using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class charachterController : MonoBehaviour
{
    public float jumpForce = 1f;
    public float gravity = 1f;
    public float groundPos = -58;

    public bool isGrounded = false;

    public GameObject walk;
    public GameObject jump;

    private RectTransform rectTransform;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if(rectTransform.anchoredPosition.y <= groundPos)
        {
            Vector2 newPos = rectTransform.anchoredPosition;

            newPos.y = groundPos;
                
            rectTransform.anchoredPosition = newPos;

            isGrounded = true;
        }

        if (isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rectTransform.anchoredPosition += Vector2.up * jumpForce;
                isGrounded = false;
            }
        }
        else
        {
            rectTransform.anchoredPosition += Vector2.down * gravity * Time.deltaTime;
        }
    }

    private void LateUpdate()
    {
        if (isGrounded)
        {
            walk.SetActive(true);
            jump.SetActive(false);
        }
        else
        {
            walk.SetActive(false);
            jump.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("spike"))
        {


            //Das hier passiert, wenn sie auf ablehnen drückt
            //SceneManager.LoadScene("bluescreen");
        }
    }

    public void BlueScreen() 
    {
        SceneManager.LoadScene("bluescreen");
    }
}
