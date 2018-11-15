using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Touhou.Core;
using Touhou.Core.Configuration;
using Zenject;

namespace Touhou.Core.Player.Action
{
    public class PlayerCommandGenerator : MonoBehaviour
    {
        Player playerController;
        IPlayerCommandRecorder playerCommandRecorder;
        IUnityService unityService;

        PlayerCommand perivousCommand;

        KeyCode focusedKey, boomKey,shootKey;
       

        [Inject]
        public void Construct(IPlayerCommandRecorder playerCommandRecorder,IUnityService unityService)
        {
            this.playerCommandRecorder = playerCommandRecorder;
            this.unityService = unityService;
        }


        private void Start()
        {
            intializePlayreCommand();

            getCurrentPlayerSetting();

        }

        private void intializePlayreCommand()
        {
            playerController = FindObjectOfType<Player>();
            perivousCommand = new PlayerCommand() { IsBoomUsed = false, IsFocused = false, IsShooting = false, X_Input = 0, Y_Input = 0, CommandTime = 0 };
            playerController.CurrentCommand = perivousCommand;
            playerCommandRecorder.AddCommand(perivousCommand);
        }

        private void getCurrentPlayerSetting()
        {
            focusedKey = SettingContext.CurrentSetting.FocuseKey;
            boomKey = SettingContext.CurrentSetting.BoomKey;
            shootKey = SettingContext.CurrentSetting.ShootKey;
            
        }

        private void Update()
        {

            // If the last frame command's IsBoomUsed is true, force the new command IsBoomUsed to false, Boom act as a one time switch
            if (perivousCommand.IsBoomUsed == true)
            {
                generateNewCommandWithNoBoomUsed();

            }
            else
            {
                generateNewCommand();
            }
        }

        private void generateNewCommandWithNoBoomUsed()
        {
            PlayerCommand playerCommand = generatePlayerCommandWithNoBoom();
            playerCommand.IsBoomUsed = false;

            setNewCommand(playerCommand);
        }

        private void generateNewCommand()
        {
            PlayerCommand playerCommand = generatePlayerCommandWithNoBoom();
            playerCommand.IsBoomUsed = unityService.GetKeyDown(boomKey);

            if (hasCommandChanged(playerCommand))
            {
                setNewCommand(playerCommand);

            }
        }

        private void setNewCommand(PlayerCommand playerCommand)
        {
            perivousCommand = playerCommand;
            playerController.CurrentCommand = playerCommand;
            playerCommandRecorder.AddCommand(playerCommand);
        }

        PlayerCommand generatePlayerCommandWithNoBoom()
        {
            PlayerCommand playerCommand = new PlayerCommand();
            float x_input = unityService.GetAxisRaw("Horizontal");
            float y_input = unityService.GetAxisRaw("Vertical"); 

            if (perivousCommand.IsShooting)
                playerCommand.IsShooting = !unityService.GetKeyUp(shootKey);
            else
                playerCommand.IsShooting = unityService.GetKeyDown(shootKey);

            if (perivousCommand.IsFocused)
                playerCommand.IsFocused = !unityService.GetKeyUp(focusedKey);
            else
                playerCommand.IsFocused = unityService.GetKeyDown(focusedKey);

            if (perivousCommand.X_Input != x_input)
                playerCommand.X_Input = x_input;
            else
                playerCommand.Y_Input = y_input;

            return playerCommand;

        }
        bool hasCommandChanged(PlayerCommand currentCommand)
        {
            return false;

        }


        
    }
}
