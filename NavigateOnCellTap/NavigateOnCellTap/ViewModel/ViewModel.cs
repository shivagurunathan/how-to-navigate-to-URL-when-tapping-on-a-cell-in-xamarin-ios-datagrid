using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;


namespace NavigateOnCellTap
{
    public class ViewModel:INotifyPropertyChanged
    {
        public ViewModel()
        {
            SetRowstoGenerate(100);
        }

        #region ItemsSource

        public OrderInfoRepository order;

        private ObservableCollection<OrderInfo> ordersInfo;

        public ObservableCollection<OrderInfo> OrdersInfo
        {
            get { return ordersInfo; }
            set { this.ordersInfo = value; RaisePropertyChanged("OrdersInfo"); }
        }

        #endregion

        #region ItemSource Generator

        public void SetRowstoGenerate(int count)
        {
            order = new OrderInfoRepository();
            ordersInfo = order.GetOrderDetails(count);
        }

        #endregion

        private Random random = new Random();

        internal void ItemsSourceRefresh()
        {
            var count = random.Next(1, 6);

            for (int i = 11000; i < 11000 + count; i++)
            {
                int val = i + random.Next(100, 150);
                this.OrdersInfo.Insert(0, order.RefreshItemsource(val));
            }
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(String name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        #endregion


    }
}