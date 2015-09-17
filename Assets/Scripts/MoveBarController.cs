using UnityEngine;

public class MoveBarController : MonoBehaviour 
{
    public float gap = 1.5f;                        // 柱子之间的间距
    public float horizontalSpeed = 3.0f;            // 柱子左右移动的速度 
    public float verticalSpeed = -5.0f;              // 柱子下落的速度
    public Vector2 initPos = new Vector2(0, 7f);    // 柱子的初始位置

    public Transform leftBar;
    public Transform rightBar;

	private void Start () 
    {
	    // 初始化柱子的位置
        transform.position = initPos;
        leftBar.Translate(new Vector2(-gap/2f, 0), Space.Self);
        rightBar.Translate(new Vector2(gap / 2f, 0), Space.Self);
	}
	

	private void Update () 
    {
        // 当到达最右边时，将速度取反，往回走。
	    if (transform.position.x >= 4f-gap/2f)
        {
            if (horizontalSpeed > 0)
            {
                horizontalSpeed = -horizontalSpeed;
            }
        }

        // 当到达最左边时，将速度取反，往右走。
        if (transform.position.x <= -4f + gap/2f)
        {
            if (horizontalSpeed < 0)
            {
                horizontalSpeed = -horizontalSpeed;
            }
        }

        transform.Translate(new Vector2(horizontalSpeed * Time.deltaTime, verticalSpeed * Time.deltaTime));
	}
}
