using System;

namespace Touhou.Core.Player.Data
{
    [Serializable]
    public struct SelectedCharacter : IEquatable<SelectedCharacter>
    {
        public int SelectedPlayerID;
        public int SelectedShootTypeID;

        public SelectedCharacter(int selectedPlayerID, int selectedShootTypeID)
        {
            SelectedPlayerID = selectedPlayerID;
            SelectedShootTypeID = selectedShootTypeID;
        }

        public override bool Equals(object obj)
        {
            if (obj is SelectedCharacter)
            {
                return this.Equals((SelectedCharacter)obj);
            }
            else
                return false;
        }

        public bool Equals(SelectedCharacter other)
        {
            if (other.GetType() != this.GetType())
            {
                return false;
            }

            return other.SelectedPlayerID == SelectedPlayerID && other.SelectedShootTypeID == SelectedShootTypeID;
        }

        public override int GetHashCode()
        {
            var hashCode = -894429566;
            hashCode = hashCode * -1521134295 + SelectedPlayerID.GetHashCode();
            hashCode = hashCode * -1521134295 + SelectedShootTypeID.GetHashCode();
            return hashCode;
        }
    }
}