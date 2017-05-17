using System;
using System.Collections.Generic;

using Slb.Ocean.Core;

namespace FracScope
{
    public class Plugin : Slb.Ocean.Core.Plugin
    {
        public override string AppVersion
        {
            get { return "2014.1"; }
        }

        public override string Author
        {
            get { return "Bengal Tigers"; }
        }

        public override string Contact
        {
            get { return "bengaltigers@gmail.com"; }
        }

        public override IEnumerable<PluginIdentifier> Dependencies
        {
            get { return null; }
        }

        public override string Description
        {
            get { return "FracScope is an exploration plugin based on latest technology to provide critical insight to best zone for fracturing. It provides quantitative and qualitative tools from wireline logging data. The user will be able to calculate relevant geological and petrophysical properties such as shale volume, Uranium to Thorium ratio and pore fractions (organic pore, fracture pore, TOC, clay pore and inter-particle pore). The plugin also provides elastic and engineering properties for isotropic and anisotropic cases to choose the best fracture-able zones."; }
        }

        public override string ImageResourceName
        {
            get { return null; }
        }

        public override Uri PluginUri
        {
            get { return new Uri("http://www.pluginuri.info"); }
        }

        public override IEnumerable<ModuleReference> Modules
        {
            get 
            {
                // Please fill this method with your modules with lines like this:
                //yield return new ModuleReference(typeof(Module));
                yield return new ModuleReference(typeof(Module));

            }
        }

        public override string Name
        {
            get { return "Plugin"; }
        }

        public override PluginIdentifier PluginId
        {
            get { return new PluginIdentifier(GetType().FullName, GetType().Assembly.GetName().Version); }
        }

        public override ModuleTrust Trust
        {
            get { return new ModuleTrust("Default"); }
        }
    }
}
