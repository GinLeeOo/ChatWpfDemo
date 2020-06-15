using PropertyChanged;
using System.ComponentModel;

namespace Fasetto.Word

{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    
     [ImplementPropertyChanged]
    public class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => {

        };

        /// <summary>
        /// call this is to fire <see cref="PropertyChanged"/> event
        /// </summary>
        /// <param name="name"></param>

        public void OnPropertyChanged(string name)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(name));
          
        }
    }
}
