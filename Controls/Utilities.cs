using MyStuff11net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace StockRoom11net.Controls
{
    public class Utilities
    {
        #region"Strongly typed contants"

        /// <summary>
        /// 30	␞	INFORMATION SEPARATOR, record separator, End of a record or row.
        /// </summary>
        public static readonly char SeparatorRecordEndOfRecord = '␞';

        /// <summary>
        /// 31	␟	INFORMATION SEPARATOR, unit separator, Between fields of a record, or members of a row.
        /// </summary>
        public static readonly char SeparatorBetweenFieldsOfRecord = '␟';

        public static string WarningRed = "Selected(" + Color.Red.ToArgb() + ")";
        public static string WarningYellow = "Selected(" + Color.Yellow.ToArgb() + ")";

        #endregion"Strongly typed contants"

        #region"Enums are strongly typed constants"

        #region"My Enums declaration"

        public enum WindowsMsg
        {
            WM_NULL = 0x00,
            WM_CREATE = 0x01,
            WM_DESTROY = 0x02,
            WM_MOVE = 0x03,
            WM_SIZE = 0x05,
            WM_ACTIVATE = 0x06,
            WM_SETFOCUS = 0x07,
            WM_KILLFOCUS = 0x08,
            WM_ENABLE = 0x0A,
            WM_SETREDRAW = 0x0B,
            WM_SETTEXT = 0x0C,
            WM_GETTEXT = 0x0D,
            WM_GETTEXTLENGTH = 0x0E,
            WM_PAINT = 0x0F,
            WM_CLOSE = 0x10,
            WM_QUERYENDSESSION = 0x11,
            WM_QUIT = 0x12,
            WM_QUERYOPEN = 0x13,
            WM_ERASEBKGND = 0x14,
            WM_SYSCOLORCHANGE = 0x15,
            WM_ENDSESSION = 0x16,
            WM_SYSTEMERROR = 0x17,
            WM_SHOWWINDOW = 0x18,
            WM_CTLCOLOR = 0x19,
            WM_WININICHANGE = 0x1A,
            WM_SETTINGCHANGE = 0x1A,
            WM_DEVMODECHANGE = 0x1B,
            WM_ACTIVATEAPP = 0x1C,
            WM_FONTCHANGE = 0x1D,
            WM_TIMECHANGE = 0x1E,
            WM_CANCELMODE = 0x1F,
            WM_SETCURSOR = 0x20,
            WM_MOUSEACTIVATE = 0x21,
            WM_CHILDACTIVATE = 0x22,
            WM_QUEUESYNC = 0x23,
            WM_GETMINMAXINFO = 0x24,
            WM_PAINTICON = 0x26,
            WM_ICONERASEBKGND = 0x27,
            WM_NEXTDLGCTL = 0x28,
            WM_SPOOLERSTATUS = 0x2A,
            WM_DRAWITEM = 0x2B,
            WM_MEASUREITEM = 0x2C,
            WM_DELETEITEM = 0x2D,
            WM_VKEYTOITEM = 0x2E,
            WM_CHARTOITEM = 0x2F,

            WM_SETFONT = 0x30,
            WM_GETFONT = 0x31,
            WM_SETHOTKEY = 0x32,
            WM_GETHOTKEY = 0x33,
            WM_QUERYDRAGICON = 0x37,
            WM_COMPAREITEM = 0x39,
            WM_COMPACTING = 0x41,
            WM_WINDOWPOSCHANGING = 0x46,
            WM_WINDOWPOSCHANGED = 0x47,
            WM_POWER = 0x48,
            WM_COPYDATA = 0x4A,
            WM_CANCELJOURNAL = 0x4B,
            WM_NOTIFY = 0x4E,
            WM_INPUTLANGCHANGEREQUEST = 0x50,
            WM_INPUTLANGCHANGE = 0x51,
            WM_TCARD = 0x52,
            WM_HELP = 0x53,
            WM_USERCHANGED = 0x54,
            WM_NOTIFYFORMAT = 0x55,
            WM_CONTEXTMENU = 0x7B,
            WM_STYLECHANGING = 0x7C,
            WM_STYLECHANGED = 0x7D,
            WM_DISPLAYCHANGE = 0x7E,
            WM_GETICON = 0x7F,
            WM_SETICON = 0x80,

            WM_NCCREATE = 0x81,
            WM_NCDESTROY = 0x82,
            WM_NCCALCSIZE = 0x83,
            WM_NCHITTEST = 0x84,
            WM_NCPAINT = 0x85,
            WM_NCACTIVATE = 0x86,
            WM_GETDLGCODE = 0x87,
            WM_NCMOUSEMOVE = 0xA0,
            WM_NCLBUTTONDOWN = 0xA1,
            WM_NCLBUTTONUP = 0xA2,
            WM_NCLBUTTONDBLCLK = 0xA3,
            WM_NCRBUTTONDOWN = 0xA4,
            WM_NCRBUTTONUP = 0xA5,
            WM_NCRBUTTONDBLCLK = 0xA6,
            WM_NCMBUTTONDOWN = 0xA7,
            WM_NCMBUTTONUP = 0xA8,
            WM_NCMBUTTONDBLCLK = 0xA9,

            WM_KEYFIRST = 0x100,
            WM_KEYDOWN = 0x100,
            WM_KEYUP = 0x101,
            WM_CHAR = 0x102,
            WM_DEADCHAR = 0x103,
            WM_SYSKEYDOWN = 0x104,
            WM_SYSKEYUP = 0x105,
            WM_SYSCHAR = 0x106,
            WM_SYSDEADCHAR = 0x107,
            WM_KEYLAST = 0x108,

            WM_IME_STARTCOMPOSITION = 0x10D,
            WM_IME_ENDCOMPOSITION = 0x10E,
            WM_IME_COMPOSITION = 0x10F,
            WM_IME_KEYLAST = 0x10F,

            WM_INITDIALOG = 0x110,
            WM_COMMAND = 0x111,
            WM_SYSCOMMAND = 0x112,
            WM_TIMER = 0x113,
            WM_HSCROLL = 0x114,
            WM_VSCROLL = 0x115,
            WM_INITMENU = 0x116,
            WM_INITMENUPOPUP = 0x117,
            WM_MENUSELECT = 0x11F,
            WM_MENUCHAR = 0x120,
            WM_ENTERIDLE = 0x121,

            WM_CTLCOLORMSGBOX = 0x132,
            WM_CTLCOLOREDIT = 0x133,
            WM_CTLCOLORLISTBOX = 0x134,
            WM_CTLCOLORBTN = 0x135,
            WM_CTLCOLORDLG = 0x136,
            WM_CTLCOLORSCROLLBAR = 0x137,
            WM_CTLCOLORSTATIC = 0x138,

            WM_MOUSEFIRST = 0x200,
            WM_MOUSEMOVE = 0x200,
            WM_LBUTTONDOWN = 0x201,
            WM_LBUTTONUP = 0x202,
            WM_LBUTTONDBLCLK = 0x203,
            WM_RBUTTONDOWN = 0x204,
            WM_RBUTTONUP = 0x205,
            WM_RBUTTONDBLCLK = 0x206,
            WM_MBUTTONDOWN = 0x207,
            WM_MBUTTONUP = 0x208,
            WM_MBUTTONDBLCLK = 0x209,
            WM_MOUSEWHEEL = 0x20A,
            WM_MOUSEHWHEEL = 0x20E,

            WM_PARENTNOTIFY = 0x210,
            WM_ENTERMENULOOP = 0x211,
            WM_EXITMENULOOP = 0x212,
            WM_NEXTMENU = 0x213,
            WM_SIZING = 0x214,
            WM_CAPTURECHANGED = 0x215,
            WM_MOVING = 0x216,
            WM_POWERBROADCAST = 0x218,
            WM_DEVICECHANGE = 0x219,

            WM_MDICREATE = 0x220,
            WM_MDIDESTROY = 0x221,
            WM_MDIACTIVATE = 0x222,
            WM_MDIRESTORE = 0x223,
            WM_MDINEXT = 0x224,
            WM_MDIMAXIMIZE = 0x225,
            WM_MDITILE = 0x226,
            WM_MDICASCADE = 0x227,
            WM_MDIICONARRANGE = 0x228,
            WM_MDIGETACTIVE = 0x229,
            WM_MDISETMENU = 0x230,
            WM_ENTERSIZEMOVE = 0x231,
            WM_EXITSIZEMOVE = 0x232,
            WM_DROPFILES = 0x233,
            WM_MDIREFRESHMENU = 0x234,

            WM_IME_SETCONTEXT = 0x281,
            WM_IME_NOTIFY = 0x282,
            WM_IME_CONTROL = 0x283,
            WM_IME_COMPOSITIONFULL = 0x284,
            WM_IME_SELECT = 0x285,
            WM_IME_CHAR = 0x286,
            WM_IME_KEYDOWN = 0x290,
            WM_IME_KEYUP = 0x291,

            WM_MOUSEHOVER = 0x2A1,
            WM_NCMOUSELEAVE = 0x2A2,
            WM_MOUSELEAVE = 0x2A3,

            WM_CUT = 0x300,
            WM_COPY = 0x301,
            WM_PASTE = 0x302,
            WM_CLEAR = 0x303,
            WM_UNDO = 0x304,

            WM_RENDERFORMAT = 0x305,
            WM_RENDERALLFORMATS = 0x306,
            WM_DESTROYCLIPBOARD = 0x307,
            WM_DRAWCLIPBOARD = 0x308,
            WM_PAINTCLIPBOARD = 0x309,
            WM_VSCROLLCLIPBOARD = 0x30A,
            WM_SIZECLIPBOARD = 0x30B,
            WM_ASKCBFORMATNAME = 0x30C,
            WM_CHANGECBCHAIN = 0x30D,
            WM_HSCROLLCLIPBOARD = 0x30E,
            WM_QUERYNEWPALETTE = 0x30F,
            WM_PALETTEISCHANGING = 0x310,
            WM_PALETTECHANGED = 0x311,

            WM_HOTKEY = 0x312,
            WM_PRINT = 0x317,
            WM_PRINTCLIENT = 0x318,

            WM_HANDHELDFIRST = 0x358,
            WM_HANDHELDLAST = 0x35F,
            WM_PENWINFIRST = 0x380,
            WM_PENWINLAST = 0x38F,
            WM_COALESCE_FIRST = 0x390,
            WM_COALESCE_LAST = 0x39F,
            WM_DDE_FIRST = 0x3E0,
            WM_DDE_INITIATE = 0x3E0,
            WM_DDE_TERMINATE = 0x3E1,
            WM_DDE_ADVISE = 0x3E2,
            WM_DDE_UNADVISE = 0x3E3,
            WM_DDE_ACK = 0x3E4,
            WM_DDE_DATA = 0x3E5,
            WM_DDE_REQUEST = 0x3E6,
            WM_DDE_POKE = 0x3E7,
            WM_DDE_EXECUTE = 0x3E8,
            WM_DDE_LAST = 0x3E8,

            WM_USER = 0x400,
            WM_APP = 0x8000
        }

        /// <summary>
        /// StateItemsData defined the possible state of items data.
        /// None : The data has no change.
        /// UpDate : The data has change.
        /// Import : The data has been imported.
        /// </summary>
        public enum StateItemsData
        {
            /// <summary>
            /// The items data has no change.
            /// </summary>
            [Description("None")]
            None,
            /// <summary>
            /// The items data has change.
            /// </summary>
            [Description("UpDate")]
            UpDate,
            /// <summary>
            /// The items data has been imported.
            /// </summary>
            [Description("Import")]
            Import
        }

        /// <summary>
        /// Enumerate the possible resizable options.
        /// </summary>
        public enum EdgeEnum
        {
            None,
            Right,
            Left,
            Top,
            Bottom,
            Moving,
            BottomRight,
            BottomLeft,
            TopLeft,
            TopRight
        };

        public enum DocumentationBehavior
        {
            /// <summary>
            /// Specified Document will be open.
            /// </summary>
            [Description("Specified Document will be open.")]
            SpecifiedDocument = 1,
            /// <summary>
            /// The last document revision will be open.
            /// </summary>
            [Description("The last document revision will be open.")]
            LastRevision = 2,
            /// <summary>
            /// All Versions Found will be opens.
            /// </summary>
            [Description("All Versions Found will be opens.")]
            AllVersionsFound = 3,
            /// <summary>
            /// The last two versions will be opens.
            /// </summary>
            [Description("The last two versions will be opens.")]
            Last2Versions = 4,
            /// <summary>
            /// The user will be browser for an version.
            /// </summary>
            [Description("The user will be browser for an version.")]
            BrowserForAnVersion = 5,
            /// <summary>
            /// The user will be browser for an version.
            /// </summary>
            [Description("The user will not see any documents.")]
            NoDocumentsExist = 6
        }

        public enum NotificationEvents
        {
            /// <summary>
            /// Warning, TreeView DataBase has been changed.
            /// </summary>
            [Description("Warning, the TreeView Information has been change.")]
            TreeViewStockRoomChange,
            /// <summary>
            /// Warning, DataBase has been updated.
            /// </summary>
            [Description("Warning, the Employees Information has been change.")]
            EmployeesInformationChange,
            /// <summary>
            /// Warning, DataBase has been updated.
            /// </summary>
            [Description("Warning, the department information has been change.")]
            DepartmentInformationChange,
            /// <summary>
            /// Warning, DataBase has been updated.
            /// </summary>
            [Description("Warning,Component Information has been change.")]
            ComponentInformationChange,
            /// <summary>
            /// Warning, DataBase has been updated.
            /// </summary>
            [Description("Warning, DataBase has been updated.")]
            DataBaseUpDated,
            /// <summary>
            /// Warning, Row information has been change by user.
            /// </summary>
            [Description("Warning, Row information change.")]
            RowInformationChange,
            /// <summary>
            /// Warning, a new Row has been added by user.
            /// </summary>
            [Description("Warning, a new Row has been added.")]
            RowAdded,
            /// <summary>
            /// Warning, a Row has been deleted by user.
            /// </summary>
            [Description("Warning, a Row has been removed.")]
            RowRemoved,
            /// <summary>
            /// Warning, DataBase has been change by user.
            /// </summary>
            [Description("Warning, DataBase change.")]
            Warning,
            /// <summary>
            /// Email, an email has been send.
            /// </summary>
            [Description("Email, an email has been send.")]
            Email,
            /// <summary>
            /// Clear all selected roows, do not save the database.
            /// </summary>
            [Description("Clear all selected roows, do not save the database.")]
            ClearAllSelected
        }

        public enum NumericDataFilter
        {
            /// <summary>
            /// Select all value equals to.
            /// </summary>
            [Description("Equals to")]
            Equals,
            /// <summary>
            /// Select all value not equals to.
            /// </summary>
            [Description("NOT Equals")]
            NOT_Equals,
            /// <summary>
            /// Select all value less than.
            /// </summary>
            [Description("Less than")]
            Less_than,
            /// <summary>
            /// Select all value greater than.
            /// </summary>
            [Description("Greater than")]
            Greater_than,
            /// <summary>
            /// Select all value less than or equal to.
            /// </summary>
            [Description("Less than or equal to")]
            Less_than_or_equal_to,
            /// <summary>
            /// Select all value Greater than or equal to.
            /// </summary>
            [Description("Greater than or equal to")]
            Greater_than_or_equal_to
        }

        public enum DataFilter
        {
            /// <summary>
            /// Select all rows regardless of the information.
            /// </summary>
            [Description("Any Information")]
            Any_Information,
            /// <summary>
            /// Select only rows with null value.
            /// </summary>
            [Description("Null Value")]
            Null_Value,
            /// <summary>
            /// Select rows where the value type string is empty.
            /// </summary>
            [Description("Empty String")]
            Empty_String
        }

        public enum ProcessProject
        {
            /// <summary>
            /// Unknown new project, an event from WeekPlanerGrid, double click over
            /// nothing, no select row or no select item or record.
            /// </summary>
            [Description("Unknown new project, event from WeekplanerGrid.")]
            UnknownNewProject,
            /// <summary>
            /// A new project or record, an event from WeekPlanerRow. A double click on
            /// a selected row or record.
            /// </summary>
            [Description("New project, new record, event from WeekPlanerRow.")]
            NewProjectNewRecord,
            /// <summary>
            /// View or edit a record, an event from a record or item doubleClick, the accessLevel
            /// determines whether the current employee is selected to edit o view mode.
            /// </summary>
            [Description("View or Edit a record, event from a Item or Record.")]
            ViewEditRecord
        }

        /// <summary>
        /// Keep information about the process,
        /// AddNew   -> Process to add new component.
        /// Received -> Process to received components.
        /// Adjusted -> Process to adjust the inventory.
        /// </summary>
        public enum ProcessMode
        {
            /// <summary>
            /// Receive Component Process Mode, add to any existent component in StockRoom new quantity of components.
            /// </summary>
            [Description("Receive Component Process Mode")]
            Receive,
            /// <summary>
            /// Inventory Adjustment, we can adjust the quantity existent in StockRoom.
            /// </summary>
            [Description("Inventory Adjustment")]
            Adjust,
            /// <summary>
            /// Inventory Add new, we can add new componet to StockRoom.
            /// </summary>
            [Description("Add new Component")]
            AddNew

        }

        /// <summary>
        /// Defined the edit mode for dataGridView,
        /// View mode : Only are allowed view.
        /// Edit mode : Can only edit on existing data.
        /// Add mode : Allowed to add new data and edit.
        /// Delete mode: Allowed to delete any data.
        /// </summary>
        public enum EditMode
        {
            /// <summary>
            /// Any form of editing is allowed.
            /// </summary>
            View = 0,
            /// <summary>
            /// Editing is permitted, but not add or delete.
            /// </summary>
            Edit = 1,
            /// <summary>
            /// Editing and Add is allowed, but not delete.
            /// </summary>
            Add = 2,
            /// <summary>
            /// Edit, Add and Delete are allowed.
            /// </summary>
            Delete = 3
        }

        /// <summary>
        /// Defined the edit mode for dataGridView,
        /// View mode : Only are allowed view.
        /// Edit mode : Can only edit on existing data.
        /// Add mode : Allowed to add new data and edit.
        /// Delete mode: Allowed to delete any data.
        /// </summary>
        public enum EnableSetting
        {
            /// <summary>
            /// Any form of editing is not allowed.
            /// </summary>
            False = 0,
            /// <summary>
            /// Editing is permitted.
            /// </summary>
            True = 1
        }

        /// <summary>
        /// Defined the user access level :
        /// User            : Only can view basis information.
        /// Editor          : Allowed to edit, add, delete the basis information.
        /// Administrator   : Allowed access to all information.
        /// Manager         : Allowed access to managerial information.
        /// </summary>
        public enum AccessLevel
        {
            User = 0,
            Editor = 1,
            Administrator = 2,
            Manager = 3
        }

        /// <summary>
        /// Keep information about the possible new project,
        /// New_Project       -> Process to start a new project.
        /// Estimated_Project -> Process to start a estimated project.
        /// Inventory_Project -> Process to start a inventory project.
        /// </summary>
        public enum ProjectKind
        {
            /// <summary>
            /// Process to start a new project.
            /// </summary>
            [Description("Start a new project.")]
            New_Project,

            /// <summary>
            /// Process to start a estimated project.
            /// </summary>
            [Description("Start a estimated project.")]
            Estimated_Project,

            /// <summary>
            /// Process to start a inventory project.
            /// </summary>
            [Description("Start a inventory project.")]
            Inventory_Project,

            /// <summary>
            /// Process to add new record in an open project.
            /// </summary>
            [Description("Add new record in an open project.")]
            Partial_prod,

            /// <summary>
            /// Process to hold production an open project.
            /// </summary>
            [Description("Hold production an open project.")]
            Hold_prod,

            /// <summary>
            /// Process to finish and close an open project.
            /// </summary>
            [Description("Finish and close an open project.")]
            Finish_prod
        }

        public enum EncodeMonth
        {
            [Description("January")]
            A = 1,
            [Description("February")]
            B = 2,
            [Description("March")]
            C = 3,
            [Description("April")]
            D = 4,
            [Description("May")]
            E = 5,
            [Description("June")]
            F = 6,
            [Description("July")]
            G = 7,
            [Description("August")]
            H = 8,
            [Description("September")]
            I = 9,
            [Description("October")]
            J = 10,
            [Description("November")]
            K = 11,
            [Description("December")]
            L = 12
        }

        public enum EncodeYear
        {
            [Description("2001")]
            A = 2001,
            [Description("2002")]
            B = 2002,
            [Description("2003")]
            C = 2003,
            [Description("2004")]
            D = 2004,
            [Description("2005")]
            E = 2005,
            [Description("2006")]
            F = 2006,
            [Description("2007")]
            G = 2007,
            [Description("2008")]
            H = 2008,
            [Description("2009")]
            I = 2009,
            [Description("2010")]
            J = 2010,
            [Description("2011")]
            K = 2011,
            [Description("2012")]
            L = 2012,
            [Description("2013")]
            M = 2013,
            [Description("2014")]
            N = 2014,
            [Description("2015")]
            O = 2015,
            [Description("2016")]
            P = 2016,
            [Description("2017")]
            Q = 2017,
            [Description("2018")]
            R = 2018,
            [Description("2019")]
            S = 2019,
            [Description("2020")]
            T = 2020,
            [Description("2021")]
            U = 2021,
            [Description("2022")]
            V = 2022,
            [Description("2023")]
            W = 2023,
            [Description("2024")]
            X = 2024,
            [Description("2025")]
            Y = 2025,
            [Description("2026")]
            Z = 2026
        }

        public enum EncodeCode
        {
            [Description("014")]
            A = 014,
            [Description("015")]
            B = 015,
            [Description("018")]
            C = 018,
            [Description("040")]
            D = 040,
            [Description("045")]
            E = 045,
            [Description("050")]
            F = 050,
            [Description("055")]
            G = 055,
            [Description("056")]
            H = 056,
            [Description("058")]
            I = 058,
            [Description("060")]
            J = 060,
            [Description("065")]
            K = 065,
            [Description("070")]
            L = 070,
            [Description("075")]
            M = 070,
            [Description("080")]
            N = 080,
            [Description("090")]
            O = 090,
            [Description("095")]
            P = 095,
            [Description("098")]
            Q = 098,
            [Description("099")]
            R = 099,
            [Description("103")]
            S = 103,
            [Description("104")]
            T = 104,
            [Description("105")]
            U = 105,
            [Description("106")]
            V = 106,
            [Description("107")]
            W = 107,
            [Description("108")]
            X = 108,
            [Description("109")]
            Y = 109,
            [Description("110")]
            Z = 110
        }

        public enum HTMLEditor
        {
            [Description("Full editor interface.")]
            FullEditor,
            [Description("Simple editor, minimal interface.")]
            SimpleEditor,
            [Description("Full editor, blue skin interface.")]
            O2k7Editor
        }

        public enum HTMLFileTemple
        {
            /// <summary>
            /// Select all value equals to.
            /// </summary>
            [Description("Application")]
            Application,
            /// <summary>
            /// Select all value not equals to.
            /// </summary>
            [Description("SMT Project")]
            SMTproject,
            /// <summary>
            /// Select all value less than.
            /// </summary>
            [Description("Less than")]
            Less_than,
            /// <summary>
            /// Select all value greater than.
            /// </summary>
            [Description("Greater than")]
            Greater_than,
            /// <summary>
            /// Select all value less than or equal to.
            /// </summary>
            [Description("Less than or equal to")]
            Less_than_or_equal_to,
            /// <summary>
            /// Select all value Greater than or equal to.
            /// </summary>
            [Description("Greater than or equal to")]
            Greater_than_or_equal_to
        }

        /// <summary>
        /// This enum is used to determine the status of each element in a DataGridView rows collection,
        /// also to alter the status of a selected item.
        /// </summary>
        public enum RowStatus
        {
            [Description("This row can not be deleted.")]
            Unerasable,
            [Description("This row is write protected.")]
            Locked,
            [Description("This row has been selected.")]
            Selected
        }

        public enum BarCodeSuffix
        {
            [Description("00 NULL (SP)")]
            SP = 0,
            [Description("01 (SOH)")]
            SOH = 1,
            [Description("02 (STX)")]
            STX = 2,
            [Description("03 (ETX)")]
            ETX = 3,
            [Description("04 (EOT) END OF TRANSMISSION")]
            EOT = 4,
            [Description("05 (ENQ)")]
            ENQ = 5,
            [Description("06 (ACK)")]
            ACK = 6,
            [Description("07 (BEL)")]
            BEL = 7,
            [Description("08 (BackSpace)")]
            BackSpace = 8,
            [Description("0D (CarriageReturn)")]
            CarriageReturn = 13
        }

        public static string GetDescription(Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);

            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    var attr = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;

                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }

        #endregion"My Enums declaration"

        public static T ParseEnum<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value, ignoreCase: true);
        }

        /// <summary>
        /// How parse a string to enum value.
        /// </summary>
        public void UseParseEnum()
        {
            StateItemsData testEnumParse;
            testEnumParse = ParseEnum<StateItemsData>("None");
            //.NET 4.0 has a generic Enum.TryParse
            testEnumParse = (StateItemsData)Enum.Parse(typeof(StateItemsData), "None", true);
            bool testParseOK = Enum.TryParse("None", true, out testEnumParse);
        }

        #region"Check if value is defined in enum keys."

        /*
        private void HowTest_if_Keyis_Defined()
        {
            string PartNumber = "014-0234";

            if (FileSystemExt.IsDefinedEnum(typeof(FileSystemExt.EncodeCode), PartNumber.Substring(0, 3)))
            {
                // Do some code here.

            }

        }
        public static bool IsDefinedEnum<T>(this T enumtes, string value)
        {
            return System.Enum.IsDefined(typeof(T), value);
        }
         */

        #endregion"Check if value is defined in enum keys."

        #endregion"Enums are strongly typed constants"

        #region"Convert string to Dictionary and dictionary to string, check is no null"

        /// <summary>
        /// Converts SortedDictionary to a string in the form: Name:Quantity;
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static string GetString(SortedDictionary<string, int> dict)
        {
            if (dict.Count == 0)
                return "Error:1;Error:2";

            //Build up each line one by one and them trim the end
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, int> pair in dict)
            {
                if (string.IsNullOrEmpty(pair.Value.ToString()) || string.IsNullOrWhiteSpace(pair.Value.ToString()))
                {
                    MessageBox.Show("Error in string information, Dictionary format is as follows 'Name:int', " + pair.Key + " : lose value",
                                            "Dictionary information loss in GetString procedure.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }

                builder.Append(pair.Key).Append(":").Append(pair.Value).Append(";");
            }

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd(';');

            return result;
        }

        public static SortedDictionary<string, int> GetDict(string stringDict)
        {
            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();

            if (string.IsNullOrEmpty(stringDict) || string.IsNullOrWhiteSpace(stringDict))
                return dict;

            // Divide all pairs (remove empty strings)
            string[] allRecords = new string[] { stringDict };
            if (stringDict.Contains(";"))
                allRecords = stringDict.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            // Walk through each item
            int countError = 0;
            foreach (string projectRecord in allRecords)
            {
                if (!projectRecord.Contains(":"))
                {
                    countError++;
                    dict.Add("Error Information Loss : " + countError, 0);
                    continue;
                }

                if (projectRecord.Count(x => x == ':') > 1)
                {
                    countError++;
                    dict.Add("Error Information Founded twice : " + countError, 0);
                    continue;
                }

                int value = 0;
                string[] projectNameValue = projectRecord.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);

                // Parse the int (this can throw)
                try
                {
                    value = int.Parse(projectNameValue[(projectNameValue.Length - 1)]);
                }
                catch (Exception)
                {
                    value = 0;
                    countError++;
                    dict.Add("Error Information Parse value " + projectNameValue[(projectNameValue.Length - 1)] + countError, 0);
                }

                // Fill the value in the sorted dictionary
                if (dict.ContainsKey(projectNameValue[0].Trim()))
                {
                    countError++;
                    dict.Add("Error Information Duplicated key " + projectNameValue[0] + countError, 0);
                }
                else
                {
                    dict.Add(projectNameValue[0].Trim(), value);
                }
            }
            return dict;
        }

        /// <summary>
        /// Convert dictionary(string,Boolean) to a string contained all information.
        /// "Unerasable:true;Locked:true;Selected:false"
        /// </summary>
        /// <param name="dict"></param>
        /// <returns></returns>
        public static string GetString(SortedDictionary<string, bool> dict)
        {
            //Build up each line one by one and them trim the end
            StringBuilder builder = new StringBuilder();
            foreach (KeyValuePair<string, bool> pair in dict)
            {
                builder.Append(pair.Key).Append(":").Append(pair.Value).Append(";");
            }

            string result = builder.ToString();
            //Remove the final delimiter
            result = result.TrimEnd(';');

            return result;
        }

        public static SortedDictionary<string, bool> GetDictBool(string value)
        {
            SortedDictionary<string, bool> dict = new SortedDictionary<string, bool>();

            // Divide all pairs (remove empty strings)
            string[] _strings = value.Split(new char[] { ':', ';' }, StringSplitOptions.RemoveEmptyEntries);

            if (_strings.Length < 2)
                return dict;

            // Walk through each item
            for (int i = 0; i < _strings.Length; i += 2)
            {
                string _name = _strings[i];
                bool _value = Convert.ToBoolean(_strings[i + 1]);

                // Fill the value in the sorted dictionary
                if (dict.ContainsKey(_name))
                {
                    dict[_name] = _value;
                }
                else
                {
                    dict.Add(_name, _value);
                }
            }
            return dict;
        }


        public static string DescriptionExpand(string Who_uses_this, Font _font, Graphics _graphics)
        {
            string information;
            Font font = _font;

            if (Who_uses_this == "")
            {
                information = null;
                return information;
            }

            float space_Size = _graphics.MeasureString(". ", font).Width;
            float maxSpace = 0.0f;

            int padRight = 0;

            int count = 1;
            float actual_space = 0;
            string rowInfo = "";

            string headtext = "";
            string headline = "";
            string _punts;

            bool isSmall = false;

            var dict = Utilities.GetDict(Who_uses_this);

            #region"Max_Space & Max_String"

            foreach (KeyValuePair<string, int> inf in dict)
            {
                // if (maxSpace < graphics.MeasureString(inf.Key.PadRight(inf.Key.Length, '.'), Font).Width)
                if (maxSpace < _graphics.MeasureString(inf.Key, _font).Width)
                {
                    maxSpace = _graphics.MeasureString(inf.Key, _font).Width;
                    padRight = (Int32)(maxSpace / space_Size);
                }
            }

            #endregion"Max_Space & Max_String"

            count = 1;
            headtext = " Project Name";
            actual_space = _graphics.MeasureString(headtext, font).Width;

            float def = (maxSpace - actual_space) / 6;

            #region"Positioning string Comp used."
            // Psitioning string Comp used.
            if (actual_space < maxSpace)
            {
                while ((actual_space + def) < maxSpace)
                {
                    headtext = " Project Name".PadRight(count, '.');
                    actual_space = _graphics.MeasureString(headtext, _font).Width;

                    count++;
                }

                headtext += ".....Comp used.\r\n";
            }
            else
            {
                isSmall = true;
                headtext += "    Comp used.\r\n";

            }

            #endregion"Positioning string Comp used."

            count = 1;
            actual_space = _graphics.MeasureString(rowInfo, font).Width;
            while (actual_space < maxSpace)
            {
                rowInfo = rowInfo.PadRight(count, '-');
                actual_space = _graphics.MeasureString(rowInfo, font).Width;

                count++;
            }
            headline = "|------" + rowInfo + string.Format("|".PadRight(20, '-')) + "|\r\n";


            information = headtext + headline;

            Font _myfont = new Font(font, FontStyle.Bold);

            maxSpace = maxSpace + 10;

            foreach (KeyValuePair<string, int> inf in dict)
            {
                rowInfo = " " + inf.Key;

                _punts = ".";
                count = 1;
                actual_space = _graphics.MeasureString(rowInfo, _myfont).Width;

                if (maxSpace <= actual_space)
                    def = (actual_space - maxSpace) / 6;
                else
                    def = (maxSpace - actual_space) / 5.55f;

                float _actualSpace = actual_space - def;
                float _maxSpace = maxSpace + 9;

                if (_actualSpace <= _maxSpace)
                {
                    while (_actualSpace < _maxSpace)
                    {
                        _punts = _punts.PadRight(count, '.');
                        _actualSpace = _graphics.MeasureString(rowInfo + _punts, _myfont).Width;
                        //    _actualSpace -= def;
                        count++;
                    }

                    if (isSmall)
                        rowInfo += "..........." + inf.Value.ToString();
                    else
                        rowInfo += _punts + inf.Value.ToString();
                }
                else
                {
                    rowInfo += "." + inf.Value.ToString();

                }

                information += rowInfo + "\r\n";

            }

            return information;
        }

        public static string DescriptionExpand(string Who_uses_this, Font _font, Graphics _graphics, int OnAvailable,
                                                                     string BindingSourceFilter, string RootNodeActived)
        {
            string information;

            if (Who_uses_this == "")
            {
                information = "This component has not been assigned to any other project.<br/>";
                return information;
            }

            Font UsedFont = _font;

            float space_Size = _graphics.MeasureString(". ", UsedFont).Width;
            float maxSpace = 0;

            int padRight = 0;

            string headtext = "";
            string headline = "";

            var dict = Utilities.GetDict(Who_uses_this);

            #region"Max_Space & Max_String"

            foreach (KeyValuePair<string, int> inf in dict)
            {
                if (maxSpace < _graphics.MeasureString(inf.Key.PadRight(inf.Key.Length, '.'), _font).Width)
                {
                    maxSpace = _graphics.MeasureString(inf.Key + ".", _font).Width;
                    padRight = (Int32)(maxSpace / space_Size);
                }
            }

            #endregion"Max_Space & Max_String"

            if (maxSpace < 125)
            {
                maxSpace = 125;
                headtext = string.Format("Project Name".PadRight(16)) + string.Format("Number of Comp used".PadRight(24)) + "Enough to produced<br/>";
                headline = string.Format("|".PadLeft(24, '-')) + string.Format("|".PadLeft(40, '-')) + "----------------------------------<br/>";
            }
            else
            {
                headtext = string.Format("Project Name".PadRight(padRight)) + string.Format("Number of Comp used".PadRight(24)) + "Enough to produced<br/>";
                headline = "---------------------------|-------------------------------------------|-----------------------------------<br/>";
            }

            information = headtext + headline;

            Font _fontBold = new Font(UsedFont, FontStyle.Bold);

            string Active_Filter = Utilities.GetTextfrontFilter(BindingSourceFilter);

            foreach (KeyValuePair<string, int> inf in dict)
            {
                string rowInfo = "";
                int count = 1;
                int max_prod;

                float actual_space = _graphics.MeasureString(inf.Key, UsedFont).Width;

                if (inf.Key.Contains(Active_Filter))
                {
                    if (RootNodeActived != "Stock Room")
                    {
                        rowInfo = "<b>";
                        actual_space = _graphics.MeasureString(rowInfo, _fontBold).Width;
                    }
                }

                rowInfo += inf.Key;

                // 1122-02 External Speaker...........
                while (actual_space < maxSpace)
                {
                    rowInfo = rowInfo.PadRight(count, '.');
                    actual_space = _graphics.MeasureString(rowInfo, UsedFont).Width;

                    if (inf.Key.Contains(Active_Filter))
                        actual_space = _graphics.MeasureString(rowInfo, _font).Width;

                    count++;
                }

                // 1122-02 External Speaker...........4
                if (inf.Value < 10)
                {
                    rowInfo = rowInfo.PadRight(2, '.');
                    rowInfo += inf.Value.ToString();
                }
                // 1122-02 External Speaker..........23
                else
                    if (inf.Value < 100)
                    {
                        rowInfo = rowInfo.PadRight(1, '.');
                        rowInfo += inf.Value.ToString();
                    }

                // 1122-02 External Speaker..........23................
                count = 1;
                while (actual_space < 250)
                {
                    rowInfo = rowInfo.PadRight(count, '.');
                    actual_space = _graphics.MeasureString(rowInfo, UsedFont).Width;

                    if (inf.Key.Contains(Active_Filter))
                        actual_space = _graphics.MeasureString(rowInfo, _font).Width;

                    count++;
                }

                // 1122-02 External Speaker..........23................51
                max_prod = OnAvailable / inf.Value;

                if (inf.Key.Contains(Active_Filter))
                {
                    if (RootNodeActived != "Stock Room")
                    {
                        rowInfo += max_prod + "</b>";
                        information += rowInfo + "<br/>";
                    }
                }
                else
                    information += rowInfo + max_prod + "<br/>";

            }

            information += "--------------------------------------------------------------------------------------------------<br/>";

            return information;
        }

        /// <summary>
        /// Extract the string Text front the filter, this have to be
        /// "PartNumber Like '*044-34*'", the '----' most be present.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public static string GetTextfrontFilter(string filter)
        {
            if (filter == null)
                return "";

            if (!(filter.Contains("'")))
                return "";

            int _starIndex = filter.IndexOf('\'') + 1;
            int _lengt = filter.LastIndexOf('\'') - _starIndex;

            filter = filter.Substring(_starIndex, _lengt);
            filter = filter.Replace("*", "");

            return filter.Trim();
        }

        #endregion"Convert string to Dictionary and dictionary to string, check is no null"

        #region"ConvertToInt,FastParse and CastAs<T>"

        /// <summary>
        /// Return true if the number is even. Divisible by 2.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEven(int value)
        {
            return value % 2 == 0;
        }

        /// <summary>
        /// Convert int value 0 to false, any other int value != 0 will be true;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AsBool(int value)
        {
            if (value == 0)
                return false;

            return true;
        }

        /// <summary>
        /// Convert string to false, any other string != "" will be true;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool AsBool(string value)
        {
            if (value == "")
                return false;

            return true;
        }

        /// <summary>
        /// Convert bool value true to int 1 and bool value false to int 0;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int AsInt(bool value)
        {
            if (value)
                return 1;

            return 0;
        }

        /// <summary>
        /// Converts strings into ints. Often we have strings containing char digits.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int IntParseFast(string value)
        {
            int result = 0;

            if (string.IsNullOrEmpty(value))
                return result;

            for (int index = 0; index < value.Length; index++)
            {
                result = 10 * result + (value[index] - 48);
            }
            return result;
        }

        public static int Get_Value(string value)
        {
            if (!(string.IsNullOrEmpty(value)))
            {
                int result = Convert.ToInt32(string.Format("{0:0}", value));

                if (result < 0)
                    return 0;
                else
                    return result;
            }
            else
                return 0;
        }

        public static string Get_String(string value)
        {
            if (!(string.IsNullOrEmpty(value)))
                return value.Trim();

            return "0";
        }

        public static class ConvertDBNull
        {
            public static T To<T>(object value, T defaultValue)
            {
                if (value == DBNull.Value)
                    return defaultValue;

                return (T)Convert.ChangeType(value, typeof(T));
            }
        }

        //public static object DbNullIfNull(object obj)
        //{
        //   return obj != null ? obj : DBNull.Value;
        //}

        //public static object DbNullIfNullOrEmpty(string str)
        //{
        //   return !String.IsNullOrEmpty(str) ? str : DBNull.Value;
        //}

        public static T CastAs<T>(object value, T defaultValue)
        {
            if (value == DBNull.Value)
                return defaultValue;

            return (T)Convert.ChangeType(value, typeof(T));
        }

        public static int CastAsInt(object value)
        {
            if (value != DBNull.Value)
                return Convert.ToInt32(value);

            return 0;
        }

        public static void ConvertHexToString()
        {
            byte[] data = { 1, 2, 4, 8, 16, 32 };

            string hex = BitConverter.ToString(data);
            //Result: 01-02-04-08-10-20

            //If you want it without the dashes, just remove them:

            string hex1 = BitConverter.ToString(data).Replace("-", string.Empty);
            //Result: 010204081020

            //If you want a more compact representation, you can use Base64:

            string base64 = Convert.ToBase64String(data);
            //Result: AQIECBAg

        }

        public static string ByteArrayToHexString(byte[] Bytes)
        {
            StringBuilder Result = new StringBuilder(Bytes.Length * 2);
            string HexAlphabet = "0123456789ABCDEF";

            foreach (byte B in Bytes)
            {
                Result.Append(HexAlphabet[(int)(B >> 4)]);
                Result.Append(HexAlphabet[(int)(B & 0xF)]);
            }

            return Result.ToString();
        }

        public static byte[] HexStringToByteArray(string Hex)
        {
            byte[] Bytes = new byte[Hex.Length / 2];
            int[] HexValue = new int[] { 0x00, 0x01, 0x02, 0x03, 0x04, 0x05,
            0x06, 0x07, 0x08, 0x09, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,
            0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            for (int x = 0, i = 0; i < Hex.Length; i += 2, x += 1)
            {
                Bytes[x] = (byte)(HexValue[Char.ToUpper(Hex[i + 0]) - '0'] << 4 | HexValue[Char.ToUpper(Hex[i + 1]) - '0']);
            }

            return Bytes;
        }

        public static decimal CodeSMTAxes(string hexCodeValue)
        {
            // Array index.
            int valueIndex = 0;

            int[] HexValue = new int[] { 0x00, 0x30E0, 0x60C0, 0x90A0, 0xC080, 0xF060, 0x2041, 0x5021,
                                         0x8001, 0xB0E1, 0xE0C1, 0x10A2, 0x4082, 0x7062, 0xA042, 0xD022, 0x0003 };

            int[] DecHexValue = new int[] { 0x00, 0x0300, 0x0700, 0x0B00, 0x0F00, 0x1300, 0x1700, 0x1B00,
                                         0x1F00, 0x2200, 0x2600, 0x2A00, 0x2E00, 0x3200, 0x3600, 0x3A00, 0x3E00 };

            int codeValue;
            string primeroCuatros = hexCodeValue.Substring(0, 4);
            bool goValue = int.TryParse(primeroCuatros, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out codeValue);

            for (int i = 0; i < HexValue.Length; i++)
            {
                if (HexValue[i] == codeValue)
                {
                    valueIndex = i;
                    break;
                }
            }

            goValue = int.TryParse(hexCodeValue.Substring(4, 4), NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out codeValue);

            decimal INTcodeValue = (codeValue - DecHexValue[valueIndex]) / 1000;
            INTcodeValue += valueIndex;

            return INTcodeValue;
        }

        public static decimal CodeSMTAxes(byte[] hexCodeValue)
        {
            // Array index.
            int valueIndex = 0;

            string hexcodevalue = BitConverter.ToString(hexCodeValue).Replace("-", string.Empty);

            int[] HexValue = new int[] { 0x00, 0x30E0, 0x60C0, 0x90A0, 0xC080, 0xF060, 0x2041, 0x5021,
                                         0x8001, 0xB0E1, 0xE0C1, 0x10A2, 0x4082, 0x7062, 0xA042, 0xD022, 0x0003 };

            int[] DecHexValue = new int[] { 0x00, 0x0300, 0x0700, 0x0B00, 0x0F00, 0x1300, 0x1700, 0x1B00,
                                         0x1F00, 0x2200, 0x2600, 0x2A00, 0x2E00, 0x3200, 0x3600, 0x3A00, 0x3E00 };

            int codeValue;
            string primeroCuatros = hexcodevalue.Substring(0, 4);
            bool goValue = int.TryParse(primeroCuatros, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out codeValue);

            for (int i = 0; i < HexValue.Length; i++)
            {
                if (HexValue[i] == codeValue)
                {
                    valueIndex = i;
                    break;
                }
            }

            string segundoCuatros = hexcodevalue.Substring(4, 4);
            goValue = int.TryParse(segundoCuatros, NumberStyles.AllowHexSpecifier, CultureInfo.InvariantCulture, out codeValue);

            decimal INTcodeValue = (codeValue - DecHexValue[valueIndex]) / 1000;
            INTcodeValue += valueIndex;

            return INTcodeValue;
        }

        #endregion"ConvertToInt,FastParse and CastAs<T>"

        #region"Date Time converters."

        public static string TimeAgo(DateTime dt)
        {
            TimeSpan span = DateTime.Now - dt;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                if (span.Days % 365 != 0)
                    years += 1;

                return string.Format("about {0} {1} ago", years, years == 1 ? "year" : "years");
            }

            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                if (span.Days % 31 != 0)
                    months += 1;
                return string.Format("about {0} {1} ago", months, months == 1 ? "month" : "months");
            }

            if (span.Days > 0)
                return string.Format("about {0} {1} ago", span.Days, span.Days == 1 ? "day" : "days");
            if (span.Hours > 0)
                return string.Format("about {0} {1} ago", span.Hours, span.Hours == 1 ? "hour" : "hours");
            if (span.Minutes > 0)
                return string.Format("about {0} {1} ago", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            if (span.Seconds > 5)
                return string.Format("about {0} seconds ago", span.Seconds);
            if (span.Seconds <= 5)
                return "just now";

            return string.Empty;
        }

        public static string TimeFromNow(DateTime dt)
        {
            if (dt < DateTime.Now)
                return "about sometime ago";
            TimeSpan span = dt - DateTime.Now;
            if (span.Days > 365)
            {
                int years = (span.Days / 365);
                return string.Format("about {0} {1} from now", years, years == 1 ? "year" : "years");
            }
            if (span.Days > 30)
            {
                int months = (span.Days / 30);
                return string.Format("about {0} {1} from now", months, months == 1 ? "month" : "months");
            }
            if (span.Days > 0)
                return string.Format("about {0} {1} from now", span.Days, span.Days == 1 ? "day" : "days");
            if (span.Hours > 0)
                return string.Format("about {0} {1} from now", span.Hours, span.Hours == 1 ? "hour" : "hours");
            if (span.Minutes > 0)
                return string.Format("about {0} {1} from now", span.Minutes, span.Minutes == 1 ? "minute" : "minutes");
            if (span.Seconds > 5)
                return string.Format("about {0} seconds from now", span.Seconds);
            if (span.Seconds == 0)
                return "just now";

            return string.Empty;
        }

        #endregion"Date Time converters."

        #region"Convert or parse string to DateTime."

        private static string[] formats = new string[]
        {
            "H:mm",                                     // 6:30
            "HH:mm",                                    // 06:30
            "h:mm tt",                                  // 6:30 AM
            "hh:mm tt",                                 // 06:30 AM            
            "HH:mm:ss",                                 // 06:30:07
            
            "MM/dd/yyyy",                               // 08/22/2006
            "MM/dd/yyyy HH:mm",                         // 08/22/2006 06:30
            "M/dd/yyyy H:mm:ss tt",                     //  8/22/2006 06:30 AM
            "MM/dd/yyyy hh:mm tt",                      // 08/22/2006 06:30 AM
            "MM/dd/yyyy H:mm",                          // 08/22/2006 6:30
            "MM/dd/yyyy HH:mm:ss",                      // 08/22/2006 06:30:07
            "M/dd/yyyy H:mm:ss"  ,                      //  8/22/2006 06:30:07
     
            "dddd, dd MMMM yyyy",                       // Tuesday, 22 August 2006
            "dddd, dd MMMM yyyy HH:mm",                 // Tuesday, 22 August 2006 06:30
            "dddd, dd MMMM yyyy hh:mm tt",              // Tuesday, 22 August 2006 06:30 AM
            "dddd, dd MMMM yyyy H:mm",                  // Tuesday, 22 August 2006 6:30
            "dddd, dd MMMM yyyy h:mm tt",               // Tuesday, 22 August 2006 6:30 AM
            "dddd, dd MMMM yyyy HH:mm:ss",              // Tuesday, 22 August 2006 06:30:07
            "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'",      // Tues, 22 Aug 2006 06:30:07 GMT

            "MMMM dd",                                  // August 22
            "yyyy MMMM",                                // 2006 August
            "yyyy'-'MM'-'dd HH':'mm':'ss'Z'",           // 2006-08-22 06:30:07Z
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK",   // 2006-08-22T06:30:07.7199222-04:00
            "yyyy'-'MM'-'dd'T'HH':'mm':'ss"             // 2006-08-22T06:30:07
        };

        public static DateTime ParseDate(string input)
        {
            DateTime result;
            if (DateTime.TryParseExact(input, formats, CultureInfo.InvariantCulture, DateTimeStyles.None, out result))
            {
                return result;
            }
            return DateTime.Now;
        }

        #endregion"Convert or parse string to DateTime."

        #region"DesignMode and Conditional Break Point."

        public static bool IsInDesignMode()
        {
            bool returnFlag = false;
#if DEBUG
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
            {
                returnFlag = true;
            }
            else
                using (Process process = System.Diagnostics.Process.GetCurrentProcess())
                {
                    returnFlag = process.ProcessName.ToLower().Trim() == "devenv";
                }
#endif
            return returnFlag;
        }

        public static void ConditionalBreakPoint(bool condition)
        {
#if DEBUG
            if (condition)
                System.Diagnostics.Debugger.Break();
#endif
        }

        public static bool IsDesignMode(Control caller)
        {
            // Use this class to test if you are in design mode or not.
            while (caller != null)
            {
                if (caller.Site == null)
                    return false; //not designer mode
                if (caller.Site.DesignMode)
                    return true;

                caller = caller.Parent;
            }
            return false;
        }

        #endregion"DesignMode and Conditional Break Point."

        #region"DataView, RowFilter"

        /// <summary>
        /// If a pattern in a LIKE clause contains any of these special characters * % [ ],
        /// <para></para>
        /// those characters must be escaped in brackets [ ] like this [*], [%], [[] or []].
        /// </summary>
        /// <param name="valueWithoutWildcards"></param>
        /// <returns></returns>
        public static string EscapeLikeValue(string valueWithoutWildcards)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < valueWithoutWildcards.Length; i++)
            {
                char c = valueWithoutWildcards[i];
                if (c == '*' || c == '%' || c == '[' || c == ']')
                    sb.Append("[").Append(c).Append("]");
                else if (c == '\'')
                    sb.Append("''");
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }

        /// <summary>
        /// If a column name contains any of these special characters ~ ( ) # \ / = > + - * % | ^ ' " [ ],
        /// <para></para>
        /// you must enclose the column name within square brackets [ ].
        /// <para></para>
        /// If a column name contains right bracket ] or backslash \, escape it with backslash (\] or \\).
        /// </summary>
        public void ColumnNameException()
        {
            // special characters < and & cant' not be in XML.
            //If a column name contains any of these special characters ~ ( ) # \ / = > < + - * % & | ^ ' " [ ],
            //you must enclose the column name within square brackets [ ].
            //If a column name contains right bracket ] or backslash \, escape it with backslash (\] or \\).

            DataView dataView = new DataView();

            dataView.RowFilter = "id = 10";      // no special character in column name "id"
            dataView.RowFilter = "$id = 10";     // no special character in column name "$id"
            dataView.RowFilter = "[#id] = 10";   // special character "#" in column name "#id"
            dataView.RowFilter = "[[id\\]] = 10"; // special characters in column name "[id]"
        }

        #endregion"DataView, RowFilter"

        #region"Valid File.Ext in image or picture file"

        static readonly string[] _validExtensions = { ".jpg", ".bmp", ".gif", ".png", ".jpeg" };
        //private static string[] _validExtensions;

        static string[] ValidExtensions()
        {
            if (_validExtensions == null)
            {
                // load from app.config, text file, DB, wherever
            }
            return _validExtensions;
        }

        public static bool IsImageExtension(string ext)
        {
            return ValidExtensions().Contains(ext.ToLower());
        }

        //This method automatically creates a filter for the OpenFileDialog. It uses the informations
        //of the image decoders supported by Windows. It also adds information of "unknown" image
        //formats (see default case of the switch statement).
        static string SupportedImageDecodersFilter()
        {
            // ext = "*.BMP;*.DIB;*.RLE"           descr = BMP
            // ext = "*.JPG;*.JPEG;*.JPE;*.JFIF"   descr = JPEG
            // ext = "*.GIF"                       descr = GIF
            // ext = "*.TIF;*.TIFF"                descr = TIFF
            // ext = "*.PNG"                       descr = PNG

            ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();

            string allExtensions = "";//encoders.Select(enc => enc.FilenameExtension).Join(";").ToLowerInvariant();
            var sb = new StringBuilder(500)
                .AppendFormat("Image files  ({0})|{1}", allExtensions.Replace(";", ", "),
                              allExtensions);
            foreach (ImageCodecInfo encoder in encoders)
            {
                string ext = encoder.FilenameExtension.ToLowerInvariant();
                string caption;
                switch (encoder.FormatDescription)
                {
                    case "BMP":
                        caption = "Windows Bitmap";
                        break;
                    case "JPEG":
                        caption = "JPEG file";
                        break;
                    case "GIF":
                        caption = "Graphics Interchange Format";
                        break;
                    case "TIFF":
                        caption = "Tagged Image File Format";
                        break;
                    case "PNG":
                        caption = "Portable Network Graphics";
                        break;
                    default:
                        caption = encoder.FormatDescription;
                        break;
                }
                sb.AppendFormat("|{0}  ({1})|{2}", caption, ext.Replace(";", ", "), ext);
            }
            return sb.ToString();
        }
        //Use it like this:
        void UseItLike()
        {
            var dlg = new OpenFileDialog
            {
                Filter = SupportedImageDecodersFilter(),
                Multiselect = false,
                Title = "Choose Image"
            };
        }

        #endregion"Valid File.Ext in image or picture file"

        #region"Valided if PartNumber is a BOM"

        static readonly string[] _validPartNumberBOM = { "AT", "ATT", "FTN", "IGER", "IKEN", "IMAR", "IMID", "IMOT", "VA", "VE", "210", "310", "410", "510" };
        //private static string[] _validExtensions;

        static string ValidPartNumberBOM(string partNumber)
        {
            if (_validPartNumberBOM == null)
            {
                // load from app.config, text file, DB, wherever
            }

            foreach (var item in _validPartNumberBOM)
            {
                if (partNumber.Contains(item))
                { return item; }
            }
            return "NotValid";
        }

        /// <summary>
        /// IsPartNumberBOM is true if the PartNumber is defined into the list of accepted BOM name.
        /// </summary>
        public static bool IsPartNumberBOM(string partNumber)
        {
            return partNumber.Contains(ValidPartNumberBOM(partNumber), StringComparison.OrdinalIgnoreCase);
        }

        #endregion"Valided if PartNumber is a BOM"

        #region"Getting and Setting the Mouse Position and Clicking the Mouse."

        public class MouseUtility
        {
            /// <summary>
            /// Struct representing a point. 
            /// </summary>
            [StructLayout(LayoutKind.Sequential)]
            public struct POINT
            {
                public int X;
                public int Y;
                public static implicit operator Point(POINT point)
                {
                    return new Point(point.X, point.Y);
                }
            }

            /// <summary>
            /// Retrieves the cursor's position, in screen coordinates.
            /// </summary>
            /// <see>See MSDN documentation for further information.</see>
            [DllImport("user32.dll")]
            public static extern bool GetCursorPos(out POINT lpPoint);
            public static Point GetCursorPosition()
            {
                POINT lpPoint;
                GetCursorPos(out lpPoint);
                //bool success = User32.GetCursorPos(out lpPoint);
                // if (!success)
                return lpPoint;
            }


            /// <summary>
            /// Sets the cursor position to the location of the control.
            /// </summary>
            public static void MousePointerPosition(Control value)
            {
                var _TopParent = value.Parent;

                int Xposition = value.Location.X;

                int Yposition = value.Location.Y;

                while (_TopParent != null)
                {
                    if (_TopParent.Location.X > 0)
                        Xposition += _TopParent.Location.X;

                    if (_TopParent.Location.Y > 0)
                        Yposition += _TopParent.Location.Y;

                    _TopParent = _TopParent.Parent;

                }

                Xposition += 20;
                Yposition += 45;

                Cursor.Position = new Point(Xposition, Yposition);

            }

            /// <summary>
            /// Set the mouse pointer in the center of this control.
            /// </summary>
            /// <param name="control_ref"></param>
            public static void MousePointerPositionToCenterOf(Control control_ref)
            {
                Point sendMouseto = control_ref.PointToScreen(control_ref.Location);

                int control_X_centrer = control_ref.Width / 2;
                int control_Y_centrer = control_ref.Height / 2;

                sendMouseto.X += control_X_centrer;
                sendMouseto.Y -= 24;

                Cursor.Position = sendMouseto;

            }

            /// <summary>
            /// Sets the cursor position to the location of the control.
            /// Plus X and Y offset.
            /// </summary>
            public static void MousePointerPosition(Control control_ref, int x, int y)
            {
                Point sendMouseto = control_ref.PointToScreen(control_ref.Location);

                int control_X_centrer = control_ref.Height / 2;
                int control_Y_centrer = control_ref.Width / 2;

                sendMouseto.X += control_X_centrer + x;
                sendMouseto.Y += control_Y_centrer + y;

                Cursor.Position = sendMouseto;

            }

            /// <summary>
            /// This funtion allows us to click the mouse.
            /// </summary>
            // this allows us to make a call to the native user32 dll
            [DllImport("user32.dll")]
            public static extern void Mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

            [DllImport("user32.dll")]
            public static extern IntPtr GetMessageExtraInfo();

            [DllImport("user32.dll")]
            public static extern bool CloseWindow(IntPtr iHandle);

            #region"Luke Quinane answer modif."

            public enum InputType : int
            {
                Mouse = 0,
                Keyboard = 1,
                Hardware = 2
            };

            public enum MouseFlags : uint
            {
                Move = 0x0001,     // MouseEventF_Move - Specifies that movement occurred.
                LeftDown = 0x0002,     // MouseEventF_LeftDown -Specifies that the left button was pressed.
                LeftUp = 0x0004,     // MouseEventF_LeftUp - Specifies that the left button was released.
                RightDown = 0x0008,     // MouseEventF_RightDown - Specifies that the right button was pressed.
                RightUp = 0x0010,     // MouseEventF_Rightup - Specifies that the right button was released.
                Absolute = 0x8000,     // MouseEventF_Absolute - Specifies that the dx and dy members contain
                                       // normalized absolute coordinates. If the flag is not set, dx and dy contain
                                       // relative data ( the change position since the last reported position. ) This
                                       // flag can be set or nor set, regardless of what kind of mouse or other pointing
                                       // device, if any, is conected to the system.
                Wheel = 0x0080,     // MouseEventF_Wheel - Windows NT/2000/XP - Specifies that the wheel was moved, if
                                    // the mouse has a wheel. The amount of movement is spacified in mouseData.
                MiddleDow = 0x0020,     // MouseEventF_MiddleDow - Specifies that the middle button was pressed.
                MiddleUp = 0x0040,     // MouseEventF_MiddleUp - Specifies that the middle button was released;
                VirtualDesk = 0x4000,     // MouseEventF_VirtualDesk - Windows 2000/XP - Maps coordinates to the entire
                                          // desktop. Must be used with MouseEventF_Absolute.
                XDows = 0x0080,     // MouseEventF_XDown - Specifies that an X button was pressed.
                XUp = 0x0100,     // MouseEventF_XDown - Specifies that an X button was released.
                HWheel = 0x1000,     // MouseEventF_HWheel - Windows Vista - Specifies that the wheel was moved
                                     // horizontally, if the mouse has a wheel. The amount movement is specified in mouseData.
            };

            public enum VirtualKeyBoard : ushort
            {
                Shift = 0x10,
                Control = 0x11,
                Menu = 0x12,
                Escape = 0x1B,
            }

            [DllImport("user32.dll", SetLastError = true)]
            public static extern uint SendInput(uint cInputs, INPUT[] input, int size);

            [StructLayout(LayoutKind.Sequential)]
            public struct MouseInput
            {
                int dx;                     // 0 - 65535
                int dy;                     // 0 - 65535
                int mouseData;              // if dwFlags = MouseEventF_Wheel or MouseEventf_HWheel, then mouseData specifies the amount of wheel movement.
                                            // +/- multiples of Wheel_Delta which is 20.
                public MouseFlags dwFlags;  // Specifies MouseEventF.
                uint time;                  // Time stamp for the event, in milliseconds. If this parameter is 0, the system will provide its own time stamp.
                IntPtr dwExtraInfo;         // specifies an additional value with the mouse event.An application calls
                                            // GetMessageExtraInfo to obtain this extra informatio.

                public MouseInput(MouseFlags flags)
                {
                    dx = 0;
                    dy = 0;
                    mouseData = 0;
                    time = 0;
                    dwExtraInfo = GetMessageExtraInfo();
                    dwFlags = flags;
                }

                public MouseInput(int dx, int dy, MouseFlags flags)
                {
                    dx = dx;
                    dy = dy;
                    mouseData = 0;
                    time = 0;
                    dwExtraInfo = GetMessageExtraInfo();
                    dwFlags = flags;
                }

                public MouseInput(int mouseScroll)
                {
                    dx = 0;
                    dy = 0;
                    mouseData = 120 * mouseScroll;  // Mouse_Delta = 120
                    time = 0;
                    dwExtraInfo = GetMessageExtraInfo();
                    dwFlags = MouseFlags.Wheel;
                }
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct KeyboardInput
            {
                public VirtualKeyBoard wVK;
                public ushort wScan;
                public uint dwFlags;
                public uint time;
                public IntPtr dwExtraInfo;
            }

            [StructLayout(LayoutKind.Sequential)]
            public struct HardwareInput
            {
                public uint uMsg;
                public ushort wParamL;
                public ushort wParamH;
            }

            [StructLayout(LayoutKind.Explicit)]
            public struct INPUT
            {
                [FieldOffset(0)]
                public InputType InputDevice;

                [FieldOffset(4)]
                public MouseInput InputMouse;

                [FieldOffset(4)]
                public KeyboardInput InputKeyBoard;

                [FieldOffset(4)]
                public HardwareInput InputHardware;

                public INPUT(MouseInput inputmouse)
                {
                    InputDevice = InputType.Mouse;
                    InputKeyBoard = new KeyboardInput();
                    InputHardware = new HardwareInput();
                    InputMouse = inputmouse;
                }
            }

            public static void DoMouseClick(MouseButtons my_mouseButton)
            {
                /*

                INPUT[] i = new INPUT[3];
                i[0] = new INPUT(new MouseInput(0, 0, MouseFlags.Move | MouseFlags.Absolute));
                i[1] = new INPUT(new MouseInput(MouseFlags.LeftDown));
                i[2] = new INPUT(new MouseInput(MouseFlags.LeftUp));

                if (SendInput(3, i, Marshal.SizeOf(i[0])) == 0)
                    throw new Exception();
                 */

                INPUT[] i = new INPUT[2];
                i[0] = new INPUT(new MouseInput(MouseFlags.LeftDown));
                i[1] = new INPUT(new MouseInput(MouseFlags.LeftUp));

                if (SendInput(2, i, Marshal.SizeOf(i[0])) == 0)
                    throw new Exception();
            }

            public static void DoMouseClick(int x, int y, MouseButtons my_mouseButton)
            {
                //  INPUT[] i = new INPUT[3];
                //  i[0] = new INPUT(new MouseInput(x, y, MouseFlags.Move));
                //  i[1] = new INPUT(new MouseInput(MouseFlags.LeftDown));
                //  i[2] = new INPUT(new MouseInput(MouseFlags.LeftUp));

                INPUT[] i = new INPUT[2];
                i[0] = new INPUT(new MouseInput(MouseFlags.LeftDown));
                i[1] = new INPUT(new MouseInput(MouseFlags.LeftUp));

                if (SendInput(2, i, Marshal.SizeOf(i[0])) == 0)
                    throw new Exception();
            }

            public static void DoMouseDoubleClick(MouseButtons my_mouseButton)
            {
                DoMouseClick(my_mouseButton);
                DoMouseClick(my_mouseButton);
            }

            #endregion"Luke Quinane answer modif."

            private static int MouseButtonDow(MouseButtons my_mouseButton)
            {
                switch (my_mouseButton)
                {
                    case System.Windows.Forms.MouseButtons.Left:
                        {
                            return 0x02;
                        }
                    case System.Windows.Forms.MouseButtons.Right:
                        {
                            return 0x08;
                        }
                    case System.Windows.Forms.MouseButtons.Middle:
                        {
                            return 0x20;
                        }
                    case System.Windows.Forms.MouseButtons.None:    // Absolute
                        {
                            return 0x8000;
                        }
                    case System.Windows.Forms.MouseButtons.XButton1:
                        {
                            return 0x021;
                        }
                    case System.Windows.Forms.MouseButtons.XButton2:
                        {
                            return 0x024;
                        }
                    //  case System.Windows.Forms.MouseButtons.Move:
                    //      {
                    //          return 0x1;
                    //      }
                    default:
                        return 0;
                }
                ;

            }

            private static int MouseButtonUp(MouseButtons my_mouseButton)
            {
                switch (my_mouseButton)
                {
                    case System.Windows.Forms.MouseButtons.Left:
                        {
                            return 0x04;
                        }
                    case System.Windows.Forms.MouseButtons.Right:
                        {
                            return 0x10;
                        }
                    case System.Windows.Forms.MouseButtons.Middle:
                        {
                            return 0x40;
                        }
                    case System.Windows.Forms.MouseButtons.None: // Absolute
                        {
                            return 0x8000;
                        }
                    case System.Windows.Forms.MouseButtons.XButton1:
                        {
                            return 0x023;
                        }
                    case System.Windows.Forms.MouseButtons.XButton2:
                        {
                            return 0x026;
                        }
                    default:
                        return 0;
                }
                ;

            }

            public static void DoMouseDow(MouseButtons my_mouseButton)
            {
               // mouse_event(MouseButtonDow(my_mouseButton), 0, 0, 0, 0);
            }

            public static void DoMouseUp(MouseButtons my_mouseButton)
            {
               // mouse_event(MouseButtonUp(my_mouseButton), 0, 0, 0, 0);
            }
        }

        #endregion"Getting and Setting the Mouse Position and Clicking the Mouse."


        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;
        public static bool IsFileLocked(Exception exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }
    
    }
}
