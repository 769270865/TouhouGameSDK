namespace Touhou.Core.Enemy
{
    public interface IBoss
    {
        string BossName { get; }
        int TotalSpellCount { get; }
        int SpellLeft { get; }

        IEnemyComponent CurrentEnemy { get; }
        int CurrentEnenmyIndex { get; }

    }
}