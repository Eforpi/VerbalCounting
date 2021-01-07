using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SnapScroll : MonoBehaviour 
{

	[Header("Pan1")]
	public GameObject pan1;// слож

	[Header("Pan2")]
	public GameObject pan2; // слож несколько

	[Header("Pan3")]
	public GameObject pan3; // умнож

	[Header("Pan4")]
	public GameObject pan4; // дел

    [Header("Pan5")]
    public GameObject pan5; //смеш

    [Header("Pan6")]
    public GameObject pan6; //смеш несколько

    [Range(0f , 20f)]
	public float snapSpeed;

	private GameObject instPans1;

	private GameObject instPans2;

	private GameObject instPans3;

	private GameObject instPans4;

    private GameObject instPans5;

    private GameObject instPans6;

    public Vector3[] pansPos;

	private RectTransform contentRect;

	public int selectedPanID;

	public bool isScrolling;

	private Vector2 contentVector;

	public ScrollRect scrollrect;

    public float distance;

    private void Start ()
	{
        contentRect = GetComponent<RectTransform> ();
		pansPos = new Vector3[6];

		instPans1 = Instantiate(pan1, transform, false);
		instPans1.transform.localPosition = new Vector2 (distance, 30f);
	    pansPos[0] = -instPans1.transform.localPosition;

	    instPans2 = Instantiate(pan2, transform, false);
		instPans2.transform.localPosition = new Vector2 (distance*2, 30f);
	    pansPos[1] = -instPans2.transform.localPosition;
	
	    instPans3 = Instantiate(pan3, transform, false);
	    instPans3.transform.localPosition = new Vector2 (distance*3, 30f);
        pansPos[2] = -instPans3.transform.localPosition;

	    instPans4 = Instantiate(pan4, transform, false);
	    instPans4.transform.localPosition = new Vector2 (distance*4, 30f);
	    pansPos[3] = -instPans4.transform.localPosition;

        instPans5 = Instantiate(pan5, transform, false);
        instPans5.transform.localPosition = new Vector2(distance*5, 30f);
        pansPos[4] = -instPans5.transform.localPosition;

        instPans6 = Instantiate(pan6, transform, false);
        instPans6.transform.localPosition = new Vector2(distance * 6, 30f);
        pansPos[5] = -instPans6.transform.localPosition;
    }

	private void FixedUpdate ()
	{
		if (contentRect.anchoredPosition.x >= pansPos [0].x && !isScrolling || contentRect.anchoredPosition.x <= pansPos [5].x && !isScrolling) 
		{
			scrollrect.inertia = false;
		}
		float nerPos = float.MaxValue;
		for (int i = 0; i < 6; i++) 
		{
			float distanse = Mathf.Abs (contentRect.anchoredPosition.x - pansPos[i].x);
			if (distanse < nerPos) 
			{
				nerPos = distanse;
				selectedPanID = i;
				PlayerPrefs.SetInt("theme", i);
			}
		}
		float scrollVelocity = Mathf.Abs (scrollrect.velocity.x);
		if (scrollVelocity < 400 &&  !isScrolling )scrollrect.inertia = false;
		if (isScrolling || scrollVelocity > 400 )return;		
		contentVector.x = Mathf.SmoothStep (contentRect.anchoredPosition.x, pansPos[selectedPanID].x , snapSpeed * Time.fixedDeltaTime);
		contentRect.anchoredPosition = contentVector;
	}
	public void Scrolling(bool scroll)
	{
		isScrolling = scroll;
		if (scroll)
			scrollrect.inertia = true;
	}
}
