using UnityEngine;

public class CloudSwapScript : MonoBehaviour 
{
    public GameObject[] clouds;             // 生成云的种类
    public float speed = 0.5f;              // 云向下飘落的速度
    public float cloudSize = 2.0f;          // 生成云的放大倍数
    public float leftX = -4f;               // 云朵生成最左边的距离
    public float rightX = 4f;               // 云朵生成最右边的距离
    public float swapTime = 10f;            // 生成云朵的间隔时间
    
    private float timer = 0;                // 用来统计时间

	private void Start () 
    {
	   
	}
	
	private void Update () 
    {
	    // 随机产生云的方式，总的来说以一定的速度往下移动，但是随机在一定范围内慢速的飘动
        timer += Time.deltaTime;
        if (timer >= swapTime)
        {
            timer = 0;
            SwapCloud();
        }
	}

    // 用来生成新的云朵
    private void SwapCloud()
    {
        // 先随机生成初始位置
        int index = Random.Range(0, clouds.Length);
        float posX = Random.Range(leftX, rightX);

        GameObject tempCloud = Instantiate(clouds[index]) as GameObject;
        tempCloud.GetComponent<CloudController>().Reset(speed, cloudSize, posX);
    }
}
