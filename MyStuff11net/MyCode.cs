using CodeVendor.Controls;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;
using static MyStuff11net.Custom_Events_Args;

namespace MyStuff11net
{
    public class MyCode
    {
        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public static event StatusBarMessage_EventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessage_EventHandler(object sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public static void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            // Notify Subscribers
            StatusBarMessage?.Invoke(new object(), e);
        }

        #endregion"StatusBarMessage"

        #region"LogFile information"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("LogFile information are append.")]
        public static event Custom_Events_Args.LogFileMessageEventHandler LogFileMessage;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        public virtual void On_LogFileMessage(Custom_Events_Args.LogFileMessageEventArgs e)
        {
            // If an event has no subscriber registered, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            // Notify Subscribers
            LogFileMessage?.Invoke(this, e);
        }

        #endregion"LogFile information"

        #region"Dictionary Dynamic Initialization"

        //public Dictionary<string,Icon>

        #endregion"Dictionary Dynamic Initialization"

        //You could use the Where extension method to filter the array:
        //byte[] newArray = oldArray.Where(b => b != 0xff).ToArray();

        //or if you want to remove multiple elements you could use the Except extension method:
        //byte[] newArray = oldArray.Except(new byte[] { 0xff, 0xaa }).ToArray();

        public string SpecialCaracter = "" + '\u03A9';

        /*The advantage of verbatim strings is that escape sequences are not processed,
        which makes it easy to write, for example, a fully qualified file name:*/

        //string _test = @"c:\Docs\Source\a.txt";  // rather than "c:\\Docs\\Source\\a.txt"

        //To include a double quotation mark in an @-quoted string, double it:

        //string _test1 = @"""Ahoy!"" cried the captain."; // "Ahoy!" cried the captain.

        DataTable tableToFTV = new DataTable("tableToFTV");
        private void ToSave()
        {
            Dictionary<int, bool> toDelete = new Dictionary<int, bool>();

        }


        #region"Access -> Sql-Server -> c# equivalent."

        private void Access_SqlServer_Cshart_equivalent()
        {
            /*
            Jet Engine (Access) | Sql-Server                          | c#
            ------------------------------------------------------------------
            Text                | char, nchar, varchar, nvarchar      | string
            Memo                | text, ntext, the above with len>255 | string
            Byte                | tinyint                             | byte
            Integer             | smallint                            | short
            Long Integer        | integer (int)                       | int
            Single              | real                                | float
            Double              | float                               | double
            Replication ID      | uniqueidentifier                    | Guid
            Decimal             | decimal                             | decimal
            Date/Time           | smalldatetime, datetime, timestamp  | DateTime
            Currency            | smallmoney, money                   | decimal
            AutoNumber          | int + identity property             | int
            Yes/No              | bit                                 | bool
            OLE Object          | image                               | byte[]
            Hyperlink           | <no equivalent>                     | string
            <no equivalent>     | binary, varbinary                   | byte[]
            */
        }

        #endregion"Access -> Sql-Server -> c# equivalent."

        #region"The most common of the operators are:"
        /*
        **************Arithmetic
          Operator 		Action 		    Example 			Result
              +   		Addition 	    z = 1 + 2 	    	z = 3
              - 		    Subtraction     z = 1 – 2 	    	z = -1
              *   		Multiplication 	z = 2 * 2 			z = 4
              / 		    Division 		z = 22 / 7 	    	z = 3.142857
              %     		Modulus 		z = 22 % 7  		z = 1
                          The modulus operator (%) computes the remainder after
                          dividing its first operand by its second.

        **************Logic
          Operator 		Action 		    Example 			Result
                                        true && false		false
              && 	    Logical AND 	true && true		true
                                        false && false 		false

                                        true || false		true
              ||        Logical OR 	    true || true		true
                                        false || false		false

              || only checks the right-side condition if the left side evaluates to false.

              ! 		Logical NOT 	true && !false 		true

        **************Increment and Decrement
          Operator 		Action 		    Example 			Result
            ++ 		    Increment 	    a=1;
                                        a++; 		    	a = 2

            –– 		    Decrement 	    a=1;
                                        a––; 		    	a = 0;

        **************Relational
          Operator 		Action 		    Example 			Result
            == 		    Equals 		    x = 1;
                                        x == 1 		    	true

            != 		    NOT Equals 	    x = 1;
                                        x != 1 		    	false
            < 		    Less than 	    x = 1;
                                        x < 2; 	    		true
            > 		    Greater than 	x = 1;
                                        x > 0; 		    	true
            <= 		    Less than or
                        equal to 		x = 1;
                                        x <= 0 	    		false
            >= 		    Greater than or
                        equal to 		x = 1;
                                        x >= 5  			false

        **************Assignment
          Operator 		Action 		    Example 			Result
            = 		    Assignment 	    x = 1

            += 		    Incremental
                        Addition 		a=1;
                                        a += 3; 			a = 4;
            -= 		    Incremental
                        Decrement 	    a=1;
                                        a -= 3; 			a = -2;

            *= 		    Multiply by 	a=2;
                                        a *= 4; 			a = 8;
            /= 		    Divide by 	    a=8;
                                        a /= 2; 			a = 4;
            %= 		    Modulus or
                        Remainder 	    a=8;
                                        a %= 3; 			a = 2;

            &= 		    Logical AND     "x &= y" is equivalent to "x = x & y"

            |=		    Logical OR 	    "x |= y" is equivalent to "x = x | y"

            <<= 		Left Shift 		"x <<= y" is equivalent to "x = x << y"

            >>= 		Right Shift 	"x >>= y" is equivalent to "x = x >> y"

        **************************others
          Operator 	    Action 		        Example 			    Result
            & 		    Logical AND 	    if (false & ++i == 1) 	false

            | 		    Logical OR 	         true | false	    	true
                                            false | false 	    	false

            | always checks both the left and right conditions, if the operands are Boolean,
              the | operator is a logical operator. It's only treated as binary if operands are integral.

            ^ 		    Logical Exclusive	false ^ false	    	false
                        XOR 		        false ^ true		    true
                                             true ^ true 	    	false

            ~ 		    Bitwise
                        Complement 	        x = ~0×00000000 	    x = 0xffffffff

            << 		    Left Shift 		    1 << 1 			        2
            >> 		    Right Shift 	    -1000 >> 3 		        -125
            ?? 		    Default Value 	    int y = x ?? -1; 	    if x = null y = -1 else y = x

            :? 		    Conditional 	    condition ? expression if true:expression if false
                        Operator
         _____________________________________________________________________
          Precedence 	Operators 	            Cardinality 	Associativity
         _____________________________________________________________________
            High 		() [] . new typeof 	    Unary 		    Left to right
                        ! ~ + - ++ -- (cast)    Unary 		    Left to right
                        * / % 		            Binary 		    Left to right
                        + - 		            Binary 		    Left to right
                        < <= > >= is as 	    Binary 		    Left to right
                        == != 		            Binary 		    Left to right
                        & 		                Binary 		    Left to right
                        ^ 		                Binary 		    Left to right
                        | 		                Binary 		    Left to right
                        && 		                Binary 		    Left to right
                        || 		                Binary 		    Left to right
                        ?: 		                Ternary 		Right to left

            Low 		= *= /= %= +=
                        -= &= ^= |= 	        Binary 		    Right to left
                        <<= >>=
         _____________________________________________________________________
        */

        #endregion"The most common of the operators are:"

        private void Split_String()
        {
            string _selectRow = "This is a sample/list about split char";

            string[] ColumnData = _selectRow.Split(new char[] { '\u0061' });

            string[] ColumnData1 = _selectRow.Split(new char[] { '/' });

            // Single quote se represent
            char[] c = new char[] { (char)39 };
        }

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
        /// User : Only can view basis information.
        /// Editor : Allowed to edit, add, delete the basis information.
        /// Administrator : Allowed access to all information.
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



