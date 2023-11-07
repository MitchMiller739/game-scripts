using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCText : MonoBehaviour
{

    public Transform player;
    public GameObject text;
    private float textRange = 8f;

    // Start is called before the first frame update
    void Start() {
        text.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        float playerDistance = Vector2.Distance(transform.position, player.position);

        if (playerDistance <= textRange) {
            text.SetActive(true);
        }
        else if (playerDistance > textRange) {
            text.SetActive(false);
        }
    }
}
