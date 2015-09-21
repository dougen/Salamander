using UnityEngine;

public class PlayerControls : MonoBehaviour 
{
    public Vector2 shipInitPos;             // 飞船的初始位置
    public float shipSpeed = 4f;            // 飞船左右移动的速度

    public float dashTime = 3f;             // 飞船冲刺到最大距离保持的时间
    public float dashDistance = 3f;         // 飞船最大冲刺距离
    public float dashSpeed = 10f;           // 飞船冲刺速度
    public float dashCooldown = 5f;         // 冲刺技能CD时间
    public float backSpeed = -3f;           // 冲刺完成后返回的速度，值为负数

    public float boardX = 3.5f;             // 飞机的左右移动范围

    private Rigidbody2D rig2d = null;
    private float dashTimeCount = 0;          

	private void Start () 
    {
        // 将飞船放到初始位置
        transform.position = shipInitPos;

        rig2d = GetComponent<Rigidbody2D>();
	}
	

	private void Update () 
    {

#if UNITY_STANDALONE

        Vector2 speed = rig2d.velocity;

        // <-左箭头向左移动，->向右移动
        // 当超过边界时停止移动
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            speed = new Vector2(-shipSpeed, speed.y);

            if (transform.position.x < -boardX)
            {
                transform.position = new Vector2(-boardX, transform.position.y);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            speed = new Vector2(shipSpeed, speed.y);

            if (transform.position.x > boardX)
            {
                transform.position = new Vector2(boardX, transform.position.y);
            }
        }
        else
        {
            speed = new Vector2(0, speed.y);
        }

        // 当按下空格键时，飞机进行冲刺。冲刺过程分为三部分
        // 1. 加速前进，飞到最大距离
        // 2. 停在最大距离一段时间，此时速度为0.
        // 3. 持续时间过后，以-dashSpeed回到原来的初始位置
        // 4. 冲刺技能的CD处理
        if (Input.GetKeyDown(KeyCode.Space) && rig2d.velocity.y == 0)
        {
            speed = new Vector2(speed.x, dashSpeed);
            Debug.Log("开始冲刺");
        }

        if (rig2d.velocity.y > 0 && transform.position.y >= dashDistance)
        {
            speed = new Vector2(speed.x, 0);
            transform.position = new Vector2(transform.position.x, dashDistance);
            Debug.Log("冲刺完成");
        }
        else if (rig2d.velocity.y < 0 && transform.position.y <= shipInitPos.y)
        {
            speed = new Vector2(speed.x, 0);
            transform.position = new Vector2(transform.position.x, shipInitPos.y);
            Debug.Log("冲刺结束");
        }
        // 当飞机已经到达顶部时，开始计时。当时间到达冲刺时间后开始后退恢复原来位置
        else if (rig2d.velocity.y ==0 && transform.position.y == dashDistance)
        {
            dashTimeCount += Time.deltaTime;

            if (dashTimeCount >= dashTime)
            {
                dashTimeCount = 0;
                speed = new Vector2(speed.x, backSpeed);
                Debug.Log("冲刺时间结束");
            }
        }
        
        rig2d.velocity = speed;
       
#endif

#if UNITY_ANDROID

#endif
        

	}


}
