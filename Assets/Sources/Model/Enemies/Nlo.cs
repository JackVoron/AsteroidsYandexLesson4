using System;
using UnityEngine;

namespace Asteroids.Model
{
    public class Nlo : Enemy
    {
        private readonly float _speed;
        private readonly EnemiesTeams _team;
        private Transformable _target;

        public Nlo(Transformable target, Vector2 position, float speed, EnemiesTeams team = EnemiesTeams.AgainstPlayer) : base(position, 0)
        {
            Target = target;
            _speed = speed;
            _team = team;
        }

        public override void Update(float deltaTime)
        {
            Vector2 nextPosition = Vector2.MoveTowards(Position, Target.Position, _speed * deltaTime);
            MoveTo(nextPosition);
            LookAt(Target.Position);
        }

        private void LookAt(Vector2 point)
        {
            Rotate(Vector2.SignedAngle(Quaternion.Euler(0, 0, Rotation) * Vector3.up, (Position - point)));
        }

        public EnemiesTeams Team { get => _team; }

        public Transformable Target { get => _target; set => _target = value; }
    }
}
