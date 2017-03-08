using UnityEngine;
using System.Collections;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distanceBetween;

	private float platformWidth;

	public float distanceBetweenMin;
	public float distanceBetweenMax;

	private int platformSelector;
	private float[] platformWidths;

	public ObjectPooler[] theObjectPools;

	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;

	private FlowerGenerator theFlowerGenerator;

	public ObjectPooler wolfPool;

	private bool lastPlatformWolf;
	// Use this for initialization
	void Start () {
		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
			platformWidths [i] = theObjectPools [i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;

		theFlowerGenerator = FindObjectOfType<FlowerGenerator> ();
		lastPlatformWolf = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(transform.position.x < generationPoint.position.x)
		{
			distanceBetween = Random.Range (distanceBetweenMin, distanceBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} 
			else if (heightChange < minHeight) {
				heightChange = minHeight;
			}

			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, heightChange, transform.position.z);
		
			//Instantiate (thePlatform, transform.position, transform.rotation);
			GameObject newPlatform= theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			if(Random.Range(0,2)==0)
			theFlowerGenerator.SpawnFlowers (new Vector3 (transform.position.x, transform.position.y + 1.2f, transform.position.z));
		
			if (Random.Range (0, 9) == 0 && !lastPlatformWolf) {

				lastPlatformWolf = true;
				GameObject newWolf = wolfPool.GetPooledObject ();

				float wolfPosition = Random.Range (-platformWidths [platformSelector] / 2 + 1f, platformWidths [platformSelector] / 2 - 1f);

				newWolf.transform.position = new Vector3 (transform.position.x + wolfPosition, transform.position.y + 1f, transform.position.z);
				newWolf.transform.rotation = transform.rotation;
				newWolf.SetActive (true);

			} else {
				lastPlatformWolf = false;
			}
			transform.position = new Vector3 (transform.position.x + (platformWidths[platformSelector]/2) + distanceBetween, transform.position.y, transform.position.z);

		}


	}
}
