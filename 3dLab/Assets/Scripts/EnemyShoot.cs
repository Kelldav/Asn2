using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour {

    public float range = 100f; // for now
    public int damage = 10;
    public GameObject player;
    public float cooldown = 1.0f;
    public float lastShootTime = 0.0f;

    private void Update() {
        transform.LookAt(player.transform.position);
    }

    private void OnTriggerStay(Collider other) {
        // ignore collisions with other objects
        if (other.tag != "Player") {
            return;
        }
        Debug.Log("Player is within range!");

        if (Time.time > (lastShootTime + cooldown)) {
            RaycastHit playerHit;
            LayerMask playerMask = LayerMask.GetMask("Player");
            if (Physics.Raycast(transform.position, transform.forward, out playerHit, range, playerMask)) {
                if (playerHit.collider != null &&
                    playerHit.collider.gameObject != null &&
                    playerHit.collider.gameObject.tag == "Player") {
                    Shoot(playerHit.collider.gameObject);
                }
            } else {
                // hit the wall, no line of sight
                Debug.Log("No line of sight!");
            }
        }
    }

    private void Shoot(GameObject player) {
        lastShootTime = Time.time;
        Debug.Log("Pew!");
        Debug.Log(player);
        Health playerHealth = player.GetComponent<Health>();
        playerHealth.TakeDamage(damage);
        if (playerHealth.isDead) {
            // game over
        }
    }
}
