using UnityEngine;

using System.Collections.Generic;

public class CloudSwapScript : MonoBehaviour 
{
    public Transform[] clouds;              // 使用数组来容纳随机产生的云
    public float maxSpeed = 2.0f;           // 云向下飘落的最大速度
    public float minSpeed = 0.5f;           // 云向下飘落的最小速度
    public float maxSize = 1.5f;            // 产生云的最大放大倍数
    public float minSize = 1.0f;            // 产生云的最小放大倍数
    public int maxCount = 5;                // 同屏内最多显示的云朵数量

    private List<Transform> cloudPool;          // 用来存储已经没用的云对象池
    private int cloudCount;                 // 当前屏幕内存在的云的数量

	private void Start () 
    {
	    // 初始化变量
        cloudPool = new List<Transform>();
        cloudCount = 0;
	}
	
	private void Update () 
    {
	    // 随机产生云的方式，总的来说以一定的速度往下移动，但是随机在一定范围内慢速的飘动
        // 
	}

    // 用来生成新的云朵
    private void SwapCloud()
    {
        // 先用随机函数生成本次云朵的类型，大小，下落速度等
        int index = Random.Range(0, clouds.Length);
        float speed = Random.Range(minSpeed, maxSpeed);
        float size = Random.Range(minSize, maxSize);

        // 查看cloudPool中是否还有可用的对象
        foreach(var v in cloudPool)
        {
            // 从自己的脚本中得知类型
        }
    }
}
