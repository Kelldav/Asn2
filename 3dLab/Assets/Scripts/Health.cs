using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Health : MonoBehaviour {
    public TextMeshProUGUI text;
    public int maxHP = 100;
    public int hp = 100;
    public bool isDead = false;
    void Update(){
      text.text= this.hp.ToString();
    }
    public void TakeDamage(int damage) {
        this.hp -= damage;
        if (this.hp <= 0) {
            this.hp = 0;
            this.isDead = true;
        } else {
            this.isDead = false;
        }
        text.text= this.hp.ToString();
    }
}
