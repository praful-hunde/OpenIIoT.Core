﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Symbiote.Core.Plugin;

namespace Symbiote.Plugin.Connector.Simulator
{
    public class Plugin : IConnector
    {
        private IConnectorItem itemRoot;
        
        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public Version Version { get; private set; }
        public PluginType PluginType { get; private set; }
        public string InstanceName { get; private set; }
        public bool Browseable { get { return true; } }
        public bool Writeable { get { return false; } }

        public Plugin(string instanceName)
        {
            InstanceName = instanceName;

            Name = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            Namespace = System.Reflection.Assembly.GetEntryAssembly().GetTypes()[0].Namespace;
            Version = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            PluginType = PluginType.Connector;
            InitializeItems();
        }

        public List<IConnectorItem> Browse(IConnectorItem root)
        {
            return (root == null ? itemRoot.Children : root.Children);
        }

        public object Read(string value)
        {
            double val = DateTime.Now.Second;
            switch(value.Split('.')[3])
            {
                case "Sine":
                    return Math.Sin(val);
                case "Cosine":
                    return Math.Cos(val);
                case "Tangent":
                    return Math.Tan(val);
                case "Ramp":
                    return val;
                case "Step":
                    return val % 5;
                case "Toggle":
                    return val % 2;
                default:
                    return 0;
            }
                
        }

        public void Write(string item, object value)
        {
            throw new NotImplementedException();
        }

        private void InitializeItems()
        {
            // instantiate an item root
            itemRoot = new PluginConnectorItem("Items");
            itemRoot.SetItemAsRoot(InstanceName);

            // create some simulation items
            IConnectorItem mathRoot = itemRoot.AddChild(new PluginConnectorItem("Math"));
            mathRoot.AddChild(new PluginConnectorItem("Sine", typeof(double), "Sine"));
            mathRoot.AddChild(new PluginConnectorItem("Cosine", typeof(double), "Cosine"));
            mathRoot.AddChild(new PluginConnectorItem("Tangent", typeof(double), "Tangent"));

            IConnectorItem processRoot = itemRoot.AddChild(new PluginConnectorItem("Process"));
            processRoot.AddChild(new PluginConnectorItem("Ramp", typeof(double), "Ramp"));
            processRoot.AddChild(new PluginConnectorItem("Step", typeof(double), "Step"));
            processRoot.AddChild(new PluginConnectorItem("Toggle", typeof(double), "Toggle"));
        }
    }

    public class PluginConnectorItem : IConnectorItem
    {
        public IConnectorItem Parent { get; private set; }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string FQN { get; private set; }
        public Type Type { get; private set; }
        public string SourceAddress { get; private set; }
        public List<IConnectorItem> Children { get; private set; }
        public string InstanceName { get; private set; }

        public PluginConnectorItem(string name) : this(name, typeof(void), "") { }
        public PluginConnectorItem(string name, Type type, string sourceAddress)
        {
            Name = name;
            Path = "";
            FQN = "";
            Type = type;
            SourceAddress = sourceAddress;
            Children = new List<IConnectorItem>();
        }

        public bool HasChildren()
        {
            return (Children.Count > 0);
        }

        public IConnectorItem AddChild(IConnectorItem child)
        {
            Children.Add(child.SetParent(this));
            return child;
        }

        public IConnectorItem SetParent(IConnectorItem parent)
        {
            Path = parent.FQN;
            FQN = Path + "." + Name;
            return this;
        }

        public IConnectorItem SetItemAsRoot(string instanceName)
        {
            InstanceName = instanceName;
            this.FQN = InstanceName;
            this.SetParent(this);
            return this;
        }

        public void Refresh()
        {

        }
    }
}