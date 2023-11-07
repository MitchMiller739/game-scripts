using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCText : MonoBehaviour
{

    public Transform player;
    public GameObject lostDonut;
    public GameObject returnedDonut;
    public CoinBehaviour coinBehaviour;
    private float textRange = 8f;
    private int donuts;

    // Start is called before the first frame update
    void Start() {
        lostDonut.SetActive(false);
        returnedDonut.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        donuts = CoinBehaviour.totalCoins;

        float playerDistance = Vector2.Distance(transform.position, player.position);

        if (playerDistance <= textRange && donuts <= 0) {
            lostDonut.SetActive(true);
        }
        else if (playerDistance <= textRange && donuts > 0) {
            lostDonut.SetActive(false);
            returnedDonut.SetActive(true);
        }
        else if (playerDistance > textRange) {
            lostDonut.SetActive(false);
            returnedDonut.SetActive(false);
        }
        else {
            Debug.Log("Error");
        }
    }
}
