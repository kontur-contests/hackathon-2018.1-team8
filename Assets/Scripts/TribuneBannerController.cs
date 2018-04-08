using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TribuneBannerController : MonoBehaviour {

	public List<Transform> banners = new List<Transform>();
	void Start () {
		var selectedBanners = new Transform[2];
		selectedBanners[0] = banners[Random.Range(0, banners.Count)];
		selectedBanners[1] = banners[Random.Range(0, banners.Count)];

		Instantiate(selectedBanners[0], transform, false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
