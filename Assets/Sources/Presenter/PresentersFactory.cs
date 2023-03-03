using UnityEngine;
using Asteroids.Model;
using System;

public class PresentersFactory : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private Presenter _laserGunBulletTemplate;
    [SerializeField] private Presenter _defaultGunBulletTemplate;
    [SerializeField] private Presenter _asteroidTemplate;
    [SerializeField] private Presenter _asteroidPartTemplate;
    [SerializeField] private Presenter _nloTemplate;
    [SerializeField] private Presenter _redNloTemplate;
    [SerializeField] private Presenter _blueNloTemplate;

    public void CreateBullet(Bullet bullet)
    {
        if(bullet is LaserGunBullet)
            CreatePresenter(_laserGunBulletTemplate, bullet);
        else
            CreatePresenter(_defaultGunBulletTemplate, bullet);
    }

    public void CreateAsteroidParts(AsteroidPresenter asteroid)
    {
        for (int i = 0; i < 4; i++)
            CreatePresenter(_asteroidPartTemplate, asteroid.Model.CreatePart());
    }

    public void CreateNlo(Nlo nlo)
    {
        switch (nlo.Team)
        {
            case EnemiesTeams.AgainstPlayer:
                CreatePresenter(_nloTemplate, nlo);
                break;
            case EnemiesTeams.Red:
                CreatePresenter(_redNloTemplate, nlo);
                break;
            case EnemiesTeams.Blue:
                CreatePresenter(_blueNloTemplate, nlo);
                break;
        }
    }

    public void CreateAsteroid(Asteroid asteroid)
    {
        AsteroidPresenter presenter = CreatePresenter(_asteroidTemplate, asteroid) as AsteroidPresenter;
        presenter.Init(this);
    }

    private Presenter CreatePresenter(Presenter template, Transformable model)
    {
        Presenter presenter = Instantiate(template);
        presenter.Init(model, _camera);

        return presenter;
    }
}
