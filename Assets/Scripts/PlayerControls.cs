using UnityEngine;

public class PlayerControls : MonoBehaviour 
{
    public float forwardSpeed = 4f;
    public float shipSpeed = 4f;

    public float jumpTime = 3f;
    public float jumpDistance = 10f;

    public float boardX = 3.5f;

//    private float jumpTimeCount = 0;

	
	private void Start () 
    {

	}
	

	private void Update () 
    {

#if UNITY_STANDALONE

        Vector2 speed = GetComponent<Rigidbody2D>().velocity;

        // <-左箭头向左移动，->向右移动
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = new Vector2(-shipSpeed, forwardSpeed);

            if (transform.position.x < -boardX)
            {
                transform.position = new Vector2(-boardX, transform.position.y);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = new Vector2(shipSpeed, forwardSpeed);

            if (transform.position.x > boardX)
            {
                transform.position = new Vector2(boardX, transform.position.y);
            }
        }
        else
        {
            speed = new Vector2(0, forwardSpeed);
        }

        GetComponent<Rigidbody2D>().velocity = speed;

#endif

#if UNITY_ANDROID

#endif
        

	}
}
