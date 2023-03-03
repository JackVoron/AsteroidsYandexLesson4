using UnityEngine;
using Asteroids.Model;
using System.Collections.Generic;

public class SpawnExample : MonoBehaviour
{
    [SerializeField] private PresentersFactory _factory;
    [SerializeField] private Root _init;

    private int _index;
    private float _secondsPerIndex = 1f;

    private void Update()
    {
        int newIndex = (int)(Time.time / _secondsPerIndex);

        if(newIndex > _index)
        {
            _index = newIndex;
            OnTick();
        }
    }

    private void OnTick()
    {
        float chance = Random.Range(0, 100);

        if (chance < 30)
        {
           _factory.CreateNlo(new Nlo(_init.Ship, GetRandomPositionOutsideScreen(), Config.NloSpeed));
        }
        else if(chance < 60)
        {
            for (int i = 0; i < 3; i++)
            {
                Nlo redNlo = new Nlo(_init.Ship, GetRandomPositionOutsideScreen(), Config.NloSpeed, EnemiesTeams.Red);
                Nlo blueNlo = new Nlo(redNlo, GetRandomPositionOutsideScreen(), Config.NloSpeed, EnemiesTeams.Blue);
                redNlo.Target = blueNlo;
            
                _factory.CreateNlo(redNlo);
                _factory.CreateNlo(blueNlo);
            }
        }
        else
        {
            Vector2 position = GetRandomPositionOutsideScreen();
            Vector2 direction = GetDirectionThroughtScreen(position);

            _factory.CreateAsteroid(new Asteroid(position, direction, Config.AsteroidSpeed));
        }
    }

    private Vector2 GetRandomPositionOutsideScreen()
    {
        return Random.insideUnitCircle.normalized + new Vector2(0.5F, 0.5F);
    }

    private static Vector2 GetDirectionThroughtScreen(Vector2 postion)
    {
        return (new Vector2(Random.value, Random.value) - postion).normalized;
    }
}
