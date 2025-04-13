using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Store_Management_Project
{
    internal static class Program
    {
        public static frmLogin loginForm = null;
        public static frmMain mainForm = null;
        public static frmCustomer customerForm = null;
        public static frmBrand brandForm = null;
        public static frmCategories categoriesForm = null;
        public static frmStaff staffForm = null;
        public static frmOrder orderForm = null;
        public static frmImport importForm = null;
        public static frmImportFinsh importfinishForm = null;
        public static frmWarehouse warehouseForm = null;
        public static frmProduct productForm = null;
        public static frmAccountStaff accountStaffForm = null;
        public static frmBillManagement billManagementForm = null;
        public static frmAccountCustomer accountCustomerForm = null;
        public static frmOrderOnline orderOnlineForm = null;
        public static frmStatistics statisticsForm = null;
        public static frmVoucher voucherForm = null;
        public static frmChangePassword changePasswordForm = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            new Harmony("com.store.management.project").PatchAll();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmLogin());
            //Application.Run(new AIForm());
        }
    }
}
