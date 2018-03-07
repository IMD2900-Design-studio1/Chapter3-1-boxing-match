using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour {



	void OnTriggerEnter(Collider mCollider)  
	{  
		//transform.Translate(Vector3.forward * Time.deltaTime * 5);  

		Destroy(gameObject);  

		//collision
		/*if(mCollider.gameObject.tag=="...")  
		{  
			...
		}*/ 
	}  

}
