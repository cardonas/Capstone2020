﻿using LogicLayer;
using LogicLayerInterfaces;
using System.Windows;
using System.Windows.Controls;

namespace WPFPresentationLayer.PoSPages
{
    /// <summary>
    /// Creator: Cash Carlson
    /// Created: 02/21/2020
    /// Approver: Zach Behrensmeyer
    ///
    /// Interaction logic for InventoryItems.xaml
    /// </summary>
    public partial class pgInventoryItems : Page
    {
        private IInventoryItemsManager _inventoryItemsManager;
        private Frame _frame;

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 02/21/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Default Constructor for InventoryItems Page
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public pgInventoryItems()
        {
            _inventoryItemsManager = new InventoryItemsManager();
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: 
        /// 
        /// Constructor that takes a frame for navigation purposes.
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="frame">The frame to use for navigation.</param>
        public pgInventoryItems(Frame frame)
        {
            _inventoryItemsManager = new InventoryItemsManager();
            _frame = frame;
            InitializeComponent();
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 02/21/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Event Handler Method that activates on page load
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RefreshData();
        }

        /// <summary>
        /// Creator: Cash Carlson
        /// Created: 02/21/2020
        /// Approver: Zach Behrensmeyer
        ///
        /// Data Refresh Method to be called on every time it is needed.
        /// </summary>
        /// <remarks>
        /// Updater:
        /// Updated:
        /// Update:
        /// </remarks>
        public void RefreshData()
        {
            dgInventoryItems.ItemsSource = _inventoryItemsManager.RetrieveInventoryItems();
            dgInventoryItems.Columns[0].Header = "UPC";
        }

        /// <summary>
        /// Creator: Robert Holmes
        /// Created: 2020/03/17
        /// Approver: 
        /// 
        /// </summary>
        /// <remarks>
        /// Updater: 
        /// Updated: 
        /// Update: 
        /// 
        /// </remarks>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            _frame.Navigate(new pgChooseItemForProduct(_frame));
        }
    }
}
