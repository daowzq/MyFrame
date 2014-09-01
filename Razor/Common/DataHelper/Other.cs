using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;

namespace Razor.DataHelper
{
    public delegate void RazorPropertyChangedEventHandler(object sender, RazorPropertyChangedEventArgs e);
    public interface IAimNotifyPropertyChanged
    {
        // Events
        event RazorPropertyChangedEventHandler RazorPropertyChanged;
    }

    #region 事件属性
    [HostProtection(SecurityAction.LinkDemand, SharedState = true)]
    public class PropertyChangedEventArgs : EventArgs
    {
        // Fields
        private readonly string propertyName;

        // Methods
        public PropertyChangedEventArgs(string propertyName)
        {
            this.propertyName = propertyName;
        }

        // Properties
        public virtual string PropertyName
        {
            get
            {
                return this.propertyName;
            }
        }
    }

    public class RazorPropertyChangedEventArgs : PropertyChangedEventArgs
    {
        // Methods
        public RazorPropertyChangedEventArgs(string propertyName, object oldValue, object newValue)
            : base(propertyName)
        {
            this.OldValue = oldValue;
            this.NewValue = newValue;
        }

        // Properties
        public object NewValue { get; private set; }

        public object OldValue { get; private set; }
    }
    #endregion
}
