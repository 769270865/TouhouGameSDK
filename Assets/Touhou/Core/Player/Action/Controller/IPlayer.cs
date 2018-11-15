using System;

namespace Touhou.Core.Player.Action
{
    internal interface IPlayer
    {
        int PlayerContinues { get; }
        int PlayerLife { get; }
        int playerLifeTotal { get; }

        int PlayerBoom { get; }
        int PlayerBoomTotal { get; }

        int PlayerPower { get; }
        

        event EventHandler<EventArgs> OnPlayerHit;
        event EventHandler<EventArgs> OnPlayerLifeReachZero;
        event EventHandler<EventArgs> OnPlayerContinuesReachZero;
        event EventHandler<EventArgs> OnPlayerUseContinues;

        void UseContinue();
        
    }

}