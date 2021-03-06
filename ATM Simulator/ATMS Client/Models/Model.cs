﻿using ATMS_Client.ServiceReference1;
using ATMS_Client.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMS_Client.Models
{
    class Model : IServerInterfaceCallback
    {


        private int clientID = 0;
        private ServerInterfaceClient c1;


        public string someData;
        private ViewModel viewModel;


        public Model(ViewModel viewModel)
        {
            // Construct InstanceContext to handle messages on callback interface
            InstanceContext instanceContext = new InstanceContext(this);

            //create a client
            this.c1 = new ServerInterfaceClient(instanceContext);

            this.viewModel = viewModel;
        }

        #region service methods
        public void poke()
        {
            viewModel.plotModel = new PlotModel(c1.ReturnPoke());
        }

        public void register()
        {
            
            clientID = c1.RegisterClient(clientID);
            viewModel.serverAvailable = true;
        }

        public void newScenario()
        {
            c1.createSimulation();
        }
        #endregion

        #region callback methods
        public void updateClient(string data)
        {
            viewModel.callbackBox = data;
        }

        public void notifyNewScenario(string data)
        {
            viewModel.newScenarioString = data;
        }
        #endregion
    }
}
