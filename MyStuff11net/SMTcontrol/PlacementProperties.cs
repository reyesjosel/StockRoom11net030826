using System.ComponentModel;

namespace MyStuff11net
{
    public class PlacementInformation
    {

        public PlacementInformation(PlacementStruct_H7H placement, string projectfilename)
        {
            Placement = placement;
            ProjectName = projectfilename;
        }

        private PlacementStruct_H7H Placement;

        [Browsable(false)]
        [DisplayName("ID")]
        public int ID { get; private set; }

        [DisplayName("Index")]
        public int Index { get; private set; }

        /// <summary>
        /// ID assigned to this placement, can be 8 characters
        /// example: R135, Q56, RTDFR452.
        /// </summary>
        [DisplayName("Placement")]
        public string Placement_ID
        {
            get
            {
                return Placement.ID.ToString();
            }
            set { }
        }

        [DisplayName("Axes X")]
        public decimal Axes_X
        {
            get
            {
                return (decimal)(Placement.Axes_X / 1000);
            }
            set { }
        }

        [DisplayName("Axes Y")]
        public decimal Axes_Y
        {
            get
            {
                return (decimal)(Placement.Axes_Y / 1000);
            }
            set { }
        }

        [DisplayName("Angle")]
        public int Angle
        {
            get
            {
                return (Placement.Angle / 80);
            }
            set { }
        }

        [Browsable(false)]
        [DisplayName("Place")]
        public string Place { get; private set; }

        /// <summary>
        /// True if the placement will be skipped, false by default the
        /// placement will be placed.
        /// </summary>
        [DisplayName("Skip")]
        public bool Skip
        {
            get
            {
                return MyCode.AsBool(Placement.Skip);
            }
            set { }
        }

        [Browsable(false)]
        public string Try { get; private set; }

        [Browsable(false)]
        public string Layers { get; private set; }

        /// <summary>
        /// If the assembly line is multi station,
        /// station index or id.
        /// </summary>
        [DisplayName("Station")]
        public int Station
        {
            get
            {
                return Placement.Station;
            }
            set { }
        }

        /// <summary>
        /// Component Index into the component table.
        /// </summary>
        public int IndexComp
        {
            get
            {
                return Placement.CompTableIndex;
            }
            set { }
        }

        public int IndexPlac { get; private set; }

        /// <summary>
        /// The component name or description.
        /// </summary>
        public string CompName { get; private set; }

        /// <summary>
        /// Component PartNumber used in the place.
        /// </summary>
        [DisplayName("PartNumber")]
        public string PartNumber { get; private set; }

        /// <summary>
        /// A flag to warn of an activity.
        /// </summary>
        [DisplayName("Status")]
        public string Status { get; private set; }

        public string ProjectName { get; private set; }

    }
}
