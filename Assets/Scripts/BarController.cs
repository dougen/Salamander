using UnityEngine;

public class BarController : MonoBehaviour 
{
    public float downSpeed = 4.0f;      // 柱子下降的速度
    public float gap = 3.0f;            // 两个柱子之间的空隙大小
    public float gapPos = 0f;           // 间隙所在的位置
    public float endPos = 0f;           // 距离飞船多远的时候完成移动操作
    public float startPos = 1.0f;       // 距离飞船多远的时候，开始移动操作
    public float initY = 7f;

    public float barLength = 8f;
    public float wallLength = 4f;

    public GameObject leftBar;
    public GameObject rightBar;


	private void Start () 
    {
        Reset(downSpeed, gapPos, initY);
	}
	

	private void Update () 
    {
        float posy = transform.position.y;

	    if (posy <= startPos && posy >= endPos)
        {
            // 执行合并操作
            BarAnimation();
        }

        posy -= downSpeed * Time.deltaTime;
        transform.position = new Vector2(transform.position.x, posy);
	}

    // 用来控制两边柱子收缩的函数
    private void BarAnimation()
    {
        // 先计算到底部的距离占百分之几
        float distancePercent = (startPos - transform.position.y) / (startPos - endPos);

        // 然后收缩左边的柱子
        float leftPos = (wallLength + (gapPos - gap / 2f))* distancePercent;
        leftBar.transform.localPosition = new Vector2(-barLength + leftPos, 0);

        // 搜索右边的柱子
        float rightPos = (wallLength - (gapPos + gap / 2f)) * distancePercent;
        rightBar.transform.localPosition = new Vector2(barLength - rightPos, 0);
    }

    // 重置柱子
    public void Reset(float downSpeed, float gapPos, float initY)
    {
        this.downSpeed = downSpeed;
        this.gapPos = gapPos;

        // 将两个柱子的位置初始化
        leftBar.transform.localPosition = new Vector2(-barLength, 0);
        rightBar.transform.localPosition = new Vector2(barLength, 0);

        transform.position = new Vector3(0f, initY, 0f);
        
    }
}
