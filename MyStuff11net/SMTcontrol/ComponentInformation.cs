using System.Data;
using System.Text.RegularExpressions;

namespace MyStuff11net
{
    public class ComponentInformation
    {
        CustomPanelDoubleBuffered containerCompInfo;
        public ComponentInformation(string partNumber)
        {
            try
            {
                PartNumber = partNumber;
                PartNumberTag = PartNumber.Remove(4);
                Description = "Inserting new component, please fill all records.";

                ProcessSelectComponent();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ComponentInformation has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ComponentInformation(DataRowView componentRow)
        {
            try
            {
                ComponentRow = componentRow;

                DetermineTableNameUpDateAllFields(ComponentRow);

                ProcessSelectComponent();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ComponentInformation has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ComponentInformation(DataRowView componentRow, CustomPanelDoubleBuffered container)
        {
            try
            {
                ComponentRow = componentRow;
                containerCompInfo = container;

                DetermineTableNameUpDateAllFields(ComponentRow);
               
                ProcessSelectComponent();
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ComponentInformation has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
               
        public ComponentInformation(object partNumber, object description, object placements, int places)
        {
            try
            {
                PartNumber = partNumber.ToString();
                Description = description.ToString();
                Placements = placements.ToString();
                Places = places;
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ComponentInformation has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public ComponentInformation(object partNumber, object description, object placements, int places,
                                                    int compForProduction, int onHandBefore, int onAvailable)
        {
            try
            {
                PartNumber = partNumber.ToString();
                Description = description.ToString();
                Placements = placements.ToString();
                Places = places;
                CompForProduction = compForProduction;
                OnHandBefore = onHandBefore;
                OnAvailable = onAvailable;
            }
            catch (Exception error)
            {
                MessageBox.Show(new Form() { TopMost = true }, @"Message related to this error is " + error.Message,
                                 @"ComponentInformation has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // For SMT project, component and placements.
        public int Places;
        public string Placements;
        public int CompForProduction;
        public int OnHandBefore;

        DataRowView ComponentRow;

        /// <summary>
        /// Contiene el nombre del component selected, Resistor, Diode.
        /// </summary>
        public string SeletedComponentName { get; private set; }

        BaseComponent currentComp;
        public BaseComponent SeletedComponent;

        public void ProcessNewCompInformation(DataRowView componentRow,
                                              CustomPanelDoubleBuffered container)
        {
            ComponentRow = componentRow;
            containerCompInfo = container;            

            DetermineTableNameUpDateAllFields(ComponentRow);
            ProcessSelectComponent();

            if (currentComp != null && currentComp.PartNumberTag.Contains(PartNumberTag))
            {
                // Same component, only update information.
                currentComp.UpdateInformation(this);
                return;
            }

            currentComp = SeletedComponent;
            container.Controls.Clear();
            container.Controls.Add(SeletedComponent);
        }

        private void DetermineTableNameUpDateAllFields(DataRowView componentRow)
        {
            switch (componentRow.DataView.Table.TableName)
            {
                case "Table_Components":
                    {
                        #region"Components"
                        /*
                Index;
                ID
                PartNumber
                Component_Name
                Size/Packaging
                Number_of_Placements
                Placements
                Comp_for_Production
                Comp_On_Hand
                Max_Possible_Quantity
                Pack
                Feeder_Type
                Centering(Nozzle)
                For_Ordering
                Index_Comp
                Quantity_to_Prod
                StockRoom_Index
                Status
                ProjectName
                ComponentInformations
                */
                        #endregion"Components"
                        break;
                    }
                case "Table_Placements":
                    {
                        #region"Placements"
                        /*
                    Index
                    ID
                    Placement_ID
                    Axes_X
                    Axes_Y
                    Angle
                    Place
                    Try 
                    Layers
                    Station 
                    Index_Table_Component
                    Placement_Index 
                    Component_Name
                    PartNumber 
                    Status
                    ProjectName                        
                    */
                        #endregion"Placements"
                        break;
                    }
                case "Table_StockRoom":
                    {
                        #region"Table_StockRoom"

                        PartNumber = componentRow["PartNumber"].ToString();

                        if (PartNumber.Length < 4)
                            return;

                        PartNumberTag = PartNumber.Remove(4);
                        Description = componentRow["Description"].ToString();
                        Manufacturer = componentRow["Manufacturer"].ToString();
                        ModelNumber = componentRow["ModelNumber"].ToString();
                        Supplier = componentRow["Supplier"].ToString();
                        DataSheet_File = componentRow["DataSheet_File"].ToString();
                        Who_uses_this = componentRow["Who_uses_this"].ToString();
                        OnHand = MyCode.ConvertDBNull.To(componentRow["OnHand"], 0);
                        OnHold = MyCode.CastAs(componentRow["OnHold"], 0);
                        OnHoldBy = componentRow["OnHoldby"].ToString();
                        OnAvailable = MyCode.CastAsInt(componentRow["OnAvailable"]);

                        #endregion"Table_StockRoom"
                        break;
                    }
                default:
                    {
                        return;
                    }
            }

        }

        private void ProcessSelectComponent()
        {
            switch (PartNumberTag)
            {
                case "014-":
                    Resistor(Description);
                    SeletedComponentName = "Resistors";
                    SeletedComponent = new Resistor(this);
                    break;
                case "015-":
                    IC(Description);
                    SeletedComponentName = "IC";
                    SeletedComponent = new IntegratedCircuit(this);
                    break;
                case "018-":
                    Capacitor(Description);
                    SeletedComponentName = "Capacitors";
                    SeletedComponent = new Capacitors(this);
                    break;
                case "040-":
                    Heatsinks(Description);
                    SeletedComponentName = "Heatsinks";
                    SeletedComponent = new Heatsink(this);
                    break;
                case "045-":
                    Connectors(Description);
                    SeletedComponentName = "Connectors";
                    SeletedComponent = new Connectors(this);
                    break;
                case "050-":
                    CristalOscillators(Description);
                    SeletedComponentName = "Cristal";
                    SeletedComponent = new CristalOscillators(this);
                    break;
                case "055-":
                    Transformers(Description);
                    SeletedComponentName = "Transformers";
                    SeletedComponent = new Transformers(this);
                    break;
                case "056-":
                    Inductors(Description);
                    SeletedComponentName = "Inductors";
                    SeletedComponent = new Inductors(this);
                    break;
                case "058-":
                    Speakers(Description);
                    SeletedComponentName = "Speakers";
                    SeletedComponent = new Speakers(this);
                    break;
                case "059-":
                    Relays(Description);
                    SeletedComponentName = "Relays";
                  //  SeletedComponent = new BaseComponent();
                    break;
                case "060-":
                    Transistor(Description);
                    SeletedComponentName = "Transistors";
                    SeletedComponent = new Transistors(this);
                    break;
                case "065-":
                    Diodes(Description);
                    SeletedComponentName = "Diodes";
                    SeletedComponent = new Diodes(this);
                    break;
                case "070-":
                    Leds(Description);
                    SeletedComponentName = "Leds";
                    SeletedComponent = new Leds(this);
                    break;
                case "075-":
                    Switches(Description);
                    SeletedComponentName = "Switches";
                    SeletedComponent = new Switches(this);
                    break;
                case "080-":
                    Plastic(Description);
                    SeletedComponentName = "Plastic";
                  //  SeletedComponent = new BaseComponent();
                    break;
                case "095-":
                    CoversSheetMetal(Description);
                    SeletedComponentName = "CoverSheetMetal";
                    SeletedComponent = new CoversSheetMetals(this);
                    break;
                case "098-":
                    Antenna(Description);
                    SeletedComponentName = "Antennas";
                    SeletedComponent = new Antennas(this);
                    break;
                case "099-":
                    Cables(Description);
                    SeletedComponentName = "Cables";
                    SeletedComponent = new Cables(this);
                    break;
                case "103-":
                    Hardware(Description);
                    SeletedComponentName = "Hardware's";
                    SeletedComponent = new Hardware(this);
                    break;
                case "104-":
                    Hardware(Description);
                    SeletedComponentName = "Hardware's";
                    SeletedComponent = new Hardware(this);
                    break;
                case "105-":
                    Hardware(Description);
                    SeletedComponentName = "Hardware's";
                    SeletedComponent = new Hardware(this);
                    break;
                case "106-":
                    Labels(Description);
                    SeletedComponentName = "Labels";
                    SeletedComponent = new Labels(this);
                    break;
                case "107-":
                    ManualsWarrantyCard(Description);
                    SeletedComponentName = "ManualsWarrantyCards";
                    SeletedComponent = new ManualsWarrantyCards(this);
                    break;
                case "108-":
                    Packaging(Description);
                    SeletedComponentName = "Packaging";
                    SeletedComponent = new Packaging(this);
                    break;
                case "109-":
                    SchematicDiagrams(Description);
                    SeletedComponentName = "SchematicDiagrams";
                    SeletedComponent = new SchematicDiagrams(this);
                    break;
                case "110-":
                    PCB(Description);
                    SeletedComponentName = "PCBs";
                    SeletedComponent = new PCBs(this);
                    break;
                case "111-":
                    PCB(Description);
                    SeletedComponentName = "PCB Screen";
                    SeletedComponent = new PCBs(this);
                    break;
                case "210-":
                    Assembled_210(Description);
                    SeletedComponentName = "PCBs Populated";
                 //   SeletedComponent = new BaseComponent();
                    break;
                case "510-":
                    Assembled_510(Description);
                    SeletedComponentName = "Product ready for pakaging";
                 //   SeletedComponent = new BaseComponent();
                    break;
                case "AT":
                    Assembled_AT(Description);
                    SeletedComponentName = "Product of AdvanceTec Comp.";
                 //   SeletedComponent = new BaseComponent();
                    break;
                case "ATT":
                    Assembled_ATT(Description);
                    SeletedComponentName = "Produc of ATT comp.";
                 //   SeletedComponent = new BaseComponent();
                    break;
                case "NewC":
                    Assembled_ATT(Description);
                    SeletedComponentName = "New comp initialization";
                //    SeletedComponent = new BaseComponent();
                    break;

                default:
                    MessageBox.Show("No identificado components in ComponentInformations, PartNumber code " + PartNumberTag,
                    "CellDoubleClick_EventArgs StockRoom Inventory, Custom_Events_Args.cs file.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }


        public string PartNumber { get; private set; }

        /// <summary>
        /// Gets the part number tag associated with the item.
        /// </summary>
        /// <remarks>
        /// This is typically the first four characters of the part number,
        /// and is used to categorize the type of component.
        /// We calcule it removing at 4th character from PartNumber in method DetermineTableName().
        /// </remarks>
        public string PartNumberTag { get; private set; }
        public string Description { get; private set; }
        public string Manufacturer { get; private set; }
        public string ModelNumber { get; private set; }
        public string Supplier { get; private set; }
        public string DataSheet_File { get; private set; }
        public string Who_uses_this { get; private set; }
        public int OnHand { get; private set; }
        public int OnHold { get; private set; }
        public string OnHoldBy { get; private set; }
        public int OnAvailable { get; private set; }
        public string Reel_Number { get; private set; }
        public string OnOrder { get; private set; }
        public string OnDemand { get; private set; }
        public string ToOrder { get; private set; }
        public string MinQty { get; private set; }
        public string MaxQty { get; private set; }
        public string LTime { get; private set; }
        public string PrevQty { get; private set; }
        public string SalePrice { get; private set; }

        public string Value { get; private set; }
        public string Tolerance { get; private set; }
        public string Unit { get; private set; }
        public string Power { get; private set; }
        public string Volts { get; private set; }        
        public string Size { get; private set; }

        public string Comment_about_it { get; private set; }

        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Vce { get; private set; }
        public string Ice { get; private set; }

        public string Vrms { get; private set; }
        public string Vr { get; private set; }
        public string If { get; private set; }
        public string Package { get; private set; }

        public string LedsColor { get; private set; }

        //HeatSinks
        public string Power_Dissipation { get; private set; }
        public string Package_Cooled { get; private set; }
        public string Attachment_Method { get; private set; }
        public string Length { get; private set; }
        public string Width { get; private set; }
        public string Height { get; private set; }


        private void Resistor(string value)
        {
            Package = null;
            Unit = null;
            Value = null;
            Power = null;
            Tolerance = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries |
                                                                        StringSplitOptions.TrimEntries);
            
            for (int i = 0; i < description.Length; i++)
            {
                description[i] = description[i].Trim();
                                                
                if (i == 0)
                {
                    description[i] = NormalizesResistence_to_SI_format(description[i]);

                    if (description[i].Contains('Ω'))
                    {
                        Unit = "" + 'Ω';
                        if (description[i].Contains("KΩ"))
                            Unit = "KΩ";
                        if (description[i].Contains("MΩ"))
                            Unit = "MΩ";

                        Value = description[i].Replace(Unit, "").Trim();
                        continue;
                    }
                }

                if (description[i].Contains('%'))
                {
                    Tolerance = description[i].Replace("%", "").Trim();
                    continue;
                }
                if (description[i].Contains("watts"))
                {
                    Power = description[i].Replace("watts", "").Trim();
                    continue;
                }

                IsPackage(description[i]);
            }
        }

        string NormalizesResistence_to_SI_format(string input)
        { 
            //input = "10k, 4.7M, 100 ohm, 2.2kohm, 1 megaohm, 470Ω";

            string pattern = @"
                            \b
                            (?<value>\d+(\.\d+)?)
                            \s*
                            (?:
                                (?<kilo>k|kilo)
                              | (?<mega>m|meg|mega)
                            )?
                            \s*
                            (ohm|Ω)?
                            \b";

            string result = Regex.Replace(
                input,
                pattern,
                match =>
                {
                    // Must contain a unit hint; otherwise skip pure numbers
                    if (!match.Groups["kilo"].Success &&
                        !match.Groups["mega"].Success &&
                        !Regex.IsMatch(match.Value, "(ohm|Ω)", RegexOptions.IgnoreCase))
                        return match.Value;

                    string value = match.Groups["value"].Value;

                    if (match.Groups["kilo"].Success) return $"{value}KΩ";
                    if (match.Groups["mega"].Success) return $"{value}MΩ";
                    return $"{value}Ω";
                },
                RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace
            );

            return result;
        }



        private void IC(string value)
        {
            Name = null;
            Package = null;
            Comment_about_it = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameter in description)
            {
                if (parameter.Contains("Comm:"))
                {
                    Comment_about_it = parameter.Replace("Comm:", "").Trim();
                    continue;
                }

                if (parameter.Contains("SO-") || parameter.Contains("SOT-") || parameter.Contains("TO-") ||
                    parameter.Contains("SOIC") || parameter.Contains("DPAK"))
                {
                    Package = parameter.Trim();
                    continue;
                }

                Name = parameter.Trim();
                continue;
            }
        }

        private void Capacitor(string value)
        {
            Package = null;
            Unit = null;
            Volts = null;
            Value = null;
            Tolerance = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < description.Length; i++)
            {
                description[i] = description[i].Trim(new char[] { ' ' });

                if (description[i].Contains("pF"))
                {
                    Value = description[i].Replace("pF", "").Trim();
                    Unit = "pF";
                    continue;
                }
                if (description[i].Contains("nF"))
                {
                    Value = description[i].Replace("nF", "").Trim();
                    Unit = "nF";
                    continue;
                }
                if (description[i].Contains("" + '\u03BC'))
                {
                    Value = description[i].Replace("" + '\u03BC' + "F", "").Trim();
                    Unit = "" + '\u03BC' + "F";
                    continue;
                }
                if (description[i].Contains("mF"))
                {
                    Value = description[i].Replace("mF", "").Trim();
                    Unit = "mF";
                    continue;
                }
                if (description[i].Contains('%'))
                {
                    Tolerance = description[i].Replace("%", "").Trim();
                    continue;
                }
                if (description[i].Contains("volts"))
                {
                    Volts = description[i].Replace("volts", "").Trim();
                    continue;
                }

                IsPackage(description[i]);
            }


        }

        private void Heatsinks(string value)
        {
            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameter in description)
            {
                if (parameter.Contains("@"))
                {
                    Power_Dissipation = parameter.Trim();
                    continue;
                }

                if (parameter.Contains("SO-") || parameter.Contains("SOT-") || parameter.Contains("TO-") ||
                    parameter.Contains("SOIC") || parameter.Contains("DPAK"))
                {
                    Package = parameter.Trim();
                    continue;
                }

                if (parameter.Contains("Bolt On") || parameter.Contains("Clip") || parameter.Contains("Press Fit") ||
                    parameter.Contains("Slide On") || parameter.Contains("PC Pin") || parameter.Contains("SMD Pad"))
                {
                    Attachment_Method = parameter.Trim();
                    continue;
                }

                if (parameter.Contains(" x "))
                {
                    string[] LengthWidthHeight = parameter.Split(new char[] { 'x', ';' }, StringSplitOptions.RemoveEmptyEntries);

                    Length = LengthWidthHeight[0].Trim();
                    Width = LengthWidthHeight[1].Trim();
                    Height = LengthWidthHeight[2].Trim();

                    continue;
                }





            }

        }

        private void Connectors(string value)
        {


        }

        private void CristalOscillators(string value)
        {


        }

        private void Transformers(string value)
        {


        }

        private void Inductors(string value)
        {
            Package = null;
            Unit = null;
            Value = null;
            Power = null;
            Tolerance = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < description.Length; i++)
            {
                description[i] = description[i].Trim();

                if (description[i].Contains("NH"))
                {
                    Unit = "" + '\u03A9';
                    if (description[i].Contains("K" + '\u03A9'))
                        Unit = "K" + '\u03A9';
                    if (description[i].Contains("M" + '\u03A9'))
                        Unit = "M" + '\u03A9';

                    Value = description[i].Replace(Unit, "").Trim();
                    continue;
                }

                if (IsTolerance(description[i]))
                    continue;

                if (IsPower(description[i]))
                    continue;

                if (IsPackage(description[i]))
                    continue;
            }

        }

        private void Speakers(string value)
        {
            Value = null;
            Power = null;
            Comment_about_it = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameter in description)
            {
                if (parameter.Contains("" + '\u03A9'))
                {
                    Value = parameter.Replace("" + '\u03A9', "").Trim();
                    continue;
                }
                if (parameter.Contains("watts"))
                {
                    Power = parameter.Replace("watts", "").Trim();
                    continue;
                }

                Comment_about_it = parameter.Trim();
                continue;
            }
        }

        private void Relays(string value)
        {
            Value = null;
            Power = null;
            Comment_about_it = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameter in description)
            {
                if (parameter.Contains("" + '\u03A9'))
                {
                    Value = parameter.Replace("" + '\u03A9', "").Trim();
                    continue;
                }
                if (parameter.Contains("watts"))
                {
                    Power = parameter.Replace("watts", "").Trim();
                    continue;
                }

                Comment_about_it = parameter.Trim();
                continue;
            }
        }

        private void Transistor(string value)
        {
            Vce = null;
            Ice = null;
            Type = null;
            Name = null;
            Package = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries |
                                                                        StringSplitOptions.TrimEntries);

            foreach (string parameter in description)
            {
                if (parameter.Contains("NPN") || parameter.Contains("PNP") || parameter.Contains("FET") || parameter.Contains("MOSFET"))
                {
                    Type = parameter.Trim();
                    continue;
                }
                if (parameter.Contains("volts"))
                {
                    Vce = parameter.Replace("volts", "").Trim();
                    continue;
                }
                if (parameter.Contains("amps"))
                {
                    Ice = parameter.Replace("amps", "").Trim();
                    continue;
                }
                if (parameter.Contains("SO-") || parameter.Contains("SOT") ||
                    parameter.Contains("TO-") || parameter.Contains("DPAK"))
                {
                    Package = parameter.Trim();
                    continue;
                }

                Name = parameter.Trim();
                continue;
            }


        }

        private void Diodes(string value)
        {
            If = null;
            Type = null;
            Vrms = null;
            Name = null;
            Package = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameter in description)
            {
                parameter.Trim();

                if (parameter.Contains("Signal") || parameter.Contains("Power") || parameter.Contains("Switching") || parameter.Contains("Zener")
                                            || parameter.Contains("Tunnel") || parameter.Contains("Schottky") || parameter.Contains("Suppressor"))
                {
                    Type = parameter.Trim();
                    continue;
                }
                if (parameter.Contains("volts"))
                {
                    Vrms = parameter.Replace("volts", "").Trim();
                    continue;
                }
                if (parameter.Contains("amps"))
                {
                    If = parameter.Replace("amps", "").Trim();
                    continue;
                }
                if (parameter.Contains("SO-") || parameter.Contains("SOT-") || parameter.Contains("SOT") || parameter.Contains("TO-") ||
                                                  parameter.Contains("TOP") || parameter.Contains("DPAK") || parameter.Contains("DO-") ||
                                                  parameter.Contains("DO") || parameter.Contains("KBL"))
                {
                    Package = parameter.Trim();
                    continue;
                }

                Name = parameter.Trim();
                continue;
            }


        }

        private void Leds(string value)
        {
            Vce = null;
            Ice = null;
            Type = null;
            Name = null;
            Package = null;

            // Divide all pairs (remove empty strings)
            string[] description = value.Split(new char[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string parameter in description)
            {
                if (parameter.Contains("Red") || parameter.Contains("Green") || parameter.Contains("Yellow") ||
                                                  parameter.Contains("Blue") || parameter.Contains("Amber") ||
                                               parameter.Contains("Bicolor") || parameter.Contains("Tricolor"))
                {
                    LedsColor = parameter.Trim();
                    continue;
                }
                if (parameter.Contains("volts"))
                {
                    Vrms = parameter.Replace("volts", "").Trim();
                    continue;
                }
                if (parameter.Contains("amps"))
                {
                    If = parameter.Replace("amps", "").Trim();
                    continue;
                }

                if (parameter.Contains("watts"))
                {
                    Power = parameter.Replace("watts", "").Trim();
                    continue;
                }

                if (parameter.Contains("0402") || parameter.Contains("0603") || parameter.Contains("0805") ||
                    parameter.Contains("1008") || parameter.Contains("1206") || parameter.Contains("1210") ||
                    parameter.Contains("1411") || parameter.Contains("1612") || parameter.Contains("1806") ||
                    parameter.Contains("1812") || parameter.Contains("1913") || parameter.Contains("2010") ||
                    parameter.Contains("2225") || parameter.Contains("2412") || parameter.Contains("2416") ||
                    parameter.Contains("2512") || parameter.Contains("2916") || parameter.Contains("3119") ||
                    parameter.Contains("3312") || parameter.Contains("Hole") || parameter.Contains("Through") ||
                      parameter.Contains("T1") || parameter.Contains("Round") || parameter.Contains("Display") ||
                      parameter.Contains("LCD Module"))
                {
                    Package = parameter;
                    continue;
                }

                Name = parameter.Trim();
                continue;
            }


        }

        private void Switches(string value)
        {


        }

        private void Plastic(string value)
        {


        }

        private void CoversSheetMetal(string value)
        {


        }

        private void Antenna(string value)
        {


        }

        private void Cables(string value)
        {


        }

        private void Hardware(string value)
        {


        }

        private void Labels(string value)
        {


        }

        private void ManualsWarrantyCard(string value)
        {


        }

        private void Packaging(string value)
        {


        }

        private void SchematicDiagrams(string value)
        {


        }

        private void PCB(string value)
        {


        }

        private void Assembled_210(string value)
        {


        }

        private void Assembled_510(string value)
        {


        }

        private void Assembled_AT(string value)
        {


        }

        private void Assembled_ATT(string value)
        {


        }



        readonly string[] PackageTokens =[
                                            // Chip sizes
                                            "0402","0603","0805","1008","1206","1210","1411","1612",
                                            "1806","1812","1913","2010","2225","2412","2416","2512",
                                            "2916","3119","3312","3516","3528","6032",

                                            // Through-hole
                                            "THole","Through",

                                            // Case sizes
                                            "A case","B case","C case","D case","E case","F case"
                                        ];



        /// <summary>
        /// Check if value is Package value, if is true
        /// Package value return the value, if is false
        /// Package = null;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsPackage(string value)
        {
            if (PackageTokens.Any(t => value.Contains(t, StringComparison.OrdinalIgnoreCase)))
            {
                Package = value;
                return true;
            }
            
            Package = "";
            return false;
        }

        /// <summary>
        ///  Check if value is Power value, if is true
        /// Power value return the value, if is false
        /// Power = null;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsPower(string value)
        {
            if (value.Contains("watts"))
            {
                Power = value.Replace("watts", "").Trim();
                return true;
            }

            Power = null;
            return false;
        }

        /// <summary>
        /// Check if value is Tolerance value, if is true
        /// Tolerance value return the value, if is false
        /// Tolerance = null;
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        private bool IsTolerance(string value)
        {
            if (value.Contains("%"))
            {
                Tolerance = value.Replace("%", "").Trim();
                return true;
            }

            Tolerance = null;
            return false;
        }

        public override string ToString()
        {
            string toReturn = "";

            toReturn += PartNumber + ":" + Places;

            return toReturn;
        }
    }
}