        void DateTimeToString()
        {
            DateTime dt = DateTime.Now;
            string strDate = "";
            strDate = dt.ToString("MM/dd/yyyy");   // 07/21/2007 
            strDate = dt.ToString("dddd, dd MMMM yyyy");   //Saturday, 21 July 2007
            strDate = dt.ToString("dddd, dd MMMM yyyy HH:mm"); // Saturday, 21 July 2007 14:58
            strDate = dt.ToString("dddd, dd MMMM yyyy hh:mm tt"); // Saturday, 21 July 2007 03:00 PM
            strDate = dt.ToString("dddd, dd MMMM yyyy H:mm"); // Saturday, 21 July 2007 5:01 
            strDate = dt.ToString("dddd, dd MMMM yyyy h:mm tt"); // Saturday, 21 July 2007 3:03 PM
            strDate = dt.ToString("dddd, dd MMMM yyyy HH:mm:ss"); // Saturday, 21 July 2007 15:04:10
            strDate = dt.ToString("MM/dd/yyyy HH:mm"); // 07/21/2007 15:05
            strDate = dt.ToString("MM/dd/yyyy hh:mm tt"); // 07/21/2007 03:06 PM
            strDate = dt.ToString("MM/dd/yyyy H:mm"); // 07/21/2007 15:07
            strDate = dt.ToString("MM/dd/yyyy h:mm tt"); // 07/21/2007 3:07 PM
            strDate = dt.ToString("MM/dd/yyyy HH:mm:ss"); // 07/21/2007 15:09:29
            strDate = dt.ToString("MMMM dd"); // July 21
            strDate = dt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffK"); // 2007-07-21T15:11:19.1250000+05:30    
            strDate = dt.ToString("ddd, dd MMM yyyy HH':'mm':'ss 'GMT'"); // Sat, 21 Jul 2007 15:12:16 GMT
            strDate = dt.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss"); // 2007-07-21T15:12:57
            strDate = dt.ToString("HH:mm"); // 15:14
            strDate = dt.ToString("hh:mm tt"); // 03:14 PM
            strDate = dt.ToString("H:mm"); // 5:15
            strDate = dt.ToString("h:mm tt"); // 3:16 PM
            strDate = dt.ToString("HH:mm:ss"); // 15:16:29
            strDate = dt.ToString("yyyy'-'MM'-'dd HH':'mm':'ss'Z'"); // 2007-07-21 15:17:20Z
            strDate = dt.ToString("dddd, dd MMMM yyyy HH:mm:ss"); // Saturday, 21 July 2007 15:17:58
            strDate = dt.ToString("yyyy MMMM"); // 2007 July
        }

        #region"Initialize ToolTip"

        private readonly ToolTip _toolTip = new ToolTip();
        private void InitializeToolTip()
        {
            _toolTip.IsBalloon = true;
            _toolTip.AutomaticDelay = 0;
            _toolTip.OwnerDraw = true;
            _toolTip.ShowAlways = true;
            _toolTip.UseAnimation = false;
            _toolTip.UseFading = false;
            _toolTip.Draw += ToolTipDraw;
        }

        // if toolTip.IsBalloon = true, toolTip_Draw never is called.
        private void ToolTipDraw(object sender, System.Windows.Forms.DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Chocolate, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
            e.Graphics.DrawString(_toolTip.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Red, e.Bounds);
        }

        /// <summary>
        /// Call from the control handle mouseLeave to hide the tooltip. 
        /// </summary>
        private void ToolTip_MouseLeave(Control controlToHideToolTip)
        {
            _toolTip.Hide(controlToHideToolTip);
        }

