using CustomObjects;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Text;

namespace QScaleNew
{
    public class GlobalVariables
    {
        public static string CurrentComputerName;
        public static string AppDataDirectoryPath;
        public static string DatabaseDirectory;
        public static string OperatingYear;
        public static CultureInfo CurrentCultureInfo;
        public static string ConnectionString;
        public static CurrentUser currentUser; //0=SuperAdmin, 1=Admin. Don't check their permission. They are permitted for all tasks.
        public static MeasurementUnit measurementUnit;

        //Variables for Language Setting
        public string MyInputMethod = "NonUnicode";
        //    public Font MyFont;
        public float MyFontSize = 14;
        public string MyFontName = "SutonnyMJ";

        //public CrystalDecisions.CrystalReports.Engine.ReportDocument MyReport;

        public static string[] InputDateFormatsAllowed = {
                                                       "d/M/yy", "d/M/yyyy",
                                                       "d/MM/yy", "d/MM/yyyy",
                                                       "dd/M/yy", "dd/M/yyyy",
                                                       "dd/MM/yy", "dd/MM/yyyy",

                                                       "d-M-yy", "d-M-yyyy",
                                                       "d-MM-yy", "d-MM-yyyy",
                                                       "dd-M-yy", "dd-M-yyyy",
                                                       "dd-MM-yy", "dd-MM-yyyy",

                                                       "d.M.yy", "d.M.yyyy",
                                                       "d.MM.yy", "d.MM.yyyy",
                                                       "dd.M.yy", "dd.M.yyyy",
                                                       "dd.MM.yy", "dd.MM.yyyy"

                                                    };

        public static Color GotFocusBackColor = SystemColors.GradientActiveCaption;
        public static Color LostFocusBackColor = SystemColors.Window;
        public static Color GotFocusForeColor = Color.Black;
        public static Color LostFocusForeColor = Color.Black;


        public static string productKey;
        public static string licenseKey;
        public static bool isRegistered;
    }
}
