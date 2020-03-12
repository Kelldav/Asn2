using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerShoot : MonoBehaviour {
    [SerializeField] private Transform camera = null;
    public TextMeshProUGUI text;
    float range = 100f; // for now
    int counter=0;
    void Update() {
        if (Input.GetButtonDown("Fire1")) {
            Shoot();
        }
        text.text=counter.ToString();
    }

    private void Shoot() {
        RaycastHit hit = new RaycastHit();

        LayerMask wallMask = LayerMask.GetMask("Structures");
        LayerMask enemyMask = LayerMask.GetMask("Enemies");



        if (Physics.Raycast(camera.position, camera.forward, out hit, range, enemyMask)) {
            Debug.Log("Shot the following enemy: " + hit.collider.name);
            EnemyHealth enemyHealth = hit.collider.GetComponent<EnemyHealth>();
            enemyHealth.TakeDamage(10);
            counter=counter+1;
            text.text = counter.ToString();
            if (enemyHealth.isDead) {
              hit.collider.gameObject.SetActive(false);
            }

        } else if (Physics.Raycast(camera.position, camera.forward, out hit, range, wallMask)) {
            Debug.Log("Shot the following wall: " + hit.collider.name);
        }
    }
}
