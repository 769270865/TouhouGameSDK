using System;

namespace Touhou.Core.Enemy
{
    public class EnemyHealth : IEnemyHealth
    {
        public EnemyHealth(int health)
        {
            Health = health;
        }

        public int Health { get; private set; }


        public bool ActiveState { get; private set; }

        public event EventHandler<EventArgs> OnHealthReachZero;

        public void DecreseHealth(int healthLoss)
        {
            if (ActiveState && Health > 0)
                Health -= healthLoss;

            if (Health <= 0)
                OnHealthReachZero?.Invoke(this, new EventArgs());

        }

        public void SetHealthActive(bool value)
        {
            ActiveState = value;
        }
    }
}