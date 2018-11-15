using Touhou.Core.Enemy;

namespace Touhou.Core.Enemy
{
    public interface IBulletPattern
    {
        IEnemyHealth Health { get; set; }
        IEnemyCountDownTimer Timer { get; set; }
    }
}