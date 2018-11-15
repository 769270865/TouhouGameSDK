using System;

namespace Touhou.Core.Enemy
{
    public interface IEnemyHealth
    {
        int Health { get; }
        bool ActiveState { get; }
        void DecreseHealth(int healthLoss);
        void SetHealthActive(bool value);
        event EventHandler<EventArgs> OnHealthReachZero;
    }
}