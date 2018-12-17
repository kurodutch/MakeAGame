using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CoinPickup : MonoBehaviour {

    public bool enter = true;
    public Transform CoinEffect;
    public int CoinValue = 1;
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider Ball)
    {
        if (enter)
        {
            GameMaster.CurrentScore += CoinValue;
            var effect = Instantiate(CoinEffect, transform.position, transform.rotation);
            Destroy(effect.gameObject, 3);
            Destroy(gameObject);
        }
    }
}
