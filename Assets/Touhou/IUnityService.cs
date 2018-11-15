using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core
{
    public interface IUnityService
    {
        float GetAxisRaw(string axisName);
        float GetAxis(string axisName);
        bool GetKeyDown(KeyCode key);

    }
}
