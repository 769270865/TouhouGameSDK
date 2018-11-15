using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core.Enemy;

namespace Touhou.Core.Player.Data
{
    [Serializable]
    public class SelectedGame : IEquatable<SelectedGame>
    {
        public SelectedCharacter SelectedCharacter { get; set; }
        public SelectedStages SelectedStages { get; set; }

        public SelectedGame(SelectedCharacter selectedCharacter, SelectedStages selectedStages)
        {
            SelectedCharacter = selectedCharacter;
            SelectedStages = selectedStages;
        }

        public override bool Equals(object obj)
        {
            return obj is SelectedGame && Equals(obj as SelectedGame);
        }


        public bool Equals(SelectedGame obj)
        {
            if (obj == null)
            {
                return false;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return SelectedCharacter.Equals(obj.SelectedCharacter) && SelectedStages.Equals(obj.SelectedStages);

        }

        public override int GetHashCode()
        {
            var hashCode = 1448281622;
            hashCode = hashCode * -1521134295 + SelectedCharacter.GetHashCode();
            hashCode = hashCode * -1521134295 + SelectedStages.GetHashCode();
            return hashCode;
        }
    }
}
