using UnityEngine;
using System.Collections;

public class FlowerGenerator : MonoBehaviour {

	public ObjectPooler flowerPool;

	public float distanceBetweenFlowers;

	public void SpawnFlowers(Vector3 startPosition)
	{
		GameObject flower1 = flowerPool.GetPooledObject ();
		flower1.transform.position = startPosition;
		flower1.SetActive (true);

		GameObject flower2 = flowerPool.GetPooledObject ();
		flower2.transform.position = new Vector3 (startPosition.x - distanceBetweenFlowers, startPosition.y, startPosition.z);
		flower2.SetActive (true);

		GameObject flower3 = flowerPool.GetPooledObject ();
		flower3.transform.position = new Vector3 (startPosition.x + distanceBetweenFlowers, startPosition.y, startPosition.z);
		flower3.SetActive (true);




	}


}