        /// <summary>
        /// Call from the control handle mouseEnter to show the tooltip. 
        /// </summary>
        /// <param name="e"></param>
        private void ToolTip_CellMouseEnter(Control controlToShowToolTip, string toolTipTitle, string toolTipInfo)
        {
            try
            {
                // To show, workaround.
                _toolTip.SetToolTip(controlToShowToolTip, "");
                _toolTip.Hide(controlToShowToolTip);

                //        Point mousePos = controlToShowToolTip.PointToClient(MousePosition);

                _toolTip.ToolTipTitle = toolTipTitle;
                _toolTip.ToolTipIcon = ToolTipIcon.Info;

                _toolTip.SetToolTip(controlToShowToolTip, toolTipInfo);
                //       _toolTip.Show(toolTipInfo, controlToShowToolTip, mousePos);
            }
            catch (Exception error)
            {
                MessageBox.Show("ToolTip_CellMouseEnter " + error.Message, "ToolTip_CellMouseEnter", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion"Initialize ToolTip"

        #region"if else them"

        private void IF_else_Them()
        {
            int a = 1;
            int b = 2;
            int c = 0;

            if (a > b)
                c = 30000;
            else
                c = 10000;

            //   if     true  : false
            c = a > b ? 30000 : 10000;

            // if is null
            string name;
            string code = null;

            name = code ?? "No name";
        }

        #endregion"if else them"



        #region"Reading large files"

        #region"This claims to read 180mb in 1.4 seconds "

        private int _bufferSize = 16384;
        private void ReadFile(string filename)
        {
            StringBuilder stringBuilder = new StringBuilder();
            FileStream fileStream = new FileStream(filename, FileMode.Open, FileAccess.Read);
            using (StreamReader streamReader = new StreamReader(fileStream))
            {
                char[] fileContents = new char[_bufferSize];
                int charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                // Can't do much with 0 bytes
                if (charsRead == 0)
                    throw new Exception("File is 0 bytes");

                while (charsRead > 0)
                {
                    stringBuilder.Append(fileContents);
                    charsRead = streamReader.Read(fileContents, 0, _bufferSize);
                }
            }
        }

        #endregion"This claims to read 180mb in 1.4 seconds "

        #region"Iterator, Load a File With Progress"

        public static IEnumerable<int> LoadFileWithProgress(string filename, StringBuilder stringData)
        {
            const int charBufferSize = 4096;
            using (FileStream fs = File.OpenRead(filename))
            {
                using (BinaryReader br = new BinaryReader(fs))
                {
                    long length = fs.Length;
                    int numberOfChunks = Convert.ToInt32((length / charBufferSize)) + 1;
                    double iter = 100 / Convert.ToDouble(numberOfChunks);
                    double currentIter = 0;
                    yield return Convert.ToInt32(currentIter);
                    while (true)
                    {
                        char[] buffer = br.ReadChars(charBufferSize);
                        if (buffer.Length == 0)
                            break;
                        stringData.Append(buffer);
                        currentIter += iter;
                        yield return Convert.ToInt32(currentIter);
                    }
                }
            }
        }

        private void HowUseThis()
        {
            string filename = "C:\\myfile.txt";
            StringBuilder sb = new StringBuilder();
            foreach (int progress in LoadFileWithProgress(filename, sb))
            {
                // Update your progress counter here!
            }
            string fileData = sb.ToString();
        }

        #endregion"Iterator, Load a File With Progress"

        #region"Using a BufferedStream"

        /// <summary>
        /// Trabajo bien, leyo todas las lineas del file into List<string>;
        /// </summary>
        private void LoadFileWithBufferedStream()
        {
            List<string> lines = new List<string>();

            using (FileStream fs = File.Open("path", FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (BufferedStream bs = new BufferedStream(fs))
            using (StreamReader sr = new StreamReader(bs))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }


        }

        #endregion"Using a BufferedStream"

        #endregion"Reading large files"

        #region"Read fron DBF file, use ExecuteReader"

        /*
        public IEnumerable<Player> GetPlayers()
        {
            string connectionString = ConfigurationManager.AppSettings["AllRttpDBConnectionString"];
            using (var conn = new MySqlConnection(connectionString))
            using (var cmd = conn.CreateCommand())
            {
                conn.Open();
                cmd.CommandText = "SELECT Name, Number FROM test WHERE ServiceName LIKE 'T%';";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return new Player
                        {
                            Name = reader.GetString(0),
                            Number = reader.GetInt32(1)
                        };
                    }
                }
            }
        }

        And when you need to create a list:

        List<Player> playersList = GetPlayers().ToList();
        */

        /*
                _orderNumber = textBox_Sales_Order.Text;


                OdbcConnection oConn = new OdbcConnection("Driver={Microsoft Visual FoxPro Driver};SourceType=DBF;Exclusive=No;Collate=Machine;"
                                                      + "NULL=NO;DELETED=YES;BACKGROUNDFETCH=NO;SourceDB=" + Settings.Default["DataBaseAddress"]);

                oConn.Open();

                OdbcCommand oCmd = oConn.CreateCommand();
                oCmd.CommandText = @"SELECT * FROM " + Settings.Default["DataBaseName"] + " WHERE sono LIKE '" + _orderNumber + "'";


                // If there isn't even a file, just return an empty DataTable
                if (!(File.Exists(Settings.Default["SMT_InventoryConnectionString"].ToString())))
                {
                    MessageBox.Show(@"Cannot find this file. Make sure it exists and that its name is spelled correctly.", @"File not found");
                    return;
                }

                _datatable_itemsbyOrder.Load(oCmd.ExecuteReader());

                oConn.Close();

                dataRepeater1.DataSource = _datatable_itemsbyOrder;

                timing_Control.Start = false;
             * 
            */
        #endregion

        #region"Read an entire standard DBF file into a DataTable, need diret access a file."

        // Read an entire standard DBF file into a DataTable
        public void ReadDbf()
        {
            BackgroundWorker_ReadDbf();
        }

        /// <summary>
        /// Convert a Julian Date to a .NET DateTime structure
        /// Implemented from pseudo code at http://en.wikipedia.org/wiki/Julian_day
        /// </summary>
        /// <param name="lJdn">Julian Date to convert (days since 01/01/4713 BC)</param>
        /// <returns>DateTime</returns>
        private static DateTime JulianToDateTime(long lJdn)
        {
            double p = Convert.ToDouble(lJdn);
            double s1 = p + 68569;
            double n = Math.Floor(4 * s1 / 146097);
            double s2 = s1 - Math.Floor((146097 * n + 3) / 4);
            double i = Math.Floor(4000 * (s2 + 1) / 1461001);
            double s3 = s2 - Math.Floor(1461 * i / 4) + 31;
            double q = Math.Floor(80 * s3 / 2447);
            double d = s3 - Math.Floor(2447 * q / 80);
            double s4 = Math.Floor(q / 11);
            double m = q + 2 - 12 * s4;
            double j = 100 * (n - 49) + i + s4;
            return new DateTime(Convert.ToInt32(j), Convert.ToInt32(m), Convert.ToInt32(d));
        }


        #region "BackgroundWorker_ReadDbf"

        private BackgroundWorker _backgroundWorkerReadDbf;

        private BinaryReader _binaryreader;
        private byte[] _buffer;
        private GCHandle _handle;
        private DbfHeader _header;
        private ProgressChangedEventArgs _progressBackground;
        private string _myFileDbf = "";

        private void BackgroundWorker_ReadDbf()
        {
            // If there isn't even a file, just return an empty DataTable
            if (!(File.Exists(_myFileDbf))) return;

            _binaryreader = new BinaryReader(File.OpenRead(_myFileDbf));

            // Read the header into a buffer
            _buffer = _binaryreader.ReadBytes(Marshal.SizeOf(typeof(DbfHeader)));

            // Marshall the header into a DBFHeader structure
            _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
            _header = (DbfHeader)Marshal.PtrToStructure(_handle.AddrOfPinnedObject(), typeof(DbfHeader));
            _handle.Free();

            _backgroundWorkerReadDbf = new BackgroundWorker
            {
                WorkerReportsProgress = true
            };

            _backgroundWorkerReadDbf.DoWork += BackgroundWorker_ReadDbf_DoWork;
            _backgroundWorkerReadDbf.ProgressChanged += BackgroundWorker_ReadDbf_ReportProgress;
            _backgroundWorkerReadDbf.RunWorkerCompleted += BackgroundWorker_ReadDbf_RunWorkerCompleted;

            _backgroundWorkerReadDbf.RunWorkerAsync();
        }

        private void BackgroundWorker_ReadDbf_DoWork(Object sender, DoWorkEventArgs e)
        {
            var myDataTable = new DataTable { TableName = "datatable_DBF" };

            string number;

            // Read in all the Column descriptors. Per the spec, 13 (0D) marks the end of the column descriptors

            var columns = new ArrayList();
            while ((13 != _binaryreader.PeekChar()))
            {
                _buffer = _binaryreader.ReadBytes(Marshal.SizeOf(typeof(ColumnDescriptor)));
                _handle = GCHandle.Alloc(_buffer, GCHandleType.Pinned);
                columns.Add(
                    (ColumnDescriptor)Marshal.PtrToStructure(_handle.AddrOfPinnedObject(), typeof(ColumnDescriptor)));
                _handle.Free();
            }

            // Read in the first row of records, we need this to help determine column types below
            _binaryreader.BaseStream.Seek(_header.headerLen + 1, SeekOrigin.Begin);
            _buffer = _binaryreader.ReadBytes(_header.recordLen);

            #region"Create the columns in our new DataTable"

            foreach (ColumnDescriptor column in columns)
            {
                DataColumn newColumn;
                switch (column.ColumnType)
                {
                    case 'M':
                        newColumn = new DataColumn(column.ColumnName, typeof(Int32));
                        break;
                    case 'N':
                        newColumn = new DataColumn(column.ColumnName, typeof(int));
                        break;
                    case 'C':
                        newColumn = new DataColumn(column.ColumnName, typeof(string));
                        break;
                    case 'T':
                        newColumn = new DataColumn(column.ColumnName, typeof(DateTime));
                        break;
                    case 'D':
                        newColumn = new DataColumn(column.ColumnName, typeof(DateTime));
                        break;
                    case 'L':
                        newColumn = new DataColumn(column.ColumnName, typeof(bool));
                        break;
                    case 'F':
                        newColumn = new DataColumn(column.ColumnName, typeof(Double));
                        break;
                    case 'I':
                        newColumn = new DataColumn(column.ColumnName, typeof(int));
                        break;
                    default:
                        newColumn = null;
                        break;
                }
                if (newColumn != null)
                    myDataTable.Columns.Add(newColumn);
            }

            #endregion

            // Skip past the end of the header. 
            _binaryreader.BaseStream.Seek(_header.headerLen, SeekOrigin.Begin);

            #region"Read in all the records"

            for (int counter = 0; counter <= _header.numRecords - 1; counter++)
            {
                // First we'll read the entire record into a buffer (memory) and then read each field from the buffer
                // This helps account for any extra space at the end of each record and probably performs better
                _buffer = _binaryreader.ReadBytes(_header.recordLen);
                BinaryReader recReader = new BinaryReader(new MemoryStream(_buffer));

                // All dbf field records begin with a deleted flag field. Deleted - 0x2A (asterisk) else 0x20 (space)
                if (recReader.ReadChar() == '*')
                    continue;

                // Loop through each column in a record
                int fieldIndex = 0;
                DataRow row = myDataTable.NewRow();
                decimal mynumber;
                foreach (ColumnDescriptor column in columns)
                {
                    switch (column.ColumnType)
                    {
                        case 'M': // 
                            row[fieldIndex] = recReader.ReadInt32();
                            break;

                        case 'N': // Number
                            number = Encoding.ASCII.GetString(recReader.ReadBytes(column.ColumnLen));
                            decimal.TryParse(number, out mynumber);
                            row[fieldIndex] = mynumber;
                            break;

                        case 'C': // String
                            row[fieldIndex] = Encoding.ASCII.GetString(recReader.ReadBytes(column.ColumnLen));
                            break;

                        case 'D': // Date (YYYYMMDD)
                            Int32 yearout;
                            Int32 monthout;
                            Int32 dayout;

                            string year = Encoding.ASCII.GetString(recReader.ReadBytes(4));
                            string month = Encoding.ASCII.GetString(recReader.ReadBytes(2));
                            string day = Encoding.ASCII.GetString(recReader.ReadBytes(2));
                            row[fieldIndex] = DBNull.Value;

                            Int32.TryParse(year, out yearout);
                            Int32.TryParse(month, out monthout);
                            Int32.TryParse(day, out dayout);


                            if (yearout > 1900)
                            {
                                row[fieldIndex] = new DateTime(yearout, monthout, dayout);
                            }

                            break;

                        case 'T': // Timestamp, 8 bytes - two integers, first for date, second for time
                                  // Date is the number of days since 01/01/4713 BC (Julian Days)
                                  // Time is hours * 3600000L + minutes * 60000L + Seconds * 1000L (Milliseconds since midnight)
                            long lDate = recReader.ReadInt32();
                            long lTime = recReader.ReadInt32() * 10000L;
                            row[fieldIndex] = JulianToDateTime(lDate).AddTicks(lTime);
                            break;

                        case 'L': // Boolean (Y/N)
                            if ('Y' == recReader.ReadByte())
                                row[fieldIndex] = true;
                            else
                                row[fieldIndex] = false;
                            break;

                        case 'F':
                            number = Encoding.ASCII.GetString(recReader.ReadBytes(column.ColumnLen));
                            row[fieldIndex] = double.Parse(number);
                            break;
                    }
                    fieldIndex++;
                }

                myDataTable.Rows.Add(row);
                recReader.Close();
                if ((counter % 100) == 0)
                    _backgroundWorkerReadDbf.ReportProgress(counter);
            }

            #endregion

            _binaryreader.Close();
        }

        private void BackgroundWorker_ReadDbf_ReportProgress(object sender,
                                                             ProgressChangedEventArgs progressChangedEventArgs)
        {
            ReportProgress(progressChangedEventArgs);
        }

        private void BackgroundWorker_ReadDbf_RunWorkerCompleted(Object sender, RunWorkerCompletedEventArgs e)
        {
            RunWorkerCompleted();
        }

        // Es llamado front BackgroundWorker_ReadDbf_ReportProgress.
        public void ReportProgress(ProgressChangedEventArgs progressChange)
        {
            _progressBackground = progressChange;
            //  Invoke(new EventHandler(Report_progress_call));
        }

        private void Report_progress_call(Object sender, EventArgs e)
        {
            //  toolStripLabel_Loading_Record.Text = "Loading Record " + _progressBackground.ProgressPercentage;
            //  toolStripProgressBar_Loading_Record.Value = _progressBackground.ProgressPercentage;
        }

        // Es llamado front BackgroundWorker_ReadDbf_RunWorkerCompleted.
        public void RunWorkerCompleted()
        {
            //   Invoke(new EventHandler(RunWorkerCompletedCall));
        }

        private void RunWorkerCompletedCall(Object sender, EventArgs e)
        {/*
            toolStripLabel_Loading_Record.Visible = false;
            toolStripLabel_of_max.Visible = false;
            toolStripProgressBar_Loading_Record.Value = 0;
            toolStripProgressBar_Loading_Record.Visible = false;

            //       dataSet_ExplorerDataBase.    Merge(myDataTable);
            //       dataSet_ExplorerDataBase.Tables.Clear();
            //        dataSet_ExplorerDataBase.Tables.Add(_myDataTable);
            //        dataView1.Table = dataSet_ExplorerDataBase.Tables[_myDataTable.TableName];

            dataView1.BeginInit();

            dataView1.Table = _myDataTable;
            BindingSource_dataSet.DataSource = dataView1;
            BindingSource_dataSet.ResumeBinding();
            //        dataGridView1.ResetBindings();

            dataView1.EndInit();
            //        dataGridView1.Refresh();
          */
        }

        #endregion



        // This is the file header for a DBF. We do this special layout with everything
        // packed so we can read straight from disk into the structure to populate it
        // the header are the 32 ferst bytes.

        #region Nested type: DBFHeader

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        private struct DbfHeader
        {
            public readonly byte version;
            public readonly byte updateYear;
            public readonly byte updateMonth;
            public readonly byte updateDay;
            public readonly Int32 numRecords;
            public readonly Int16 headerLen;
            public readonly Int16 recordLen;
            public readonly Int16 reserved1;
            public readonly byte incompleteTrans;
            public readonly byte encryptionFlag;
            public readonly Int32 reserved2;
            public readonly Int64 reserved3;
            public readonly byte MDX;
            public readonly byte language;
            public readonly Int16 reserved4;
        }

        #endregion

        #region Nested type: ColumnDescriptor

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
        private struct ColumnDescriptor
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 11)]
            public readonly string ColumnName;
            public readonly char ColumnType;
            public readonly Int32 address;
            public readonly byte ColumnLen;
            public readonly byte count;
            public readonly Int16 reserved1;
            public readonly byte workArea;
            public readonly Int16 reserved2;
            public readonly byte flag;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 7)]
            public readonly byte[] reserved3;
            public readonly byte indexFlag;
        }

