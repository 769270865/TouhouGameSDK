using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.Core.Enemy
{
    [Serializable]
    public struct SelectedStages : IEquatable<SelectedStages>
    {
        public SelectedStages(int mainStageID, StageDiffculity diffculity)
        {
            MainStageID = mainStageID;
            Diffculity = diffculity;
        }


        public int MainStageID;
        public enum StageDiffculity
        {
            Easy, Normal, Hard, Lunatic, Extra, Phantasm

        }
        public StageDiffculity Diffculity;

        public override bool Equals(object obj)
        {
            if (obj is SelectedStages)
            {
                return this.Equals((SelectedStages)obj);
            }
            else
                return false;


        }
        public bool Equals(SelectedStages other)
        {
            if (other.GetType() != this.GetType())
            {
                return false;
            }

            return other.MainStageID == MainStageID && other.Diffculity == Diffculity;
        }
        public override int GetHashCode()
        {
            
            var hashCode = -485574400;
            hashCode = hashCode * -1521134295 + MainStageID.GetHashCode();
            hashCode = hashCode * -1521134295 + Diffculity.GetHashCode();
            return hashCode;
        }
    }
}
