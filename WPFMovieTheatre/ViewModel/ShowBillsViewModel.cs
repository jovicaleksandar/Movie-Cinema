using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPFMovieTheatre.Command;
using WPFMovieTheatre.Model;

namespace WPFMovieTheatre.ViewModel
{
    class ShowBillsViewModel : INotifyPropertyChanged
    {
        public int TableID { get; set; }
        public string TableName { get; set; }
        public bill SelectedBill { get; set; }
        public string BillAmount { get; set; }
        public string BillEditAmount { get; set; }
        public Window Window { get; set; }
        private ObservableCollection<bill> billsList;
        public ObservableCollection<bill> BillsList
        {
            get
            {
                return billsList;
            }
            set
            {
                billsList = value;
                OnPropertyChanged("BillsList");
            }
        }
        public ICommand AddBillCommand
        {
            get;
            private set;
        }
        public ICommand EditBillCommand
        {
            get;
            private set;
        }
        public ICommand RemoveBillCommand
        {
            get;
            private set;
        }

        public ShowBillsViewModel(int id, string name)
        {
            BillsList = new ObservableCollection<bill>();
            AddBillCommand = new AddBillCommand(this);
            RemoveBillCommand = new RemoveBillCommand(this);
            EditBillCommand = new EditBillCommand(this);


            using (var db = new NewBioskopEntities())
            {
                Table table = db.Tables.FirstOrDefault(x => x.tableid == id);
                foreach (bill b in db.bills)
                {
                    if (b.table_tableid == table.tableid)
                        BillsList.Add(b);
                }
            }
        }

        #region Add Bill
        public bool CanAddBill
        {
            get
            {
                return !String.IsNullOrWhiteSpace(BillAmount);
            }
        }

        public void AddBill()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    int billamount = 0;
                    Int32.TryParse(BillAmount, out billamount);
                    bill bill = new bill();

                    byte[] giid = Guid.NewGuid().ToByteArray();
                    int id = BitConverter.ToInt32(giid, 0);

                    bill.billid = id;
                    bill.billid1 = bill.billid;
                    bill.billamount = billamount;
                    bill.billdatetime = DateTime.Now;
                    Table table = db.Tables.FirstOrDefault(x => x.tablename == TableName);
                    bill.table_tableid = table.tableid;

                    db.bills.Add(bill);

                    db.SaveChanges();
                    if (bill.table_tableid < 4)
                        bill.billamount += bill.billamount;

                    billsList.Add(bill);

                    MessageBox.Show("Bill was successfully added!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Remove Bill
        public bool CanRemoveBill
        {
            get
            {
                return SelectedBill == null ? false : true;
            }
        }

        public void RemoveBill()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    bill bill = db.bills.FirstOrDefault(x => x.billid == SelectedBill.billid);

                    if (bill != null)
                    {
                        db.bills.Remove(bill);
                        db.SaveChanges();
                        bill temp = billsList.FirstOrDefault(x => x.billid == bill.billid);
                        billsList.Remove(temp);

                        MessageBox.Show("Bill was successfully removed!");
                    }
                    else
                    {
                        MessageBox.Show("That bill doesn't exist!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Edit Bill

        public bool CanEditBill
        {
            get
            {
                return !String.IsNullOrWhiteSpace(BillEditAmount);
            }
        }

        public void EditBill()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    bill bill = db.bills.FirstOrDefault(x => x.billid == SelectedBill.billid);

                    if (bill != null)
                    {
                        bill temp = billsList.FirstOrDefault(x => x.billid == bill.billid);
                        billsList.Remove(temp);
                        int amount = 0;
                        Int32.TryParse(BillEditAmount, out amount);
                        bill.billamount = amount;
                        db.bills.AddOrUpdate(bill);
                        db.SaveChanges();
                        billsList.Add(bill);

                        MessageBox.Show("Bill has been updated!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region INotifyPropertyChanged
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
    }
}
