namespace Touhou.Core.Player.Action
{
    /// <summary>
    /// Interface for player weapons,accessory, bullets, focused unfocused apperance, boom and dynmic speed
    /// </summary>
    public interface IPlayerWeapon
    {
        void SetFocused();
        void SetUnFocused();

        void Boom();

        void StartShoot();
        void StopShooting();

        float GetPlayerCurrentSpeed(PlayerCommand playerCommand);
    }
}