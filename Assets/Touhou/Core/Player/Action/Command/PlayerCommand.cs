using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Player.Action
{
    public struct PlayerCommand
    {
        public float X_Input, Y_Input;

        /// <summary>
        /// isFocused is a toga switch, onece a command is send with isFocuse set to true
        /// player is in Focused mode untile a command with isFocused is false been sent
        /// </summary>
        public bool IsFocused;
        /// <summary>
        /// isShooting is a toga switch, onece a command is send with IsShooting set to true
        /// player is to continue shooting untile a command with IsShooting is false been sent
        /// </summary>
        public bool IsShooting;
        /// <summary>
        /// IsBoomUsed is a single active switch, onece it is set to true, boom is only used for onece
        /// the boom wil not be activeted untill a false followed by a true is recived
        /// </summary>
        public bool IsBoomUsed;

        public float CommandTime;

        public PlayerCommand(Vector2 translationVector, bool isFocused, bool isShooting, bool isBoomUsed, float time)
        {

            IsFocused = isFocused;
            IsShooting = isShooting;
            IsBoomUsed = isBoomUsed;
            CommandTime = time;

            X_Input = translationVector.x;
            Y_Input = translationVector.y;
        }
    }
}
