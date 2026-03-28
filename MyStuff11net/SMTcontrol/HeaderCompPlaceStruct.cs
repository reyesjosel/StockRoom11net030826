using System.Data;
using System.Runtime.InteropServices;

namespace MyStuff11net
{
    #region Nested type: HxH_Header

    // This is the file header for a HxH. We do this special layout with everything
    // packed so we can read straight from disk into the structure to populate it
    // the header are the first 122 bytes.

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct HxH_HeaderStruct
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 33)]
        public readonly string machineName;                 // Index 0 
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public readonly string machine701;                  // Index 33
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public readonly string unknow01;                    // Index 45

        public readonly Int32 addressForPlacementStar;      // Index 86, + 4 byte on any Int32
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public readonly string unknow02;
        public readonly Int32 numberOfPlacements;           // Index 98, + 4 byte on any Int32

        public readonly Int32 addressForComponentStar;      // Index 102, + 4 byte on any Int32
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public readonly string unknow03;
        public readonly Int32 numberOfComponets;            // Index 114, + 4 byte on any Int32
        public readonly Int32 addressForComponentEnd;       // Index 118, + 4 byte on any Int32

    }

    #endregion

    #region Nested type: ComponentStruct

    /// <summary>
    /// Struct Component in H5H file format.
    /// struct component length 792 bytes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ComponentStruct_H5H
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string Name;                 // 21 bytes.

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public readonly string unknow01;   // 12 bytes.

        public readonly Int32 unknow02;    // 4 bytes.

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public readonly string unknow03;    // 10 bytes.


        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string Comment;              // 30 bytes.

        public readonly Int32 unknow04;    // 4 bytes.
        public readonly Int32 unknow05;    // 4 bytes.
        public readonly Int32 unknow06;    // 4 bytes.
        public readonly Int32 unknow07;    // 4 bytes.
        public readonly Int32 unknow08;    // 4 bytes.

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 691)]
        public readonly string unknow09;    // 691 bytes.
    }

    /// <summary>
    /// Struct Component in H7H file format.
    /// struct component length 1792 bytes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct ComponentStruct_H7H
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 21)]
        public string Name;                 // 21 bytes.

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
        public readonly string unknow01;   // 12 bytes.   21+12=33

        public readonly Int32 unknow02;    // 4 bytes.    33+4=37

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 10)]
        public readonly string unknow03;    // 10 bytes.  37+10=47


        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 30)]
        public string Comment;              // 30 bytes.  47+30=77

        public readonly Int32 unknow04;    // 4 bytes.   77+4=81
        public readonly Int32 unknow05;    // 4 bytes.   81+4=85
        public readonly Int32 unknow06;    // 4 bytes.   85+4=89
        public readonly Int32 unknow07;    // 4 bytes.   89+4=93
        public readonly Int32 unknow08;    // 4 bytes.   93+4=97

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1695)]
        public readonly string unknow09;    // 1695 bytes. 97+1695=1792
    }

    #endregion Nested type: ComponentStruct

    #region"Nested type: PlacementStruct"

    /// <summary>
    /// Struct placement in H5H file format.
    /// struct placement length 96 bytes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlacementStruct_H5H
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public readonly string Placement_ID;        // 8 bytes.
        public readonly Int32 Axes_X;               // 4 bytes.  8+4=12
        public readonly Int32 Axes_Y;               // 4 bytes. 12+4=16
        public readonly Int16 Angle;                // 2 bytes. 16+2=18

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 13)]
        public readonly string unknow01;            // 13 bytes. 18+13=31

        public readonly Int16 IndexComponent;       // 2 bytes.  31+2=33

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 63)]
        public readonly string unknow03;            // 63 bytes. 33+63=96
    }

    /// <summary>
    /// Struct placement in H7H file format.
    /// struct placement length 256 bytes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct PlacementStruct_H7H
    {
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 8)]
        public readonly string ID;         // 8 bytes.
        public Int32 Axes_X;               // 4 bytes.  8+4=12
        public Int32 Axes_Y;               // 4 bytes. 12+4=16
        public Int16 Angle;                // 2 bytes. 16+2=18

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public readonly string _unknow02;            // 2 bytes. 18+2=20

        public Int16 Station;            // 2 bytes. 20+2=22

        public Int16 StationPlacementIndex;// 2 bytes. 22+2=24

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public readonly string Boolean1;            // 1 bytes. 24+1=25        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public readonly string Boolean2;            // 1 bytes. 25+1=26        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public readonly string Boolean3;            // 1 bytes. 26+1=27        
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 1)]
        public readonly string Skip;                // 1 bytes. 27+1=28

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public readonly string _unknow06;          // 2 bytes. 28+2=30

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public readonly string _unknow07;          // 2 bytes. 30+2=32

        public Int16 CompTableIndex;     // 2 bytes. 32+2=34        

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2)]
        public readonly string _unknow08;          // 2 bytes. 34+2=36

        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 220)]
        public readonly string _unknow09;          // 220 bytes. 36+220=256


    }

    #endregion"Nested type: PlacementStruct"

    #region "ComponentData"

    public class ComponentData : IComparable<ComponentData>
    {
        public ComponentData(int index, int qtyProjectPlaned, object componentObject, string version, BindingSource bindingSource)
        {
            Version = version;
            Index_Comp = index;
            QtyProjectPlaned = qtyProjectPlaned;

            if (version.Contains("H5H"))
            {
                component = new ComponentStruct_H5H();
                component = (ComponentStruct_H5H)componentObject;

                componentH5H = (ComponentStruct_H5H)component;
                Name = componentH5H.Name;
                Comment = componentH5H.Comment;
            }

            if (version.Contains("H7H"))
            {
                component = new ComponentStruct_H7H();
                component = (ComponentStruct_H7H)componentObject;

                componentH7H = (ComponentStruct_H7H)component;
                Name = componentH7H.Name;
                Comment = componentH7H.Comment;
            }

            if (string.IsNullOrEmpty(Comment))
            {
                SetNoComponentInformation(index);
                return;
            }

            PartNumber = GetPartNumbert(Comment);
            int stockRoomIndex = bindingSource.Find("PartNumber", PartNumber);

            if (stockRoomIndex == -1)
            {
                Name = Name + remplacementsComp;
                return;
            }

            componentInformations = new ComponentInformation((DataRowView)bindingSource[stockRoomIndex]);

            Description = componentInformations.Description + remplacementsComp;
            CompOnHand = componentInformations.OnAvailable;
            SizePackaging = componentInformations.Package;
        }

        string Version;
        object component;
        ComponentStruct_H5H componentH5H;
        ComponentStruct_H7H componentH7H;
        ComponentInformation componentInformations;


        /// <summary>
        /// PartNumber of the component into the database, extrac it from
        /// Comment.
        /// </summary>
        public string PartNumber { get; set; }

        /// <summary>
        /// Description of the component front the database, it is the description
        /// present in InventorydataBase.
        /// </summary>
        public string Description { get; set; }

        public int CompOnHand { get; set; }

        public int QtyProjectPlaned { get; set; }

        int compForProduction;
        public int CompForProduction
        {
            get
            {
                return (QtyProjectPlaned * NumberOfPlacements);
            }
            set
            {
                compForProduction = value;
            }
        }

        public int NumberOfPlacements { get; set; }

        public string Placements { get; set; }

        public string SizePackaging { get; set; }

        public string ProjectName { get; set; }

        public string Status { get; set; }


        /// <summary>
        /// Name fiel in HxH file, SMT operator fill it.
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// Comment fiel in HxH file, SMT operator fill it.
        /// 018-0034; 018-0054; *018-0234, different replacement parts,
        /// using tha one wit * in the begining.
        /// </summary>
        string Comment;

        public int Index_Comp;




        void SetNoComponentInformation(int index)
        {
            Index_Comp = index;
            CompOnHand = 0;
            PartNumber = "Undefined";
        }

        string remplacementsComp = "";
        string GetPartNumbert(string component_Comment)
        {
            string partNumberOut = "";

            if (component_Comment.Contains(","))
            {
                MessageBox.Show(new Form() { TopMost = true }, @"The correct format is '018-0054; *018-0234'" + Environment.NewLine +
                                                                "Place a ';' semicolon between each partNumber" + Environment.NewLine +
                                                                "(The '*' Mark determines the active PartNumber) ",
                                                                                   @"ERROR: wrong format.",
                                                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // if component.Comment contains ; example: 018-0034; 018-0054; *018-0234
            if (component_Comment.Contains(";"))
            {
                string[] commentSplit = component_Comment.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string partnumber in commentSplit)
                {
                    if (partnumber.Contains("*"))
                    {
                        partNumberOut = partnumber.Trim();
                        partNumberOut = partnumber.Replace("*", "").Trim();
                        break;
                    }
                }

                // *018-0054; 018-0095  and  018-0054; *018-0095
                if (partNumberOut.Length != 0)
                {
                    remplacementsComp = "; (Replacements: ";

                    foreach (string _partNumber in commentSplit)
                    {
                        if (_partNumber.Contains(partNumberOut))
                            continue;

                        remplacementsComp += _partNumber + ";";
                    }

                    remplacementsComp += ")";
                }

                // No contains (*), pick the first
                if (partNumberOut.Length == 0)
                {
                    partNumberOut = commentSplit[0];

                    remplacementsComp = "; Replacements: " + component_Comment.Replace(commentSplit[0], "");

                    if (remplacementsComp.Length == 0)
                        remplacementsComp = "; Replacements: " + component_Comment.Replace("; " + commentSplit[0], "");
                    if (remplacementsComp.Length == 0)
                        remplacementsComp = "; Replacements: " + component_Comment.Replace(";" + commentSplit[0], "");
                }
            }
            else
            {
                // component_Comment no contains (;) is only one partNumber.
                partNumberOut = component_Comment;
                remplacementsComp = "";
            }

            return partNumberOut;
        }

        public int CompareTo(ComponentData p)
        {
            return PartNumber.CompareTo(p.PartNumber);
        }

    }

    #endregion "ComponentData"

    #region"PlacementData"

    public class PlacementData
    {
        object placement;
        int StructSize;
        Type StructType;
        GCHandle _handlePlacements;
        PlacementStruct_H5H placementH5H;
        PlacementStruct_H7H placementH7H;
        Trictionary<int, string, int> _trictionaryPlacements = new Trictionary<int, string, int>();

        public PlacementData(int index, byte[] bufferPlacements, string version)
        {
            if (version.Contains("H5H"))
            {
                StructType = typeof(PlacementStruct_H5H);
                StructSize = Marshal.SizeOf(typeof(PlacementStruct_H5H));
            }
            if (version.Contains("H7H"))
            {
                StructType = typeof(PlacementStruct_H7H);
                //StructSize = Marshal.SizeOf(typeof(PlacementStruct_H7H));
                StructSize = 256;
            }

            _handlePlacements = GCHandle.Alloc(bufferPlacements, GCHandleType.Pinned);
            placement = Marshal.PtrToStructure(_handlePlacements.AddrOfPinnedObject(), StructType);
            _handlePlacements.Free();

            if (version.Contains("H5H"))
            {
                placementH5H = (PlacementStruct_H5H)placement;
                Placement_ID = placementH5H.Placement_ID;
                Axes_X = placementH5H.Axes_X;
                Axes_Y = placementH5H.Axes_Y;
                Angle = placementH5H.Angle;

                Index_Table_Component = placementH5H.IndexComponent;
                //    Skip = placementH5H.s
            }
            if (version.Contains("H7H"))
            {
                placementH7H = (PlacementStruct_H7H)placement;
                Placement_ID = placementH7H.ID.ToString();
                Axes_X = placementH7H.Axes_X;
                Axes_Y = placementH7H.Axes_Y;
                Angle = placementH7H.Angle;

                Index_Table_Component = placementH7H.CompTableIndex / 256;


                if (Placement_ID.Contains("PCB"))
                    Skip = true;

                Skip = MyCode.AsBool(placementH7H.Skip);
            }

        }

        public string Placement_ID { get; set; }

        public int Axes_X { get; set; }

        public int Axes_Y { get; set; }

        public short Angle { get; set; }

        public string Station { get; set; }

        public string Placement_Index { get; set; }

        public bool Skip { get; set; }

        public int Index_Table_Component { get; set; }

        public string ProjectName { get; set; }

        public string Status { get; set; }
    }

    #endregion"PlacementData"



}
