using Asteroids.Model;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FeudingNloPresenter: EnemyPresenter
{
    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        FeudingNloPresenter nlo;
        if(collision.gameObject.TryGetComponent<FeudingNloPresenter>(out nlo))
        {
            if(((Nlo)Model).Team != ((Nlo)nlo.Model).Team)
            {
                DestroyCompose();
            }
        }
    }
}
