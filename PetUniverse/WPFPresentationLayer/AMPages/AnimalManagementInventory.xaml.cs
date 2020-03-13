﻿
using DataTransferObjects;
using LogicLayer;
using LogicLayerInterfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace WPFPresentationLayer
{
    /// <summary>
    /// Creator: Daulton Schilling
    /// Created: 2/12/2020
    /// Approver: Carl Davis, 2/13/2020
    /// Approver: Chuck Baxter, 2/13/2020
    /// 
    /// Main window partial class
    /// </summary>
    /// <remarks>
    /// Updater:
    /// Updated:
    /// Update:
    /// </remarks>
    public partial class AnimalManagementInventory : Page
    {
        private IMedicationManager _medicationManager;



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// No argument constructor for main window
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public AnimalManagementInventory()
        {
            InitializeComponent();

            OS.Visibility = Visibility.Hidden;
            ID.Visibility = Visibility.Hidden;
            Name.Visibility = Visibility.Hidden;
            Number.Visibility = Visibility.Hidden;

            ItemID_.Visibility = Visibility.Hidden;

            ItemName_.Visibility = Visibility.Hidden;

            Quantity_.Visibility = Visibility.Hidden;

            OS.Visibility = Visibility.Hidden;

            four.Visibility = Visibility.Hidden;

            Med.Visibility = Visibility.Hidden;
            MedList.Visibility = Visibility.Hidden;

            Quantity_form.Visibility = Visibility.Hidden;
            Quantity_input.Visibility = Visibility.Hidden;
            four.Visibility = Visibility.Hidden;

            ShowMedicationInventory();

            _medicationManager = new MedicationManager();
        }
        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Displays the medication inventory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void ShowMedicationInventory()
        {

            _medicationManager = new MedicationManager();

            List<Medication> productList = _medicationManager.RetrieveMedicationInventory();

            MedList.ItemsSource = productList;



        }



        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Order more medications
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void OrderMedications()
        {


            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();


            object item = MedList.SelectedItem;
            string ItemID = (MedList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            string ItemName = (MedList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;



            _medicationManager.CreateMedicationOrder(Int32.Parse(ItemID), ItemName, Int32.Parse(Quantity_input.Text));

            ItemID_.Text = ItemID.ToString();

            ItemName_.Text = ItemName.ToString();

            Quantity_.Text = Int32.Parse(Quantity_input.Text).ToString();



        }

        private void View_AutoGeneratedColumns(object sender, EventArgs e)
        {
            MedList.Columns[0].Header = "ItemID";
            MedList.Columns[1].Header = "ItemName";
            MedList.Columns[2].Header = "ItemQuantity";

        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Button to begin making an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void Row_DoubleClick(object sender, MouseButtonEventArgs e)
        {

            OS.Visibility = Visibility.Visible;
            ID.Visibility = Visibility.Visible;
            Name.Visibility = Visibility.Visible;
            Number.Visibility = Visibility.Visible;

            Quantity_form.Visibility = Visibility.Visible;
            Quantity_input.Visibility = Visibility.Visible;



            ItemID_.Visibility = Visibility.Visible;

            ItemName_.Visibility = Visibility.Visible;

            Quantity_.Visibility = Visibility.Visible;

            OS.Visibility = Visibility.Visible;


            NewAnimalChecklistManager _ChecklistManager = new NewAnimalChecklistManager();


            object item = MedList.SelectedItem;
            string ItemID = (MedList.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;

            string ItemName = (MedList.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;



            ItemID_.Text = ItemID;

            ItemName_.Text = ItemName;



        }




        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/12/2020
        /// Approver: Carl Davis, 2/13/2020
        /// Approver: Chuck Baxter, 2/13/2020
        /// 
        /// Button to finalize an order
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void btn4(object sender, RoutedEventArgs e)
        {
            try
            {
                OrderMedications();


            }
            catch (Exception ex) { }
        }


        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/23/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Display Medication Inventory
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void Med_Click(object sender, RoutedEventArgs e)
        {
            Med.Visibility = Visibility.Visible;
            Med.Visibility = Visibility.Visible;
            MedList.Visibility = Visibility.Visible;



        }

        /// <summary>
        /// Creator: Daulton Schilling
        /// Created: 2/23/2020
        /// Approver: 
        /// Approver: 
        /// 
        /// Text change event for quantity input box
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        private void QC(object sender, TextChangedEventArgs e)
        {
            try
            {

                if (Int32.Parse(Quantity_input.Text) >= 1)
                {
                    Quantity_.Text = Int32.Parse(Quantity_input.Text).ToString();
                    Error.Visibility = Visibility.Hidden;
                    four.Visibility = Visibility.Visible;
                }
                else
                {
                    Error.Visibility = Visibility.Visible;
                    four.Visibility = Visibility.Hidden;
                    Error.Content = "Please order atleast 1 item";
                    Quantity_.Text = "";

                }
            }
            catch (FormatException ex)
            {
                Error.Visibility = Visibility.Visible;
                four.Visibility = Visibility.Hidden;
                Error.Content = "Please enter a valid quantity";
                Quantity_.Text = "";
            }
        }


    }
}
