using UnityEngine;
using System.Collections.Generic;

public class BarSwapScript : MonoBehaviour 
{
    public float swapTime = 0.5f;
    public GameObject bar;

    private List<GameObject> bars;
    private List<GameObject> tempBars;
    private float timeCount;

	private void Start () 
    {
        bars = new List<GameObject>();
        tempBars = new List<GameObject>();  // 缓存池
        timeCount = 0f;
	}
	
	private void Update () 
    {
        // 固定时间刷出柱子
	    if (timeCount >= swapTime)
        {
            timeCount = 0f;
            
            // 缓存池中是否有可用的柱子,当没有可用的柱子时，new一个新的柱子出来
            if (tempBars.Count <= 0)
            {
                SwapBar(6f, Random.Range(-2f, 2f), 7f);
            }
            else
            {
                tempBars[0].GetComponent<BarController>().Reset(6f, Random.Range(-2f, 2f), 7f);
                bars.Add(tempBars[0]);
                tempBars.RemoveAt(0);
            }
        }

        // 检测柱子是否可以放到缓存池中
        foreach(var bar in bars)
        {
            // 当柱子已经超出屏幕的范围时，加入到缓存池中
            if (bar.transform.position.y < -8f)
            {
                tempBars.Add(bar);
            }
        }

        // 已经加入到缓存池中的柱子要从当前list中移除
        foreach(var bar in tempBars)
        {
            bars.Remove(bar);
        }

        timeCount += Time.deltaTime;
	}

    // 根据下落的速度，随机开口的范围决定生成柱子
    public void SwapBar(float downSpeed, float gapPos, float initY)
    {
        GameObject tempBar = (GameObject)Instantiate(bar, new Vector3(0, initY, 0), Quaternion.identity);
        tempBar.GetComponent<BarController>().Reset(downSpeed, gapPos, initY);
        bars.Add(tempBar);
    }

    // 判断如何生成间隙的位置
    public float CheckGapPos()
    {
        return 0f;
    }
}
