using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.PI.ReactionSystem;


public class Unit {
    public int Health;
    //void onHit

    Unit() {
        Health = Random.Range(50,100);
    }
}