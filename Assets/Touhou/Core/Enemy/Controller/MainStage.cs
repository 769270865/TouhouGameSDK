using Sirenix.OdinInspector;
using Sirenix.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Touhou.Core.Enemy.Controller
{
    public class MainStage : SerializedMonoBehaviour
    {
        [NonSerialized] [OdinSerialize]       
        public MainStageCatainer MainStageData;
        public List<IStage> Stages { get { return MainStageData.Stages; } }



        public IStage CurrentRunningStage { get; private set; }
        int currentStageIndex;

        public event EventHandler<EventArgs> OnAllStageFinish;
        public event EventHandler<EventArgs> OnStageChange;

        public MainStage InstiatiateMainStage()
        {
            GameObject thisObject = Instantiate(gameObject);
            return thisObject.GetComponent<MainStage>();
        }

        public void StartMainStage()
        {
            currentStageIndex = 0;
            CurrentRunningStage = Stages[currentStageIndex].InstiatiateStage();
            CurrentRunningStage.OnStageEnded += onCurrentStageOver;
            CurrentRunningStage.OnStageEnded += OnStageChange;
            CurrentRunningStage.ActiveStage();


            Debug.Log(OnAllStageFinish != null);

        }

        void onCurrentStageOver(object sender, EventArgs args)
        {
            tearDownCurrentStage();
            setUpNextStage();
        }
        private void tearDownCurrentStage()
        {
            CurrentRunningStage.OnStageEnded -= onCurrentStageOver;
            CurrentRunningStage.OnStageEnded -= OnStageChange;
        }


        void setUpNextStage()
        {
            currentStageIndex++;
            if (currentStageIndex > Stages.Count - 1)
            {
                allStageOver();

            }
            else
            {
                continueToNextStage();
            }
        }
        private void continueToNextStage()
        {
            CurrentRunningStage = Stages[currentStageIndex].InstiatiateStage();
            //Subscribe events         
            CurrentRunningStage.OnStageEnded += onCurrentStageOver;
            CurrentRunningStage.OnStageEnded += OnStageChange;
            CurrentRunningStage.ActiveStage();


        }
        private void allStageOver()
        {
            OnAllStageFinish?.Invoke(this, new EventArgs());

            OnStageChange = null;
            OnAllStageFinish = null;
        }
    }
}
