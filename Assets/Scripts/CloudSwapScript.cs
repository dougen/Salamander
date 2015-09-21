using UnityEngine;

using System.Collections.Generic;

public class CloudSwapScript : MonoBehaviour 
{
    public GameObject[] clouds;              // 使用数组来容纳随机产生的云
    public float maxSpeed = 2.0f;           // 云向下飘落的最大速度
    public float minSpeed = 0.5f;           // 云向下飘落的最小速度
    public float maxSize = 1.5f;            // 产生云的最大放大倍数
    public float minSize = 1.0f;            // 产生云的最小放大倍数
    public int maxCount = 5;                // 同屏内最多显示的云朵数量
    public float leftX = -4f;               // 云朵生成最左边的距离
    public float rightX = 4f;               // 云朵生成最右边的距离

    private static List<Transform> cloudPool;      // 用来存储已经没用的云对象池
    private static List<Transform> cloudCount;     // 当前屏幕内存在的云的数量
    private float swapTime = 0;

	private void Start () 
    {
	    // 初始化变量
        cloudPool = new List<Transform>();
        cloudCount = new List<Transform>();
	}
	
	private void Update () 
    {
	    // 随机产生云的方式，总的来说以一定的速度往下移动，但是随机在一定范围内慢速的飘动
        swapTime += Time.deltaTime;
        if (cloudCount.Count < 6 && swapTime >= 3f)
        {
            swapTime = 0;
            SwapCloud();
        }

        for (int i=0; i < cloudCount.Count; i++)
        {
            // 当云朵已经飞出屏幕外部时加入到对象池中
            if (cloudCount[i].position.y <= -10f)
            {
                cloudCount[i].gameObject.SetActive(false);  // 让云失效
                cloudPool.Add(cloudCount[i]);
                cloudCount.RemoveAt(i);
                i--;
            }
        }

	}

    // 用来生成新的云朵
    private void SwapCloud()
    {
        // 先用随机函数生成本次云朵的类型，大小，下落速度等
        int index = Random.Range(0, clouds.Length);
        float speed = Random.Range(minSpeed, maxSpeed);
        float size = Random.Range(minSize, maxSize);
        float posX = Random.Range(leftX, rightX);

        // 查看cloudPool中是否还有可用的对象
        for (int i=0; i<cloudPool.Count; i++)
        {
            CloudController cc = cloudPool[i].GetComponent<CloudController>();
            if (cc.cloudType == index)
            {
                cc.Reset(speed, size, posX);
                cloudCount.Add(cloudPool[i]);
                cloudPool.RemoveAt(i);
                i--;               
                return;
            }
        }

        // 当对象池中没有存在的对象时，再自己实例个出来
        GameObject tempCloud = Instantiate(clouds[index]) as GameObject;
        tempCloud.GetComponent<CloudController>().Reset(speed, size, posX);
        cloudCount.Add(tempCloud.transform);
    }
}
