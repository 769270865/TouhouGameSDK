using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou.Core.Player.Action
{
    /// Interface for Player Command Recording for Player Replays 
    public interface IPlayerCommandRecorder
    {
        List<PlayerCommand> RecordedCommand { get;  }
        float RecoredTime { get; }
        void AddCommand(PlayerCommand command);
       

    }
}
