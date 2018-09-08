using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Rigidbody2D))]
public class BirdScript : MonoBehaviour {

    public float movement=0f;

    public Image GayZ;
   public  Rigidbody2D rb;
    public bool isgamestart = false;

    public Image HiGHSCOREIMAGE;

    public static float highScore=130;

    public Text cointext;

    public static float Speed;

    public static int coinINT=0;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
    }

    private void Update()
    {
        if(Input.GetMouseButton(0)&&isgamestart)
        {
            if(Input.mousePosition.x>=360)
            {
                movement = Speed;
            }
            else
            {
                movement = -Speed;
            }
        }
        else if(isgamestart)
        {
            StartCoroutine(velo());
        }

        GayZ.fillAmount = transform.position.y / highScore;

        if(transform.position.y > highScore&&!HiGHSCOREIMAGE.gameObject.activeSelf)
        {
            HiGHSCOREIMAGE.gameObject.SetActive(true);
        }

    }
    IEnumerator velo() //스무스한 움직임
    {
        yield return new WaitForSeconds(0.01f);
        if (movement > 0)
            movement-=0.1f;
        else
            movement+=0.1f;
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        velocity.x = movement;
        rb.velocity = velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("coin"))
        {
            coinINT += 200;
            cointext.text = coinINT.ToString();
            Destroy(collision.gameObject);
        }
    }
}