        #endregion

        #endregion"Read an entire standard DBF file into a DataTable, need diret access a file."

        /*         if (_dataSetWholeDataBase != null)
                _itemsbyOrden = new DataView(_dataSetWholeDataBase.Tables[0], "sono LIKE '" + textBox_Sales_Order.Text + "'",
                                                                                                              "sono Desc", DataViewRowState.CurrentRows);
            else
                _itemsbyOrden.Table.Clear();

            dataRepeater1.DataSource = _itemsbyOrden;


         dv = New DataView(ds.Tables(0), "Product_Price > 100", "Product_Price Desc", DataViewRowState.CurrentRows)

                DataView_ItemsbyOrden = new DataView(dataSet1.Tables["sales"], "sono LIKE '" + textBox_Sales_Order.Text + "'",
                                             "sono Desc", DataViewRowState.CurrentRows);

        And the ConnectionString to use for loading the DBF file using ODBC in .Net is:
          @"Driver={Microsoft dBase Driver (*.dbf)};SourceType=DBF;SourceDB='"
            + folderName + "';Exclusive=No; Collate=Machine;NULL=NO;DELETED=NO;BACKGROUNDFETCH=NO;" 

        And here is a sample query on a date field: 
          SELECT * FROM " + fileName.dbf where dob > {D ‘2000-12-31’}

          if (DataView_ItemsbyOrden.Table != null)
            DataView_ItemsbyOrden.Table.Clear();

          if (textBox_Sales_Order.Text == "")
           {
                MessageBox.Show(@"Please type a correct Sales Order number", @"Wrong Sales Order number");
                return;
             }
        */

        #region "Using block and DialogResult, this will be dispose of automatically"        

        private void Using_dispose_block()
        {
            /*
            using (var newSaveDialog = new MessageBox())
            {
                // Verifico if the cancelo el event.
                // Si se cancelo el evento, return y salgo del lazo.
                if (newSaveDialog.Show() == DialogResult.Cancel)
                {
                    Text = @"Cancelling Item successful...";
                    return;
                }

                // "El event no sead cancelado, prosigo con el calculo.

                // Aun puedo acceder a las variables de newSave_Dialog.
                var data = newSaveDialog.Height;

                data += data;
            }
             */
        }

        private void opendialog()
        {
            using (var openfile = new OpenFileDialog
            {
                Title = @"Please found any DBF file",
                FileName = "",
                Filter = @"DBF File (*.dbf)|*.dbf",
                DefaultExt = "(*.dbf)|*.dbf"
            }
                  )
            {
                if (openfile.ShowDialog() == DialogResult.Cancel)
                    return;

                var fileName = Path.GetFileNameWithoutExtension(openfile.FileName);
                var fileExt = Path.GetExtension(openfile.FileName);
                var filePath = Path.GetDirectoryName(openfile.FileName);
            }
        }


        #endregion "Using block and DialogResult, this will be dispose of automatically"
                
        #region"Custom Controls Events with custom Args.*********************"

        #region"Axis X"
        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Line Event ***************")]
        public event AxisX_EventHandler AxisX_Changed;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void AxisX_EventHandler(object sender, AxisX_EventArgs e);

        // # 3 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class AxisX_EventArgs : EventArgs
        {
            // Constructor accepts two integer: the old value and the new value.
            public AxisX_EventArgs(int newvalue)
            {
                AxisX = newvalue;
            }

            public int AxisX { get; set; }
        }

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_AxisX_Change(AxisX_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (AxisX_Changed != null)
            {
                // Notify Subscribers
                AxisX_Changed(this, e);
            }
        }
                
        #endregion"Axis X"

        #region"Axis Y"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void AxisY_EventHandler(object sender, AxisY_EventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class AxisY_EventArgs : EventArgs
        {
            // Constructor accepts some value.
            public AxisY_EventArgs(int newvalue)
            {
                AxisY = newvalue;
            }

            public int AxisY { get; set; }
        }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Columns Events ***************")]
        public event AxisY_EventHandler AxisY_Changed;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_AxisY_Change(AxisY_EventArgs e)
        {
            // If an event has no subscriber registerd, it will
            // evaluate to Null. The test checks that the value
            // is not null, ensuring that there are subscribers
            // before calling the event itself.

            if (AxisY_Changed != null)
            {
                // Notify Subscribers
                AxisY_Changed(this, e);
            }
        }
        
        #endregion"Axis Y"

        #endregion "Custom Controls Events with custom Args.*********************"

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

