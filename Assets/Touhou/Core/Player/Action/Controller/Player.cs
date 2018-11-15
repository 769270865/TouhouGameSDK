using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touhou.Core.Configuration;
using UnityEngine;

namespace Touhou.Core.Player.Action
{
    /// <summary>
    /// Excuting the player input command, attach this to player GameObject
    /// </summary>
    public class Player : MonoBehaviour,IPlayer
    {
        IPlayerWeapon playerweapon;

        #region PlayerCommand
        private PlayerCommand _currentCommand;
        public PlayerCommand CurrentCommand
        {
            private get { return _currentCommand;}              
            
            set
            {
                _currentCommand = value;
                hasCommandExcuted = false;
            }
        }
        bool hasCommandExcuted;
        #endregion

        #region PlayerData
        public int PlayerContinues {get; private set;}
        public int PlayerLife{get; private set;}
        public int playerLifeTotal { get; private set; }

        public int PlayerBoom  { get;private set;}
        public int PlayerBoomTotal { get; private set; }

        public int PlayerPower {get;private set;}
        #endregion

        public event EventHandler<EventArgs> OnPlayerHit;
        public event EventHandler<EventArgs> OnPlayerLifeReachZero;  
        // Player is defeated when there is no continues left and no life left
        public event EventHandler<EventArgs> OnPlayerContinuesReachZero;
        public event EventHandler<EventArgs> OnPlayerUseContinues;

        private void Start()
        {
            playerweapon = GetComponent<IPlayerWeapon>();
            playerLifeTotal = SettingContext.CurrentSetting.PlayerLife;
            PlayerBoomTotal = SettingContext.CurrentSetting.PlayerBoom;
        }
        private void Update()
        {
            ExcuteCommand();

            ExcuteTranslation();
        }
        void ExcuteTranslation()
        {
            float playerSpeed = playerweapon.GetPlayerCurrentSpeed(_currentCommand);
            gameObject.transform.Translate(_currentCommand.X_Input * playerSpeed, _currentCommand.Y_Input* playerSpeed, 0);
        }
        void ExcuteCommand()
        {
            if (!hasCommandExcuted)
            {

                if (_currentCommand.IsBoomUsed && PlayerBoom > 0)
                {
                    playerweapon.Boom();
                    PlayerBoom--;
                }
                   

                if (_currentCommand.IsFocused)
                    playerweapon.SetFocused();
                else
                    playerweapon.SetUnFocused();

                if (_currentCommand.IsShooting)
                    playerweapon.StartShoot();
                else
                    playerweapon.StopShooting();
            }       

            hasCommandExcuted = true;
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            playerHitDamage(collision);
            playerItemCatch(collision);
        }

        private void playerItemCatch(Collision2D collision)
        {
            if (collision.gameObject.tag == GameObjectTags.PLAYER_LIFE_DROPITEM) { PlayerLife++; }
            if (collision.gameObject.tag == GameObjectTags.PLAYER_BOOM_DROPITEM) { PlayerBoom++; }

            if (collision.gameObject.tag == GameObjectTags.PLAYER_POWERUP_DROPITEM)
                PlayerPower += collision.gameObject.GetComponent<PowerUpDropItem>().PowerLevel;
        }

        private void playerHitDamage(Collision2D collision)
        {
            if (collision.gameObject.tag == GameObjectTags.BOSS || collision.gameObject.tag == GameObjectTags.ENEMY_BULLET)
            {
                playerHit();
            }
        }

        void playerHit()
        {
            //If this is the last life player has
            if (PlayerLife == 1)
            {
                PlayerLife--;

                // If there are no more continues left
                if (PlayerContinues == 0)
                    OnPlayerContinuesReachZero.Invoke(this, new EventArgs());
                
                OnPlayerLifeReachZero.Invoke(this,new EventArgs());
               
            }
            else
            {
                PlayerLife--;
                OnPlayerHit.Invoke(this, new EventArgs());
            }
        }

        public void UseContinue()
        {
            if (PlayerLife == 0 && PlayerContinues > 0)
            {
                PlayerContinues--;
                PlayerLife = playerLifeTotal; 
                PlayerBoom = PlayerBoomTotal;
                OnPlayerUseContinues.Invoke(this, new EventArgs());
            }
            else
            {
                throw new ArgumentException($"Use of continue fialed, PlayerLife : {PlayerLife} , PlayerContinues Remain : {PlayerContinues}");
            }
        }
    }
}
