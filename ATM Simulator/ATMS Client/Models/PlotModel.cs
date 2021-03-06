﻿using System.ComponentModel;
using ATMS_Model;

namespace ATMS_Client.Models
{
    public class PlotModel : INotifyPropertyChanged
    {
        //a test constructor to initialize a plot with the minimum required arguments
        public PlotModel(Plot data)
        {
            this._plot = data;
        }
        private Plot _plot;
        /// <summary>
        /// Gets or set the plotmodel data
        /// </summary>
        public Plot plot
        {
            get { return _plot; }
            set
            {
                _plot = value;
                OnPropertyChanged("plot");

            }
        }

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        public override string ToString()
        {
            return _plot.test;
        }
    }
}