        public static SortedDictionary<string, int> GetDict(string stringDict, SortedDictionary<string, int> dict)
        {
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
                if (dict.ContainsKey(projectNameValue[0]))
                {
                    dict[projectNameValue[0]] = value;
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

            var dict = MyCode.GetDict(Who_uses_this);

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

            var dict = MyCode.GetDict(Who_uses_this);

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

            string Active_Filter = MyCode.GetTextfrontFilter(BindingSourceFilter);

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


        #endregion"Convert string to Dictionary and dictionary to string, check is no null"

        #region"How Share Bound Data across forms using the BindingSource Component"

        class ShareBoundData
        {
            // static is only to evitar un error.
            private static BindingSource _originalbindingsource;

            public ShareBoundData()
            {
                _originalbindingsource = new BindingSource();

                // Handle the BindingComplete event to ensure the two forms
                // remain synchronized.
                _originalbindingsource.BindingComplete += bindingcompleted;
            }

            private void bindingcompleted(object? sender, BindingCompleteEventArgs e)
            {
                if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate && e.Exception == null)
                    e.Binding.BindingManagerBase.EndCurrentEdit();
            }

            // The shared BindingSource is passed to the constructor of the new form.

            class Newform : Form
            {
                private BindingSource newformDataSource;

                // The constructor takes a bindingSource object.
                public Newform(BindingSource datasource)
                {
                    newformDataSource = datasource;

                    // If you want synchronized the two forms lake intantanea.
                    TextBox textbox1 = new TextBox();

                    // Associate the property Text with a column from the datasource and set
                    // DataSourceUpdateMode to OnPropertyChanged, each time Text property change,
                    // the original BindingSource will generate the event.
                    textbox1.DataBindings.Add("Text", newformDataSource, "any column name", true,
                                               DataSourceUpdateMode.OnPropertyChanged);
                }
            }
        }
        #endregion"How Share Bound Data across forms using the BindingSource Component"

        #region"Remove row front bindingSource if it follow this condition."

        /// <summary>
        /// Remove row front bindingSource if it follow this condition.
        /// </summary>
        /// <param name="bindingsource"></param>
        /// <param name="filter"></param>
        public static void RemoveWhoFollow(BindingSource bindingsource, string filter)
        {
            DataTable table;

            Type typeDataSource = bindingsource.DataSource.GetType();

            if (typeDataSource.BaseType == typeof(DataSet))
                table = ((DataSet)bindingsource.DataSource).Tables[bindingsource.DataMember];
            else
                table = bindingsource.DataSource as DataTable;

            Dictionary<int, bool> toDelete = new Dictionary<int, bool>();

            using (var dv = new DataView(table, filter, "", DataViewRowState.CurrentRows))
            {
                // If Count == 0, no row mach.
                if (dv.Count != 0)
                {
                    foreach (DataRowView row in dv)
                    {
                        try
                        {
                            int index = int.Parse(row["Index"].ToString());
                            toDelete.Add(index, true);
                        }
                        catch (Exception error)
                        {
                            MessageBox.Show("A row with index null was found. " + error.Message, "Error in row information",
                                                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                foreach (KeyValuePair<int, bool> rowtodelete in toDelete)
                {
                    try
                    {
                        bindingsource.RemoveAt(bindingsource.Find("Index", rowtodelete.Key));
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Remove at " + rowtodelete.Key + " was not found. " + error.Message, "Error in bindingSource",
                                                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }

        #endregion"Remove row front bindingSource if follow it condition."

        #region"Table.Compute funtion"

        public void Table_Compute(string AggregateFunction_DataColumn, string Condition_Nothing_null)
        {
            // Presumes a DataTable named "Orders" that has a column named "Total."
            DataTable table = new DataTable("Orders");

            // Declare an object variable. 
            object sumObject;
            sumObject = table.Compute("Sum(Total)", "EmpID = 5");


            /* Available aggregate functions include those shown in the following table.

            Avg() The average of values in a column

            Count() The number of rows (values) in a column

            Max() The largest value in a column

            Min() The smallest value in a column

            StDev() The standard deviation of values in a column

            Sum() The sum of values in a column

            Var() The statistical variance of values in a column

             */




        }

        #endregion"Table.Compute funtion"

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
            public static extern void mouse_event(int dwFlags, int dx, int dy, int cButtons, int dwExtraInfo);

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
                mouse_event(MouseButtonDow(my_mouseButton), 0, 0, 0, 0);
            }

            public static void DoMouseUp(MouseButtons my_mouseButton)
            {
                mouse_event(MouseButtonUp(my_mouseButton), 0, 0, 0, 0);
            }
        }

        #endregion"Getting and Setting the Mouse Position and Clicking the Mouse."

        #region"Pausing Timer loop until something is not finished."

        public static System.Timers.Timer _timer;
        public static void InitializeTimer()
        {
            _timer = new System.Timers.Timer();
            _timer.AutoReset = false;
            _timer.Interval = 100;
            _timer.Elapsed += new System.Timers.ElapsedEventHandler(_timer_Elapsed);
            _timer.Enabled = true;
            Console.ReadKey();
        }

        static void _timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            //Do database refresh
            _timer.Enabled = true;
        }

        #endregion"Pausing Timer loop until something is not finished."

        #region"Pausing ThreadTimer loop until something is not finished."

        System.Threading.Timer _threadtimer;

        public void MyThreadingTest()
        {
            _threadtimer = new System.Threading.Timer(new TimerCallback(WorkMethod), null, 15000, 15000);
        }

        public void WorkMethod(object obj)
        {
            _threadtimer.Change(Timeout.Infinite, Timeout.Infinite); // suspend timer

            // do work

            _threadtimer.Change(15000, 15000); //resume
        }

        #endregion"Pausing ThreadTimer loop until something is not finished."

        #region"InitializeThreadTimer"

        System.Threading.Timer timer;
        private void InitializeThreadTimer()
        {
            //DoSomething = procedure to callback, null = object pass to, First interval = 0 ms, subsequent intervals = 1000 ms
            timer = new System.Threading.Timer(new TimerCallback(DoSomething), null, 0, 1000);
        }

        private void DoSomething(object obj)
        {
            //it executes every second
        }

        private void StartThreadTimer()
        {
            timer.Change(0, 1000); //enable First interval = 0 ms, subsequent intervals = 1000 ms
        }

        private void StopThreadTimer()
        {
            timer.Change(Timeout.Infinite, Timeout.Infinite); //disable
        }

        #endregion"InitializeThreadTimer"

        #region"If you really need your DoSomething() to be called every 10s"

        public void DoSomething()
        {
            DateTime start = DateTime.UtcNow;

            TimeSpan elapsed = (DateTime.UtcNow - start);
            int due_in = (int)(10000 - elapsed.TotalMilliseconds);
            if (due_in < 0)
                due_in = 0;
            timer.Change(due_in, Timeout.Infinite);
        }

        #endregion"If you really need your DoSomething() to be called every 10s"


        #region"Add Setting at runtime"

        private void AddSetting()
        {
            System.Configuration.SettingsProperty property = new System.Configuration.SettingsProperty("CustomSetting");
            property.DefaultValue = "Default";
            property.IsReadOnly = false;
            property.PropertyType = typeof(string);
            property.Attributes.Add(typeof(System.Configuration.UserScopedSettingAttribute), new System.Configuration.UserScopedSettingAttribute());
            Properties.Settings.Default.Properties.Add(property);

            //        property.Provider = Properties.Settings.Default.Providers["LocalFileSettingsProvider"];

            // Load settings now.

            Properties.Settings.Default.Reload();

            // Update the user interface.

            //   textBox1.Text = (string)Properties.Settings.Default["CustomSetting"];



        }

        #endregion"Add Setting at runtime"

        #region"Terminate all previous running process except current running process of an same application:"

        /// <summary>
        /// I am using the following code to solve this problem.
        /// </summary>
        private void OnlyOneProcess()
        {
            Process CurrentProcess = Process.GetCurrentProcess();

            foreach (Process p in System.Diagnostics.Process.GetProcesses())
            {
                if (p.Id != CurrentProcess.Id)
                {
                    if (p.ProcessName == "Alarm")
                    {
                        p.Kill();
                    }
                }
            }
        }

        /// <summary>
        /// Procedure to start a process from C#.
        /// </summary>
        private void StartAProcess()
        {
            //Please try this code:
            Process process = new Process();
            process.StartInfo.WorkingDirectory = @"E:\Source"; //sets the working directory in which the exe file resides.
            process.StartInfo.FileName = "msiexec.exe";

            process.StartInfo.Arguments = string.Format(@"/i E:\My Setup Files\Installer.msi"); //Pass the number of arguments.

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = false;
            process.Start();
            process.WaitForExit();
        }


        //As PhilDW noted in the comment above, the issue was one of needing to elevate privileges.
        //Even though I'm an administrator, using the /qn switch suppresses the confirmation dialog (as expected),
        //and the confirmation dialog is used as the administrative confirmation that it's OK to uninstall.
        //The solution was as follows:
        private void UNInstallAProcess(string productCode)
        {
            Process process = new Process();
            process.StartInfo.FileName = "msiexec.exe";
            process.StartInfo.Arguments = string.Format("/x {0} /qn /l*v uninstall.log", productCode);
            process.StartInfo.UseShellExecute = true;   // added to elevate privileges
            process.StartInfo.Verb = "runas";           // added to elevate privileges
            process.Start();
            process.WaitForExit();
        }

        #endregion"Terminate all previous running process except current running process of an same application:"

        #region"How set the rowIndex to a new row."

        // In the table set the column Index to type TEXT, this is the Key column.
        // In other one, set the column ID to type Long Integer. On this ID column we will ask about the last ID.

        int _lastID;
        /// <summary>
        /// Top value for ID fiel, option filter to select a group of row.
        /// table.Compute("MAX(ID)", "filter condition"), itself inc.
        /// </summary>
        private int LastID
        {
            get
            {
                ++_lastID;
                return _lastID;
            }
            set
            {
                _lastID = value;

            }
        }

        private void Get_NextID()
        {
            // This fiels are only for show.
            int LastID;
            DataTable table;
            string tableComponents = "";
            DataSet DataSetStockRoom = new DataSet();
            BindingSource _bindingSource = new BindingSource(DataSetStockRoom, tableComponents);

            // Created a reference to the table in the constructor or XXX_Load procedure.
            // If we are using a bindingsource, used 
            table = ((DataSet)_bindingSource.DataSource).Tables[_bindingSource.DataMember];

            // We ask per the lastID just before used.
            LastID = (int)table.Compute("MAX(ID)", "ID is Not null");

            // Creo new DataRowView front la tabla.
            var newRecord = (DataRowView)_bindingSource.AddNew();

            newRecord["Index"] = LastID;
            newRecord["ID"] = newRecord["Index"];


            // Save back it.
            newRecord.EndEdit();
            _bindingSource.EndEdit();
            // On_Save_Requested(new Save_Requested_EventArgs());
        }

        #endregion"How set the rowIndex to a new row."

        #region"Copy or duplicate a DataGridViewRow"

        public static DataGridViewRow Clone_Row(DataGridViewRow originalRow)
        {
            DataGridView dgv_copy = new DataGridView();

            if (dgv_copy.Columns.Count == 0)
            {
                foreach (DataGridViewColumn dgvc in originalRow.DataGridView.Columns)
                {
                    dgv_copy.Columns.Add(dgvc.Clone() as DataGridViewColumn);
                }
            }

            DataGridViewRow newRow = new DataGridViewRow();
            newRow = (DataGridViewRow)originalRow.Clone();

            int intColIndex = 0;
            foreach (DataGridViewCell cell in originalRow.Cells)
            {
                newRow.Cells[intColIndex].Value = cell.Value;
                intColIndex++;
            }

            dgv_copy.Rows.Add(newRow);

            return newRow;
        }

        #endregion"Copy or duplicate a DataGridViewRow"

        #region"CurrentUserBroadcast, Properties and fiels used in LogIn employees."

        // Properties and fiels used in LogIn employees.
        private string EmployeeName = "Not user login.";
        private string EmployeeLastName = "";
        private AccessLevel EmployeeAccessLevel = MyCode.AccessLevel.User;
        private EditMode EmployeeEditMode = MyCode.EditMode.View;
        private EnableSetting EmployeeEnableTreeViewsetting = MyCode.EnableSetting.False;

        private Employee _currentEmployeesLogIn;

        public void CurrentUserBroadcast_EventHandler(object sender, Employee e)
        {
            if (e == null)
                return;

            EmployeeName = e.Name;
            EmployeeLastName = e.LastName;
            EmployeeEditMode = e.EmployeeEditMode;
            EmployeeAccessLevel = e.EmployeeAccessLevel;
            EmployeeEnableTreeViewsetting = e.EmployeeEnableTreeViewSetting;

            _currentEmployeesLogIn = e;

            // dataGridViewExtended_Inventory.CurrentEmployeesLogIn = e;
        }

        #endregion"CurrentUserBroadcast, Properties and fiels used in LogIn employees."

        #region"Count number of occurrences of a character in a string"

        string testString = "key1=value1&key2=value2&key3=value3";

        private void NumberCharacterInString()
        {
            int count = testString.Split('&').Length - 1;
            //Or with LINQ:
            testString.Count(x => x == '&');

            count = testString.Where(x => x == '&').Count();
            //Or if you like, you can use the Count overload that take a predicate :
            count = testString.Count(x => x == '&');

            //The most straight forward, and most efficient, would be to simply loop 
            //through the characters in the string:
            count = 0;
            foreach (char c in testString)
            {
                if (c == '&')
                    count++;
            }

            //Then there is the old Replace trick, however that is better suited for languages where
            //looping is awkward (SQL) or slow (VBScript):
            count = testString.Length - testString.Replace("&", "").Length;

            //Here is the most inefficient way to get the count in all answers. But you'll get a
            //Dictionary that contains key-value pairs as a bonus.
            var keyValues = Regex.Matches(testString, @"([\w\d]+)=([\w\d]+)[&$]*")
                                 .Cast<Match>()
                                 .ToDictionary(m => m.Groups[1].Value, m => m.Groups[2].Value);

            count = keyValues.Count - 1;

        }

        #endregion"Count number of occurrences of a character in a string"

        #region"DrawingControl or SuspendLayout, removed flickering"

        //class DrawingControl
        //{
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public static void SuspendDrawing(Control parent)
        {
            if (parent == null)
                return;

            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(Control parent)
        {
            if (parent == null)
                return;

            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
        //}

        public static void SetDoubleBuffered(Panel panel)
        {
            typeof(Panel).InvokeMember("DoubleBuffered",
                                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                        null,
                                        panel,
                                        new object[] { true });
        }

        public static void SetDoubleBuffered(FlowLayoutPanel panel)
        {
            typeof(FlowLayoutPanel).InvokeMember("DoubleBuffered",
                                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                        null,
                                        panel,
                                        new object[] { true });
        }

        public static void SetDoubleBuffered(Grouper panel)
        {
            typeof(Grouper).InvokeMember("DoubleBuffered",
                                        BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                                        null,
                                        panel,
                                        new object[] { true });
        }

        #endregion"DrawingControl or SuspendLayout, removed flickering"

        #region"Row to string"

        private void RowtoString()
        {
            //Just for sample.
            DataRow row = tableToFTV.Rows[0];

            //Consider String.Join. The columns values in question must be extracted first, perhaps...

            var cols = row.ItemArray
                .Select(i => "" + i) // Not i.ToString() so when i is null -> ""
                .ToArray();          // For .NET35 and before, .NET4 Join takes IEnumerable

            var res = string.Join("|", cols);



            // LINQ adds some sugar:
            var stringArray = row.ItemArray.Cast<string>().ToArray();
        }



        #endregion"Row to string"

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

        #region"LinQ, utile uses"

        /// <summary>
        /// This LinQ expression select all controls filterConditon whit FilterControlIndex >= indexFilterControl;
        /// </summary>
        private static void DeletedControls(int indexFilterControl)
        {
            Panel panelFilterConditions = new Panel();

            List<FilterCondition> toDeleted = panelFilterConditions.Controls.OfType<FilterCondition>().Where
                                    (filterConditon => filterConditon.FilterControlIndex >= indexFilterControl).ToList();

            foreach (FilterCondition filterConditiontoDeletes in toDeleted)
            {
                panelFilterConditions.Controls.Remove(filterConditiontoDeletes);
            }
        }

        //Return the top 10 most frequently occurring words in a string.
        //In the most typical solution to this problem one would first split each word, hash the words to count
        //them efficiently and then determine the 10 most frequently occurring by sorting the key/value pairs. 

        public static List<string> CountWordsDictionaryNoLinq(string s1)
        {
            Dictionary<string, int> wordDictionary = StringToWordDictionary(s1);
            List<KeyValuePair<string, int>> kvpList = wordDictionary.ToList();
            kvpList.Sort(CompareKvpByCount);

            //  return ExtractTopTen(kvpList);

            return new List<string>(); //Solo para evitar el error.
        }

        private static Dictionary<string, int> StringToWordDictionary(string s1)
        {
            var words = s1.Split(' ');
            var wordDictionary = new Dictionary<string, int>();

            foreach (var s in words)
            {
                if (wordDictionary.ContainsKey(s))
                {
                    wordDictionary[s]++;
                }
                else
                {
                    wordDictionary.Add(s, 1);
                }
            }
            return wordDictionary;
        }

        private static int CompareKvpByCount(KeyValuePair<string, int> a, KeyValuePair<string, int> b)
        {
            if (a.Value == b.Value)
            {
                return 0;
            }
            else if (a.Value < b.Value)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        //A solution in LINQ, though a bit harder for the untrained eye to read, is quite a bit more succinct.

        public static List<string> CountWordsLinq(string s)
        {
            var words = s.Split(' ');
            var wordCounts = words.GroupBy(x => x).Select(x => new { Name = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count);
            var countedWords = wordCounts.Select(x => x.Name).Take(10).ToList();
            return countedWords;
        }

        //ToLookup is more efficient than GroupBy: http://stackoverflow.com/a/938104/489561

        public static List<string> CountWordsLinqLookup(string s)
        {
            var words = s.Split(' ');
            var wordCounts = words.ToLookup(x => x).Select(x => new { Name = x.Key, Count = x.Count() }).OrderByDescending(x => x.Count);
            var countedWords = wordCounts.Select(x => x.Name).Take(10).ToList();
            return countedWords;
        }

        #endregion"LinQ, utile uses"

        //Reading between the lines of your question, you seem to be using TextRenderer because you
        //don't have a Graphics instance outside the Paint event. If that's the case, you can create
        //one yourself to do the measuring:
        private void MesuringString()
        {
            //Solo 
            Label someControl = new Label();

            using (Graphics g = someControl.CreateGraphics())
            {
                SizeF size = g.MeasureString("some text", SystemFonts.DefaultFont);
            }

            //If you don't have access to a control to create the graphics instance you can use this to
            //create one for the screen, which works fine for measurement purposes.

            using (Graphics g = Graphics.FromHwnd(IntPtr.Zero))
            {
                SizeF size = g.MeasureString("some text", SystemFonts.DefaultFont);

                //If you want measure only physical length please add this two lines :
                g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;
                SizeF result = g.MeasureString("some text", SystemFonts.DefaultFont, int.MaxValue, StringFormat.GenericTypographic);
            }

            //you have to tell it to measure trailing spaces, which it does not by default.

            using (Graphics grfx = Graphics.FromImage(new Bitmap(1, 1)))
            {
                Font f = new Font("Times New Roman", 10, FontStyle.Regular);

                string text1 = "check_space";
                SizeF bounds1 = grfx.MeasureString(text1, f, new PointF(0, 0), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));

                string text2 = "check_space ";
                SizeF bounds2 = grfx.MeasureString(text2, f, new PointF(0, 0), new StringFormat(StringFormatFlags.MeasureTrailingSpaces));
            }
        }

        //This example does great job of illustrating the use of FormattedText. FormattedText provides low-level
        //control for drawing text in Windows Presentation Foundation (WPF) applications. You can use it to measure
        //the Width of a string with a particular Font without using a Graphics object.
        //Include WindowsBase and PresentationCore libraries.

        //public static float Measure(string text, string fontFamily, float emSize)
        //{
        //  FormattedText formatted = new FormattedText(
        //      item,
        //      CultureInfo.CurrentCulture,
        //      System.Windows.FlowDirection.LeftToRight,
        //      new Typeface(fontFamily),
        //      emSize,
        //      Brushes.Black);

        //  return formatted.Width;
        //}

        #region"OpenFileDialog"

        private void OpenFileDialog()
        {
            using (var openfile = new OpenFileDialog
            {
                Title = @"Please find the file InstallationKey.key ...",
                FileName = "InstallationKey",
                Filter = @"Installation Key (*.key)|*.key",
                DefaultExt = "(*.key)|*.key"
            }
                  )
            {
                //    if (openfile.ShowDialog(this) == DialogResult.Cancel)
                //   {
                //       MessageBox.Show(@"No Database selected. Must select one to continue.", @"DataBase Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Close();
                //       return;
                //   }

                //Settings.Default.DataBaseAddress = Path.GetDirectoryName(openfile.FileName);
                //Settings.Default.DataBaseName = Path.GetFileNameWithoutExtension(openfile.FileName);
                //Settings.Default.DataBaseConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + openfile.FileName;
                //Settings.Default.Save();
            }
        }

        #endregion"OpenFileDialog"



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

        #region"You can try filtering the .db out of the enumeration completely, that way you don't have to remove it."

        void EnumerateFiles(string activeFilepath)
        {
            foreach (string filePath in Directory.EnumerateFiles(activeFilepath, "*.*", SearchOption.AllDirectories)
                                                                                   .Where(x => Path.GetExtension(x) != ".db"))
            {

            }
        }

        #endregion"You can try filtering the .db out of the enumeration completely, that way you don't have to remove it."

        //You can also use linq extensions for DataSets:
        private void LinqReadColumnFiels()
        {
            DataTable dt = new DataTable();

            //    var imagePaths = dt.AsEnumerble().Select(r => r.Field<string>("ImagePath"));
            //    foreach(string imgPath in imagePaths)
            //    {
            //        TextBox1.Text = imgPath;
            //    }
        }

        #region"Nullable value"

        private void NullableValue()
        {
            int? accom = "123" == "noval" ? null : (int?)Convert.ToInt32("12");

            //Using the GetValueOrDefault method will assign the value if there is one,
            //otherwise the default for the type, or a default value that you specify:
            int? v1 = null;
            int v2 = 2;

            v2 = v1.GetValueOrDefault(); // assigns zero if v1 has no value

            v2 = v1.GetValueOrDefault(-1); // assigns -1 if v1 has no value

            //You can use the HasValue property to check if v1 has a value:
            if (v1.HasValue)
                v2 = v1.Value;

        }

        #endregion"Nullable value"

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

        //href="http://file:///c:\AcmeCorpSharedAssemblies\MyLibrary.dll"


        //The 'Microsoft.Jet.OLEDB.4.0' provider is not registered
        void Microsoft_Jet_OLEDB()
        {
            string filextntn = "";
            string strExcelCon = "";
            FileInfo file = new FileInfo(filextntn);

            switch (filextntn)
            {
                case ".XLS":
                    //https://qawithexperts.com/article/c-sharp/read-excel-file-in-c-console-application-example-using-oledb/168  
                    strExcelCon = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + file.Name + ";Extended Properties=\"Excel 8.0;HDR=YES;IMEX=1\"";
                    break;
                case ".XLSX":
                    strExcelCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file.Name + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
                    break;
                case ".XLSB":
                    strExcelCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file.Name + ";Extended Properties=\"Excel 12.0;HDR=YES\"";
                    break;
                case ".XLSM":
                    strExcelCon = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file.Name + ";Extended Properties=\"Excel 12.0 Macro;HDR=YES\"";
                    break;
                case ".TXT":
                    //EDITL.txt for BAJAJ  
                    //ProcessTxtFile(ofn.FileName);
                    return;
                default:
                    strExcelCon = " File Type:" + filextntn;
                    break;
            }
        }


        /*
        int stageOrdinal = dr.GetOrdinal("STAGE");
        while (dr.Read())
         {
            dto = new DataTransferObject();
            if (dr.IsDBNull(stageOrdinal))
            {
                dto.Stage = 1;
            }
            else
            {
                dto.Stage = dr.GetInt32(stageOrdinal);
            }
         }
        */

        void MessageBoxTopMost()
        {
            string MessagePositionString = "";
            Exception error = new Exception("Test for this MessageBox");

            /********* Sample # 1 ***********/
            using (var form = new Form { TopMost = true }) { MessageBox.Show(form, "Text", "Text", MessageBoxButtons.OK, MessageBoxIcon.Error); }

            /********* Sample # 2 ***********/
            using (var form = new Form { TopMost = true })
            {
                if (MessageBox.Show(form, "Text", "Text", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    MessagePositionString = "";
            }

            /********* Sample # 3 ***********/
            using (var form1 = new Form { TopMost = true })
            {
                MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                       @"StockRoom Inventory has generated an error.",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            /********* Sample # 4 ***********/
            using (var form = new Form { TopMost = true })
            {
                MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                      @", Break code at position " + MessagePositionString,
                                      @"CurrentStatus, CurrentStatus fail in ---> Method name <---",
                                      MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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



        public static bool IsNumeric(string text)
        {
            return Regex.IsMatch(text, "^\\d+$");
        }




        const int ERROR_SHARING_VIOLATION = 32;
        const int ERROR_LOCK_VIOLATION = 33;

        public static bool IsFileLocked(Exception exception)
        {
            int errorCode = Marshal.GetHRForException(exception) & ((1 << 16) - 1);
            return errorCode == ERROR_SHARING_VIOLATION || errorCode == ERROR_LOCK_VIOLATION;
        }


        /*Indeed, endianness is your issue here. While not difficult to work around,
         * it can be annoying at times on Intel-based systems due to them being in
         * Little Endian whereas Network Order is Big Endian. In short, your bytes
         * are in the reverse order. Here is a little convenience method you may use
         * to solve this issue (and even on various platforms):*/

        static uint MakeIPAddressInt32(byte[] array)
        {
            // Make a defensive copy.
            var ipBytes = new byte[array.Length];
            array.CopyTo(ipBytes, 0);

            // Reverse if we are on a little endian architecture.
            if (BitConverter.IsLittleEndian)
                Array.Reverse(ipBytes);

            // Convert these bytes to an unsigned 32-bit integer (IPv4 address).
            return BitConverter.ToUInt32(ipBytes, 0);
        }


        /// <summary>
        /// Serializes the Obj to an XML string.
        /// </summary>
        /// <param name="Obj"></param>
        /// <param name="ObjType"></param>
        public static string SaveReview(object Obj, Type ObjType)
        {
            // create the xml for the object and then send the text to the data class to be saved
            XmlSerializer ser = new XmlSerializer(ObjType);
            MemoryStream memStream = new MemoryStream();
            XmlTextWriter xmlWriter = new XmlTextWriter(memStream, Encoding.UTF8)
            {
                Namespaces = true
            };
            ser.Serialize(xmlWriter, Obj);
            xmlWriter.Close();
            memStream.Close();
            string xml;
            xml = Encoding.UTF8.GetString(memStream.GetBuffer());
            xml = xml.Substring(xml.IndexOf(Convert.ToChar(60)));
            xml = xml.Substring(0, (xml.LastIndexOf(Convert.ToChar(62)) + 1));

            // send the xml string to the dataclass so it can be saved
            //data.SaveObject(xml);

            return xml;
        }

        /// <summary>
        /// Return a object type of ObjType.
        /// </summary>
        /// <param name="Xml"></param>
        /// <param name="ObjType">System.Type to be returned.</param>
        /// <returns></returns>
        public static object FromXml(string Xml, Type ObjType)
        {
            XmlSerializer ser = new XmlSerializer(ObjType);
            StringReader stringReader = new StringReader(Xml);
            XmlTextReader xmlReader = new XmlTextReader(stringReader);
            object obj = ser.Deserialize(xmlReader);
            xmlReader.Close();
            stringReader.Close();

            return obj;
        }


        private void SendFilter()
        {
            /*
            if (pArgs.Button == MouseButtons.Left)
            {
                if (pArgs.IsMouseOverNodeHighlight)
                {
                    BindableNode boundableNode = (BindableNode)pArgs.Node;

                    if (boundableNode == null)
                        return;

                    int index = _bindingSource_tableMarshallTreeView.Find("ID", boundableNode.Id);
                    if (index == -1)
                    {
                        dataGridViewExtended_CalendarViewer.DataSource = _bindingSource_tableMarshallTreeView;
                        index = _bindingSource_tableMarshallTreeView.Find("ID", boundableNode.Id);

                        if (index == -1)
                            return;
                    }

                    FTV_currentDateRowView = (DataRowView)_bindingSource_tableMarshallTreeView[index];
                    dataGridViewExtended_CalendarViewer.CustomFilter = FTV_currentDateRowView["String_Filter"].ToString();
                }
            }
             */
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

        /// <summary>
        /// How add columns to dataGridView.
        /// </summary>
        private void Test()
        {
            DataColumnCollection _columnsCollection_Inventory = null;


            DataGridViewCellStyle cellStyle = new DataGridViewCellStyle
            {
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                BackColor = Color.Cornsilk,
                DataSourceNullValue = false,
                NullValue = false
            };

            DataGridViewCell cellCheckBox = new DataGridViewCheckBoxCell(false);

            foreach (DataColumn column in _columnsCollection_Inventory)
            {
                DataGridViewColumn newcolumn = new DataGridViewCheckBoxColumn(false)
                {
                    CellTemplate = cellCheckBox,
                    DefaultCellStyle = cellStyle,
                    Name = column.ColumnName,
                    HeaderText = column.Caption
                };

                //         dataGridView1.Columns.Add(newcolumn);

            }

            //      dataGridView1.Rows.Add(new object[] { "Visible", false, false, false });

            ColumnSetting columnsetting = new ColumnSetting();
            DataGridView dataGridView1 = new DataGridView();

            foreach (var property in columnsetting.GetType().GetProperties())
            {
                //  Console.WriteLine("{0}={1}", property.Name, property.GetValue(columnsetting, null));

                if (property.Name == "Name")
                    continue;

                int rowIndex = dataGridView1.Rows.Add();
                DataGridViewRow row = dataGridView1.Rows[rowIndex];
                row.Cells[0].Value = property.Name;
                row.Cells[1].Value = property.GetValue(columnsetting, null);
                row.Cells[2].Value = true;

            }


        }

        #region"RegularExpressions"

        /*
        C# Regular Expressions Cheat Sheet

        Cheat sheet for C# regular expressions metacharacters, operators, quantifiers etc

        Character       Description
        \	            Marks the next character as either a special character or escapes a literal. For example,
                        "n" matches the character "n". "\n" matches a newline character. The sequence "\\" matches "\" and
                        "\(" matches "(".Note: double quotes may be escaped by doubling them: "<a href=""...>"        
        ^	            Depending on whether the MultiLine option is set, matches the position before the first character in a line,
                        or the first character in the string.         
        $	            Depending on whether the MultiLine option is set, matches the position after the last character in a line,
                        or the last character in the string.         
        *	            Matches the preceding character zero or more times. For example, "zo*" matches either "z" or "zoo".        
        +	            Matches the preceding character one or more times. For example, "zo+" matches "zoo" but not "z".        
        ?	            Matches the preceding character zero or one time. For example, "a?ve?" matches the "ve" in "never".        
        .	            Matches any single character except a newline character.        
        (pattern)	    Matches pattern and remembers the match. The matched substring can be retrieved from the resulting Matches collection,
                        using Item [0]...[n]. To match parentheses characters ( ), use "\(" or "\)".         
        (?<name>pattern)	Matches pattern and gives the match a name.         
        (?:pattern)	    A non-capturing group.        
        (?=...)	        A positive lookahead.
        (?!...)	        A negative lookahead.
        (?<=...)	    A positive lookbehind .
        (?<!...)	    A negative lookbehind .
        x|y	            Matches either x or y. For example, "z|wood" matches "z" or "wood". "(z|w)oo" matches "zoo" or "wood".
        {n}	            n is a non-negative integer. Matches exactly n times. For example, "o{2}" does not match the "o" in "Bob," but matches
                        the first two o's in "foooood".
        {n,}	        n is a non-negative integer. Matches at least n times. For example, "o{2,}" does not match the "o" in "Bob" and matches
                        all the o's in "foooood." "o{1,}" is equivalent to "o+". "o{0,}" is equivalent to "o*".
        {n,m}	        m and n are non-negative integers. Matches at least n and at most m times. For example, "o{1,3}" matches the first three
                        o's in "fooooood." "o{0,1}" is equivalent to "o?".
        [xyz]	        A character set. Matches any one of the enclosed characters. For example, "[abc]" matches the "a" in "plain".
        [^xyz]	        A negative character set. Matches any character not enclosed. For example, "[^abc]" matches the "p" in "plain".
        [a-z]	        A range of characters. Matches any character in the specified range. For example, "[a-z]" matches any lowercase
                        alphabetic character in the range "a" through "z".
        [^m-z]	        A negative range characters. Matches any character not in the specified range. For example, "[m-z]" matches any
                        character not in the range "m" through "z".
        \b	            Matches a word boundary, that is, the position between a word and a space. For example, "er\b" matches the "er" in
                        "never" but not the "er" in "verb".
        \B	            Matches a non-word boundary. "ea*r\B" matches the "ear" in "never early".
        \d	            Matches a digit character. Equivalent to [0-9].
        \D	            Matches a non-digit character. Equivalent to [^0-9].
        \f	            Matches a form-feed character.
        \k	            A back-reference to a named group.
        \n	            Matches a newline character.
        \r	            Matches a carriage return character.
        \s	            Matches any white space including space, tab, form-feed, etc. Equivalent to "[ \f\n\r\t\v]".
        \S	            Matches any nonwhite space character. Equivalent to "[^ \f\n\r\t\v]".
        \t	            Matches a tab character.
        \v	            Matches a vertical tab character.
        \w	            Matches any word character including underscore. Equivalent to "[A-Za-z0-9_]".
        \W	            Matches any non-word character. Equivalent to "[^A-Za-z0-9_]".
        \num	        Matches num, where num is a positive integer. A reference back to remembered matches. For example, "(.)\1" matches
                        two consecutive identical characters.
        \n	            Matches n, where n is an octal escape value. Octal escape values must be 1, 2, or 3 digits long. For example, "\11" and
                        "\011" both match a tab character. "\0011" is the equivalent of "\001" & "1". Octal escape values must not exceed 256.
                        If they do, only the first two digits comprise the expression. Allows ASCII codes to be used in regular expressions.
        \xn	            Matches n, where n is a hexadecimal escape value. Hexadecimal escape values must be exactly two digits long. For example,
                        "\x41" matches "A". "\x041" is equivalent to "\x04" & "1". Allows ASCII codes to be used in regular expressions.
        \un	            Matches a Unicode character expressed in hexadecimal notation with exactly four numeric digits. "\u0200" matches a space character.
        \A	            Matches the position before the first character in a string. Not affected by the MultiLine setting
        \Z	            Matches the position after the last character of a string. Not affected by the MultiLine setting.
        \G	            Specifies that the matches must be consecutive, without any intervening non-matching characters.
         * 
        */

        #region"MatchEvaluator Delegate, Represents the method that is called each time a"

        // regular expression match is found during a Replace method operation.
        public string Highlight(string InputTxt)
        {
            // The string to search.
            string sInput = "aabbccddeeffcccgghhcccciijjcccckkcc";

            // A very simple regular expression.
            string sRegex = "cc";

            Regex r = new Regex(sRegex);

            // Assign the replace method to the MatchEvaluator delegate.
            MatchEvaluator myEvaluator = new MatchEvaluator(ReplaceKeyWords);

            // Replace matched characters using the delegate method.
            sInput = r.Replace(sInput, myEvaluator);

            // Write out the modified string.
            //return sInput;

            // The example displays the following output: 
            //       aabbccddeeffcccgghhcccciijjcccckkcc 
            //       aabb11ddeeff22cgghh3344iijj5566kk77

            /**************************************************/

            InputTxt = "aabbccdd|eeffcccgghhcccciijjcccckkcc";
            string Search_Str = "  dd ee  ";

            // Setup the regular expression and add the Or operator.
            Regex RegExp = new Regex(Search_Str.Replace(" ", "|").Trim(), RegexOptions.IgnoreCase);

            // Highlight keywords by calling the 
            //delegate each time a keyword is found.
            string resulString = RegExp.Replace(InputTxt, new MatchEvaluator(ReplaceKeyWords));

            // Set the RegExp to null.
            RegExp = null;

            return resulString;

            // The example displays the following output: 
            //       aabbccdd|eeffcccgghhcccciijjcccckkcc
            //       aabbccdd11eeffcccgghhcccciijjcccckkcc 
        }

        public static int y;
        private string ReplaceKeyWords(Match matchWords)
        {
            y++;
            return y.ToString() + y.ToString();
        }

        #endregion"MatchEvaluator Delegate, Represents the method that is called each time a"

        #endregion"RegularExpressions"

    }
}
