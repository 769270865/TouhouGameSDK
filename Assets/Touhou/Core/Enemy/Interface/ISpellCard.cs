namespace Touhou.Core.Enemy
{
    public interface ISpellCard
    {
        IEnemyHealth Health { get; set; }
        IEnemyCountDownTimer Timer { get; set; }
        string SpellCardName { get; set; }
    }
}