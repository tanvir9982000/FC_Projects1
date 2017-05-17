using System;
using Slb.Ocean.Core;
using Slb.Ocean.Petrel;
using Slb.Ocean.Petrel.UI;
using Slb.Ocean.Petrel.Workflow;

namespace FracScope
{
    /// <summary>
    /// This class will control the lifecycle of the Module.
    /// The order of the methods are the same as the calling order.
    /// </summary>
    public class Module : IModule
    {
        #region Private Variables
        private Process m_fracscopeInstance;
        #endregion
        public Module()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        #region IModule Members

        /// <summary>
        /// This method runs once in the Module life; when it loaded into the petrel.
        /// This method called first.
        /// </summary>
        public void Initialize()
        {
            // TODO:  Add Module.Initialize implementation
        }

        /// <summary>
        /// This method runs once in the Module life. 
        /// In this method, you can do registrations of the not UI related components.
        /// (eg: datasource, plugin)
        /// </summary>
        public void Integrate()
        {
            
            // TODO:  Add Module.Integrate implementation
            
            // Register FracScope
            FracScope fracscopeInstance = new FracScope();
            PetrelSystem.WorkflowEditor.AddUIFactory<FracScope.Arguments>(new FracScope.UIFactory());
            PetrelSystem.WorkflowEditor.Add(fracscopeInstance);
            m_fracscopeInstance = new Slb.Ocean.Petrel.Workflow.WorkstepProcessWrapper(fracscopeInstance);
            PetrelSystem.ProcessDiagram.Add(m_fracscopeInstance, "Plug-ins");
        }

        /// <summary>
        /// This method runs once in the Module life. 
        /// In this method, you can do registrations of the UI related components.
        /// (eg: settingspages, treeextensions)
        /// </summary>
        public void IntegratePresentation()
        {

            // TODO:  Add Module.IntegratePresentation implementation
        }

        /// <summary>
        /// This method called once in the life of the module; 
        /// right before the module is unloaded. 
        /// It is usually when the application is closing.
        /// </summary>
        public void Disintegrate()
        {
            // TODO:  Add Module.Disintegrate implementation
            // Unregister FracScope
            PetrelSystem.WorkflowEditor.RemoveUIFactory<FracScope.Arguments>();
            PetrelSystem.ProcessDiagram.Remove(m_fracscopeInstance);
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            // TODO:  Add Module.Dispose implementation
        }

        #endregion

    }


}