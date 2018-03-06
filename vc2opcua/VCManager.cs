﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using Caliburn.Micro;
using VisualComponents.Create3D;
using VisualComponents.UX.Shared;
using log4net.Appender;

namespace vc2opcua
{
    class VcManager
    {
        // Accesses the application itself, initialize to null for avoiding compiling errors
        [Import]
        IApplication _application = null;

        ReadOnlyCollection<ISimComponent> _components;

        IMessageService _ms = IoC.Get<IMessageService>();
        log4net.ILog logger;

        public void GetComponentProperties()
        {
            _application = IoC.Get<IApplication>();
            _components = _application.World.Components;

            foreach (ISimComponent comp in _components)
            {
                Debug.WriteLine(comp.Name);
                foreach (IProperty property in comp.Properties)
                {
                    Debug.WriteLine("  " + property.Name);
                }
            }


        }

        public void VcWriteWarningMsg(string message)
        {
            _ms.AppendMessage(message, MessageLevel.Warning);
        }
    }
}
