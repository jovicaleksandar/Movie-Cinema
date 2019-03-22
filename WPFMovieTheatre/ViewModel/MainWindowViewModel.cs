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
using WPFMovieTheatre.View;

namespace WPFMovieTheatre.ViewModel
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        #region Properties
        public string AdminName { get; set; }
        public string AdminSurname { get; set; }
        public string AdminUsername { get; set; }
        public string AdminEmail { get; set; }
        public string WaiterName { get; set; }
        public string WaiterSurname { get; set; }
        public string WaiterUsername { get; set; }
        public string WaiterEmail { get; set; }
        public string TicketSellerName { get; set; }
        public string TicketSellerSurname { get; set; }
        public string TicketSellerUsername { get; set; }
        public string TicketSellerEmail { get; set; }
        public employee SelectedAdmin { get; set; }
        public employee SelectedTicketSeller { get; set; }
        public employee SelectedWaiter { get; set; }
        public string DrinkName { get; set; }
        public string DrinkPrice { get; set; }
        public string SnackName { get; set; }
        public string SnackPrice { get; set; }
        public string SnackEditName { get; set; }
        public string SnackEditPrice { get; set; }
        public string MovieName { get; set; }
        public string MoviePrice { get; set; }
        public Table SelectedTable { get; set; }
        public drink SelectedDrink { get; set; }
        public snack SelectedSnack { get; set; }
        public ticket SelectedMovie { get; set; }
        private BindingList<drink> allDrinks;
        public BindingList<drink> AllDrinks
        {
            get
            {
                return allDrinks;
            }
            set
            {
                allDrinks = value;
                OnPropertyChanged("AllDrinks");
            }
        }
        public List<string> DrinksList
        {
            get
            {
                List<string> drinks = new List<string>();
                foreach (drink d in AllDrinks)
                {
                    drinks.Add(d.drinkname);
                }

                return drinks;
            }
        }
        private ObservableCollection<snack> allSnacks;
        public ObservableCollection<snack> AllSnacks
        {
            get
            {
                return allSnacks;
            }
            set
            {
                allSnacks = value;
                OnPropertyChanged("AllSnacks");
            }
        }
        public List<Table> AllTables
        {
            get
            {
                using (var db = new NewBioskopEntities())
                {
                    return db.Tables.ToList();
                }
            }
        }
        private BindingList<bill> billsList;
        public BindingList<bill> BillsList
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
        private ObservableCollection<ticket> allMovies;
        public ObservableCollection<ticket> AllMovies
        {
            get
            {
                return allMovies;
            }
            set
            {
                allMovies = value;
                OnPropertyChanged("AllMovies");
            }
        }
        private List<int> admins;
        private ObservableCollection<employee> allAdmins;
        public ObservableCollection<employee> AllAdmins
        {
            get
            {
                return allAdmins;
            }
            set
            {
                allAdmins = value;
                OnPropertyChanged("AllAdmins");
            }
        }

        private List<int> waiters;
        private ObservableCollection<employee> allWaiters;
        public ObservableCollection<employee> AllWaiters
        {
            get
            {
                return allWaiters;
            }
            set
            {
                allWaiters = value;
                OnPropertyChanged("AllWaiters");
            }
        }
        private List<int> ticketSellers;
        private ObservableCollection<employee> allTicketSellers;
        public ObservableCollection<employee> AllTicketSellers
        {
            get
            {
                return allTicketSellers;
            }
            set
            {
                allTicketSellers = value;
                OnPropertyChanged("AllTicketSellers");
            }
        }

        #endregion

        #region Commands
        public Window Window { get; set; }
        public ICommand AddDrinkCommand
        {
            get;
            private set;
        }
        public ICommand AddSnackCommand
        {
            get;
            private set;
        }
        public ICommand AddMovieCommand
        {
            get;
            private set;
        }
        public ICommand GetSnackInfoCommand
        {
            get;
            private set;
        }
        public ICommand GetBillsCommand
        {
            get;
            private set;
        }
        public ICommand EditDrinkCommand
        {
            get;
            private set;
        }
        public ICommand EditSnackCommand
        {
            get;
            private set;
        }
        public ICommand RemoveDrinkCommand
        {
            get;
            private set;
        }
        public ICommand RemoveMovieCommand
        {
            get;
            private set;
        }
        public ICommand EditMovieCommand
        {
            get;
            private set;
        }
        public ICommand RemoveSnackCommand
        {
            get;
            private set;
        }
        public ICommand AddAdminCommand
        {
            get;
            private set;
        }
        public ICommand EditAdminCommand
        {
            get;
            private set;
        }
        public ICommand RemoveAdminCommand
        {
            get;
            private set;
        }

        public ICommand AddWaiterCommand
        {
            get;
            private set;
        }
        public ICommand EditWaiterCommand
        {
            get;
            private set;
        }
        public ICommand RemoveWaiterCommand
        {
            get;
            private set;
        }
        public ICommand AddTicketSellerCommand
        {
            get;
            private set;
        }
        public ICommand EditTicketSellerCommand
        {
            get;
            private set;
        }
        public ICommand RemoveTicketSellerCommand
        {
            get;
            private set;
        }
        public ICommand GetAvgPriceCommand
        {
            get;
            private set;
        }

        #endregion

        #region Constructor
        public MainWindowViewModel()
        {
            AddDrinkCommand = new AddDrinkCommand(this);

            GetBillsCommand = new GetBillsCommand(this);

            EditDrinkCommand = new EditDrinkCommand(this);

            AddSnackCommand = new AddSnackCommand(this);

            AddMovieCommand = new AddMovieCommand(this);

            RemoveDrinkCommand = new RemoveDrinkCommand(this);

            EditSnackCommand = new EditSnackCommand(this);

            RemoveSnackCommand = new RemoveSnackCommand(this);

            EditMovieCommand = new EditMovieCommand(this);

            RemoveMovieCommand = new RemoveMovieCommand(this);

            AddAdminCommand = new AddNewAdminCommand(this);

            EditAdminCommand = new EditAdminCommand(this);

            RemoveAdminCommand = new RemoveAdminCommand(this);

            AddWaiterCommand = new AddWaiterCommand(this);

            EditWaiterCommand = new EditWaiterCommand(this);

            RemoveWaiterCommand = new RemoveWaiterCommand(this);

            AddTicketSellerCommand = new AddTicketSellerCommand(this);

            EditTicketSellerCommand = new EditTicketSellerCommand(this);

            RemoveTicketSellerCommand = new RemoveTicketSellerCommand(this);

            GetAvgPriceCommand = new GetAvgPriceCommand(this);


            AllDrinks = new BindingList<drink>();
            AllSnacks = new ObservableCollection<snack>();
            AllMovies = new ObservableCollection<ticket>();
            AllAdmins = new ObservableCollection<employee>();
            AllWaiters = new ObservableCollection<employee>();
            AllTicketSellers = new ObservableCollection<employee>();
            admins = new List<int>();
            waiters = new List<int>();
            ticketSellers = new List<int>();


            using (var db = new NewBioskopEntities())
            {
                foreach (drink d in db.drinks)
                    AllDrinks.Add(d);

                foreach (snack s in db.snacks)
                    AllSnacks.Add(s);

                foreach (ticket t in db.tickets)
                    AllMovies.Add(t);


                foreach (admin a in db.admins)
                    admins.Add(a.employeeid);

                employee e = new employee();
                admins.ForEach(x =>
                {
                    e = db.employees.FirstOrDefault(y => y.employeeid == x);
                    if (e != null)
                        AllAdmins.Add(e);
                });

                foreach (waiter w in db.waiters)
                    waiters.Add(w.employeeid);

                employee ew = new employee();
                waiters.ForEach(x =>
                {
                    ew = db.employees.FirstOrDefault(y => y.employeeid == x);
                    if (ew != null)
                        AllWaiters.Add(ew);
                });

                foreach (ticketseller ts in db.ticketsellers)
                    ticketSellers.Add(ts.employeeid);

                employee ets = new employee();
                ticketSellers.ForEach(x =>
                {
                    ets = db.employees.FirstOrDefault(y => y.employeeid == x);
                    if (ets != null)
                        AllTicketSellers.Add(ets);
                });
            }
        }
        #endregion

        #region Add Drink
        public bool CanAddDrink
        {
            get
            {
                return !String.IsNullOrWhiteSpace(DrinkName) && !String.IsNullOrWhiteSpace(DrinkPrice);
            }
        }

        public void AddDrink()
        {
            int price;
            bool successful = Int32.TryParse(DrinkPrice, out price);
            if (String.IsNullOrWhiteSpace(DrinkName) || String.IsNullOrWhiteSpace(DrinkPrice))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            else
            {
                if (!successful)
                {
                    MessageBox.Show("For price you need to enter numbers");
                }
            }

            try
            {
                //int price;
                //bool successful = Int32.TryParse(DrinkPrice, out price);

                if (successful)
                {
                    using (var db = new NewBioskopEntities())
                    {
                        drink temp = db.drinks.FirstOrDefault(x => x.drinkname.ToLower() == DrinkName.ToLower());

                        if (temp == null)
                        {
                            byte[] giid = Guid.NewGuid().ToByteArray();
                            int id = BitConverter.ToInt32(giid, 0);
                            drink drink = new drink();
                            drink.drinkname = DrinkName;
                            drink.drinkprice = price;
                            drink.drinkid = id;
                            drink.bar = db.bars.FirstOrDefault();
                            drink.bar_barid = drink.bar.barid;
                            db.drinks.Add(drink);

                            db.SaveChanges();
                            AllDrinks.Add(drink);
                            MessageBox.Show("Drink has been added!");
                        }
                        else
                        {
                            MessageBox.Show("That drink already exists!");
                        }
                    }
                }
                else
                {
                    //MessageBox.Show("Invalid input!");
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Edit Drink
        public bool CanEditDrink
        {
            get
            {
                return SelectedDrink != null && !String.IsNullOrWhiteSpace(DrinkPrice);
            }
        }

        public void EditDrink()
        {
            int price = 0;
            bool successful = Int32.TryParse(DrinkPrice, out price);

            if (String.IsNullOrWhiteSpace(DrinkName) || String.IsNullOrWhiteSpace(DrinkPrice))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            else
            {
                if (!successful)
                {
                    MessageBox.Show("For price you need to enter numbers");
                }
            }

            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        drink drink = db.drinks.FirstOrDefault(x => x.drinkid == SelectedDrink.drinkid);

                        if (drink != null)
                        {
                            drink.drinkname = DrinkName;
                            drink.drinkprice = price;
                            db.drinks.AddOrUpdate(drink);
                            db.SaveChanges();
                            drink temp = AllDrinks.FirstOrDefault(x => x.drinkid == drink.drinkid);
                            AllDrinks.Remove(temp);
                            AllDrinks.Add(drink);

                            MessageBox.Show("Drink has been updated!");
                        }
                        if (String.IsNullOrWhiteSpace(DrinkName) || String.IsNullOrWhiteSpace(DrinkPrice))
                        {
                            MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                            successful = false;
                        }
                        else
                        {
                            if (!successful)
                            {
                                MessageBox.Show("For price you need to enter numbers");
                            }
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Remove Drink
        public bool CanRemoveDrink
        {
            get
            {
                return SelectedDrink == null ? false : true;
            }
        }

        public void RemoveDrink()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    drink drink = db.drinks.FirstOrDefault(x => x.drinkid == SelectedDrink.drinkid);

                    if (drink != null)
                    {
                        db.drinks.Remove(drink);
                        db.SaveChanges();
                        drink d = AllDrinks.FirstOrDefault(x => (x.drinkname == drink.drinkname && x.drinkprice == drink.drinkprice));
                        AllDrinks.Remove(d);
                        MessageBox.Show("Drink has been removed!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Get Bills
        public bool CanGetBills
        {
            get
            {
                return SelectedTable == null ? false : true;
            }
        }

        public void GetBills()
        {
            try
            {
                Window w = new ShowBillsWindow();
                w.DataContext = new ShowBillsViewModel(SelectedTable.tableid, SelectedTable.tablename) { Window = w, TableID = SelectedTable.tableid, TableName = SelectedTable.tablename };
                w.Show();
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Add Snack

        public bool CanAddSnack
        {
            get
            {
                return !String.IsNullOrWhiteSpace(SnackName) && !String.IsNullOrWhiteSpace(SnackPrice);
            }
        }

        public void AddSnack()
        {
            int price = 0;
            bool successful = Int32.TryParse(SnackPrice, out price);
            if (String.IsNullOrWhiteSpace(SnackName) || String.IsNullOrWhiteSpace(SnackPrice))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            else
            {
                if (!successful)
                {
                    MessageBox.Show("For price you need to enter numbers");
                }
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    //int price = 0;
                    //Int32.TryParse(SnackPrice, out price);
                    if (successful)
                    {
                        snack snack = new snack();

                        snack.snackprice = price;
                        snack.snackname = SnackName;

                        byte[] giid = Guid.NewGuid().ToByteArray();
                        int id = BitConverter.ToInt32(giid, 0);
                        snack.snackid = id;

                        ticketseller ticketseller = db.ticketsellers.FirstOrDefault();
                        snack.ticketseller_employeeid = ticketseller.employeeid;

                        db.snacks.Add(snack);
                        db.SaveChanges();
                        AllSnacks.Add(snack);
                        MessageBox.Show("Snack has been successfully added!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Edit Snack
        public bool CanEditSnack
        {
            get
            {
                return !String.IsNullOrWhiteSpace(SnackEditPrice) && SelectedSnack != null;
            }
        }

        public void EditSnack()
        {
            int price = 0;
            bool successful = Int32.TryParse(SnackEditPrice, out price);
            if (String.IsNullOrWhiteSpace(SnackEditPrice))
            {
                MessageBox.Show("Invalid snack input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            else
            {
                if (!successful)
                {
                    MessageBox.Show("For price you need to enter numbers");
                }
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    //int price = 0;
                    //Int32.TryParse(SnackPrice, out price);
                    if (successful)
                    {
                        snack snack = db.snacks.FirstOrDefault(x => x.snackid == SelectedSnack.snackid);

                        if (snack != null)
                        {
                            snack.snackprice = price;
                            db.snacks.AddOrUpdate(snack);

                            snack temp = AllSnacks.FirstOrDefault(x => x.snackid == snack.snackid);
                            AllSnacks.Remove(temp);
                            AllSnacks.Add(snack);
                            db.SaveChanges();

                            MessageBox.Show("Snack has been updated!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Remove Snack
        public bool CanRemoveSnack
        {
            get
            {
                return SelectedSnack == null ? false : true;
            }
        }

        public void RemoveSnack()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    snack snack = db.snacks.FirstOrDefault(x => x.snackid == SelectedSnack.snackid);

                    if (snack != null)
                    {
                        db.snacks.Remove(snack);
                        snack temp = AllSnacks.FirstOrDefault(x => x.snackid == SelectedSnack.snackid);
                        AllSnacks.Remove(temp);
                        db.SaveChanges();
                        MessageBox.Show("Snack has been removed!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Add Movie

        public bool CanAddMovie
        {
            get
            {
                return !String.IsNullOrWhiteSpace(MovieName) && !String.IsNullOrWhiteSpace(MoviePrice);
            }
        }

        public void AddMovie()
        {
            int price = 0;
            bool successful = Int32.TryParse(MoviePrice, out price);
            if (String.IsNullOrWhiteSpace(MoviePrice) || String.IsNullOrWhiteSpace(MovieName))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            else
            {
                if (!successful)
                {
                    MessageBox.Show("For price you need to enter numbers");
                }
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        //int price = 0;
                        //Int32.TryParse(MoviePrice, out price);
                        ticket ticket = new ticket();
                        byte[] giid = Guid.NewGuid().ToByteArray();
                        int id = BitConverter.ToInt32(giid, 0);
                        ticket.ticketid = id;
                        ticket.ticketprice = price;
                        ticket.ticketmoviename = MovieName;
                        Random random = new Random();
                        ticket.ticketseatnumber = random.Next(1, 300).ToString();
                        ticket.ticketdatetime = DateTime.Now;
                        ticketseller ticketseller = db.ticketsellers.FirstOrDefault();
                        ticket.ticketseller_employeeid = ticketseller.employeeid;

                        projectionroom projectionroom = db.projectionrooms.FirstOrDefault();
                        ticket.projectionroom_prjroomid = projectionroom.prjroomid;

                        db.tickets.Add(ticket);
                        db.SaveChanges();

                        AllMovies.Add(ticket);
                        MessageBox.Show("Ticket has been successfully added!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Edit Movie

        public bool CanEditMovie
        {
            get
            {
                return SelectedMovie == null ? false : true && !String.IsNullOrWhiteSpace(MovieName) && !String.IsNullOrWhiteSpace(MoviePrice);
            }
        }

        public void EditMovie()
        {
            int price = 0;
            bool successful = Int32.TryParse(MoviePrice, out price);
            if (String.IsNullOrWhiteSpace(MoviePrice) && String.IsNullOrWhiteSpace(MovieName))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            else
            {
                if (!successful)
                {
                    MessageBox.Show("For price you need to enter numbers");
                }
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        ticket ticket = db.tickets.FirstOrDefault(x => x.ticketid == SelectedMovie.ticketid);

                        if (ticket != null)
                        {
                            ticket.ticketmoviename = MovieName;
                            ticket.ticketprice = price;
                            db.tickets.AddOrUpdate(ticket);

                            db.SaveChanges();

                            ticket temp = AllMovies.FirstOrDefault(x => x.ticketid == ticket.ticketid);
                            AllMovies.Remove(temp);
                            AllMovies.Add(ticket);

                            MessageBox.Show("Ticket has been updated!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Remove Movie

        public bool CanRemoveMovie
        {
            get
            {
                return SelectedMovie == null ? false : true;
            }
        }

        public void RemoveMovie()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    ticket ticket = db.tickets.FirstOrDefault(x => x.ticketid == SelectedMovie.ticketid);

                    if (ticket != null)
                    {
                        db.tickets.Remove(ticket);

                        db.SaveChanges();

                        ticket temp = AllMovies.FirstOrDefault(x => x.ticketid == ticket.ticketid);
                        AllMovies.Remove(temp);

                        MessageBox.Show("Ticket has been removed!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Add Admin

        public bool CanAddAdmin
        {
            get
            {
                return !String.IsNullOrWhiteSpace(AdminName) && !String.IsNullOrWhiteSpace(AdminSurname) && !String.IsNullOrWhiteSpace(AdminUsername) && !String.IsNullOrWhiteSpace(AdminEmail);
            }
        }

        public void AddAdmin()
        {
            bool successful = true;
            if (String.IsNullOrWhiteSpace(AdminName) || String.IsNullOrWhiteSpace(AdminSurname) || String.IsNullOrWhiteSpace(AdminUsername) || String.IsNullOrWhiteSpace(AdminEmail))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        employee employee = new employee();
                        byte[] giid = Guid.NewGuid().ToByteArray();
                        int id = BitConverter.ToInt32(giid, 0);
                        employee.employeeid = id;
                        employee.employeename = AdminName;
                        employee.employeeemail = AdminEmail;
                        employee.employeesurname = AdminSurname;
                        employee.employeeusername = AdminUsername;

                        admin admin = new admin();
                        admin.employeeid = id;

                        employee.admin = admin;

                        db.employees.Add(employee);
                        db.admins.Add(admin);

                        db.SaveChanges();

                        AllAdmins.Add(employee);

                        MessageBox.Show("Admin has been successfully added!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Edit Admin
        public bool CanEditAdmin
        {
            get
            {
                return SelectedAdmin == null ? false : true && !String.IsNullOrWhiteSpace(AdminName) && !String.IsNullOrWhiteSpace(AdminSurname) && !String.IsNullOrWhiteSpace(AdminUsername) && !String.IsNullOrWhiteSpace(AdminEmail);
            }
        }

        public void EditAdmin()
        {
            bool successful = true;
            if (String.IsNullOrWhiteSpace(AdminName) || String.IsNullOrWhiteSpace(AdminSurname) || String.IsNullOrWhiteSpace(AdminUsername) || String.IsNullOrWhiteSpace(AdminEmail))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        employee employee = db.employees.FirstOrDefault(x => x.employeeid == SelectedAdmin.employeeid);

                        if (employee != null)
                        {
                            employee.employeename = AdminName;
                            employee.employeesurname = AdminSurname;
                            employee.employeeemail = AdminEmail;
                            employee.employeeusername = AdminUsername;

                            db.employees.AddOrUpdate(employee);

                            employee temp = AllAdmins.FirstOrDefault(x => x.employeeid == employee.employeeid);
                            AllAdmins.Remove(temp);
                            AllAdmins.Add(employee);
                            db.SaveChanges();

                            MessageBox.Show("Admin has been updated!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Remove Admin
        public bool CanRemoveAdmin
        {
            get
            {
                return SelectedAdmin == null ? false : true;
            }
        }

        public void RemoveAdmin()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    employee employee = db.employees.FirstOrDefault(x => x.employeeid == SelectedAdmin.employeeid);
                    admin admin = db.admins.FirstOrDefault(x => x.employeeid == SelectedAdmin.employeeid);

                    if (employee != null)
                    {
                        db.employees.Remove(employee);
                        db.admins.Remove(admin);

                        employee temp = AllAdmins.FirstOrDefault(x => x.employeeid == employee.employeeid);
                        AllAdmins.Remove(temp);
                        db.SaveChanges();

                        MessageBox.Show("Admin has been removed!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Add Waiter

        public bool CanAddWaiter
        {
            get
            {
                return !String.IsNullOrWhiteSpace(WaiterName) && !String.IsNullOrWhiteSpace(WaiterSurname) && !String.IsNullOrWhiteSpace(WaiterUsername) && !String.IsNullOrWhiteSpace(WaiterEmail);
            }
        }

        public void AddWaiter()
        {
            bool successful = true;
            if (String.IsNullOrWhiteSpace(WaiterName) || String.IsNullOrWhiteSpace(WaiterSurname) || String.IsNullOrWhiteSpace(WaiterUsername) || String.IsNullOrWhiteSpace(WaiterEmail))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        employee employee = new employee();
                        byte[] giid = Guid.NewGuid().ToByteArray();
                        int id = BitConverter.ToInt32(giid, 0);
                        employee.employeeid = id;
                        employee.employeename = WaiterName;
                        employee.employeeemail = WaiterEmail;
                        employee.employeesurname = WaiterSurname;
                        employee.employeeusername = WaiterUsername;

                        waiter waiter = new waiter();
                        waiter.employeeid = id;
                        waiter.bar = db.bars.FirstOrDefault();
                        waiter.bar_barid = waiter.bar.barid;

                        employee.waiter = waiter;

                        db.employees.Add(employee);
                        db.waiters.Add(waiter);

                        db.SaveChanges();

                        AllWaiters.Add(employee);

                        MessageBox.Show("Waiter has been successfully added!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Edit Waiter
        public bool CanEditWaiter
        {
            get
            {
                return SelectedWaiter == null ? false : true && !String.IsNullOrWhiteSpace(WaiterName) && !String.IsNullOrWhiteSpace(WaiterSurname) && !String.IsNullOrWhiteSpace(WaiterUsername) && !String.IsNullOrWhiteSpace(WaiterEmail);
            }
        }

        public void EditWaiter()
        {
            bool successful = true;
            if (String.IsNullOrWhiteSpace(WaiterName) || String.IsNullOrWhiteSpace(WaiterSurname) || String.IsNullOrWhiteSpace(WaiterUsername) || String.IsNullOrWhiteSpace(WaiterEmail))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        employee employee = db.employees.FirstOrDefault(x => x.employeeid == SelectedWaiter.employeeid);

                        if (employee != null)
                        {
                            employee.employeename = WaiterName;
                            employee.employeesurname = WaiterSurname;
                            employee.employeeemail = WaiterEmail;
                            employee.employeeusername = WaiterUsername;

                            db.employees.AddOrUpdate(employee);

                            employee temp = AllWaiters.FirstOrDefault(x => x.employeeid == employee.employeeid);
                            AllWaiters.Remove(temp);
                            AllWaiters.Add(employee);
                            db.SaveChanges();

                            MessageBox.Show("Waiter has been updated!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Remove Waiter
        public bool CanRemoveWaiter
        {
            get
            {
                return SelectedWaiter == null ? false : true;
            }
        }

        public void RemoveWaiter()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    employee employee = db.employees.FirstOrDefault(x => x.employeeid == SelectedWaiter.employeeid);
                    waiter waiter = db.waiters.FirstOrDefault(x => x.employeeid == SelectedWaiter.employeeid);

                    if (employee != null)
                    {
                        db.employees.Remove(employee);
                        db.waiters.Remove(waiter);

                        employee temp = AllWaiters.FirstOrDefault(x => x.employeeid == employee.employeeid);
                        AllWaiters.Remove(temp);
                        db.SaveChanges();

                        MessageBox.Show("Waiter has been removed!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Add Ticket Seller

        public bool CanAddTicketSeller
        {
            get
            {
                return !String.IsNullOrWhiteSpace(TicketSellerName) && !String.IsNullOrWhiteSpace(TicketSellerSurname) && !String.IsNullOrWhiteSpace(TicketSellerUsername) && !String.IsNullOrWhiteSpace(TicketSellerEmail);
            }
        }

        public void AddTicketSeller()
        {
            bool successful = true;
            if (String.IsNullOrWhiteSpace(TicketSellerName) || String.IsNullOrWhiteSpace(TicketSellerSurname) || String.IsNullOrWhiteSpace(TicketSellerUsername) || String.IsNullOrWhiteSpace(TicketSellerEmail))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        employee employee = new employee();
                        byte[] giid = Guid.NewGuid().ToByteArray();
                        int id = BitConverter.ToInt32(giid, 0);
                        employee.employeeid = id;
                        employee.employeename = TicketSellerName;
                        employee.employeeemail = TicketSellerEmail;
                        employee.employeesurname = TicketSellerSurname;
                        employee.employeeusername = TicketSellerUsername;

                        ticketseller ticketseller = new ticketseller();
                        ticketseller.employeeid = id;

                        employee.ticketseller = ticketseller;

                        db.employees.Add(employee);
                        db.ticketsellers.Add(ticketseller);

                        db.SaveChanges();

                        AllTicketSellers.Add(employee);

                        MessageBox.Show("Ticket Seller has been successfully added!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Edit Ticket Seller
        public bool CanEditTicketSeller
        {
            get
            {
                return SelectedTicketSeller == null ? false : true && !String.IsNullOrWhiteSpace(TicketSellerName) && !String.IsNullOrWhiteSpace(TicketSellerSurname) && !String.IsNullOrWhiteSpace(TicketSellerUsername) && !String.IsNullOrWhiteSpace(TicketSellerEmail);
            }
        }

        public void EditTicketSeller()
        {
            bool successful = true;
            if (String.IsNullOrWhiteSpace(TicketSellerName) || String.IsNullOrWhiteSpace(TicketSellerSurname) || String.IsNullOrWhiteSpace(TicketSellerUsername) || String.IsNullOrWhiteSpace(TicketSellerEmail))
            {
                MessageBox.Show("Invalid input!", "Invalid input", MessageBoxButton.OK, MessageBoxImage.Warning);
                successful = false;
            }
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    if (successful)
                    {
                        employee employee = db.employees.FirstOrDefault(x => x.employeeid == SelectedTicketSeller.employeeid);

                        if (employee != null)
                        {
                            employee.employeename = TicketSellerName;
                            employee.employeesurname = TicketSellerSurname;
                            employee.employeeemail = TicketSellerEmail;
                            employee.employeeusername = TicketSellerUsername;

                            db.employees.AddOrUpdate(employee);

                            employee temp = AllTicketSellers.FirstOrDefault(x => x.employeeid == employee.employeeid);
                            AllTicketSellers.Remove(temp);
                            AllTicketSellers.Add(employee);
                            db.SaveChanges();

                            MessageBox.Show("Ticket Seller has been updated!");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion

        #region Remove Ticket Seller
        public bool CanRemoveTicketSeller
        {
            get
            {
                return SelectedTicketSeller == null ? false : true;
            }
        }

        public void RemoveTicketSeller()
        {
            try
            {
                using (var db = new NewBioskopEntities())
                {
                    employee employee = db.employees.FirstOrDefault(x => x.employeeid == SelectedTicketSeller.employeeid);
                    ticketseller ticketSeller = db.ticketsellers.FirstOrDefault(x => x.employeeid == SelectedTicketSeller.employeeid);

                    if (employee != null)
                    {
                        db.employees.Remove(employee);
                        db.ticketsellers.Remove(ticketSeller);

                        employee temp = AllTicketSellers.FirstOrDefault(x => x.employeeid == employee.employeeid);
                        AllTicketSellers.Remove(temp);
                        db.SaveChanges();

                        MessageBox.Show("Ticket Seller has been removed!");
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Exepction was thrown: " + e.Message);
            }
        }

        #endregion


        #region Get Avg Price
        public bool CanGetAvgPrice
        {
            get
            {
                return SelectedTable == null ? false : true;
            }
        }

        public void GetAvgPrice()
        {
            try
            {
                decimal x = 0;
                using (var db = new NewBioskopEntities())
                {
                    x = db.Database.SqlQuery<decimal>($"SELECT [dbo].[AvgValue]({SelectedTable.tableid})").FirstOrDefault();
                }
                MessageBox.Show("Prosecni racun na stolu " + SelectedTable.tablename + " je: " + x);
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
