using System;

namespace Touhou.Core.Enemy
{
    [Serializable]
    public struct EnemyComponentID : IEquatable<EnemyComponentID>
    {

        public readonly SelectedStages.StageDiffculity StageDiffculity;
        public enum EnemyComponentType
        {
            SpellCard, BulletPattern, Boss
        }
        public readonly EnemyComponentType ComponentType;
        public readonly int ComponentID;

        public EnemyComponentID(SelectedStages.StageDiffculity stageDiffculity, EnemyComponentType componentType, int componentID)
        {
            StageDiffculity = stageDiffculity;
            ComponentType = componentType;
            ComponentID = componentID;
        }

        public override bool Equals(object obj)
        {
            return obj is EnemyComponentID && Equals((EnemyComponentID)obj);
        }

        public bool Equals(EnemyComponentID other)
        {
            return StageDiffculity == other.StageDiffculity &&
                   ComponentType == other.ComponentType &&
                   ComponentID == other.ComponentID;
        }

        public override int GetHashCode()
        {
            var hashCode = 228261519;
            hashCode = hashCode * -1521134295 + StageDiffculity.GetHashCode();
            hashCode = hashCode * -1521134295 + ComponentType.GetHashCode();
            hashCode = hashCode * -1521134295 + ComponentID.GetHashCode();
            return hashCode;
        }
    }
}