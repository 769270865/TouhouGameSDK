namespace Touhou.Core.Enemy
{
    public interface IEnemyComponentTimerHealth
    {
        IEnemyHealth Health { get; set; }
        IEnemyCountDownTimer Timer { get; set; }
    }
}