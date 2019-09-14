﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomAnimBehaviour : StateMachineBehaviour {

    public int numAnimacoes;

    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHash){
        int valor = Random.Range(0, numAnimacoes);
        animator.SetInteger("valor", valor);
    }

}
