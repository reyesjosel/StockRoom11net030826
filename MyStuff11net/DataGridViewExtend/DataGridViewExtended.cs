using MyStuff11net.DataGridViewExtended;
using MyStuff11net.Properties;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Text.RegularExpressions;
using static MyStuff11net.DataGridViewExtend.BindingSourceGroups;
using static MyStuff11net.MyCode;
using CellClick_EventArgs = MyStuff11net.Custom_Events_Args.CellClick_EventArgs;
using CellDoubleClick_EventArgs = MyStuff11net.Custom_Events_Args.CellDoubleClick_EventArgs;
using CurrentRowActive_EventArgs = MyStuff11net.Custom_Events_Args.CurrentRowActive_EventArgs;
using CurrentRowMouseEnterEventArgs = MyStuff11net.Custom_Events_Args.RowsMouseEnterEventArgs;
using DataGridViewMouseDownEventArgs = MyStuff11net.Custom_Events_Args.DataGridViewMouseDownEventArgs;
using DataGridViewMouseEnterEventArgs = MyStuff11net.Custom_Events_Args.DataGridViewMouseEnterEventArgs;
using DataGridViewSort_EventArgs = MyStuff11net.Custom_Events_Args.DataGridViewSort_EventArgs;
using Get_String = MyStuff11net.MyCode;
using Need_SaveData_EventArgs = MyStuff11net.Custom_Events_Args.Need_SaveData_EventArgs;
using Refresh_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Refresh_Requested_EventArgs;
using Save_Requested_EventArgs = MyStuff11net.Custom_Events_Args.Save_Requested_EventArgs;
using SaveSettingEventArgs = MyStuff11net.Custom_Events_Args.SaveSettingEventArgs;
using StatusBarMessage_EventArgs = MyStuff11net.Custom_Events_Args.StatusBarMessage_EventArgs;
using Tags = MyStuff11net.HTML_Tags;

namespace MyStuff11net.DataGridViewExtend
{
    public partial class DataGridViewExtended : UserControl
    {
        #region"designer"

        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new Container();
            ComponentResourceManager resources = new ComponentResourceManager(typeof(DataGridViewExtended));
            _contextMenuStrip_DataGridView = new ContextMenuStrip(components);
            toolStripTextBox_SearchBy = new ToolStripTextBox();
            toolStripSeparatorSearchBy = new ToolStripSeparator();
            ToolStripMenuItem_GroupByThisColumn = new ToolStripMenuItem();
            ToolStripMenuItem_RemoveGroup = new ToolStripMenuItem();
            ToolStripMenuItem_CollapseAll = new ToolStripMenuItem();
            ToolStripMenuItem_ExpandAll = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            ToolStripMenuItem_FilterByThisCell = new ToolStripMenuItem();
            toolStripMenuItem_Custom_Filter = new ToolStripMenuItem();
            ToolStripMenuItem_RemoveThisFilter = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            ToolStripMenuItem_HideThisColumn = new ToolStripMenuItem();
            ToolStripMenuItem_FrozenUntilHere = new ToolStripMenuItem();
            ToolStripMenuItem_changeGraphics = new ToolStripMenuItem();
            toolStripMenuItem_BarGraphics = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_Columns = new ToolStripMenuItem();
            ToolStripMenuItem_Hide_all_to_tha_righ = new ToolStripMenuItem();
            toolStripMenuItem_Show_all_hide = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            ToolStripMenuItem_Select_by = new ToolStripMenuItem();
            toolStripMenuItem_editByColumn = new ToolStripMenuItem();
            toolStripMenuItem_Replace_by = new ToolStripMenuItem();
            toolStripMenuItem_Fill_by = new ToolStripMenuItem();
            ToolStripMenuItem_UnSelect_all_Rows = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            toolStripMenuItem_SortByPDF = new ToolStripMenuItem();
            ToolStripMenuItem_columnsMaintenance = new ToolStripMenuItem();
            ToolStripMenuItem_Alignment = new ToolStripMenuItem();
            leftToolStripMenuItem = new ToolStripMenuItem();
            centerToolStripMenuItem = new ToolStripMenuItem();
            rightToolStripMenuItem = new ToolStripMenuItem();
            ToolStripMenuItem_AutoSizeMode = new ToolStripMenuItem();
            ToolStripMenuItem_FillTheDisplay = new ToolStripMenuItem();
            ToolStripMenuItem_AllCells = new ToolStripMenuItem();
            ToolStripMenuItem_ColumnHeader = new ToolStripMenuItem();
            ToolStripMenuItem_DisplayedCells = new ToolStripMenuItem();
            ToolStripMenuItem_AllCellsExceptHeader = new ToolStripMenuItem();
            ToolStripMenuItem_DisplayedCellsExceptHeader = new ToolStripMenuItem();
            ToolStripMenuItem_None = new ToolStripMenuItem();
            ToolStripMenuItem_Maintenance = new ToolStripMenuItem();
            ToolStripMenuItem_Setting = new ToolStripMenuItem();
            ToolStripMenuItem_ClearColumns = new ToolStripMenuItem();
            ToolStripMenuItem_Tools = new ToolStripMenuItem();
            ToolStripMenuItem_Project_References = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripMenuItem_UnLocked = new ToolStripMenuItem();
            toolStripMenuItem_MarkWithNote = new ToolStripMenuItem();
            toolStripMenuItem_EditThisNote = new ToolStripMenuItem();
            toolStripMenuItem_RemoveThisNote = new ToolStripMenuItem();
            toolStripMenuItem_MarkToBeErase = new ToolStripMenuItem();
            ToolStripMenuItem_TheUserHaveNotRightToEdit = new ToolStripMenuItem();
            toolStripMenuItem_SearchBy = new ToolStripMenuItem();
            toolStripMenuItem_PrintCompLabel = new ToolStripMenuItem();
            _bindingNavigator = new BindingNavigator(components);
            _bindingSource = new BindingSource(components);
            bindingNavigatorCountItem = new ToolStripLabel();
            bindingNavigatorMoveFirstItem = new ToolStripButton();
            bindingNavigatorMovePreviousItem = new ToolStripButton();
            bindingNavigatorSeparator = new ToolStripSeparator();
            bindingNavigatorPositionItem = new ToolStripTextBox();
            bindingNavigatorSeparator1 = new ToolStripSeparator();
            bindingNavigatorMoveNextItem = new ToolStripButton();
            bindingNavigatorMoveLastItem = new ToolStripButton();
            bindingNavigatorSeparator2 = new ToolStripSeparator();
            bindingNavigatorAddNewItem = new ToolStripButton();
            bindingNavigatorDeleteItem = new ToolStripButton();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripLabel2 = new ToolStripLabel();
            toolStripButton_Save = new ToolStripButton();
            toolStripLabel8 = new ToolStripLabel();
            toolStripSeparator = new ToolStripSeparator();
            toolStripLabel7 = new ToolStripLabel();
            ToolStripButton_print = new ToolStripDropDownButton();
            toolStripMenuItem_ExportToExcel = new ToolStripMenuItem();
            toolStripMenuItemExportToCSV = new ToolStripMenuItem();
            toolStripMenuItemExportToTXT = new ToolStripMenuItem();
            toolStripMenuItemExportToWebPage = new ToolStripMenuItem();
            toolStripLabel1 = new ToolStripLabel();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripLabel3 = new ToolStripLabel();
            toolStripButton_Refresh = new ToolStripButton();
            toolStripLabel4 = new ToolStripLabel();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripLabel5 = new ToolStripLabel();
            toolStripLabel_Information_Label = new ToolStripLabel();
            toolStripLabel6 = new ToolStripLabel();
            toolStripLabel_Help = new ToolStripLabel();
            panel = new Panel();
            _dataGridView = new DataGridViewControlExtended();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            _contextMenuStrip_DataGridView.SuspendLayout();
            ((ISupportInitialize)_bindingNavigator).BeginInit();
            _bindingNavigator.SuspendLayout();
            ((ISupportInitialize)_bindingSource).BeginInit();
            panel.SuspendLayout();
            ((ISupportInitialize)_dataGridView).BeginInit();
            SuspendLayout();
            // 
            // _contextMenuStrip_DataGridView
            // 
            _contextMenuStrip_DataGridView.BackColor = Color.LightGoldenrodYellow;
            _contextMenuStrip_DataGridView.ImeMode = ImeMode.On;
            _contextMenuStrip_DataGridView.Items.AddRange(new ToolStripItem[] { toolStripTextBox_SearchBy, toolStripSeparatorSearchBy, ToolStripMenuItem_GroupByThisColumn, ToolStripMenuItem_RemoveGroup, ToolStripMenuItem_CollapseAll, ToolStripMenuItem_ExpandAll, toolStripSeparator1, ToolStripMenuItem_FilterByThisCell, toolStripMenuItem_Custom_Filter, ToolStripMenuItem_RemoveThisFilter, toolStripSeparator2, ToolStripMenuItem_HideThisColumn, ToolStripMenuItem_FrozenUntilHere, ToolStripMenuItem_changeGraphics, ToolStripMenuItem_Columns, toolStripSeparator3, ToolStripMenuItem_Select_by, toolStripMenuItem_editByColumn, ToolStripMenuItem_UnSelect_all_Rows, toolStripSeparator4, toolStripMenuItem_SortByPDF, ToolStripMenuItem_columnsMaintenance, ToolStripMenuItem_Maintenance, toolStripSeparator8, toolStripMenuItem_UnLocked, toolStripMenuItem_MarkWithNote, toolStripMenuItem_EditThisNote, toolStripMenuItem_RemoveThisNote, toolStripMenuItem_MarkToBeErase, ToolStripMenuItem_TheUserHaveNotRightToEdit, toolStripMenuItem_SearchBy, toolStripMenuItem_PrintCompLabel });
            _contextMenuStrip_DataGridView.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
            _contextMenuStrip_DataGridView.Name = "PreviewDataGridViewContextMenuStrip";
            _contextMenuStrip_DataGridView.RenderMode = ToolStripRenderMode.Professional;
            _contextMenuStrip_DataGridView.ShowImageMargin = false;
            _contextMenuStrip_DataGridView.Size = new Size(257, 708);
            _contextMenuStrip_DataGridView.Opening += ContextMenuStripDataGridViewOpening;
            // 
            // toolStripTextBox_SearchBy
            // 
            toolStripTextBox_SearchBy.AutoSize = false;
            toolStripTextBox_SearchBy.BackColor = Color.LightGoldenrodYellow;
            toolStripTextBox_SearchBy.BorderStyle = BorderStyle.None;
            toolStripTextBox_SearchBy.Font = new Font("Segoe UI", 9F);
            toolStripTextBox_SearchBy.Margin = new Padding(5, 1, 0, 1);
            toolStripTextBox_SearchBy.Name = "toolStripTextBox_SearchBy";
            toolStripTextBox_SearchBy.Size = new Size(170, 16);
            toolStripTextBox_SearchBy.Text = "Search by...";
            // 
            // toolStripSeparatorSearchBy
            // 
            toolStripSeparatorSearchBy.Name = "toolStripSeparatorSearchBy";
            toolStripSeparatorSearchBy.Size = new Size(253, 6);
            // 
            // ToolStripMenuItem_GroupByThisColumn
            // 
            ToolStripMenuItem_GroupByThisColumn.Name = "ToolStripMenuItem_GroupByThisColumn";
            ToolStripMenuItem_GroupByThisColumn.Size = new Size(256, 26);
            ToolStripMenuItem_GroupByThisColumn.Text = "Group by this Column";
            ToolStripMenuItem_GroupByThisColumn.Click += Tool_strip_menu_item_group_by_this_column_click;
            // 
            // ToolStripMenuItem_RemoveGroup
            // 
            ToolStripMenuItem_RemoveGroup.Name = "ToolStripMenuItem_RemoveGroup";
            ToolStripMenuItem_RemoveGroup.Size = new Size(256, 26);
            ToolStripMenuItem_RemoveGroup.Text = "Remove Grouping";
            ToolStripMenuItem_RemoveGroup.Click += Tool_strip_menu_item_remove_group_click;
            // 
            // ToolStripMenuItem_CollaseAll
            // 
            ToolStripMenuItem_CollapseAll.Name = "ToolStripMenuItem_CollaseAll";
            ToolStripMenuItem_CollapseAll.Size = new Size(256, 26);
            ToolStripMenuItem_CollapseAll.Text = "Collapse All";
            ToolStripMenuItem_CollapseAll.Click += Tool_strip_menu_item_collase_all_click;
            // 
            // ToolStripMenuItem_ExpandAll
            // 
            ToolStripMenuItem_ExpandAll.Name = "ToolStripMenuItem_ExpandAll";
            ToolStripMenuItem_ExpandAll.Size = new Size(256, 26);
            ToolStripMenuItem_ExpandAll.Text = "Expand All";
            ToolStripMenuItem_ExpandAll.Click += Tool_strip_menu_item_expand_all_click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(253, 6);
            // 
            // ToolStripMenuItem_FilterbythisCell
            // 
            ToolStripMenuItem_FilterByThisCell.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem_FilterByThisCell.Name = "ToolStripMenuItem_FilterbythisCell";
            ToolStripMenuItem_FilterByThisCell.Size = new Size(256, 26);
            ToolStripMenuItem_FilterByThisCell.Text = "Filter by this cell";
            ToolStripMenuItem_FilterByThisCell.Click += Tool_strip_menu_item_filterbythis_cell_click;
            // 
            // toolStripMenuItem_Custom_Filter
            // 
            toolStripMenuItem_Custom_Filter.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItem_Custom_Filter.Name = "toolStripMenuItem_Custom_Filter";
            toolStripMenuItem_Custom_Filter.Size = new Size(256, 26);
            toolStripMenuItem_Custom_Filter.Text = "Custom Filter";
            toolStripMenuItem_Custom_Filter.Click += Tool_strip_menu_item_custom_filter_click;
            // 
            // ToolStripMenuItem_RemovethisFilter
            // 
            ToolStripMenuItem_RemoveThisFilter.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem_RemoveThisFilter.Font = new Font("Segoe UI", 12F);
            ToolStripMenuItem_RemoveThisFilter.Name = "ToolStripMenuItem_RemovethisFilter";
            ToolStripMenuItem_RemoveThisFilter.Size = new Size(256, 26);
            ToolStripMenuItem_RemoveThisFilter.Tag = "False";
            ToolStripMenuItem_RemoveThisFilter.Text = "Remove this Filter";
            ToolStripMenuItem_RemoveThisFilter.Click += Tool_strip_menu_item_removethis_filter_click;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(253, 6);
            // 
            // ToolStripMenuItem_HidethisColumn
            // 
            ToolStripMenuItem_HideThisColumn.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_HideThisColumn.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem_HideThisColumn.Name = "ToolStripMenuItem_HidethisColumn";
            ToolStripMenuItem_HideThisColumn.Size = new Size(256, 26);
            ToolStripMenuItem_HideThisColumn.Text = "Hide this Column";
            ToolStripMenuItem_HideThisColumn.Click += Tool_strip_menu_item_hidethis_column_click;
            // 
            // ToolStripMenuItem_FrozenuntilHere
            // 
            ToolStripMenuItem_FrozenUntilHere.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem_FrozenUntilHere.Name = "ToolStripMenuItem_FrozenuntilHere";
            ToolStripMenuItem_FrozenUntilHere.Size = new Size(256, 26);
            ToolStripMenuItem_FrozenUntilHere.Text = "Frozen until here";
            ToolStripMenuItem_FrozenUntilHere.Click += Tool_strip_menu_item_frozenuntil_here_click;
            // 
            // ToolStripMenuItem_changeGraphics
            // 
            ToolStripMenuItem_changeGraphics.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_BarGraphics, testToolStripMenuItem });
            ToolStripMenuItem_changeGraphics.Name = "ToolStripMenuItem_changeGraphics";
            ToolStripMenuItem_changeGraphics.Size = new Size(256, 26);
            ToolStripMenuItem_changeGraphics.Text = "Change Graphics";
            // 
            // toolStripMenuItem_BarGraphics
            // 
            toolStripMenuItem_BarGraphics.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_BarGraphics.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItem_BarGraphics.Name = "toolStripMenuItem_BarGraphics";
            toolStripMenuItem_BarGraphics.Size = new Size(164, 26);
            toolStripMenuItem_BarGraphics.Text = "BarGraphics";
            toolStripMenuItem_BarGraphics.Click += ToolStripMenuItemBarGraphicsClick;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(164, 26);
            testToolStripMenuItem.Text = "test";
            testToolStripMenuItem.Click += TestToolStripMenuItemClick;
            // 
            // ToolStripMenuItem_Columns
            // 
            ToolStripMenuItem_Columns.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem_Columns.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_Hide_all_to_tha_righ, toolStripMenuItem_Show_all_hide });
            ToolStripMenuItem_Columns.ImageAlign = ContentAlignment.MiddleLeft;
            ToolStripMenuItem_Columns.Name = "ToolStripMenuItem_Columns";
            ToolStripMenuItem_Columns.Size = new Size(256, 26);
            ToolStripMenuItem_Columns.Text = "Columns";
            ToolStripMenuItem_Columns.DropDownItemClicked += Tool_strip_menu_item_columns_drop_down_item_clicked;
            // 
            // ToolStripMenuItem_Hide_all_to_tha_righ
            // 
            ToolStripMenuItem_Hide_all_to_tha_righ.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_Hide_all_to_tha_righ.BackgroundImageLayout = ImageLayout.None;
            ToolStripMenuItem_Hide_all_to_tha_righ.DisplayStyle = ToolStripItemDisplayStyle.Text;
            ToolStripMenuItem_Hide_all_to_tha_righ.ImageAlign = ContentAlignment.MiddleLeft;
            ToolStripMenuItem_Hide_all_to_tha_righ.ImageScaling = ToolStripItemImageScaling.None;
            ToolStripMenuItem_Hide_all_to_tha_righ.Name = "ToolStripMenuItem_Hide_all_to_tha_righ";
            ToolStripMenuItem_Hide_all_to_tha_righ.ShowShortcutKeys = false;
            ToolStripMenuItem_Hide_all_to_tha_righ.Size = new Size(203, 26);
            ToolStripMenuItem_Hide_all_to_tha_righ.Text = "Hide all to tha right";
            ToolStripMenuItem_Hide_all_to_tha_righ.TextAlign = ContentAlignment.MiddleLeft;
            ToolStripMenuItem_Hide_all_to_tha_righ.TextImageRelation = TextImageRelation.Overlay;
            ToolStripMenuItem_Hide_all_to_tha_righ.Click += Tool_strip_menu_item_hide_all_to_tha_righ_click;
            // 
            // toolStripMenuItem_Show_all_hide
            // 
            toolStripMenuItem_Show_all_hide.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_Show_all_hide.ImageAlign = ContentAlignment.MiddleLeft;
            toolStripMenuItem_Show_all_hide.Name = "toolStripMenuItem_Show_all_hide";
            toolStripMenuItem_Show_all_hide.Size = new Size(203, 26);
            toolStripMenuItem_Show_all_hide.Text = "Show all hided";
            toolStripMenuItem_Show_all_hide.TextAlign = ContentAlignment.MiddleLeft;
            toolStripMenuItem_Show_all_hide.Click += Tool_strip_menu_item_show_all_hide_click;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(253, 6);
            // 
            // ToolStripMenuItem_Select_by
            // 
            ToolStripMenuItem_Select_by.Image = (Image)resources.GetObject("ToolStripMenuItem_Select_by.Image");
            ToolStripMenuItem_Select_by.ImageTransparentColor = Color.White;
            ToolStripMenuItem_Select_by.Name = "ToolStripMenuItem_Select_by";
            ToolStripMenuItem_Select_by.Size = new Size(256, 26);
            ToolStripMenuItem_Select_by.Text = "Select by";
            ToolStripMenuItem_Select_by.Click += Tool_strip_menu_item_find_by_click;
            // 
            // toolStripMenuItem_editByColumn
            // 
            toolStripMenuItem_editByColumn.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_Replace_by, toolStripMenuItem_Fill_by });
            toolStripMenuItem_editByColumn.Name = "toolStripMenuItem_editByColumn";
            toolStripMenuItem_editByColumn.Size = new Size(256, 26);
            toolStripMenuItem_editByColumn.Text = "Edit by Column";
            // 
            // toolStripMenuItem_Replace_by
            // 
            toolStripMenuItem_Replace_by.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_Replace_by.Image = (Image)resources.GetObject("toolStripMenuItem_Replace_by.Image");
            toolStripMenuItem_Replace_by.ImageTransparentColor = Color.White;
            toolStripMenuItem_Replace_by.Name = "toolStripMenuItem_Replace_by";
            toolStripMenuItem_Replace_by.Size = new Size(155, 26);
            toolStripMenuItem_Replace_by.Text = "Replace by";
            // 
            // toolStripMenuItem_Fill_by
            // 
            toolStripMenuItem_Fill_by.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_Fill_by.Image = (Image)resources.GetObject("toolStripMenuItem_Fill_by.Image");
            toolStripMenuItem_Fill_by.ImageTransparentColor = Color.White;
            toolStripMenuItem_Fill_by.Name = "toolStripMenuItem_Fill_by";
            toolStripMenuItem_Fill_by.Size = new Size(155, 26);
            toolStripMenuItem_Fill_by.Text = "Fill by";
            // 
            // ToolStripMenuItem_UnSelect_all_Rows
            // 
            ToolStripMenuItem_UnSelect_all_Rows.Font = new Font("Segoe UI", 12F);
            ToolStripMenuItem_UnSelect_all_Rows.Name = "ToolStripMenuItem_UnSelect_all_Rows";
            ToolStripMenuItem_UnSelect_all_Rows.Size = new Size(256, 26);
            ToolStripMenuItem_UnSelect_all_Rows.Text = "UnSelect all Rows";
            ToolStripMenuItem_UnSelect_all_Rows.Click += Tool_strip_menu_item_un_select_all_rows_click;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(253, 6);
            // 
            // toolStripMenuItem_SortByPDF
            // 
            toolStripMenuItem_SortByPDF.Name = "toolStripMenuItem_SortByPDF";
            toolStripMenuItem_SortByPDF.Size = new Size(256, 26);
            toolStripMenuItem_SortByPDF.Text = "Sort by PDF";
            // 
            // ToolStripMenuItem_columnsMaintenance
            // 
            ToolStripMenuItem_columnsMaintenance.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_Alignment, ToolStripMenuItem_AutoSizeMode });
            ToolStripMenuItem_columnsMaintenance.Name = "ToolStripMenuItem_columnsMaintenance";
            ToolStripMenuItem_columnsMaintenance.Size = new Size(256, 26);
            ToolStripMenuItem_columnsMaintenance.Text = "Columns Setting";
            // 
            // ToolStripMenuItem_Alignment
            // 
            ToolStripMenuItem_Alignment.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_Alignment.DropDownItems.AddRange(new ToolStripItem[] { leftToolStripMenuItem, centerToolStripMenuItem, rightToolStripMenuItem });
            ToolStripMenuItem_Alignment.Name = "ToolStripMenuItem_Alignment";
            ToolStripMenuItem_Alignment.Size = new Size(185, 26);
            ToolStripMenuItem_Alignment.Text = "Alignment";
            ToolStripMenuItem_Alignment.DropDownItemClicked += ToolStripMenuItem_Alignment_DropDownItemClicked;
            // 
            // leftToolStripMenuItem
            // 
            leftToolStripMenuItem.BackColor = Color.LightGoldenrodYellow;
            leftToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            leftToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            leftToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            leftToolStripMenuItem.Name = "leftToolStripMenuItem";
            leftToolStripMenuItem.Size = new Size(196, 26);
            leftToolStripMenuItem.Text = "Left <--";
            leftToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            leftToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
            // 
            // centerToolStripMenuItem
            // 
            centerToolStripMenuItem.BackColor = Color.LightGoldenrodYellow;
            centerToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            centerToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            centerToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            centerToolStripMenuItem.Name = "centerToolStripMenuItem";
            centerToolStripMenuItem.Size = new Size(196, 26);
            centerToolStripMenuItem.Text = "  --> Center <--";
            centerToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            centerToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
            // 
            // rightToolStripMenuItem
            // 
            rightToolStripMenuItem.BackColor = Color.LightGoldenrodYellow;
            rightToolStripMenuItem.BackgroundImageLayout = ImageLayout.None;
            rightToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
            rightToolStripMenuItem.ImageAlign = ContentAlignment.MiddleLeft;
            rightToolStripMenuItem.Name = "rightToolStripMenuItem";
            rightToolStripMenuItem.Size = new Size(196, 26);
            rightToolStripMenuItem.Text = "             --> Right";
            rightToolStripMenuItem.TextAlign = ContentAlignment.MiddleLeft;
            rightToolStripMenuItem.TextImageRelation = TextImageRelation.Overlay;
            // 
            // ToolStripMenuItem_AutoSizeMode
            // 
            ToolStripMenuItem_AutoSizeMode.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_AutoSizeMode.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_FillTheDisplay, ToolStripMenuItem_AllCells, ToolStripMenuItem_ColumnHeader, ToolStripMenuItem_DisplayedCells, ToolStripMenuItem_AllCellsExceptHeader, ToolStripMenuItem_DisplayedCellsExceptHeader, ToolStripMenuItem_None });
            ToolStripMenuItem_AutoSizeMode.Name = "ToolStripMenuItem_AutoSizeMode";
            ToolStripMenuItem_AutoSizeMode.Size = new Size(185, 26);
            ToolStripMenuItem_AutoSizeMode.Text = "AutoSize Mode";
            ToolStripMenuItem_AutoSizeMode.DropDownItemClicked += ToolStripMenuItem_AutoSizeMode_DropDownItemClicked;
            // 
            // ToolStripMenuItem_FillTheDisplay
            // 
            ToolStripMenuItem_FillTheDisplay.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_FillTheDisplay.Name = "ToolStripMenuItem_FillTheDisplay";
            ToolStripMenuItem_FillTheDisplay.Size = new Size(287, 26);
            ToolStripMenuItem_FillTheDisplay.Text = "Fill the display";
            // 
            // ToolStripMenuItem_AllCells
            // 
            ToolStripMenuItem_AllCells.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_AllCells.Name = "ToolStripMenuItem_AllCells";
            ToolStripMenuItem_AllCells.Size = new Size(287, 26);
            ToolStripMenuItem_AllCells.Text = "All Cells";
            // 
            // ToolStripMenuItem_ColumnHeader
            // 
            ToolStripMenuItem_ColumnHeader.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_ColumnHeader.Name = "ToolStripMenuItem_ColumnHeader";
            ToolStripMenuItem_ColumnHeader.Size = new Size(287, 26);
            ToolStripMenuItem_ColumnHeader.Text = "Column Header";
            // 
            // ToolStripMenuItem_DisplayedCells
            // 
            ToolStripMenuItem_DisplayedCells.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_DisplayedCells.Name = "ToolStripMenuItem_DisplayedCells";
            ToolStripMenuItem_DisplayedCells.Size = new Size(287, 26);
            ToolStripMenuItem_DisplayedCells.Text = "Displayed Cells";
            // 
            // ToolStripMenuItem_AllCellsExceptHeader
            // 
            ToolStripMenuItem_AllCellsExceptHeader.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_AllCellsExceptHeader.Name = "ToolStripMenuItem_AllCellsExceptHeader";
            ToolStripMenuItem_AllCellsExceptHeader.Size = new Size(287, 26);
            ToolStripMenuItem_AllCellsExceptHeader.Text = "All Cells Except Header";
            // 
            // ToolStripMenuItem_DisplayedCellsExceptHeader
            // 
            ToolStripMenuItem_DisplayedCellsExceptHeader.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_DisplayedCellsExceptHeader.Name = "ToolStripMenuItem_DisplayedCellsExceptHeader";
            ToolStripMenuItem_DisplayedCellsExceptHeader.Size = new Size(287, 26);
            ToolStripMenuItem_DisplayedCellsExceptHeader.Text = "Displayed Cells Except Header";
            // 
            // ToolStripMenuItem_None
            // 
            ToolStripMenuItem_None.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_None.Name = "ToolStripMenuItem_None";
            ToolStripMenuItem_None.Size = new Size(287, 26);
            ToolStripMenuItem_None.Text = "None";
            // 
            // ToolStripMenuItem_Maintenance
            // 
            ToolStripMenuItem_Maintenance.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_Setting, ToolStripMenuItem_Tools });
            ToolStripMenuItem_Maintenance.Name = "ToolStripMenuItem_Maintenance";
            ToolStripMenuItem_Maintenance.Size = new Size(256, 26);
            ToolStripMenuItem_Maintenance.Text = "Maintenance";
            // 
            // ToolStripMenuItem_Setting
            // 
            ToolStripMenuItem_Setting.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_Setting.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_ClearColumns });
            ToolStripMenuItem_Setting.Name = "ToolStripMenuItem_Setting";
            ToolStripMenuItem_Setting.Size = new Size(129, 26);
            ToolStripMenuItem_Setting.Text = "Setting";
            ToolStripMenuItem_Setting.DropDownItemClicked += ToolStripMenuItem_Setting_DropDownItemClicked;
            // 
            // ToolStripMenuItem_ClearColumns
            // 
            ToolStripMenuItem_ClearColumns.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_ClearColumns.Name = "ToolStripMenuItem_ClearColumns";
            ToolStripMenuItem_ClearColumns.Size = new Size(182, 26);
            ToolStripMenuItem_ClearColumns.Text = "Clear Columns";
            ToolStripMenuItem_ClearColumns.ToolTipText = "Will clear all setting for this columns.";
            // 
            // ToolStripMenuItem_Tools
            // 
            ToolStripMenuItem_Tools.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_Tools.DropDownItems.AddRange(new ToolStripItem[] { ToolStripMenuItem_Project_References });
            ToolStripMenuItem_Tools.Name = "ToolStripMenuItem_Tools";
            ToolStripMenuItem_Tools.Size = new Size(129, 26);
            ToolStripMenuItem_Tools.Text = "Tools";
            // 
            // ToolStripMenuItem_Proyects_References
            // 
            ToolStripMenuItem_Project_References.BackColor = Color.LightGoldenrodYellow;
            ToolStripMenuItem_Project_References.Name = "ToolStripMenuItem_Proyects_References";
            ToolStripMenuItem_Project_References.Size = new Size(215, 26);
            ToolStripMenuItem_Project_References.Text = "Projects References";
            ToolStripMenuItem_Project_References.ToolTipText = "Open a dialog windows where can be fixed or add a references to any projects.";
            // 
            // toolStripSeparator8
            // 
            toolStripSeparator8.Name = "toolStripSeparator8";
            toolStripSeparator8.Size = new Size(253, 6);
            // 
            // toolStripMenuItem_UnLocked
            // 
            toolStripMenuItem_UnLocked.Name = "toolStripMenuItem_UnLocked";
            toolStripMenuItem_UnLocked.Size = new Size(256, 26);
            toolStripMenuItem_UnLocked.Text = "UnLock";
            // 
            // toolStripMenuItem_MarkWithNote
            // 
            toolStripMenuItem_MarkWithNote.Name = "toolStripMenuItem_MarkWithNote";
            toolStripMenuItem_MarkWithNote.Size = new Size(256, 26);
            toolStripMenuItem_MarkWithNote.Text = "Mark with Note";
            // 
            // toolStripMenuItem_EditThisNote
            // 
            toolStripMenuItem_EditThisNote.Name = "toolStripMenuItem_EditThisNote";
            toolStripMenuItem_EditThisNote.Size = new Size(256, 26);
            toolStripMenuItem_EditThisNote.Text = "Edit this Note";
            // 
            // toolStripMenuItem_RemoveThisNote
            // 
            toolStripMenuItem_RemoveThisNote.Name = "toolStripMenuItem_RemoveThisNote";
            toolStripMenuItem_RemoveThisNote.Size = new Size(256, 26);
            toolStripMenuItem_RemoveThisNote.Text = "Remove this Note";
            // 
            // toolStripMenuItem_MarkToBeErase
            // 
            toolStripMenuItem_MarkToBeErase.Name = "toolStripMenuItem_MarkToBeErase";
            toolStripMenuItem_MarkToBeErase.Size = new Size(256, 26);
            toolStripMenuItem_MarkToBeErase.Text = "Mark to be Erase";
            // 
            // ToolStripMenuItem_TheUserHaveNotRightToEdit
            // 
            ToolStripMenuItem_TheUserHaveNotRightToEdit.Name = "ToolStripMenuItem_TheUserHaveNotRightToEdit";
            ToolStripMenuItem_TheUserHaveNotRightToEdit.Size = new Size(256, 26);
            ToolStripMenuItem_TheUserHaveNotRightToEdit.Text = "The user has no rights to Edit";
            // 
            // toolStripMenuItem_SearchBy
            // 
            toolStripMenuItem_SearchBy.Name = "toolStripMenuItem_SearchBy";
            toolStripMenuItem_SearchBy.Size = new Size(256, 26);
            toolStripMenuItem_SearchBy.Text = "Search by ...";
            // 
            // toolStripMenuItem_PrintCompLabel
            // 
            toolStripMenuItem_PrintCompLabel.Name = "toolStripMenuItem_PrintCompLabel";
            toolStripMenuItem_PrintCompLabel.Size = new Size(256, 26);
            toolStripMenuItem_PrintCompLabel.Text = "Print Comp Label";
            // 
            // _bindingNavigator
            // 
            _bindingNavigator.AddNewItem = null;
            _bindingNavigator.BindingSource = _bindingSource;
            _bindingNavigator.CountItem = bindingNavigatorCountItem;
            _bindingNavigator.DeleteItem = null;
            _bindingNavigator.ImageScalingSize = new Size(18, 18);
            _bindingNavigator.Items.AddRange(new ToolStripItem[] { bindingNavigatorMoveFirstItem, bindingNavigatorMovePreviousItem, bindingNavigatorSeparator, bindingNavigatorPositionItem, bindingNavigatorCountItem, bindingNavigatorSeparator1, bindingNavigatorMoveNextItem, bindingNavigatorMoveLastItem, bindingNavigatorSeparator2, bindingNavigatorAddNewItem, bindingNavigatorDeleteItem, toolStripSeparator7, toolStripLabel2, toolStripButton_Save, toolStripLabel8, toolStripSeparator, toolStripLabel7, ToolStripButton_print, toolStripLabel1, toolStripSeparator5, toolStripLabel3, toolStripButton_Refresh, toolStripLabel4, toolStripSeparator6, toolStripLabel5, toolStripLabel_Information_Label, toolStripLabel6, toolStripLabel_Help });
            _bindingNavigator.Location = new Point(0, 0);
            _bindingNavigator.MoveFirstItem = bindingNavigatorMoveFirstItem;
            _bindingNavigator.MoveLastItem = bindingNavigatorMoveLastItem;
            _bindingNavigator.MoveNextItem = bindingNavigatorMoveNextItem;
            _bindingNavigator.MovePreviousItem = bindingNavigatorMovePreviousItem;
            _bindingNavigator.Name = "_bindingNavigator";
            _bindingNavigator.Padding = new Padding(0, 0, 2, 0);
            _bindingNavigator.PositionItem = bindingNavigatorPositionItem;
            _bindingNavigator.Size = new Size(1365, 28);
            _bindingNavigator.TabIndex = 1;
            _bindingNavigator.Text = "bindingNavigator";
            // 
            // bindingNavigatorCountItem
            // 
            bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            bindingNavigatorCountItem.Size = new Size(47, 25);
            bindingNavigatorCountItem.Text = "of {0}";
            bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            bindingNavigatorMoveFirstItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveFirstItem.Image = (Image)resources.GetObject("bindingNavigatorMoveFirstItem.Image");
            bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveFirstItem.Size = new Size(23, 25);
            bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            bindingNavigatorMovePreviousItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMovePreviousItem.Image = (Image)resources.GetObject("bindingNavigatorMovePreviousItem.Image");
            bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMovePreviousItem.Size = new Size(23, 25);
            bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            bindingNavigatorSeparator.Size = new Size(6, 28);
            // 
            // bindingNavigatorPositionItem
            // 
            bindingNavigatorPositionItem.AccessibleName = "Position";
            bindingNavigatorPositionItem.AutoSize = false;
            bindingNavigatorPositionItem.Font = new Font("Segoe UI", 9F);
            bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            bindingNavigatorPositionItem.Size = new Size(73, 23);
            bindingNavigatorPositionItem.Text = "0";
            bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            bindingNavigatorSeparator1.Size = new Size(6, 28);
            // 
            // bindingNavigatorMoveNextItem
            // 
            bindingNavigatorMoveNextItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveNextItem.Image = (Image)resources.GetObject("bindingNavigatorMoveNextItem.Image");
            bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveNextItem.Size = new Size(23, 25);
            bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            bindingNavigatorMoveLastItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorMoveLastItem.Image = (Image)resources.GetObject("bindingNavigatorMoveLastItem.Image");
            bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorMoveLastItem.Size = new Size(23, 25);
            bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            bindingNavigatorSeparator2.Size = new Size(6, 28);
            // 
            // bindingNavigatorAddNewItem
            // 
            bindingNavigatorAddNewItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorAddNewItem.Image = (Image)resources.GetObject("bindingNavigatorAddNewItem.Image");
            bindingNavigatorAddNewItem.MergeAction = MergeAction.MatchOnly;
            bindingNavigatorAddNewItem.MergeIndex = 1;
            bindingNavigatorAddNewItem.Name = "bindingNavigatorAddNewItem";
            bindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorAddNewItem.Size = new Size(23, 25);
            bindingNavigatorAddNewItem.Text = "Add new";
            bindingNavigatorAddNewItem.Click += BindingNavigatorAddNewItemClick;
            // 
            // bindingNavigatorDeleteItem
            // 
            bindingNavigatorDeleteItem.DisplayStyle = ToolStripItemDisplayStyle.Image;
            bindingNavigatorDeleteItem.Image = (Image)resources.GetObject("bindingNavigatorDeleteItem.Image");
            bindingNavigatorDeleteItem.MergeAction = MergeAction.Remove;
            bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            bindingNavigatorDeleteItem.Size = new Size(23, 25);
            bindingNavigatorDeleteItem.Text = "Delete";
            bindingNavigatorDeleteItem.Click += BindingNavigatorDeleteItemClick;
            bindingNavigatorDeleteItem.MouseDown += BindingNavigatorDeleteItemMouseDown;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 28);
            // 
            // toolStripLabel2
            // 
            toolStripLabel2.Name = "toolStripLabel2";
            toolStripLabel2.Size = new Size(30, 25);
            toolStripLabel2.Text = "     ";
            // 
            // toolStripButton_Save
            // 
            toolStripButton_Save.DisplayStyle = ToolStripItemDisplayStyle.Image;
            toolStripButton_Save.Image = (Image)resources.GetObject("toolStripButton_Save.Image");
            toolStripButton_Save.ImageTransparentColor = Color.Magenta;
            toolStripButton_Save.Name = "toolStripButton_Save";
            toolStripButton_Save.Size = new Size(23, 25);
            toolStripButton_Save.Text = "&Save";
            toolStripButton_Save.Click += ToolStripButtonSaveClick;
            // 
            // toolStripLabel8
            // 
            toolStripLabel8.Name = "toolStripLabel8";
            toolStripLabel8.Size = new Size(30, 25);
            toolStripLabel8.Text = "     ";
            // 
            // toolStripSeparator
            // 
            toolStripSeparator.Name = "toolStripSeparator";
            toolStripSeparator.Size = new Size(6, 28);
            // 
            // toolStripLabel7
            // 
            toolStripLabel7.Name = "toolStripLabel7";
            toolStripLabel7.Size = new Size(30, 25);
            toolStripLabel7.Text = "     ";
            // 
            // ToolStripButton_print
            // 
            ToolStripButton_print.DisplayStyle = ToolStripItemDisplayStyle.Image;
            ToolStripButton_print.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem_ExportToExcel, toolStripMenuItemExportToCSV, toolStripMenuItemExportToTXT, toolStripMenuItemExportToWebPage });
            ToolStripButton_print.Image = (Image)resources.GetObject("ToolStripButton_print.Image");
            ToolStripButton_print.ImageTransparentColor = Color.Magenta;
            ToolStripButton_print.Name = "ToolStripButton_print";
            ToolStripButton_print.Size = new Size(31, 25);
            ToolStripButton_print.Text = "&Print";
            ToolStripButton_print.Click += ToolStripButtonPrintClick;
            // 
            // toolStripMenuItem_ExportToExcell
            // 
            toolStripMenuItem_ExportToExcel.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItem_ExportToExcel.BackgroundImageLayout = ImageLayout.None;
            toolStripMenuItem_ExportToExcel.Image = Properties.Resources.goldstar3;
            toolStripMenuItem_ExportToExcel.Name = "toolStripMenuItem_ExportToExcell";
            toolStripMenuItem_ExportToExcel.Size = new Size(223, 26);
            toolStripMenuItem_ExportToExcel.Text = "Export to Excel ...";
            toolStripMenuItem_ExportToExcel.TextAlign = ContentAlignment.MiddleLeft;
            toolStripMenuItem_ExportToExcel.TextImageRelation = TextImageRelation.Overlay;
            toolStripMenuItem_ExportToExcel.Click += ToolStripMenuItemExportToExcellClick;
            // 
            // toolStripMenuItemExportToCSV
            // 
            toolStripMenuItemExportToCSV.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItemExportToCSV.Image = Properties.Resources.Document_CSV;
            toolStripMenuItemExportToCSV.Name = "toolStripMenuItemExportToCSV";
            toolStripMenuItemExportToCSV.Size = new Size(223, 26);
            toolStripMenuItemExportToCSV.Text = "Export to CSV ...";
            // 
            // toolStripMenuItemExportToTXT
            // 
            toolStripMenuItemExportToTXT.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItemExportToTXT.Image = Properties.Resources.Document_TXT;
            toolStripMenuItemExportToTXT.Name = "toolStripMenuItemExportToTXT";
            toolStripMenuItemExportToTXT.Size = new Size(223, 26);
            toolStripMenuItemExportToTXT.Text = "Export to TXT ...";
            // 
            // toolStripMenuItemExportToWebPage
            // 
            toolStripMenuItemExportToWebPage.BackColor = Color.LightGoldenrodYellow;
            toolStripMenuItemExportToWebPage.Image = (Image)resources.GetObject("toolStripMenuItemExportToWebPage.Image");
            toolStripMenuItemExportToWebPage.Name = "toolStripMenuItemExportToWebPage";
            toolStripMenuItemExportToWebPage.Size = new Size(223, 26);
            toolStripMenuItemExportToWebPage.Text = "Export to WebPage ...";
            // 
            // toolStripLabel1
            // 
            toolStripLabel1.Name = "toolStripLabel1";
            toolStripLabel1.Size = new Size(30, 25);
            toolStripLabel1.Text = "     ";
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 28);
            // 
            // toolStripLabel3
            // 
            toolStripLabel3.Name = "toolStripLabel3";
            toolStripLabel3.Size = new Size(30, 25);
            toolStripLabel3.Text = "     ";
            // 
            // toolStripButton_Refresh
            // 
            toolStripButton_Refresh.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButton_Refresh.Font = new Font("Segoe UI", 12F);
            toolStripButton_Refresh.Image = (Image)resources.GetObject("toolStripButton_Refresh.Image");
            toolStripButton_Refresh.ImageTransparentColor = Color.Magenta;
            toolStripButton_Refresh.Name = "toolStripButton_Refresh";
            toolStripButton_Refresh.Size = new Size(67, 25);
            toolStripButton_Refresh.Text = "Refresh";
            toolStripButton_Refresh.Click += ToolStripButtonRefreshClick;
            // 
            // toolStripLabel4
            // 
            toolStripLabel4.Name = "toolStripLabel4";
            toolStripLabel4.Size = new Size(30, 25);
            toolStripLabel4.Text = "     ";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 28);
            // 
            // toolStripLabel5
            // 
            toolStripLabel5.Name = "toolStripLabel5";
            toolStripLabel5.Size = new Size(30, 25);
            toolStripLabel5.Text = "     ";
            // 
            // toolStripLabel_Information_Label
            // 
            toolStripLabel_Information_Label.Font = new Font("Segoe UI", 12F);
            toolStripLabel_Information_Label.Name = "toolStripLabel_Information_Label";
            toolStripLabel_Information_Label.Size = new Size(136, 25);
            toolStripLabel_Information_Label.Text = "Information Label.";
            // 
            // toolStripLabel6
            // 
            toolStripLabel6.Name = "toolStripLabel6";
            toolStripLabel6.Size = new Size(18, 25);
            toolStripLabel6.Text = "  ";
            // 
            // toolStripLabel_Help
            // 
            toolStripLabel_Help.Name = "toolStripLabel_Help";
            toolStripLabel_Help.Size = new Size(291, 25);
            toolStripLabel_Help.Text = "Help to remove selected or filtering data.";
            // 
            // panel
            // 
            panel.Controls.Add(_dataGridView);
            panel.Controls.Add(_bindingNavigator);
            panel.Dock = DockStyle.Fill;
            panel.Location = new Point(0, 0);
            panel.Margin = new Padding(0);
            panel.Name = "panel";
            panel.Size = new Size(1365, 788);
            panel.TabIndex = 3;
            // 
            // _dataGridView
            // 
            _dataGridView.ActiveFilter = "";
            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.AllowUserToDeleteRows = false;
            _dataGridView.AllowUserToOrderColumns = true;
            _dataGridView.AllowUserToResizeRows = false;
            _dataGridView.BorderStyle = BorderStyle.None;
            _dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            _dataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            _dataGridView.ColumnHeadersHeight = 30;
            _dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            _dataGridView.ContextMenuStrip = _contextMenuStrip_DataGridView;
            _dataGridView.CurrentColumnActive = null;
            _dataGridView.CurrentDataGridViewRowMouseEnter = null;
            _dataGridView.CurrentDataRowviewMouseEnter = null;
            _dataGridView.CurrentRowBackgroundColor = Color.DeepSkyBlue;
            _dataGridView.CurrentRowBorderColor = Color.DarkBlue;
            _dataGridView.CurrentRowMouseEnterStatus = null;
            _dataGridView.DividerColor = Color.Red;
            _dataGridView.DividerHeight = 0;
            _dataGridView.Dock = DockStyle.Fill;
            _dataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            _dataGridView.LastColumnActive = null;
            _dataGridView.Location = new Point(0, 28);
            _dataGridView.Margin = new Padding(4, 5, 4, 5);
            _dataGridView.Name = "_dataGridView";
            _dataGridView.RowHeadersWidth = 30;
            _dataGridView.SelectionBorderWidth = 3;
            _dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            _dataGridView.ShowCellToolTips = false;
            _dataGridView.Size = new Size(1365, 760);
            _dataGridView.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "PartNumber";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // DataGridViewExtended
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "DataGridViewExtended";
            Size = new Size(1365, 788);
            _contextMenuStrip_DataGridView.ResumeLayout(false);
            _contextMenuStrip_DataGridView.PerformLayout();
            ((ISupportInitialize)_bindingNavigator).EndInit();
            _bindingNavigator.ResumeLayout(false);
            _bindingNavigator.PerformLayout();
            ((ISupportInitialize)_bindingSource).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ((ISupportInitialize)_dataGridView).EndInit();
            ResumeLayout(false);
        }

        #endregion

        #region"Components"

        private ContextMenuStrip _contextMenuStrip_DataGridView;
        private ToolStripMenuItem ToolStripMenuItem_GroupByThisColumn;
        private ToolStripMenuItem ToolStripMenuItem_RemoveGroup;
        private ToolStripMenuItem ToolStripMenuItem_CollapseAll;
        private ToolStripMenuItem ToolStripMenuItem_ExpandAll;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem ToolStripMenuItem_FilterByThisCell;
        private ToolStripMenuItem ToolStripMenuItem_RemoveThisFilter;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem ToolStripMenuItem_HideThisColumn;
        private ToolStripMenuItem ToolStripMenuItem_FrozenUntilHere;
        private ToolStripMenuItem ToolStripMenuItem_Columns;
        private ToolStripMenuItem ToolStripMenuItem_Hide_all_to_tha_righ;
        private ToolStripMenuItem toolStripMenuItem_Show_all_hide;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem ToolStripMenuItem_Select_by;
        private ToolStripMenuItem ToolStripMenuItem_UnSelect_all_Rows;
        private BindingNavigator _bindingNavigator;
        private ToolStripLabel bindingNavigatorCountItem;
        private ToolStripButton bindingNavigatorMoveFirstItem;
        private ToolStripButton bindingNavigatorMovePreviousItem;
        private ToolStripSeparator bindingNavigatorSeparator;
        private ToolStripTextBox bindingNavigatorPositionItem;
        private ToolStripSeparator bindingNavigatorSeparator1;
        private ToolStripButton bindingNavigatorMoveNextItem;
        private ToolStripButton bindingNavigatorMoveLastItem;
        private ToolStripSeparator bindingNavigatorSeparator2;
        private ToolStripMenuItem ToolStripMenuItem_Maintenance;

        private ToolStripButton toolStripButton_Save;
        private ToolStripButton toolStripButton_Refresh;
        private ToolStripLabel toolStripLabel2;
        private ToolStripLabel toolStripLabel1;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripLabel toolStripLabel3;
        private ToolStripLabel toolStripLabel4;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripMenuItem ToolStripMenuItem_changeGraphics;
        private ToolStripMenuItem toolStripMenuItem_BarGraphics;
        private ToolStripMenuItem testToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem_Custom_Filter;
        private ToolStripLabel toolStripLabel5;
        private ToolStripLabel toolStripLabel_Information_Label;
        private ToolStripLabel toolStripLabel_Help;
        private ToolStripLabel toolStripLabel6;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripButton bindingNavigatorAddNewItem;
        private ToolStripButton bindingNavigatorDeleteItem;
        private ToolStripSeparator toolStripSeparator7;
        private BindingSource _bindingSource;
        private ToolStripLabel toolStripLabel8;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripLabel toolStripLabel7;
        private ToolStripDropDownButton ToolStripButton_print;
        private ToolStripMenuItem toolStripMenuItem_ExportToExcel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private ToolStripMenuItem ToolStripMenuItem_columnsMaintenance;
        private ToolStripMenuItem ToolStripMenuItem_AutoSizeMode;
        private ToolStripMenuItem ToolStripMenuItem_FillTheDisplay;
        private ToolStripMenuItem ToolStripMenuItem_AllCells;
        private ToolStripMenuItem ToolStripMenuItem_ColumnHeader;
        private ToolStripMenuItem ToolStripMenuItem_DisplayedCells;
        private ToolStripMenuItem ToolStripMenuItem_AllCellsExceptHeader;
        private ToolStripMenuItem ToolStripMenuItem_DisplayedCellsExceptHeader;
        private ToolStripMenuItem ToolStripMenuItem_None;
        private ToolStripMenuItem ToolStripMenuItem_Setting;
        private ToolStripMenuItem ToolStripMenuItem_ClearColumns;
        private ToolStripMenuItem ToolStripMenuItem_Alignment;
        private ToolStripMenuItem leftToolStripMenuItem;
        private ToolStripMenuItem centerToolStripMenuItem;
        private ToolStripMenuItem rightToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemExportToCSV;
        private ToolStripMenuItem toolStripMenuItemExportToWebPage;
        private ToolStripMenuItem ToolStripMenuItem_Tools;
        private ToolStripMenuItem ToolStripMenuItem_Project_References;
        private Panel panel;
        private ToolStripMenuItem toolStripMenuItemExportToTXT;
        private ToolStripSeparator toolStripSeparatorSearchBy;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem toolStripMenuItem_UnLocked;
        private ToolStripMenuItem toolStripMenuItem_MarkToBeErase;
        private ToolStripMenuItem ToolStripMenuItem_TheUserHaveNotRightToEdit;
        private ToolStripMenuItem toolStripMenuItem_MarkWithNote;
        public DataGridViewControlExtended _dataGridView;
        private ToolStripMenuItem toolStripMenuItem_EditThisNote;
        private ToolStripMenuItem toolStripMenuItem_RemoveThisNote;
        private ToolStripMenuItem toolStripMenuItem_editByColumn;
        private ToolStripMenuItem toolStripMenuItem_Replace_by;
        private ToolStripMenuItem toolStripMenuItem_Fill_by;
        private ToolStripTextBox toolStripTextBox_SearchBy;
        private ToolStripMenuItem toolStripMenuItem_SearchBy;
        private ToolStripMenuItem toolStripMenuItem_SortByPDF;
        private ToolStripMenuItem toolStripMenuItem_PrintCompLabel;

        #endregion"Components"

        #endregion"designer"

        private readonly System.Windows.Forms.Timer initialDelay;

        /// <summary>
        /// The user setting name, we save control.Name + _dataGridView.DataMember.
        /// We saved the datasource name because in some cases,
        /// the same dataGridView manipulates different dataSources.
        /// </summary>
        private string userSettingName = "";

        bool _isMouseDrivenEvent;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Keep track if the event was trigger by mouse or by code.
        public bool IsMouseDrivenEvent
        {
            get
            {
                return _isMouseDrivenEvent;
            }
            set
            {
                _isMouseDrivenEvent = value;
            }
        }

        public static class ExtendedWindowStyles
        {

            public static readonly int

            WS_EX_ACCEPTFILES = 0x00000010,

            WS_EX_APPWINDOW = 0x00040000,

            WS_EX_CLIENTEDGE = 0x00000200,

            WS_EX_COMPOSITED = 0x02000000,

            WS_EX_CONTEXTHELP = 0x00000400,

            WS_EX_CONTROLPARENT = 0x00010000,

            WS_EX_DLGMODALFRAME = 0x00000001,

            WS_EX_LAYERED = 0x00080000,

            WS_EX_LAYOUTRTL = 0x00400000,

            WS_EX_LEFT = 0x00000000,

            WS_EX_LEFTSCROLLBAR = 0x00004000,

            WS_EX_LTRREADING = 0x00000000,

            WS_EX_MDICHILD = 0x00000040,

            WS_EX_NOACTIVATE = 0x08000000,

            WS_EX_NOINHERITLAYOUT = 0x00100000,

            WS_EX_NOPARENTNOTIFY = 0x00000004,

            WS_EX_OVERLAPPEDWINDOW = WS_EX_WINDOWEDGE | WS_EX_CLIENTEDGE,

            WS_EX_PALETTEWINDOW = WS_EX_WINDOWEDGE | WS_EX_TOOLWINDOW | WS_EX_TOPMOST,

            WS_EX_RIGHT = 0x00001000,

            WS_EX_RIGHTSCROLLBAR = 0x00000000,

            WS_EX_RTLREADING = 0x00002000,

            WS_EX_STATICEDGE = 0x00020000,

            WS_EX_TOOLWINDOW = 0x00000080,

            WS_EX_TOPMOST = 0x00000008,

            WS_EX_TRANSPARENT = 0x00000020,

            WS_EX_WINDOWEDGE = 0x00000100;

        }

        #region"Properties"

        /// <summary>
        /// Message to debug the code. 
        /// </summary>
        public string MessagePositionString;


        /// <summary>
        ///  Name of control parent, name;
        /// </summary>
        string _controlName;

        /// <summary>
        /// Keep tracking of current Row Index into _bindingsource.
        /// </summary>
        int _rowIndexBindingSource;


        /// <summary>
        /// Gets a value indicating whether the currently active cell is being edited.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Gets a value indicating whether the currently active cell is being edited.
        /// </summary>
        public bool IsCurrentCellInEditMode
        {
            get
            {
                return _dataGridView.IsCurrentCellInEditMode;
            }

            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridViewColumn CurrentColumnActive
        {
            get
            {
                return _dataGridView.CurrentColumnActive;
            }
            set
            {
                _dataGridView.CurrentColumnActive = value;
            }
        }

        /// <summary>
        /// Current row active ( DataGridViewRow ).
        /// return DataGridView.CurrentRow if it's not null,
        /// if it's null return a new DataGridViewRow().
        /// </summary>
        public DataGridViewRow CurrentRowActive
        {
            get
            {
                if (_dataGridView.CurrentRowActived.DataBoundItem != null && _dataGridView.CurrentRowActived.DataBoundItem.GetType() == typeof(GroupRow))
                {
                    GroupRow? groupRow = _dataGridView.CurrentRowActived.DataBoundItem as GroupRow;
                    if (groupRow != null)
                        return _dataGridView.Rows[groupRow.Index];
                }

                return _dataGridView.CurrentRowActived;
            }
        }

        /// <summary>
        /// Current row ( DataGridViewRow ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Current row ( DataGridViewRow ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        public DataGridViewRow CurrentDataGridViewRowMouseOver
        {
            get
            {
                return _dataGridView.CurrentDataGridViewRowMouseEnter;
            }

            set { }
        }

        /// <summary>
        /// Current row ( DataRowView ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Current row ( DataRowView ) where mouse is over, it's update in CellMouseEnter.
        /// The DataGridView have not RowMouseEnter, so we use CellMouseEnter.
        /// Mouse over column header this will be null.
        /// </summary>
        public DataRowView CurrentDataRowViewMouseOver
        {
            get
            {
                return _dataGridView.CurrentDataRowviewMouseEnter;
            }

            set { }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool DataGridViewDrawDoubleBuffering { get; set; }

        public bool AreSelectedRows
        {
            get
            {
                return _dataGridView.AreSelectedRows;
            }

        }

        /// <summary>
        /// Active filter, generated by "Find and Replace" dialog.
        /// or Search By... dialog
        /// </summary>
        string ActiveFilter
        {
            get
            {
                return _dataGridView.ActiveFilter;
            }
            set
            {
                if (value == null)
                    return;

                _dataGridView.ActiveFilter = value;

                UpDateActiveFilter();
            }
        }

        List<ColumnSetting> _settingColumns = new List<ColumnSetting>();
        /// <summary>
        /// List of column properties to process.
        /// </summary>
        /// 
        //  BrowsableAttribute only determines whether the property shows up in the property grid.
        //  To prevent the property from being serialized at all, use the DesignerSerializationVisibilityAttribute:
        //Second, if you want the property to be serialized, but only when the user has actually changed the value, use the DefaultValueAttribute:
        [Browsable(false),
         DefaultValue(false),
         DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public List<ColumnSetting> SettingColumns
        {
            get
            {
                return _settingColumns;
            }
            set
            {
                if (value == null)
                    return;

                _settingColumns = value;

                if (_dataGridView.Columns.Count == 0 || _settingColumns.Count == 0)
                {
                    InitializeThreadTimer();
                    return;
                }

                Font Editable = new Font(_dataGridView.Font, FontStyle.Regular);

                Font NoEdit = new Font(_dataGridView.Font, FontStyle.Italic);
                var columnsList = _settingColumns.OrderBy(i => i.DisplayIndex);

                _dataGridView.SuspendLayout();

                ToolStripMenuItem_Columns.DropDownItems.Clear();
                ToolStripMenuItem_Columns.DropDownItems.Add(ToolStripMenuItem_Hide_all_to_tha_righ);

                foreach (var column in columnsList)
                {
                    if (!_dataGridView.Columns.Contains(column.Name))
                        continue;

                    #region"Column Visible"                        

                    if (!column.VisibleSystemSetting)

                    {
                        _dataGridView.Columns[column.Name].Visible = false;
                        continue;
                    }
                    else
                    {
                        if (column.Visible)
                            _dataGridView.Columns[column.Name].Visible = true;
                        else
                        {
                            if (!ToolStripMenuItem_Columns.DropDownItems.Contains(toolStripMenuItem_Show_all_hide))
                                ToolStripMenuItem_Columns.DropDownItems.Add(toolStripMenuItem_Show_all_hide);

                            HideThisColumn(_dataGridView.Columns[column.Name]);
                        }
                    }

                    #endregion"Column Visible"

                    #region"Column Width"

                    if (column.onlyShow)
                        continue;

                    if (column.DisplayIndex < _dataGridView.Columns.Count)
                        _dataGridView.Columns[column.Name].DisplayIndex = column.DisplayIndex;
                    if (column.Name.Contains("RowHeaderColumn"))
                        _dataGridView.RowHeadersWidth = column.Width;
                    else
                        _dataGridView.Columns[column.Name].Width = column.Width;

                    #endregion"Column Width"

                    #region"Column Edit"

                    DataGridViewCellStyle style = _dataGridView.Columns[column.Name].HeaderCell.Style;

                    if (column.Edit)
                    {
                        _dataGridView.Columns[column.Name].ReadOnly = false;
                        style.Font = Editable;
                    }
                    else
                    {
                        _dataGridView.Columns[column.Name].ReadOnly = true;
                        style.Font = NoEdit;
                    }

                    #endregion"Column Edit"

                    _dataGridView.Columns[column.Name].HeaderCell.Style.Alignment = column.Alignment;
                    _dataGridView.Columns[column.Name].DefaultCellStyle.Alignment = column.Alignment;
                }

                _dataGridView.ResumeLayout();

            }
        }

        #region"InitializeThreadTimer"

        int _firstInterval;
        System.Threading.Timer timerColumnsNotReady;
        void InitializeThreadTimer()
        {
            _firstInterval += 1000;
            //DoSomething = procedure to callback, null = object pass to, First interval = 0 ms, subsequent intervals = 1000 ms
            timerColumnsNotReady = new System.Threading.Timer(new TimerCallback(DoSomething), null, _firstInterval, 1000);
        }

        void DoSomething(object obj)
        {
            //it executes a second
            StopThreadTimer();

            if (InvokeRequired)
            {
                Invoke(new EventHandler(delegate (object o, EventArgs e)
                {
                    //Do your work here.
                    SettingColumns = _settingColumns;
                }));
            }
            else
            {
                //Do your work here.
                SettingColumns = _settingColumns;

            }

        }

        void StartThreadTimer()
        {
            timerColumnsNotReady.Change(_firstInterval, 1000); //enable First interval = 0 ms, subsequent intervals = 1000 ms
        }

        void StopThreadTimer()
        {
            timerColumnsNotReady.Change(Timeout.Infinite, Timeout.Infinite); //disable
        }

        #endregion"InitializeThreadTimer"        

        /// <summary>
        /// Get a collection that contains all the columns in the control.
        /// </summary>
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]

        /// <summary>
        /// Get a collection that contains all the columns in the control.
        /// </summary>
        public DataGridViewColumnCollection ColumnsCollection
        {
            get
            {
                return _dataGridView.Columns;
            }
            set { }
        }

        public bool IsColumnVisible(string columnName)
        {
            if (_dataGridView.Columns.Contains(columnName))
                return _dataGridView.Columns[columnName].Visible;

            return false;
        }

        /// <summary>
        /// Add the given column to the collection.
        /// Return the column index into the collection.
        /// </summary>
        /// <param name="newColumn"></param>
        /// <param name="index"></param>
        /// <returns></returns>
		public int AddColumn(DataGridViewColumn newColumn, int index)
        {
            var columnAdd = _dataGridView.Columns.Add(newColumn);

            _dataGridView.Columns[newColumn.Name].DisplayIndex = index;

            return columnAdd;
        }

        /// <summary>
        /// Remove the given column to the collection.
        /// </summary>
        /// <param name="newColumn"></param>
        /// <param name="index"></param>
        /// <param name="columnName">todo: describe columnName parameter on RemoveColumn</param>
        /// <returns></returns>
        public void RemoveColumn(string columnName)
        {
            if (_dataGridView.Columns.Contains(columnName))
                _dataGridView.Columns.Remove(columnName);
        }

        public DataSet _dataSet;
        public DataTable _dataTable;

        /// <summary>
        /// Dictionary, Keep record in running of state all column.
        /// string columnName.Visible
        /// int    column width
        /// </summary>
        public SortedDictionary<string, int> ColumnState;

        /// <summary>
        /// Keep records of column Name to be hide;
        /// </summary>
        public string _columnsToHide;

        /// <summary>
        /// Keep records of column State to be hide;
        /// </summary>
        public bool _columnsToHideState;

        //AggregateBindingListView<DataRowView> _bindingListView;
        //DataGridViewExtend.BindingSourceGroups _bindingGroupsView;

        /// <summary>
        /// Enable or disable the bindingNavigator option to add a new item.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Enable or disable the bindingNavigator option to add a new item.
        /// </summary>
        public bool BindingNavigatorAddNewItemEnable
        {
            get
            {
                return bindingNavigatorAddNewItem.Enabled;
            }
            set
            {
                bindingNavigatorAddNewItem.Enabled = value;
            }
        }

        /// <summary>
        /// Enable or disable the bindingNavigator option to delete a item.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Enable or disable the bindingNavigator option to delete a item.
        /// </summary>
        public bool BindingNavigatorDeleteItemEnable
        {
            get
            {
                return bindingNavigatorDeleteItem.Enabled;
            }
            set
            {
                bindingNavigatorDeleteItem.Enabled = value;
            }
        }

        /// <summary>
        /// Enable or disable the DataGridView option to add a Row.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool AllowUserToAddRows
        {
            get
            {
                return _dataGridView.AllowUserToAddRows;
            }
            set
            {
                _dataGridView.AllowUserToAddRows = value;
            }
        }

        #endregion"Properties"

        #region"Properties, Custom Control Properties"

        /// <summary>
        /// The color of the divider displayed between rows while dragging
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The color of the divider displayed between rows while dragging")]
        public Color DividerColor
        {
            get { return _dataGridView.DividerColor; }
            set { _dataGridView.DividerColor = value; }
        }

        /// <summary>
        /// Height (in pixels) of the divider to display
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Height (in pixels) of the divider to display")]
        [DefaultValue(2)]
        public int DividerHeight
        {
            get
            {
                return _dataGridView.DividerHeight;
            }
            set
            {
                _dataGridView.DividerHeight = value;
            }
        }

        /// <summary>
        /// Width (in pixels) of the border around the selected row
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Width (in pixels) of the border around the selected row")]
        [DefaultValue(1)]
        public int SelectionBorderWidth
        {
            get
            {
                return _dataGridView.SelectionBorderWidth;
            }
            set
            {
                _dataGridView.SelectionBorderWidth = value;
            }
        }

        /// <summary>
        /// "The color of the border drawn around the selected row"
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Color of the border drawn around the selected row")]
        public Color CurrentRowBorderColor
        {
            get { return _dataGridView.CurrentRowBorderColor; }
            set { _dataGridView.CurrentRowBorderColor = value; }
        }

        /// <summary>
        /// "The Background color of the current row"
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("Background color of the current row")]
        public Color CurrentRowBackgroundColor
        {
            get { return _dataGridView.CurrentRowBackgroundColor; }
            set { _dataGridView.CurrentRowBackgroundColor = value; }
        }

        [AttributeProvider(typeof(IListSource)),
        RefreshProperties(RefreshProperties.Repaint),
        Bindable(true),
        Category("DataView Properties"),
        DefaultValue(""),
        Description("Specifies the table this DataView uses to get data.")]
        public object DataSource
        {
            get
            {
                //return _bindingSource.DataSource;
                return _bindingSource;
            }
            set
            {
                if (value == null) return;

                /*
                if (value.GetType() == typeof(BindingSourceGroups))
                {
                    _bindingGroupsView = (BindingSourceGroups)value;

                    if (InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate
                        {
                            lock (_dataGridView.Columns.SyncRoot)
                            {
                                _dataGridView.DataSource = _bindingGroupsView;
                                _bindingNavigator.BindingSource = _bindingGroupsView;
                                _bindingSource.ResetBindings(true);
                            }

                        }));
                    }
                    else
                    {
                        lock (_dataGridView.Columns.SyncRoot)
                        {
                            _dataGridView.DataSource = _bindingGroupsView;
                            _bindingNavigator.BindingSource = _bindingGroupsView;
                            _bindingSource.ResetBindings(true);
                        }
                    }
                }

                if (value.GetType() == typeof(AggregateBindingListView<DataRowView>))
                {
                    _bindingListView = (AggregateBindingListView<DataRowView>)value;

                    if (InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate
                        {
                            lock (_dataGridView.Columns.SyncRoot)
                            {
                                _dataGridView.DataSource = _bindingListView;
                                // _bindingNavigator.BindingSource = _bindingSource;
                                // _bindingSource.ResetBindings(true);
                            }

                        }));
                    }
                    else
                    {
                        lock (_dataGridView.Columns.SyncRoot)
                        {
                            _dataGridView.DataSource = _bindingListView;
                            // _bindingNavigator.BindingSource = _bindingSource;
                            // _bindingSource.ResetBindings(true);
                        }
                    }
                }
                */

                if (value.GetType() == typeof(BindingSource))
                {
                    _bindingSource = (BindingSource)value;
                    if (_bindingSource.DataSource is DataSet _dataSet)
                    {
                        // If the BindingSource is bound to a DataSet
                        // You need to specify the DataMember (table name)
                        if (!string.IsNullOrEmpty(_bindingSource.DataMember))
                        {
                            DataMember = _bindingSource.DataMember;
                            userSettingName = Name + "_" + DataMember;

                            if (_dataSet != null && !string.IsNullOrEmpty(DataMember) && _dataSet.Tables.Contains(DataMember))
                            {
                                _dataTable = _dataSet.Tables[DataMember];
                            }
                            else
                            {
                                _dataTable = null; // Handle the case where DataMember is null or the table does not exist
                            }
                        }
                    }

                    if (InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate
                                                         {
                                                             lock (_dataGridView.Columns.SyncRoot)
                                                             {
                                                                 _dataGridView.DataSource = _bindingSource;
                                                                 _bindingNavigator.BindingSource = _bindingSource;
                                                                 _bindingSource.ResetBindings(true);
                                                             }

                                                         }));
                    }
                    else
                    {
                        lock (_dataGridView.Columns.SyncRoot)
                        {
                            _dataGridView.DataSource = _bindingSource;
                            _bindingNavigator.BindingSource = _bindingSource;
                            _bindingSource.ResetBindings(true);
                        }
                    }
                }

                if (value.GetType() == typeof(DataSet))
                {
                    _dataSet = (DataSet)value;

                    if (DataMember == null) return;

                    if (_dataSet.Tables.Contains(DataMember))
                    {
                        _dataTable = _dataSet.Tables[DataMember];
                        _bindingSource.DataSource = _dataSet.Tables[DataMember];

                        if (InvokeRequired)
                        {
                            Invoke(new EventHandler(delegate
                                                        {
                                                            _dataGridView.DataSource = _bindingSource;
                                                            _bindingNavigator.BindingSource = _bindingSource;
                                                            _bindingSource.ResetBindings(true);
                                                        }));
                        }
                    }
                }

                if (value.GetType() == typeof(DataTable))
                {
                    _dataTable = (DataTable)value;

                    _bindingSource.DataSource = _dataTable;

                    if (InvokeRequired)
                    {
                        Invoke(new EventHandler(delegate
                                                    {
                                                        _dataGridView.DataSource = _bindingSource;
                                                        _bindingNavigator.BindingSource = _bindingSource;
                                                        _bindingSource.ResetBindings(true);
                                                    }));
                    }
                }
            }
        }

        string _dataMember;
        [Editor("System.Windows.Forms.Design.DataMemberListEditor, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a",
            typeof(UITypeEditor)),
        Category("DataView Properties"),
        DefaultValue(null),
        Description("Specifies the table this DataView uses to get data.")]
        public string DataMember
        {
            get
            {
                return _dataMember;
            }

            set
            {
                _dataMember = value;

                if (_dataSet == null)
                    return;

                if (_dataSet.Tables.Contains(value))
                    _bindingSource.DataSource = _dataSet.Tables[DataMember];

                //  _bindingSource.DataMember = value;
                _dataGridView.DataSource = _bindingSource;
                _bindingSource.ResetBindings(true);
            }
        }

        /// <summary>
        /// Requested filter by external user.
        /// </summary>
        string _customExternalFilter;
        /// <summary>
        /// Specifies the custom string filter, formated as, ColumnName LIKE ''
        /// </summary>
        [RefreshProperties(RefreshProperties.Repaint),
         Bindable(true),
         Category("DataView Properties"),
         DefaultValue(""),
         Description("Specifies the custom string filter, formatted as, ColumnName LIKE ''")]
        public string CustomFilter
        {
            get
            {
                if (_customExternalFilter == null)
                    _customExternalFilter = "";

                return _customExternalFilter;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _customExternalFilter = value;

                    if (_dataGridView.ActiveFilter != null & _dataGridView.ActiveFilter.Length >= 1)
                    {
                        _bindingSource.Filter = _dataGridView.ActiveFilter + " AND " + _customExternalFilter;
                        toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in " + _bindingSource.Filter;
                        toolStripLabel_Help.Text = Settings.Default.RightClickRemoveFilter;
                    }
                    else
                    {
                        try
                        {
                            _bindingSource.Filter = _customExternalFilter;
                            toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in " + _bindingSource.Filter;
                            toolStripLabel_Help.Text = Settings.Default.ThisIsAnExternalFilter;
                        }
                        catch (Exception error)
                        {
                            _bindingSource.Filter = null;
                            MessageBox.Show(@"Error in string_Filter, " + error.Message, Settings.Default.ErrorInExternalFilter,
                                                                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    _customExternalFilter = value;

                    if (_dataGridView.ActiveFilter.Length >= 1)
                    {
                        _bindingSource.Filter = _dataGridView.ActiveFilter;
                        toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in " + _bindingSource.Filter;
                        toolStripLabel_Help.Text = Settings.Default.RightClickRemoveFilter;
                    }
                    else
                    {
                        _bindingSource.Filter = null;
                        toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in the entire DataBase";
                        toolStripLabel_Help.Text = Settings.Default.ThereIsnoFiltertoClear;
                    }
                }
            }
        }

        /// <summary>
        /// Bool, true if custom is enable to add/remove Rows
        /// likewise, false.
        /// </summary>
        EditMode _customEdit;
        /// <summary>
        /// Specifies if the customer is enable to add/delete Rows.
        /// This is set in CurrentEmployeesLogIn, it's no necesary to be set independent.
        /// </summary>
        [Category("DataView Properties"),
        DefaultValue(true),
        Description("Specifies if the customer is enable to add/delete Rows.")]
        public EditMode CustomEdit
        {
            get
            {
                return _customEdit;
            }
            set
            {
                _customEdit = value;

                switch (_customEdit)
                {
                    case EditMode.Add:
                        {
                            bindingNavigatorAddNewItem.Enabled = true;
                            bindingNavigatorDeleteItem.Enabled = false;

                            _dataGridView.AllowUserToAddRows = false;
                            _dataGridView.AllowUserToDeleteRows = false;

                            _dataGridView.ReadOnly = false;
                            toolStripButton_Save.Enabled = true;
                            break;
                        }
                    case EditMode.Delete:
                        {
                            bindingNavigatorAddNewItem.Enabled = true;
                            bindingNavigatorDeleteItem.Enabled = false;

                            _dataGridView.AllowUserToAddRows = false;
                            _dataGridView.AllowUserToDeleteRows = true;

                            _dataGridView.ReadOnly = false;
                            toolStripButton_Save.Enabled = true;
                            break;
                        }

                    case EditMode.Edit:
                        {
                            bindingNavigatorAddNewItem.Enabled = false;
                            bindingNavigatorDeleteItem.Enabled = false;

                            _dataGridView.AllowUserToAddRows = false;
                            _dataGridView.AllowUserToDeleteRows = false;

                            _dataGridView.ReadOnly = false;
                            toolStripButton_Save.Enabled = true;
                            break;
                        }
                    case EditMode.View:
                        {
                            bindingNavigatorAddNewItem.Enabled = false;
                            bindingNavigatorDeleteItem.Enabled = false;

                            _dataGridView.AllowUserToAddRows = false;
                            _dataGridView.AllowUserToDeleteRows = false;

                            _dataGridView.ReadOnly = true;
                            toolStripButton_Save.Enabled = false;
                            break;
                        }
                }
            }
        }

        string _firstDisplayedRow;
        /// <summary>
        /// Set it a current row and first displayed scrolling row.
        /// String as ColumnName/Data to find, example: PartNumber/014-003; ID/876546;
        /// </summary>
        [Category("DataView Properties"),
        DefaultValue(true),
        Description("Select a row by the customer. String as ColumnName/Data to select.")]
        public string FirstDisplayedRow
        {
            get
            {
                return _firstDisplayedRow;
            }
            set
            {
                _firstDisplayedRow = value;

                if (_firstDisplayedRow == null)
                    return;

                string[] columnData = _firstDisplayedRow.Split(new[] { '/' });

                if (columnData[0] == "" | columnData[0] == null)
                    return;

                if (!_dataGridView.Columns.Contains(columnData[0]))
                    return;

                if (_bindingSource.Count == 0)
                    return;

                string columnName = columnData[0];
                string cellValue = columnData[1];

                _rowIndexBindingSource = _dataGridView.GetRowIndexInDataGridView(columnName, cellValue);

                if (_rowIndexBindingSource == -1)
                    return;

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                                                {
                                                    _bindingSource.Position = _rowIndexBindingSource;
                                                    _dataGridView.FirstDisplayedScrollingRowIndex = _rowIndexBindingSource;
                                                    _dataGridView.CurrentCell = _dataGridView.Rows[_rowIndexBindingSource].Cells[0];

                                                    _dataGridView.Focus();
                                                }));
                }
                else
                {
                    _bindingSource.Position = _rowIndexBindingSource;
                    _dataGridView.FirstDisplayedScrollingRowIndex = _rowIndexBindingSource;
                    int cellIndex = 0;
                    while (!_dataGridView.Rows[_rowIndexBindingSource].Cells[cellIndex].Visible)
                    {
                        cellIndex++;
                        if (_dataGridView.Rows[_rowIndexBindingSource].Cells[cellIndex].Visible)
                            _dataGridView.CurrentCell = _dataGridView.Rows[_rowIndexBindingSource].Cells[cellIndex];
                    }

                    _dataGridView.Focus();
                }
            }

        }

        string _setValueAt;
        /// <summary>
        /// Select a row which PartNumber = 014-0003 and update Qty_for_Production = 345 and QtyNeeded = 55.
        /// String as ColumnName/Data to set, example: PartNumber/014-0003/345/55
        /// </summary>
        [Category("DataView Properties"),
        DefaultValue(true),
        Description("Select a row by the customer. String as ColumnName/Data to select.")]
        public string SetValueAt
        {
            get { return _setValueAt; }
            set
            {
                _setValueAt = value;

                if (_setValueAt == null)
                    return;

                string[] columnData = _setValueAt.Split(new[] { '/' });

                if (string.IsNullOrEmpty(columnData[0]))
                    return;

                if (!_dataGridView.Columns.Contains(columnData[0]))
                    return;

                if (_bindingSource.Count == 0)
                    return;

                string columnName = columnData[0];
                string cellValue = columnData[1];
                string CompForProduction = columnData[2];
                string QtyNeeded = columnData[3];

                DataGridViewRow rowToUpDate = _dataGridView.GetRowInDataGridView(columnName, cellValue);

                if (rowToUpDate == null)
                    return;

                if (!_dataGridView.Columns.Contains("Comp_for_Production") || !_dataGridView.Columns.Contains("QtyNeeded"))
                    return;

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        rowToUpDate.Cells["Comp_for_Production"].Value = CompForProduction;
                        rowToUpDate.Cells["QtyNeeded"].Value = QtyNeeded;
                    }));
                }
                else
                {
                    rowToUpDate.Cells["Comp_for_Production"].Value = CompForProduction;
                    rowToUpDate.Cells["QtyNeeded"].Value = QtyNeeded;
                }
            }
        }


        /// <summary>
        /// Set or return the value of AutoSizeColumnsMode property. Most by one of 
        /// AllCells, AllCellsExceptHeader, ColumnHeader, DisplayedCells, DisplayedCellsExceptHeader, Fill , None.
        /// </summary>
        [Category("DataGridView Properties"),

        DefaultValue(DataGridViewAutoSizeColumnsMode.None),
        Description("Set AutoSizeColumnsMode front external source.")]
        public DataGridViewAutoSizeColumnsMode AutoSizeColumnsMode
        {
            get
            {
                return _dataGridView.AutoSizeColumnsMode;
            }
            set
            {
                _dataGridView.AutoSizeColumnsMode = value;
            }
        }

        bool _bindingCompleted;
        /// <summary>
        /// no recuerdo.
        /// </summary>
        [Category("DataView Properties"),
        DefaultValue(true),
        Description("No recuerdo.")]
        public bool BindingCompleted
        {
            get
            {
                return _bindingCompleted;
            }
            set
            {
                _controlName = Name;
                // The control have no name yet.
                if (_controlName == "DataGridViewExtended")
                    return;

                // If the Columns are not loaded return;
                if (_dataGridView.ColumnCount == 0)
                    return;

                // Only process this call one time.
                if (!_bindingCompleted)
                    _bindingCompleted = value;

            }


        }

        bool _needSaveData;
        [Category("DataView Properties"),
        DefaultValue(true),
        Description("Specifies if the customer need save data.")]
        public bool NeedSaveData
        {
            get
            {
                return _needSaveData;
            }
            set
            {
                _needSaveData = value;
                On_Need_SaveData(new Need_SaveData_EventArgs(Name, _needSaveData));
            }
        }

        #region Designer properties

        /// <summary>
        /// The color of the border drawn around the selected row
        /// </summary>
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Appearance")]
        [Description("The color of the CurrentRowBackgroundColor around the selected row")]
        public Color SelectionColor
        {
            get { return _dataGridView.CurrentRowBackgroundColor; }
            set { _dataGridView.CurrentRowBackgroundColor = value; }
        }

        #endregion




        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public CurrentStatus CurrentRowMouseOverStatus

        {
            get
            {
                return _dataGridView.CurrentRowMouseEnterStatus;
            }

            set { }
        }


        #endregion"Properties, Custom Control Properties"

        #region"Events, Custom Controls Events with custom Args.*********************"

        #region"PreviewKeyDown"        
        public delegate void PreviewKeyDownEventHandler(object sender, PreviewKeyDownEventArgs e);

        [Category("Controls Events")]
        [Description("PreviewKeyDown event has changed")]
        public event PreviewKeyDownEventHandler PreviewKeyDownEvent;

        protected virtual void OnPreviewKeyDownEvent(PreviewKeyDownEventArgs e)
        {
            PreviewKeyDownEvent?.Invoke(this, e);
        }
        #endregion"PreviewKeyDown"

        #region"KeyUp"        
        public delegate void KeyUpEventHandler(object sender, KeyEventArgs e);

        [Category("Controls Events")]
        [Description("KeyUp event has changed")]
        public event KeyUpEventHandler KeyUpEvent;

        protected virtual void OnKeyUpEvent(KeyEventArgs e)
        {
            KeyUpEvent?.Invoke(this, e);
        }
        #endregion"KeyDown"

        #region"KeyPress"        
        public delegate void KeyPressEventHandler(object sender, KeyPressEventArgs e);

        [Category("Controls Events")]
        [Description("KeyPress event has changed")]
        public event KeyPressEventHandler KeyPressEvent;

        protected virtual void OnKeyPressEvent(KeyPressEventArgs e)
        {
            KeyPressEvent?.Invoke(this, e);
        }
        #endregion"KeyPress"

        #region"KeyDown"        
        public delegate void KeyDownEventHandler(object sender, KeyEventArgs e);

        [Category("Controls Events")]
        [Description("KeyDown event has changed")]
        public event KeyDownEventHandler KeyDownEvent;

        protected virtual void OnKeyDownEvent(KeyEventArgs e)
        {
            KeyDownEvent?.Invoke(this, e);
        }
        #endregion"KeyDown"

        #region"DataGridViewMouseEnter"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void DataGridViewMouseEnterEventHandler(object sender, DataGridViewMouseEnterEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The Mouse has Enter at DataGridView")]
        public event DataGridViewMouseEnterEventHandler DataGridViewMouseEnterEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnDataGridViewMouseEnterEvent(DataGridViewMouseEnterEventArgs e)
        {
            DataGridViewMouseEnterEvent?.Invoke(this, e);
        }
        #endregion"DataGridViewMouseEnter"

        #region"DataGridViewMouseDown"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void DataGridViewMouseDownEventHandler(object sender, DataGridViewMouseDownEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The Mouse has Enter at DataGridView")]
        public event DataGridViewMouseDownEventHandler DataGridViewMouseDownEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnDataGridViewMouseDownEvent(DataGridViewMouseDownEventArgs e)
        {
            DataGridViewMouseDownEvent?.Invoke(this, e);
        }
        #endregion"DataGridViewMouseDown"

        #region"CellMouseEnter"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CellMouseEnterEventHandler(object sender, DataGridViewCellEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellMouseEnter has changed")]
        public event CellMouseEnterEventHandler CellMouseEnter;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnCellMouseEnter(DataGridViewCellEventArgs e)
        {
            CellMouseEnter?.Invoke(this, e);
        }

        #endregion"CellMouseEnter"

        #region"CellBegingEdit"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CellBegingEditEventHandler(object sender, DataGridViewCellCancelEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellBegingEdit value has changed")]
        public event CellBegingEditEventHandler CellBegingEditEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnCellBegingEditEvent(DataGridViewCellCancelEventArgs e)
        {
            CellBegingEditEvent?.Invoke(this, e);
        }
        #endregion"CellBegingEdit"

        #region"CellEndEdit"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CellEndEditEventHandler(object sender, DataGridViewCellEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellBegingEdit value has changed")]
        public event CellEndEditEventHandler CellEndEditEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnCellEndEditEvent(DataGridViewCellEventArgs e)
        {
            CellEndEditEvent?.Invoke(this, e);
        }
        #endregion"CellEndEdit"

        #region"CellClick"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CellClickEventHandler(object sender, CellClick_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellClick value has changed")]
        public event CellClickEventHandler CellClickEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnCellClickEvent(CellClick_EventArgs e)
        {
            CellClickEvent?.Invoke(this, e);
        }
        #endregion"CellClick"

        #region"CellDoubleClick"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CellDoubleClickEventHandler(object sender, CellDoubleClick_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("CellDoubleClick has changed")]
        public event CellDoubleClickEventHandler CellDoubleClickEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnCellDoubleClickEvent(CellDoubleClick_EventArgs e)
        {
            CellDoubleClickEvent?.Invoke(this, e);
        }
        #endregion"CellDoubleClick_Event"

        #region"ColumnHeaderMouseClick"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ColumnHeaderMouseClickEventHandler(object sender, DataGridViewCellMouseEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ColumnHeaderMouseClick has changed")]
        public event ColumnHeaderMouseClickEventHandler ColumnHeaderMouseClickEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnColumnHeaderMouseClickEvent(DataGridViewCellMouseEventArgs e)
        {
            ColumnHeaderMouseClickEvent?.Invoke(this, e);
        }
        #endregion"ColumnHeaderMouseClick"

        #region"DataGridViewSort"

        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void DataGridViewSortEventHandler(object sender, DataGridViewSort_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("DataGridView has been sorted.")]
        public event DataGridViewSortEventHandler DataGridViewSort;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_DataGridViewSort(DataGridViewSort_EventArgs e)
        {
            DataGridViewSort?.Invoke(this, e);
        }

        #endregion"DataGridViewSort"

        #region"CurrentRowActivesEvent"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void CurrentRowActiveEventHandler(object sender, CurrentRowActive_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("Current Row Active, has change in the control ")]
        public event CurrentRowActiveEventHandler CurrentRowActivesEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnCurrentRowActivesEvent(CurrentRowActive_EventArgs e)
        {
            CurrentRowActivesEvent?.Invoke(this, e);
        }
        #endregion"CurrentRowActivesEvent"

        #region"UserDeletingRow"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void UserDeletingRowEventHandler(object sender, DataGridViewRowCancelEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("RowsRemoved, has change in the control ")]
        public event UserDeletingRowEventHandler UserDeletingRow;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_UserDeletingRow(DataGridViewRowCancelEventArgs e)
        {
            UserDeletingRow?.Invoke(this, e);
        }
        #endregion"UserDeletingRow"

        #region"UserDeletedRow"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void UserDeletedRowEventHandler(object sender, DataGridViewRowEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("RowsRemoved, has change in the control ")]
        public event UserDeletedRowEventHandler UserDeletedRow;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_UserDeletedRow(DataGridViewRowEventArgs e)
        {
            UserDeletedRow?.Invoke(this, e);
        }
        #endregion"UserDeletedRow"

        #region"LogFile information"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("LogFile information are append.")]
        public event Custom_Events_Args.LogFileMessageEventHandler LogFileMessage;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_LogFileMessage(Custom_Events_Args.LogFileMessageEventArgs e)
        {
            LogFileMessage?.Invoke(this, e);
        }

        #endregion"LogFile information"

        #region"StatusBarMessage"

        // # 1 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("ActiveDataSheet has been changed")]
        public event StatusBarMessageEventHandler StatusBarMessage;

        // # 2 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void StatusBarMessageEventHandler(object sender, StatusBarMessage_EventArgs e);

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_StatusBarMessage(StatusBarMessage_EventArgs e)
        {
            StatusBarMessage?.Invoke(this, e);
        }

        #endregion"StatusBarMessage"

        #region"RowsAdded"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void RowsAddedEventHandler(object sender, DataGridViewRowsAddedEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("RowsAdded, has change in the control ")]
        public event RowsAddedEventHandler RowsAdded;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_RowsAdded(DataGridViewRowsAddedEventArgs e)
        {
            RowsAdded?.Invoke(this, e);
        }
        #endregion"RowsAdded"

        #region"RowsRemoved"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void RowsRemovedEventHandler(object sender, DataGridViewRowsRemovedEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("RowsRemoved, has change in the control ")]
        public event RowsRemovedEventHandler RowsRemoved;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_RowsRemoved(DataGridViewRowsRemovedEventArgs e)
        {
            RowsRemoved?.Invoke(this, e);
        }
        #endregion"RowsRemoved"

        #region"RowsMouseEnter"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void RowsMouseEnterEventHandler(object sender, CurrentRowMouseEnterEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event RowsMouseEnterEventHandler RowsMouseEnter;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnRowsMouseEnter(CurrentRowMouseEnterEventArgs e)
        {
            RowsMouseEnter?.Invoke(this, e);
        }
        #endregion"RowsMouseEnter"

        #region"Find_Remplace"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void FindRemplaceEventHandler(object sender, FindRemplaceEventArgs e);

        // # 2 ... Define and provide implementations for EventArgs
        // Declare the constructor and properties of custom Arg.
        public class FindRemplaceEventArgs : EventArgs
        {
            // Constructor accepts some value.
            public FindRemplaceEventArgs()
            { }

            // Constructor accepts some value.
            public FindRemplaceEventArgs(Find_and_Remplace.Find_Remplace_Execute_EventArgs e)
            {
                CurrentRowIndex = e.CurrentRowIndex;
                CurrentRowActive = e.CurrentRowActive;
                CurrentColumnIndex = e.CurrentColumnIndex;
                CurrentColumnActive = e.CurrentColumnActive;
                OperationtoDo = e.Operationto_do;

            }

            // Constructor accepts some value.
            public FindRemplaceEventArgs(int currentRowIndex, DataGridViewRow currentRowActive,
                int currentColumIndex, DataGridViewColumn currentColumnActive, string operationtoDo, string wheretodo)
            {
                CurrentRowIndex = currentRowIndex;
                CurrentRowActive = currentRowActive;
                CurrentColumnIndex = currentColumIndex;
                CurrentColumnActive = currentColumnActive;
                OperationtoDo = operationtoDo;
                WheretoDo = wheretodo;
            }

            public int CurrentRowIndex { get; set; }
            public DataGridViewRow CurrentRowActive { get; set; }
            public int CurrentColumnIndex { get; set; }
            public DataGridViewColumn CurrentColumnActive { get; set; }
            public string OperationtoDo
            {
                get
                {
                    return _operation;
                }
                set
                {
                    _operation = value;
                    if (value.Contains("Find"))
                        IsFind = true;
                    if (value.Contains("Replace"))
                        IsReplace = true;
                    if (value.Contains("Fill"))
                        IsFill = true;
                }
            }

            string _operation;
            public bool IsFind;
            public bool IsReplace;
            public bool IsFill;

            public string WheretoDo;
        }

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User executed Find & Replace Dialog.")]
        public event FindRemplaceEventHandler FindRemplace;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Find_Remplace(FindRemplaceEventArgs e)
        {
            FindRemplace?.Invoke(this, e);
        }
        #endregion

        #region"Save_Setting"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SaveSettingEventHandler(object sender, SaveSettingEventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Setting Save action")]
        public event SaveSettingEventHandler SaveSetting;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_SaveSetting(SaveSettingEventArgs e)
        {
            SaveSetting?.Invoke(this, e);
        }
        #endregion"Save_Setting"

        #region"Save_Requested"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void SaveRequestedEventHandler(object sender, Save_Requested_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event SaveRequestedEventHandler SaveRequested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Save_Requested(Save_Requested_EventArgs e)
        {
            SaveRequested?.Invoke(this, e);
        }
        #endregion

        #region"Need_SaveData"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void NeedSaveDataEventHandler(object sender, Need_SaveData_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Save action")]
        public event NeedSaveDataEventHandler Need_SaveData;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Need_SaveData(Need_SaveData_EventArgs e)
        {
            Need_SaveData?.Invoke(this, e);
        }

        #endregion"Need_SaveData"

        #region"Refresh_Requested"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void RefreshRequestedEventHandler(object sender, Refresh_Requested_EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("The User request a Refresh action on database data.")]
        public event RefreshRequestedEventHandler RefreshRequested;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void On_Refresh_Requested(Refresh_Requested_EventArgs e)
        {
            RefreshRequested?.Invoke(this, e);
        }
        #endregion

        #region"BindingNavigatorAddNewItemClick"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void BindingNavigatorAddNewItemEventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event BindingNavigatorAddNewItemEventHandler BindingNavigatorAddNewItemEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void OnBindingNavigatorAddNewItem_Event(EventArgs e)
        {
            BindingNavigatorAddNewItemEvent?.Invoke(this, e);
        }
        #endregion"BindingNavigatorAddNewItemClick"

        #region"AddNote"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void AddNoteEventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event AddNoteEventHandler AddNoteEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void AddNote_Event(EventArgs e)
        {
            AddNoteEvent?.Invoke(this, e);
        }
        #endregion"AddNote"

        #region"EditNote"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void EditNoteEventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event EditNoteEventHandler EditNoteEvent;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        protected virtual void EditNote_Event(EventArgs e)
        {
            EditNoteEvent?.Invoke(this, e);
        }
        #endregion"EditNote"

        #region"ContextMenuStrip ItemClicked"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ContextMenuStripItemClickedEventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event ContextMenuStripItemClickedEventHandler ContextMenuStripItemClicked;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        void ToolStripMenuItem_Pr_Click(object sender, EventArgs e)
        {
            ContextMenuStripItemClicked?.Invoke(this, e);
        }

        #endregion"ContextMenuStrip ItemClicked"

        #region"ContextMenuStrip Opening"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ContextMenuStripItemOpeningEventHandler(object sender, ContextMenuStrip e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event ContextMenuStripItemOpeningEventHandler ContextMenuStripOpening;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        void ContextMenuStripOpening_Click(ContextMenuStrip e)
        {
            ContextMenuStripOpening?.Invoke(this, e);
        }

        #endregion"ContextMenuStrip ItemClicked"

        #region"PrintCompLabel"
        // # 1 ... ***** New Event Declaration. *****
        // Declare the delegates for this event:
        public delegate void ContextMenuStripPrintCompLabelEventHandler(object sender, EventArgs e);

        // # 3 ... Declare the event in the control class
        // put some information to Properties Manager.
        [Category("Controls Events")]
        [Description("MouseEnter value has changed")]
        public event ContextMenuStripPrintCompLabelEventHandler ContextMenuStripPrintCompLabel;

        // # 4 ... Declare the protected virtual methods for
        // this events, in this procedure we calling the event itself.
        void ToolStripMenuItem_PrintCompLabel_Click(object sender, EventArgs e)
        {
            ContextMenuStripPrintCompLabel?.Invoke(this, e);
        }

        #endregion"PrintCompLabel"

        #endregion "Events, Custom Controls Events with custom Arg.*********************"

        #region"CurrentUserBroadcast"

        // Properties and fields used in LogIn employees.
        string _employeeName = "Not user login.";
        string _employeeLastName = "";
        AccessLevel _employeeAccessLevel = AccessLevel.User;
        EditMode _employeeEditMode = EditMode.View;
        EnableSetting EmployeeEnableTreeViewSetting = EnableSetting.False;

        Employee _currentEmployeesLogIn;
        /// <summary>
        /// Process current employee information.
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// Process current employee information.
        /// </summary>
        public Employee CurrentEmployeesLogIn
        {
            get
            {
                return _currentEmployeesLogIn;
            }
            set
            {
                if (value == null)
                    return;

                _currentEmployeesLogIn = value;

                _employeeName = _currentEmployeesLogIn.Name;
                _employeeLastName = _currentEmployeesLogIn.LastName;
                _employeeEditMode = _currentEmployeesLogIn.EmployeeEditMode;
                _employeeAccessLevel = _currentEmployeesLogIn.EmployeeAccessLevel;
                EmployeeEnableTreeViewSetting = _currentEmployeesLogIn.EmployeeEnableTreeViewSetting;

                CustomEdit = _employeeEditMode;

                _dataGridView.AutoSizeColumnsMode = _currentEmployeesLogIn.AutoSizeColumnsMode;

                LoadDataGridViewColumnsSetting();
            }
        }

        void LoadDataGridViewColumnsSetting()
        {
            if (_currentEmployeesLogIn == null)
                return;

            if (_currentEmployeesLogIn.ContainsDataGridViewColumnsSettingList(userSettingName))
            {
                _dataGridView._needSaveSetting = false;
                List<ColumnSetting> columnsSetting = _currentEmployeesLogIn.ColumnSettingList(userSettingName);

                if (columnsSetting != null)
                    SettingColumns = columnsSetting;
            }
        }

        #endregion"CurrentUserBroadcast"

        /* https://social.msdn.microsoft.com/Forums/windows/en-US/aaed00ce-4bc9-424e-8c05-c30213171c2c/flickerfree-painting?forum=winforms
		 A form that has a lot of controls takes a long time to paint.  Especially the Button control in its default style is expensive.
		 Once you get over 50 controls, it starts getting noticeable.  The Form class paints its background first and leaves "holes" where
		 the controls need to go.  Those holes are usually white, black when you use the Opacity or TransparencyKey property.  Then each
		 control gets painted, filling in the holes.  The visual effect is ugly and there's no ready solution for it in Windows Forms.
		 Double-buffering can't solve it as it only works for a single control, not a composite set of controls.
		 I discovered a new Windows style in the SDK header files, available for Windows XP and (presumably) Vista: WS_EX_COMPOSITED.
		 With that style turned on for your form, Windows XP does double-buffering on the form and all its child controls.
		 This effectively solves the 2nd cause of flicker.
		*/
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;

                //DataGridViewDrawDoubleBuffering no trabaja.
                if (Settings.Default.DataGridViewDrawDoubleBuffering)
                    cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED

                return cp;
            }
        }


        public DataGridViewExtended()
        {
            try
            {
                MessagePositionString = "InitializeComp..";
                InitializeComponent();

                MessagePositionString = "Initialize initialDelay timer..";
                initialDelay = new System.Windows.Forms.Timer
                {
                    Interval = 2500
                };
                initialDelay.Tick += new EventHandler(InitialDelay_Tick);
                initialDelay.Start();

                MessagePositionString = "ColumnFilterIndicator..";
                _dataGridView.ColumnFilterIndicator = Resources.Filtering;
                _dataGridView.ColumnClearFilterIndicator = Resources.FilterClearing;
                _dataGridView.DataSourceChanged += _dataGridView_DataSourceChanged;

                _bindingSource.RaiseListChangedEvents = true;
                _bindingSource.ListChanged += BindingSourceListChanged;
                _bindingSource.PositionChanged += BindingSourcePositionChanged;
                _bindingSource.CurrentChanged += BindingSourceCurrentChanged;
                _bindingSource.CurrentItemChanged += BindingSourceCurrentItemChanged;
                _bindingSource.ResetBindings(true);

                MessagePositionString = "toolStripMenuItem..";
                toolStripMenuItemExportToCSV.Click += new EventHandler(toolStripMenuItemExportToCSV_Click);
                toolStripMenuItemExportToTXT.Click += new EventHandler(toolStripMenuItemExportToTXT_Click);
                toolStripMenuItemExportToWebPage.Click += new EventHandler(toolStripMenuItemExportToWebPage_Click);

                _bindingNavigator.BindingSource = _bindingSource;
                bindingNavigatorDeleteItem.Tag = false;

                MessagePositionString = "InitializeContextMenu..";
                InitializeContextMenu();
                InitializeToolStrip();
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message +
                                                               @" at position " + MessagePositionString,
                                 @"DataGridViewExtended() construct has generated an error.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void _dataGridView_DataSourceChanged(object? sender, EventArgs e)
        {
            if (_dataGridView.DataSource == null)
                return;

            LoadDataGridViewColumnsSetting();
        }

        void InitialDelay_Tick(object sender, EventArgs e)
        {
            initialDelay.Stop();

            MessagePositionString = "DataGridViewInitialize..";
            DataGridViewInitialize();

            CurrentRowStatus = new CurrentStatus(_dataGridView.CurrentRowActived);

            InitializeDataGridViewEventHandler();
        }


        void BindingSourceCurrentItemChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Position == 0)
                return;
        }

        void BindingSourceCurrentChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Position == 0)
                return;
        }

        void BindingSourcePositionChanged(object sender, EventArgs e)
        {
            if (_bindingSource.Position == 0)
                return;
        }

        void BindingSourceListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded)
                return;

            //_dataGridView.Refresh();
        }


        #region"DataGridView Method"

        /// <summary>
        /// The idea here is, when selecting rows in the datagridview is changing to faster, all
        /// process associated also will be ejected to fast, it tend to freeze the interface... 
        /// </summary>
        System.Windows.Forms.Timer delaySelectionChanged = new System.Windows.Forms.Timer();

        //   DataGridViewCellStyle dataGridViewCellStyleSelectedRow = new DataGridViewCellStyle();
        //   DataGridViewCellStyle dataGridViewCellStyle = new DataGridViewCellStyle();
        void DataGridViewInitialize()
        {
            //We need call this handle to initialized.
            //var X = Handle;
            _dataGridView.AllowUserToAddRows = false;
            _dataGridView.AllowUserToDeleteRows = false;

            _dataGridView.ReadOnly = true;
            _dataGridView.TopLeftHeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
            //     dataGridViewCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 161);
            //     dataGridViewCellStyleSelectedRow.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 161);

            InitializeSaveUserSettingTimer();

            // Set the contextMenuStrip.
            _dataGridView.ContextMenuStrip = _contextMenuStrip_DataGridView;

            //	_dataGridView.DataSource = _bindingSource;

            delaySelectionChanged.Interval = 10;
            delaySelectionChanged.Tick += DelaySelectionChanged_Tick;
        }

        void DelaySelectionChanged_Tick(object sender, EventArgs e)
        {
            delaySelectionChanged.Stop();
            DataGridViewSelectionChanged();
        }

        void InitializeDataGridViewEventHandler()
        {
            _dataGridView.DataError += _dataGridView_DataError;
            _dataGridView.Sorted += DataGridViewSorted;
            _dataGridView.SelectionChanged += (o, i) => { delaySelectionChanged.Start(); };
            _dataGridView.AutoSizeColumnsModeChanged += DataGridViewAutoSizeColumnsModeChanged;
            _dataGridView.StatusBarMessage += DataGridView_StatusBarMessage;

            _dataGridView.TopLeftHeaderMouseUp += DataGridView_TopLeftHeaderMouseUp;
            _dataGridView.TopLeftHeaderMouseDown += DataGridView_TopLeftHeaderMouseDown;

            _dataGridView.UserDeletedRow += DataGridView_UserDeletedRow;
            _dataGridView.UserDeletingRow += DataGridViewUserDeletingRow;

            _dataGridView.MouseEnter += DataGridViewMouseEnter;
            _dataGridView.MouseDown += DataGridViewMouseDown;
            _dataGridView.MouseUp += DataGridViewMouseUp;

            _dataGridView.DragLeave += DataGridView_DragLeave;



            _dataGridView.CellClick += DataGridViewCellClick;
            _dataGridView.CellDoubleClick += DataGridViewCellDoubleClick;
            _dataGridView.CellContentClick += DataGridViewCellContentClick;
            _dataGridView.CellBeginEdit += DataGridViewCellBeginEdit;
            _dataGridView.CellEndEdit += DataGridViewCellEndEdit;
            _dataGridView.CellValueChanged += DataGridView_CellValueChanged;
            _dataGridView.CellsMouseEnter += DataGridView_CellsMouseEnter;

            _dataGridView.RowsAdded += DataGridView_RowsAdded;
            _dataGridView.RowsRemoved += DataGridView_RowsRemoved;
            _dataGridView.RowsMouseEnter += DataGridView_RowsMouseEnter;
            _dataGridView.Rows.CollectionChanged += DataGridView_RowsCollectionChanged;

            _dataGridView.ColumnWidthChanged += DataGridViewColumnWidthChanged;
            _dataGridView.ColumnDisplayIndexChanged += DataGridViewColumnDisplayIndexChanged;
            _dataGridView.ColumnRemoved += DataGridView_ColumnRemoved;
            _dataGridView.Columns.CollectionChanged += Columns_CollectionChanged;
            _dataGridView.ColumnDefaultCellStyleChanged += DataGridViewColumnDefaultCellStyleChanged;
            _dataGridView.ColumnHeaderMouseClick += DataGridView_ColumnHeaderMouseClick;

            _dataGridView.PreviewKeyDownEvent += DataGridView_PreviewKeyDown;
            _dataGridView.PreviewKeyDown += DataGridView_PreviewKeyDown;
            _dataGridView.KeyDown += DataGridView_KeyDown;
            _dataGridView.KeyPress += DataGridView_KeyPress;
            _dataGridView.KeyUp += DataGridView_KeyUp;

            _dataGridView.Disposed += DataGridView_Disposed;
        }

        void DataGridView_DragLeave(object sender, EventArgs e)
        {

        }

        void DataGridView_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            OnPreviewKeyDownEvent(e);
        }

        void DataGridView_KeyUp(object sender, KeyEventArgs e)
        {
            OnKeyUpEvent(e);
        }

        void DataGridView_KeyPress(object sender, KeyPressEventArgs e)
        {
            OnKeyPressEvent(e);
        }

        void DataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            OnKeyDownEvent(e);
        }

        void DataGridView_CellsMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            OnCellMouseEnter(e);
        }

        void DataGridView_Disposed(object sender, EventArgs e)
        {
            SaveUserSettingTimer.Stop();
            SaveUserSettingTimer.Dispose();
        }

        void DataGridView_StatusBarMessage(object sender, StatusBarMessage_EventArgs e)
        {
            On_StatusBarMessage(e);
        }

        void DataGridView_TopLeftHeaderMouseUp(object sender, EventArgs e)
        {
            if (_dataGridView.IsColumnResizeInternalType())
                return;

            _dataGridView.MultiSelect = true;
        }

        void DataGridView_TopLeftHeaderMouseDown(object sender, EventArgs e)
        {
            if (_dataGridView.IsColumnResizeInternalType())
                return;

            _dataGridView.MultiSelect = false;
            ToolStripMenuItem_SortByPDF_Click(sender, e);
        }

        int countError = 0;
        void _dataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (countError == 0)
            {
                countError++;
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + e.Exception.Message,
                                          @"DataGridViewExtended has generated an error at " + MessagePositionString,
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                countError++;
                DataGridView_StatusBarMessage(sender, new StatusBarMessage_EventArgs("DataGridViewExtended has generated an error, count:" + countError));
            }
        }

        void DataGridView_RowsMouseEnter(object sender, CurrentRowMouseEnterEventArgs e)
        {
            OnRowsMouseEnter(e);
        }

        void DataGridViewMouseEnter(object sender, EventArgs e)
        {
            OnDataGridViewMouseEnterEvent(new DataGridViewMouseEnterEventArgs(_dataGridView.CurrentRowActived));
        }

        /// <summary>
        /// We used DisplayIndex instead of HitTestColumnIndex, because after drag and drop process,
        /// index display does not match column index.
        /// </summary>
        // int _hitTestColumnIndexDisplayIndex = -1;
        void DataGridViewMouseDown(object sender, MouseEventArgs e)
        {
            // Note: DataGridViewMouseDown is the first event handler and then is called DataGridViewCellMouseDown event handler,
            // opposite to DataGridViewCellMouseUp/DataGridViewMouseUp event handler.
            if (e.Button == MouseButtons.Right)
                return;

            if (_dataGridView.IsColumnResizeInternalType())
            {
                IsMouseDrivenEvent = true;
                return;
            }

            OnDataGridViewMouseDownEvent(new DataGridViewMouseDownEventArgs(_dataGridView.CurrentRowActived));

            ///DoDragDrop("TestDragDrop", DragDropEffects.Copy);
        }

        void DataGridViewMouseUp(object sender, MouseEventArgs e)
        {
            // Note: DataGridViewCellMouseUp  is the first event handler and then is called DataGridViewMouseUp event handler,
            // opposite to DataGridViewMouseDown/DataGridViewCellMouseDown event handler.		   
        }


        void DataGridView_RowsCollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            switch (e.Action)
            {
                case CollectionChangeAction.Refresh:
                    {

                        break;
                    }
                case CollectionChangeAction.Add:
                    {
                        // Note: _dataGridView_RowsCollectionChanged is the first event handler and then
                        // is called _dataGridView_RowsAdded event handler.
                        break;
                    }
                case CollectionChangeAction.Remove:
                    {
                        if (!(bool)bindingNavigatorDeleteItem.Tag)
                            break;

                        bindingNavigatorDeleteItem.Tag = false;
                        //           On_UserDeletedRow(new DataGridViewRowEventArgs(_removedRow));
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        void DataGridView_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // Note: _dataGridView_RowsCollectionChanged is the first event handler and then
            // is called _dataGridView_RowsAdded event handler.
            On_RowsAdded(e);
        }

        void DataGridView_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            // This event happen when any row or group of rows are removed from the visible area.
            // Happen to by Sort, filtered, delete if the was in the visible area.

            if (e.RowCount > 1)
                return;
        }

        void DataGridViewUserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            // This event is triggered when the user hit Delete key.

            if (CurrentRowStatus.Unerasable)
            {
                e.Cancel = true;
                MessageBox.Show("Error, this row is marked as \"UNERASABLE\"",
                                "Unerasable row. Call a system manager to access this row",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bindingNavigatorDeleteItem.Tag = true;

            On_UserDeletingRow(e);

            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " deleting a row by hit the key Delete by the user at " + DateTime.Now)
                    },
                     e.Row));
        }

        void DataGridView_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            // This event occurred when the user hit Delete key and the delete process was no canceled.
            // The event occurred or sequence is:
            // # 1 _dataGridView_UserDeletingRow.
            // # 2 _dataGridView_RowsRemoved.
            // # 3 _dataGridView_UserDeletedRow.
        }


        string _owningColumnHeader = "";
        void DataGridViewCellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // If grouping is active, return.
            if (_dataGridView.CurrentRowActived.DataBoundItem.GetType() == typeof(GroupRow))
                return;

            if (CurrentRowStatus.Locked)
            {
                MessageBox.Show("Sorry, this row has been locked, cannot be edited.",
                                "Locked row. Call a system manager to access this row",
                                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                e.Cancel = true;
                return;
            }

            //if cell value type is Boolean return, mouse over and focus fired this event.
            if (_dataGridView.CurrentCell.ValueType.ToString().Contains("Boolean"))
                return;

            _owningColumnHeader = _dataGridView.CurrentCell.OwningColumn.HeaderText;

            OnCellBegingEditEvent(e);

            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " cell begin edit at " + DateTime.Now),
                        Tags.NewLineRed("Column name " + _owningColumnHeader)
                    },
                     _dataGridView.Rows[e.RowIndex]));
        }

        void DataGridViewCellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //if cell value type is boolean return, mouse over and focus firet this event.
            if (_dataGridView.CurrentCell.ValueType.ToString().Contains("Boolean"))
                return;

            OnCellEndEditEvent(e);

            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " cell end edit at " + DateTime.Now),
                        Tags.NewLineRed("Column name " + _owningColumnHeader)
                    },
                     _dataGridView.Rows[e.RowIndex]));
        }

        void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (_dataGridView.CurrentCell == null)
                return;

            //if cell value type is boolean return, mouse over and focus firet this event.
            if (_dataGridView.CurrentCell.ValueType.ToString().Contains("Boolean"))
            {
                OnCellEndEditEvent(e);

                On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " cell end edit at " + DateTime.Now),
                        Tags.NewLineRed("Column name " + _owningColumnHeader)
                    },
                         _dataGridView.Rows[e.RowIndex]));
            }

        }

        void DataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            // TopLeftHeader.
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
                return;

            // Column header event.
            if (e.RowIndex == -1)
                return;

            // Row header event.
            if (e.ColumnIndex == -1)
                return;

            if (_dataGridView.CurrentCell.ValueType == typeof(bool))
                return;

            OnCellClickEvent(new CellClick_EventArgs(e, _dataGridView.Rows[e.RowIndex]));
        }

        void DataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Column header event.
            if (e.RowIndex == -1)
                return;

            // Row header event.
            if (e.ColumnIndex == -1)
                return;

            if (_dataGridView.CurrentCell.ValueType != typeof(bool))
                return;

            _dataGridView.EndEdit();

            OnCellClickEvent(new CellClick_EventArgs(e, _dataGridView.Rows[e.RowIndex]));
        }

        void DataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Column header event.
            if (e.RowIndex == -1)
                return;

            // Row header event.
            if (e.ColumnIndex == -1)
                return;

            if (_dataGridView.CurrentRowActived.DataBoundItem.GetType() == typeof(GroupRow))
                return;

            if (e.RowIndex != _dataGridView.CurrentRowActived.Index)
                return;

            string ColumnName = _dataGridView.Columns[e.ColumnIndex].Name;

            OnCellDoubleClickEvent(new CellDoubleClick_EventArgs(_dataGridView.Rows[e.RowIndex], ProcessMode.Adjust, ColumnName));
        }

        /// <summary>
        /// Current status of the active or selected row in the datagridView.
        /// </summary>
        public CurrentStatus CurrentRowStatus;
        DataGridViewRow currentDataGriedViewRow;
        List<DataGridViewRow> rowsWithDefaultCellStyle = new List<DataGridViewRow>();
        void DataGridViewSelectionChanged()
        {
            try
            {
                MessagePositionString = "DataGridViewSelectionChanged()";
                if (CurrentRowActive.Index == -1)
                {
                    OnCurrentRowActivesEvent(new CurrentRowActive_EventArgs(CurrentRowActive.Index, CurrentRowActive));
                    return;
                }

                if (currentDataGriedViewRow == CurrentRowActive)
                    return;

                currentDataGriedViewRow = CurrentRowActive;
                CurrentRowStatus = new CurrentStatus(CurrentRowActive);
                OnCurrentRowActivesEvent(new CurrentRowActive_EventArgs(CurrentRowActive.Index, CurrentRowActive));
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(form, @"Message related to this error is " + error.Message +
                                          @", Break code at position " + MessagePositionString,
                                          @"DataGridViewExtended has generated an error.",
                                          MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void DataGridViewColumnDefaultCellStyleChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SaveUserSetting();
        }

        void DataGridViewAutoSizeColumnsModeChanged(object sender, DataGridViewAutoSizeColumnsModeEventArgs e)
        {
            SaveUserSetting();
        }

        void DataGridViewColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            SaveUserSetting();
        }

        void DataGridViewColumnDisplayIndexChanged(object sender, DataGridViewColumnEventArgs e)
        {
            //Occurs when a column shown in the display is dragged,
            //it does not occur when a column is hide.
            SaveUserSetting();
        }

        void DataGridView_ColumnRemoved(object sender, DataGridViewColumnEventArgs e)
        {
            //It occurs when a column is removed from the collection,
            //not working when the column is hide.
        }

        void DataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            OnColumnHeaderMouseClickEvent(e);
        }

        void Columns_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            //Occurs when a column is added or removed from the collection,
            //it does not work when the column is hide.
        }

        void DataGridViewSorted(object sender, EventArgs e)
        {
            #region"UpDate topleftheadercell SortGlyphDirection"
            //View ToolStripMenuItem_SortByPDF_Click for sort process.
            if (_dataGridView.SortedColumn == null)
                return;

            switch (_dataGridView.SortedColumn.HeaderText)
            {
                case "CountTxT":
                    {

                        break;
                    }
                case "CountPDF":
                    {
                        break;
                    }
                case "CountDoc":
                    {
                        break;
                    }
                case "CountDocx":
                    {
                        break;
                    }
                default:
                    {
                        _dataGridView.TopLeftHeaderCell.Value = "";
                        break;
                    }
            }
            #endregion"UpDate topleftheadercell SortGlyphDirection"

            if (DataGridViewSort == null)
                return;

            BindingSource bindingsourceSourted = new BindingSource();

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                // If Grouping is active.
                if (row.DataBoundItem.GetType().Name == "GroupRow")
                    continue;

                bindingsourceSourted.Add(row.DataBoundItem);
            }

            On_DataGridViewSort(new DataGridViewSort_EventArgs(bindingsourceSourted));
        }

        public void LockCurrentRow()
        {
            CurrentRowStatus = new CurrentStatus(_dataGridView.CurrentRowActived);
            CurrentRowStatus.Locked = true;

            CurrentRowStatus.UpDateStatus();
            _dataGridView.InvalidateRow(CurrentRowActive.Index);
        }

        public void UnLockCurrentRow()
        {
            CurrentRowStatus = new CurrentStatus(_dataGridView.CurrentRowActived)
            {
                Locked = false
            };

            CurrentRowStatus.UpDateStatus();
            _dataGridView.InvalidateRow(CurrentRowActive.Index);
        }

        public void MarkErasableCurrentRow()
        {
            bindingNavigatorDeleteItem.Enabled = true;

            CurrentRowStatus = new CurrentStatus(_dataGridView.CurrentRowActived);
            CurrentRowStatus.Unerasable = false;

            CurrentRowStatus.UpDateStatus();
            _dataGridView.InvalidateRow(CurrentRowActive.Index);
        }

        public void MarkUnerasableCurrentRow()
        {
            bindingNavigatorDeleteItem.Enabled = false;

            CurrentRowStatus = new CurrentStatus(_dataGridView.CurrentRowActived);
            CurrentRowStatus.Unerasable = true;

            CurrentRowStatus.UpDateStatus();
            _dataGridView.InvalidateRow(CurrentRowActive.Index);
        }

        #endregion"DataGridView Method"

        #region "ContextMenuStrip_DataGridView"

        /**
		* Funciones utilizadas para manipular ContextMenuStrip_DataGridView
		* Este es el menu para MouseButtons.Right Click sobre DataGridView.
		*/
        // The variables _currentColumnIndex, CurrentRowIndex, keep the position value of mouse pointer.
        void InitializeContextMenu()
        {
            toolStripMenuItem_Fill_by.Click += ToolStripMenuItem_Fill_by_Click;
            toolStripMenuItem_Replace_by.Click += ToolStripMenuItem_Replace_by_Click;


            //Use to present the toolStripTextBox_SearchBy...            
            toolStripMenuItem_SearchBy.MouseDown += ToolStripMenuItem_SearchBy_MouseDown;


            toolStripTextBox_SearchBy.AutoToolTip = false;

            toolStripTextBox_SearchBy.Click += ToolStripTextBox_SearchBy_Click;
            toolStripTextBox_SearchBy.KeyDown += ToolStripTextBox_SearchBy_KeyDown;
            toolStripTextBox_SearchBy.KeyUp += ToolStripTextBox_SearchBy_KeyUp;
            toolStripTextBox_SearchBy.LostFocus += ToolStripTextBox_SearchBy_LostFocus;
            toolStripTextBox_SearchBy.MouseHover += ToolStripTextBox_SearchBy_MouseHover;


            toolStripMenuItem_UnLocked.Click += ToolStripMenuItem_UnLocked_Click;

            toolStripMenuItem_MarkWithNote.Click += ToolStripMenuItem_MarkWithNote_Click;
            toolStripMenuItem_EditThisNote.Click += ToolStripMenuItem_EditThisNote_Click;
            toolStripMenuItem_RemoveThisNote.Click += ToolStripMenuItem_RemoveThisNote_Click;
            toolStripMenuItem_MarkToBeErase.Click += ToolStripMenuItem_SelectToDelete_Click;

            toolStripMenuItem_SortByPDF.Click += ToolStripMenuItem_SortByPDF_Click;

            toolStripMenuItem_PrintCompLabel.Click += ToolStripMenuItem_PrintCompLabel_Click;

            InitializeToolTipContextMenu();
        }


        #region"Timer SaveUserSetting if it's modifying the user interface."

        int _sec = 10;
        /// <summary>
        /// An interval of 10 seconds to save user setting if this is modifying the user interface.
        /// </summary>
        System.Windows.Forms.Timer SaveUserSettingTimer;

        void SaveUserSetting()
        {
            if (!IsMouseDrivenEvent)
                return;

            IsMouseDrivenEvent = false;

            SaveUserSettingTimer.Start();
            NeedSaveData = false;
            _sec = 10;

            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  10 sec less to save dataGridViewSetting."));
        }

        /// <summary>
        /// Initialize the SaveUserSettingTimer to 10 seconds to save
        /// user setting if this is modifying the user interface.
        /// </summary>
        void InitializeSaveUserSettingTimer()
        {
            SaveUserSettingTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            SaveUserSettingTimer.Tick += new EventHandler(SaveUserSettingTick);
        }

        void SaveUserSettingTick(object? sender, EventArgs e)
        {
            _sec--;

            if (_sec > 0)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  " + _sec + " sec less to save dataGridViewSetting."));
                return;
            }

            SaveUserSettingTimer.Stop();
            On_StatusBarMessage(new StatusBarMessage_EventArgs("", "  "));//Clear the StatusBar.

            var userSetting = new UserSetting(
                                               _dataGridView.AutoSizeColumnsMode,
                                               CustomEdit
                                             );

            if (_currentEmployeesLogIn == null)
            {
                On_StatusBarMessage(new StatusBarMessage_EventArgs("There is no registered user..."));
                return;
            }

            // User setting will be save if _bindingSource_Employees_ListChanged event is fire.
            _dataGridView.Columns["RowHeaderColumn"].Width = _dataGridView.RowHeadersWidth;

            //If the event handler is null call employeesLogIn.SaveSetting, 
            //if the control event is handle, call the handle.
            if (SaveSetting == null)
                _currentEmployeesLogIn.SaveUserSetting(userSettingName, userSetting, _dataGridView.Columns, _dataGridView.AutoSizeColumnsMode);
            else
                On_SaveSetting(new SaveSettingEventArgs(userSettingName, userSetting, _dataGridView.Columns));
        }

        #endregion"Timer SaveUserSetting if it's modifying the user interface."        

        #region"ToolTipContextMenu"

        readonly ToolTip _toolTipContextMenu = new ToolTip();

        void InitializeToolTipContextMenu()

        {

            _toolTipContextMenu.ToolTipTitle = "Search help";
            _toolTipContextMenu.IsBalloon = true;
            _toolTipContextMenu.AutomaticDelay = 0;
            _toolTipContextMenu.OwnerDraw = true;
            _toolTipContextMenu.ShowAlways = true;
            _toolTipContextMenu.UseAnimation = false;
            _toolTipContextMenu.UseFading = false;

            _toolTipContextMenu.Draw += ToolTipDrawContextMenu;

        }

        void ShowToolTip(string title, Control setToolTipTo, string tip, Point mousePos)
        {
            _toolTipContextMenu.BackColor = Color.LightGoldenrodYellow;
            _toolTipContextMenu.ToolTipTitle = title;
            _toolTipContextMenu.ToolTipIcon = ToolTipIcon.Info;
            _toolTipContextMenu.SetToolTip(setToolTipTo, tip);
            _toolTipContextMenu.Show(tip, setToolTipTo, mousePos);
        }

        void ShowToolTipWarning(Control setToolTipTo, string tip, Point mousePos)
        {
            _toolTipContextMenu.BackColor = Color.PaleVioletRed;
            _toolTipContextMenu.ToolTipTitle = "Warning ....";
            _toolTipContextMenu.ToolTipIcon = ToolTipIcon.Info;
            _toolTipContextMenu.SetToolTip(setToolTipTo, tip);
            _toolTipContextMenu.Show(tip, setToolTipTo, mousePos);
        }

        // if toolTip.IsBalloon = true, toolTip_Draw never is called.
        void ToolTipDrawContextMenu(object sender, DrawToolTipEventArgs e)
        {
            e.Graphics.FillRectangle(Brushes.AliceBlue, e.Bounds);
            e.Graphics.DrawRectangle(Pens.Chocolate, new Rectangle(0, 0, e.Bounds.Width - 1, e.Bounds.Height - 1));
            e.Graphics.DrawString(_toolTipContextMenu.ToolTipTitle + e.ToolTipText, e.Font, Brushes.Red, e.Bounds);
        }

        #endregion"ToolTipContextMenu"

        void ContextMenuStripDataGridViewOpening(object sender, CancelEventArgs e)
        {
            try
            {
                MessagePositionString = "Try and catch loop in Context_menu_strip_data_grid_view_opening.";
                if (_dataGridView.CurrentColumnActive == null)
                    return;

                if (_dataGridView.CurrentColumnActive.Index == -1)
                {
                    ColumnNameMouseRightClick = "Rows header";
                    ColumnTypeMouseRightClick = typeof(string).Name;
                }
                else
                {
                    ColumnNameMouseRightClick = _dataGridView.CurrentColumnActive.Name;
                    ColumnTypeMouseRightClick = _dataGridView.CurrentColumnActive.ValueType.Name;
                }

                _contextMenuStrip_DataGridView.Items.Clear();

                if (_dataGridView.ColumnCount == 0)
                    return;

                #region "Rows Selected & Maintenance"

                if (_dataGridView.HitTestData.RowIndex == -1 & _dataGridView.HitTestData.ColumnIndex == -1)
                {
                    _contextMenuStrip_DataGridView.Items.AddRange(new ToolStripItem[]
                                                          {
                                                                toolStripMenuItem_SortByPDF,
                                                          });

                    MessagePositionString = "Maintenance.";
                    if (_employeeAccessLevel == AccessLevel.Manager)
                    {
                        _contextMenuStrip_DataGridView.Items.AddRange(new ToolStripItem[]
                                                                 {
                                                                     ToolStripMenuItem_columnsMaintenance,
                                                                     ToolStripMenuItem_Maintenance
                                                                 });

                        _contextMenuStrip_DataGridView.Items.Add(toolStripSeparator1);
                    }
                }


                #endregion "Rows Selected & Maintenance"

                #region"ColumnHeader right-Click"

                MessagePositionString = "ColumnHeader right-Click.";
                if (_dataGridView.CurrentColumnActive == null)
                    return;

                if (_dataGridView.HitTestData.ColumnIndex > -1 & _dataGridView.HitTestData.RowIndex == -1)
                {
                    // ColumnHeader was clicked.
                    if (_dataGridView.ActiveFilterCollection.TryGetValue(
                        _dataGridView.HitTestData.ColumnIndex, out FilteredHeaderCell? value))
                    {
                        filteredHeader = value;
                        toolStripMenuItem_SearchBy.Text = "Search by " + filteredHeader.FilterStringBase;
                    }
                    else
                        toolStripMenuItem_SearchBy.Text = "Search by " + ColumnNameMouseRightClick + "..."; ;

                    _contextMenuStrip_DataGridView.Items.Add(toolStripMenuItem_SearchBy);
                    _contextMenuStrip_DataGridView.Items.Add(toolStripSeparatorSearchBy);

                    //Grouping menu.
                    ToolStripMenuItem_GroupByThisColumn.Text = @"Group by " + _dataGridView.CurrentColumnActive.HeaderText;

                    _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                       {
                                                            ToolStripMenuItem_GroupByThisColumn,
                                                            ToolStripMenuItem_RemoveGroup,
                                                            ToolStripMenuItem_CollapseAll,
                                                            ToolStripMenuItem_ExpandAll,
                                                       });

                    _contextMenuStrip_DataGridView.Items.Add(toolStripSeparator1);

                    //Selecting and filtering menu.
                    _contextMenuStrip_DataGridView.Items.Add(toolStripMenuItem_Custom_Filter);

                    if (_employeeAccessLevel == AccessLevel.Manager)
                    {
                        _contextMenuStrip_DataGridView.Items.Add(toolStripMenuItem_editByColumn);
                        toolStripMenuItem_editByColumn.DropDownItems.AddRange(new[]
                                                                                {
                                                                                    toolStripMenuItem_Replace_by,
                                                                                    toolStripMenuItem_Fill_by,
                                                                                });
                    }

                    if (_bindingSource.Filter != "")
                        _contextMenuStrip_DataGridView.Items.Add(ToolStripMenuItem_RemoveThisFilter);

                    if (_dataGridView.AreSelectedRows)
                        _contextMenuStrip_DataGridView.Items.Add(ToolStripMenuItem_UnSelect_all_Rows);

                    _contextMenuStrip_DataGridView.Items.Add(toolStripSeparator3);

                    //Columns setting menu.
                    // If column was Frozen, write UnFrozen.
                    ToolStripMenuItem_FrozenUntilHere.Text = _dataGridView.CurrentColumnActive.Frozen ? @"UnFrozen until here" : @"Frozen until here";

                    _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                     {
                                                         ToolStripMenuItem_HideThisColumn,
                                                         ToolStripMenuItem_FrozenUntilHere,
                                                     });

                    _contextMenuStrip_DataGridView.Items.Add(toolStripSeparator4);
                    _contextMenuStrip_DataGridView.Items.Add(ToolStripMenuItem_Columns);

                    if (_employeeAccessLevel == AccessLevel.Manager)
                    {
                        _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                        {
                                                            ToolStripMenuItem_changeGraphics,
                                                            ToolStripMenuItem_columnsMaintenance,
                                                        });
                    }
                }

                #endregion"ColumnHeader"

                #region"RowHeader right-Click"

                MessagePositionString = "RowHeader right-Click.";
                if (_dataGridView.CurrentRowActived == null)
                    return;

                if (_dataGridView.HitTestData.ColumnIndex == -1 && _dataGridView.HitTestData.RowIndex >= 0)
                {
                    //If the user click rightClick on different row as CurrentRowActivated,
                    //we need active it's.
                    if (_dataGridView.CurrentRowActived.Index != _dataGridView.HitTestData.RowIndex)
                    {
                        _bindingSource.Position = _dataGridView.HitTestData.RowIndex;// _rowIndexBindingSource;
                        _bindingSource.ResetBindings(false);
                        CurrentRowStatus = new CurrentStatus(_dataGridView.CurrentRowActived);
                    }

                    #region"View mode, The user have not right to Edit"

                    // RowHeader was clicked, if user have setting as view mode, return.
                    if (CustomEdit == EditMode.View)
                    {
                        _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                                 {
                                                                     ToolStripMenuItem_TheUserHaveNotRightToEdit
                                                                 });
                        return;
                    }

                    #endregion"View mode, The user have not right to Edit"

                    #region"Lock/UnLock"

                    if (CurrentRowStatus.Locked)
                        toolStripMenuItem_UnLocked.Text = "UnLock";
                    else
                        toolStripMenuItem_UnLocked.Text = "Lock";

                    _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                                  {
                                                                     toolStripMenuItem_UnLocked
                                                                  });

                    #endregion"Lock/UnLock"

                    #region"Mark with Note/Edit this Note/Remove this Note"

                    if (CurrentRowStatus.HasNote)
                        _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                              {
                                                                     toolStripMenuItem_EditThisNote,
                                                                     toolStripMenuItem_RemoveThisNote
                                                               });
                    else
                        _contextMenuStrip_DataGridView.Items.AddRange(new[] { toolStripMenuItem_MarkWithNote });


                    #endregion"Mark with Note/Edit this Note/Remove this Note"

                    #region"Mark to be Erase/Mark as Unerasable"

                    if (CustomEdit == EditMode.Delete)
                    {
                        if (CurrentRowStatus.Unerasable)
                            toolStripMenuItem_MarkToBeErase.Text = "Mark to be Erase";
                        else
                            toolStripMenuItem_MarkToBeErase.Text = "Mark as Unerasable";
                    }

                    _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                                  {
                                                                     toolStripMenuItem_MarkToBeErase
                                                                  });

                    #endregion"Mark to be Erase/Mark as Unerasable"                    

                    #region"Print Component Label"

                    if (CustomEdit == EditMode.Delete)
                    {
                        _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                                 {
                                                                     toolStripMenuItem_PrintCompLabel
                                                                 });
                    }


                    #endregion"Print Component Label"

                }

                #endregion"RowHeader right-Click"

                #region"Cells right-Click"

                MessagePositionString = "Cells right-Click.";
                if (_dataGridView.HitTestData.ColumnIndex > -1 & _dataGridView.HitTestData.RowIndex > -1)
                {

                    // El Click fue en las Cells. 
                    if (_dataGridView.Columns[_dataGridView.HitTestData.ColumnIndex].Frozen)

                    // If column was Frozen, write UnFrozen.
                    {
                        ToolStripMenuItem_FrozenUntilHere.Text = @"UnFrozen until here";
                    }
                    else
                    {
                        ToolStripMenuItem_FrozenUntilHere.Text = @"Frozen until here";
                    }

                    if (_dataGridView.CurrentCell != null)
                        if (_dataGridView.CurrentCell.OwningRow.IsNewRow)
                            _dataGridView.CancelEdit();

                    //TODO Cells right-Click.
                    // _bindingSource.Position = _currentRowIndex;

                    ToolStripMenuItem_GroupByThisColumn.Text = @"Group by " + _dataGridView.Columns[_dataGridView.HitTestData.ColumnIndex].HeaderText;

                    //Grouping menu.
                    _contextMenuStrip_DataGridView.Items.AddRange(new ToolStripItem[]
                                                                 {
                                                                     ToolStripMenuItem_GroupByThisColumn,
                                                                     ToolStripMenuItem_RemoveGroup,
                                                                     ToolStripMenuItem_CollapseAll,
                                                                     ToolStripMenuItem_ExpandAll,
                                                                 });

                    _contextMenuStrip_DataGridView.Items.Add(toolStripSeparator1);

                    //Filtering menu.
                    _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                                 {
                                                                     ToolStripMenuItem_FilterByThisCell,
                                                                     toolStripMenuItem_Custom_Filter,
                                                                 });

                    if (_bindingSource.Filter != "")
                        _contextMenuStrip_DataGridView.Items.Add(ToolStripMenuItem_RemoveThisFilter);

                    _contextMenuStrip_DataGridView.Items.Add(toolStripSeparator2);

                    //Selecting and filling menu.
                    _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                                 {
                                                                     ToolStripMenuItem_Select_by
                                                                 });

                    if (_employeeAccessLevel == AccessLevel.Manager)
                    {
                        _contextMenuStrip_DataGridView.Items.AddRange(new[]
                                                                 {
                                                                     toolStripMenuItem_Replace_by,
                                                                     toolStripMenuItem_Fill_by,
                                                                 });
                    }

                    if (_dataGridView.AreSelectedRows)
                        _contextMenuStrip_DataGridView.Items.Add(ToolStripMenuItem_UnSelect_all_Rows);
                }

                #endregion"Cells right-Click"

                ContextMenuStripOpening_Click(_contextMenuStrip_DataGridView);
            }
            catch (Exception error)
            {
                using (var form = new Form { TopMost = true })
                {
                    MessageBox.Show(@"Message related to this error is " + error.Message +
                                    @", Break code at position " + MessagePositionString,
                                    @"StockRoom Inventory has generated an error.",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void ToolStripMenuItem_SortByPDF_Click(object sender, EventArgs e)
        {
            if (!_dataGridView.Columns.Contains("CountPDF"))
                return;

            switch (_dataGridView.SortOrder)
            {
                case SortOrder.None:
                    {
                        _dataGridView.Sort(_dataGridView.Columns["CountPDF"], ListSortDirection.Ascending);
                        _dataGridView.TopLeftHeaderCell.Value = "▲";
                        break;
                    }
                case SortOrder.Ascending:
                    {
                        _dataGridView.Sort(_dataGridView.Columns["CountPDF"], ListSortDirection.Descending);
                        _dataGridView.TopLeftHeaderCell.Value = "▼";
                        break;
                    }
                case SortOrder.Descending:
                    {
                        _dataGridView.Sort(_dataGridView.Columns["CountPDF"], ListSortDirection.Ascending);
                        _dataGridView.TopLeftHeaderCell.Value = "▲";
                        break;
                    }
            }
        }

        void ToolStripMenuItem_SelectToDelete_Click(object sender, EventArgs e)
        {
            if (CurrentRowStatus.Unerasable)
                MarkErasableCurrentRow();
            else
                MarkUnerasableCurrentRow();
        }

        void ToolStripMenuItem_RemoveThisNote_Click(object sender, EventArgs e)
        {
            CurrentRowStatus.RemoveNote();
            _dataGridView.InvalidateRow(CurrentRowActive.Index);
        }

        void ToolStripMenuItem_EditThisNote_Click(object sender, EventArgs e)
        {
            EditNote_Event(e);
        }

        void ToolStripMenuItem_MarkWithNote_Click(object sender, EventArgs e)
        {
            AddNote_Event(e);
        }

        void ToolStripMenuItem_UnLocked_Click(object sender, EventArgs e)
        {
            if (CurrentRowStatus.Locked)
                UnLockCurrentRow();
            else
                LockCurrentRow();
        }

        void ToolStripTextBox_SearchBy_LostFocus(object sender, EventArgs e)
        {
            MouseRightDone = false;
            _toolTipContextMenu.Hide(toolStripTextBox_SearchBy.TextBox);
            toolStripTextBox_SearchBy.Text = "Search by...";

            if (hitEnter)
            {
                hitEnter = false;
                return;
            }

            filteredHeader?.RemoveFilter();

            _contextMenuStrip_DataGridView.Hide();

            _bindingSource.ResetBindings(false);
        }

        Point mousePos = new Point(100, 100);
        void ToolStripTextBox_SearchBy_MouseHover(object sender, EventArgs e)
        {
            _toolTipContextMenu.SetToolTip(toolStripTextBox_SearchBy.TextBox, "");
            _toolTipContextMenu.Hide(toolStripTextBox_SearchBy.TextBox);

            mousePos = new Point(toolStripTextBox_SearchBy.Bounds.Right, toolStripTextBox_SearchBy.Bounds.Bottom);

            string ColumnNameType = ColumnNameMouseRightClick + " type " + ColumnTypeMouseRightClick + "\r\n";
            string tipString = ColumnNameType +
                                "Used wildcards character * .\r\n" +
                                "It can be at the beginning '*value',\r\n" +
                                "at the end 'value*', or at both '*value*'.\r\n" +
                                "For more information, Help-> Filter expression syntax.";

            string tipNumeric = ColumnNameType +
                                "You can use these operators = <> < <= > >=.\r\n" +
                                "Equal, not equal, less, greater operators are used to\r\n" +
                                "include only values that suit to a comparison expression.\r\n" +
                                "For more information, Help-> Filter expression syntax.";


            string tipBool = ColumnNameType +

                                "Used true or false.\r\n" +
                                "It can be Y for true and N for false,\r\n" +
                                "For more information, Help-> Filter expression syntax.";

            string tip = "";
            if (ColumnTypeMouseRightClick.Contains("String"))
                tip = tipString;
            if (ColumnTypeMouseRightClick.Contains("Int32"))
                tip = tipNumeric;
            if (ColumnTypeMouseRightClick.Contains("Bool"))
                tip = tipBool;


            ShowToolTip("Remember ....", toolStripTextBox_SearchBy.TextBox, tip, mousePos);

        }

        void ToolStripTextBox_SearchBy_MouseLeave(object sender, EventArgs e)

        {
            toolStripTextBox_SearchBy.MouseLeave -= ToolStripTextBox_SearchBy_MouseLeave;
            //   toolStripTextBox_SearchBy.Text = "";
            //   _contextMenuStrip.Close();
            //   ActiveFilter = "";


            _toolTipContextMenu.Hide(toolStripTextBox_SearchBy.TextBox);

        }

        bool hitEnter;
        void ToolStripTextBox_SearchBy_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                hitEnter = true;
                _toolTipContextMenu.Hide(toolStripTextBox_SearchBy.TextBox);
                toolStripTextBox_SearchBy.MouseLeave -= ToolStripTextBox_SearchBy_MouseLeave;
                toolStripTextBox_SearchBy.Text = "Search by...";
                _contextMenuStrip_DataGridView.Close();

                return;
            }

            #region"Format filter base column type."
            // Save the toolStripTextBox_SearchBy contends into the objet.
            filteredHeader.FilterStringBase = toolStripTextBox_SearchBy.Text;

            switch (ColumnTypeMouseRightClick)
            {
                case "String":
                    {                                                    // MyCode.EscapeLikeValue(toolStripTextBox_SearchBy.Text));
                        ActiveFilter = string.Format("{0} LIKE '{1}*'", ColumnNameMouseRightClick, toolStripTextBox_SearchBy.Text);
                        break;
                    }
                case "Int32":
                    {
                        ActiveFilter = FilterInt32Sanitizer(toolStripTextBox_SearchBy.Text);
                        break;
                    }
                case "Boolean":
                    {
                        if ("T t Y y 1 true True TRUE".Contains(toolStripTextBox_SearchBy.Text))
                        {
                            ActiveFilter = string.Format("{0} = {1}", ColumnNameMouseRightClick, 1);
                            break;
                        }

                        if ("F f N n 0 false False FALSE".Contains(toolStripTextBox_SearchBy.Text))
                        {
                            ActiveFilter = string.Format("{0} = {1}", ColumnNameMouseRightClick, 0);
                            break;
                        }

                        break;
                    }
            }
            #endregion"Format filter base column type."           
        }

        void ToolStripTextBox_SearchBy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                return;

            //Keys.Home, Keys.End, Keys.Left, Keys.Right, Keys.Divide, Keys.Multiply are valid keys.

            var NoValidKeys = new List<Keys>
            {
                Keys.PageUp, Keys.PageDown, Keys.Up, Keys.Down,  Keys.Insert, Keys.Delete, Keys.Tab
            };

            if (NoValidKeys.Contains(e.KeyCode))
            {
                e.Handled = true;
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Attention, check if the numeric keypad is activate!",
                                           @"Invalid characters have been wrote.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }

            var NoValidFxx = new List<Keys>
            {
                Keys.F1, Keys.F2, Keys.F3, Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, Keys.F10,
                Keys.F11,Keys.F12,Keys.F13,Keys.F14,Keys.F15,Keys.F16,Keys.F17,Keys.F18,Keys.F19,Keys.F20
            };

            if (NoValidFxx.Contains(e.KeyCode))
            {
                e.Handled = true;
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Attention, in Search mode the function key F1 to F20 are not valid.",
                                           @"Invalid function keys have been hit.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return;
            }
        }

        FilteredHeaderCell filteredHeader;
        bool MouseRightDone;
        /// <summary>
        /// Column name where the mouse pointer is,
        /// <para></para>
        /// or column name where the mouse right click hit.
        /// </summary>
        string ColumnNameMouseRightClick = "";
        /// <summary>
        /// Column type where the mouse pointer is,
        /// <para></para>
        /// or column type where the mouse right click hit.
        /// </summary>
        string ColumnTypeMouseRightClick = "";
        void ToolStripTextBox_SearchBy_Click(object sender, EventArgs e)
        {
            if (MouseRightDone)
                return;

            if (_dataGridView.LatestMouseOverColumnHeaderCell == null)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is CurrentColumnHeaderCell == null",
                                           @"Process SearchByClick(), It has detected a null reference.",
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
            SuspendLayout();

            toolStripTextBox_SearchBy.Text = toolStripMenuItem_SearchBy.Text;
            _contextMenuStrip_DataGridView.Items.Insert(0, toolStripTextBox_SearchBy);

            RemoveAllToolStripBut(toolStripTextBox_SearchBy);
            ProcessSearchByClick();

            MouseRightDone = true;

            ColumnNameMouseRightClick = _dataGridView.CurrentColumnActive.Name;

            ColumnTypeMouseRightClick = _dataGridView.CurrentColumnActive.ValueType.Name;
            toolStripTextBox_SearchBy.MouseLeave += ToolStripTextBox_SearchBy_MouseLeave;

            ResumeLayout();

            toolStripTextBox_SearchBy.Focus();
        }

        void ToolStripMenuItem_SearchBy_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                return;

            MouseRightDone = false;
            ToolStripTextBox_SearchBy_Click(sender, e);
        }

        void ProcessSearchByClick()
        {
            try
            {
                if (_dataGridView.ActiveFilterCollection.ContainsKey(_dataGridView.HitTestData.ColumnIndex))
                {
                    //If in this column a filter was active, show it's value.
                    filteredHeader = _dataGridView.ActiveFilterCollection[_dataGridView.HitTestData.ColumnIndex];
                    toolStripTextBox_SearchBy.Text = filteredHeader.FilterStringBase;
                }
                else
                {
                    var xCoordinate = GetLeftmostColumnHeaderXCoordinate(_dataGridView.Columns[_dataGridView.HitTestData.ColumnIndex].DisplayIndex);
                    var yCoordinate = GetTopmostColumnHeaderYCoordinate(_dataGridView.HitTestData.ColumnX, _dataGridView.HitTestData.RowY);
                    var columnWidth = _dataGridView.DisplayedColumns.First(col => col.DisplayIndex == _dataGridView.Columns[_dataGridView.HitTestData.ColumnIndex].DisplayIndex).Width;
                    var columnHeight = GetColumnHeight(yCoordinate);

                    var columnRegion = new Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight);

                    //If this column has not active filter, create a new one....
                    //filteredHeader = new FilteredHeaderCell(_dataGridView, _dataGridView.ColumnClearFilterIndicator, columnRegion);
                    filteredHeader = new FilteredHeaderCell(_dataGridView, _dataGridView.ColumnClearFilterIndicator);
                    filteredHeader.RemovedFilterEvent += FilteredHeader_RemovedFilterEvent;
                    toolStripTextBox_SearchBy.Text = "";
                }

                if (_dataGridView.ActiveFilterCollection.Count > 1)
                {
                    foreach (FilteredHeaderCell headerCell in _dataGridView.ActiveFilterCollection.Values)
                    {
                        // if (headerCell.ColumnIndex == filteredHeader.ColumnIndex)
                        //     continue;

                        var filter = new ToolStripTextBoxOwnerDraw
                        {
                            Text = headerCell.FilterString,
                            BackColor = Color.LightGoldenrodYellow,
                            BorderSize = 1,
                            BorderColor = Color.Gray,
                            Size = new Size(170, 22)
                        };
                        filter.ToolStripTextBox.BorderStyle = BorderStyle.None;
                        filter.ToolStripTextBox.Text = headerCell.FilterString;
                        filter.ToolStripTextBox.BackColor = Color.LightGoldenrodYellow;
                        filter.ToolStripTextBox.Font = new Font("Segoe", 9);
                        filter.Dock = DockStyle.Top;

                        _contextMenuStrip_DataGridView.Items.Add(filter);
                    }
                }
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                           Settings.Default.ProcessSearchByClickHasgeneratedanerror,
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void RemoveAllToolStripBut(ToolStripItem toolStripItem)
        {
            var itemsToRemove = new List<ToolStripItem>();
            foreach (ToolStripItem menuStrip in _contextMenuStrip_DataGridView.Items)
            {
                if (menuStrip.Name.Contains(toolStripItem.Name))
                    continue;

                itemsToRemove.Add(menuStrip);
            }

            foreach (ToolStripItem itemRemove in itemsToRemove)
            {
                _contextMenuStrip_DataGridView.Items.Remove(itemRemove);
            }
        }

        void FilteredHeader_RemovedFilterEvent(object sender, Custom_Events_Args.RemovedFilter_EventArgs e)
        {
            UpDateActiveFilter();
        }

        void UpDateActiveFilter()
        {
            try
            {
                _bindingSource.SuspendBinding();

                #region"CustomExternalFilter"

                if (!string.IsNullOrEmpty(_customExternalFilter))
                {
                    if (!string.IsNullOrEmpty(ActiveFilter))
                    {
                        _bindingSource.Filter = _customExternalFilter + " AND " + ActiveFilter;
                        toolStripLabel_Help.Text = @"Right Click and select 'Remove this Filter' to clear that selection.";
                    }
                    else
                    {
                        _bindingSource.Filter = _customExternalFilter;
                        toolStripLabel_Help.Text = @"This is an external Filter, there is no action to clear that selection.";
                    }

                    toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in " + _bindingSource.Filter;
                    _bindingSource.ResumeBinding();
                    return;
                }

                #endregion"CustomExternalFilter"

                #region"No external filter, process if internal exist."

                if (!string.IsNullOrEmpty(ActiveFilter))
                {
                    _bindingSource.Filter = ActiveFilter;
                    toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in " + _bindingSource.Filter;
                    toolStripLabel_Help.Text = @"Right Click and select 'Remove this Filter' to clear that selection.";
                }
                else
                {
                    _bindingSource.Filter = null;
                    toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in the entire DataBase";
                    toolStripLabel_Help.Text = @"There is no Filter to clear at this moment.";
                }

                #endregion"No external filter, process if internal exist."

                _bindingSource.ResumeBinding();
            }
            catch (Exception error)
            {
                using (var form1 = new Form { TopMost = true })
                {
                    MessageBox.Show(form1, @"Message related to this error is " + error.Message,
                                           Settings.Default.SearchEngineHasGeneratedAnError,
                                           MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        string FilterInt32Sanitizer(string filterText)
        {
            string bindingFilter;
            string toSanitizer = filterText.Trim();

            if (toSanitizer.Length == 0)
            {
                bindingFilter = "";
                return bindingFilter;
            }

            /*
			"You can use these operators = <> < <= > >=.\r\n" +
			"Equal, not equal, less, greater operators are used to\r\n" +
			"include only values that suit to a comparison expression.\r\n" +
			"For more information, Help-> Filter expression syntax.";
			 */
            string numericOperator = "= <> < <= > >=";
            if (numericOperator.Contains(toSanitizer.Substring(0, 1)))
            {
                string PossibleOperator = toSanitizer.Substring(0, 1);
                string numericValue = toSanitizer.Replace(PossibleOperator, "").TrimStart();

                if (numericValue.Length == 0)
                {
                    bindingFilter = "";
                    return bindingFilter;
                }


                if (numericOperator.Contains(numericValue.Substring(0, 1)))

                {
                    PossibleOperator += numericValue.Substring(0, 1);
                    numericValue = numericValue.Replace(numericValue.Substring(0, 1), "").TrimStart();

                    if (numericValue.Length == 0)
                    {
                        bindingFilter = "";
                        return bindingFilter;
                    }

                    if (IsNumeric(numericValue))
                    {
                        bindingFilter = string.Format("{0} {1}", ColumnNameMouseRightClick, PossibleOperator + " " + numericValue);
                        return bindingFilter;
                    }
                    else
                    {
                        bindingFilter = "";
                        return bindingFilter;
                    }
                }

                if (IsNumeric(numericValue))
                {
                    bindingFilter = string.Format("{0} {1}", ColumnNameMouseRightClick, PossibleOperator + " " + numericValue);
                    return bindingFilter;
                }
                else
                {
                    bindingFilter = "";
                    return bindingFilter;
                }

            }
            else
            {
                if (IsNumeric(toSanitizer.TrimStart()))
                {
                    bindingFilter = string.Format("{0} = {1}", ColumnNameMouseRightClick, Get_String.EscapeLikeValue(toSanitizer));
                    return bindingFilter;
                }
                else
                {
                    bindingFilter = "";
                    return bindingFilter;
                }
            }
        }

        /// <summary>
        /// Test if the string is numeric,
        /// if false show a Warning .... tooltip.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool IsNumeric(string text)
        {
            if (Regex.IsMatch(text, "^\\d+$"))
            {
                if (_toolTipContextMenu.ToolTipTitle.Contains("Warning ...."))
                {
                    _toolTipContextMenu.ToolTipTitle = "";
                    _toolTipContextMenu.SetToolTip(toolStripTextBox_SearchBy.TextBox, "");
                    _toolTipContextMenu.Hide(toolStripTextBox_SearchBy.TextBox);
                }

                return true;
            }

            string tip = ColumnNameMouseRightClick + " type is Numeric\r\n" +
                                "Used only numeric characters.\r\n" +
                                "It can be negative or positive value,\r\n" +
                                "For more information, Help-> Filter expression syntax.";

            if (_toolTipContextMenu.ToolTipTitle.Contains("Warning ...."))
                return false;

            ShowToolTipWarning(toolStripTextBox_SearchBy.TextBox, tip, mousePos);
            return false;
        }



        void Tool_strip_menu_item_frozenuntil_here_click(object sender, EventArgs e)

        {
            _dataGridView.CurrentColumnActive.Frozen = !_dataGridView.CurrentColumnActive.Frozen;
        }

        void Tool_strip_menu_item_hidethis_column_click(object sender, EventArgs e)
        {
            if (!ToolStripMenuItem_Columns.DropDownItems.Contains(toolStripMenuItem_Show_all_hide))
                ToolStripMenuItem_Columns.DropDownItems.Add(toolStripMenuItem_Show_all_hide);

            HideThisColumn(_dataGridView.CurrentColumnActive);

            IsMouseDrivenEvent = true;
            SaveUserSetting();
        }

        void Tool_strip_menu_item_hide_all_to_tha_righ_click(object sender, EventArgs e)
        {
            while (_dataGridView.ColumnCount > _dataGridView.CurrentColumnActive.DisplayIndex)
            {
                _dataGridView.CurrentColumnActive = _dataGridView.Columns.GetNextColumn(_dataGridView.CurrentColumnActive,
                                                                           DataGridViewElementStates.Displayed,
                                                                           DataGridViewElementStates.None);

                if (_dataGridView.CurrentColumnActive == null)
                    return;


                HideThisColumn(_dataGridView.CurrentColumnActive);

            }

            NeedSaveData = true;
            IsMouseDrivenEvent = true;
        }

        void Tool_strip_menu_item_show_all_hide_click(object sender, EventArgs e)

        {

            foreach (ColumnSetting columnSetting in SettingColumns)
            {
                if (!columnSetting.VisibleSystemSetting)
                {
                    _dataGridView.Columns[columnSetting.Name].Visible = false;
                    continue;
                }

                _dataGridView.Columns[columnSetting.Name].Visible = true;
            }


            ToolStripMenuItem_Columns.DropDownItems.Clear();

            //ToolStripMenuItem_Columns.DropDownItems.Add(toolStripMenuItem_Show_all_hide);
            ToolStripMenuItem_Columns.DropDownItems.Add(ToolStripMenuItem_Hide_all_to_tha_righ);

            IsMouseDrivenEvent = true;
            SaveUserSetting();
        }

        /// <summary>
        /// Show the column name clicked in Columns Menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Tool_strip_menu_item_columns_drop_down_item_clicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name.Contains("ToolStripMenuItem_Hide_all_to_tha_righ"))
                return;

            if (e.ClickedItem.Name.Contains("toolStripMenuItem_Show_all_hide"))
                return;

            if (_dataGridView != null)
                if (_dataGridView.Columns.Contains(e.ClickedItem.Name))
                {
                    _dataGridView.Columns[e.ClickedItem.Name].Visible = true;

                    IsMouseDrivenEvent = true;
                    SaveUserSetting();
                }

            ToolStripMenuItem_Columns.DropDownItems.Remove(e.ClickedItem);
        }

        void Tool_strip_menu_item_group_by_this_column_click(object sender, EventArgs e)
        {
            if (_dataGridView == null && _dataGridView.Columns.Count <= 0)
                return;

            if (_dataGridView.LastColumnActive != null)
                _dataGridView.Columns[_dataGridView.LastColumnActive.Name].Visible = true;

            _dataGridView.SetGroupOn();
            _dataGridView.CollapseAll();

            _dataGridView.LastColumnActive = _dataGridView.CurrentColumnActive;

            _dataGridView.Columns[_dataGridView.CurrentColumnActive.Name].Visible = true;
        }

        void Tool_strip_menu_item_remove_group_click(object sender, EventArgs e)
        {
            _dataGridView.SetGroupOn();
        }

        void Tool_strip_menu_item_collase_all_click(object sender, EventArgs e)
        {
            _dataGridView.CollapseAll();
        }

        void Tool_strip_menu_item_expand_all_click(object sender, EventArgs e)
        {
            _dataGridView.ExpandAll();
        }

        void Tool_strip_menu_item_filterbythis_cell_click(object sender, EventArgs e)
        {
            if (_dataGridView.CurrentCellMouseHover.Value == null)
            {
                ActiveFilter = _dataGridView.CurrentColumnActive.HeaderText + " IS NULL";
                return;
            }

            if (_dataGridView.CurrentColumnActive.ValueType.FullName == "System.String")
            {
                string cellValue = _dataGridView.CurrentCellMouseHover.Value + "";

                ActiveFilter = _dataGridView.CurrentColumnActive.HeaderText + " like '*" + Get_String.EscapeLikeValue(cellValue) + "*'";
            }

            if (_dataGridView.CurrentColumnActive.ValueType.FullName == "System.Int32")
            {
                ActiveFilter = _dataGridView.CurrentColumnActive.HeaderText + " = " + _dataGridView.CurrentCellMouseHover.Value;
            }
        }

        /// <summary>
        /// Clear the information and help in bindingNavigator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Tool_strip_menu_item_removethis_filter_click(object sender, EventArgs e)
        {
            List<FilteredHeaderCell> filterToRemove = new List<FilteredHeaderCell>();

            foreach (KeyValuePair<int, FilteredHeaderCell> filterObject in _dataGridView.ActiveFilterCollection)
            {
                FilteredHeaderCell filter = filterObject.Value;
                filterToRemove.Add(filter);
            }

            foreach (FilteredHeaderCell filter in filterToRemove)
                filter.RemoveFilter();
        }

        void Tool_strip_menu_item_find_by_click(object sender, EventArgs e)
        {
            if (_dataGridView.CurrentCell == null)
                return;

            var findRemplace = new Find_and_Remplace(_dataGridView.CurrentRowIndex, _dataGridView.CurrentRowActived, _dataGridView.CurrentColumnActive.Index,
                                                     _dataGridView.CurrentColumnActive, _dataGridView.CurrentCellMouseHover, "Find");

            findRemplace.Find_Remplace_Execute += Find_remplace_find_remplace_execute;
                                    
            findRemplace.StartPosition = FormStartPosition.CenterScreen;
            findRemplace.TopMost = true;
            findRemplace.ShowDialog();
        }

        void ToolStripMenuItem_Replace_by_Click(object sender, EventArgs e)
        {
            if (_dataGridView.CurrentCell == null)
                return;

            var findRemplace = new Find_and_Remplace(_dataGridView.CurrentRowIndex, _dataGridView.CurrentRowActived, _dataGridView.CurrentColumnActive.Index,
                                                     _dataGridView.CurrentColumnActive, _dataGridView.CurrentCellMouseHover, "Replace");

            findRemplace.Find_Remplace_Execute += Find_remplace_find_remplace_execute;
                        
            findRemplace.StartPosition = FormStartPosition.CenterScreen;
            findRemplace.TopMost = true;
            findRemplace.ShowDialog();
        }

        void ToolStripMenuItem_Fill_by_Click(object sender, EventArgs e)
        {
            if (_dataGridView.CurrentCell == null)
                return;

            var findRemplace = new Find_and_Remplace(_dataGridView.CurrentRowIndex, _dataGridView.CurrentRowActived, _dataGridView.CurrentColumnActive.Index,
                                                     _dataGridView.CurrentColumnActive, _dataGridView.CurrentCellMouseHover, "Fill");

            findRemplace.Find_Remplace_Execute += Find_remplace_find_remplace_execute;

            findRemplace.StartPosition = FormStartPosition.CenterScreen;
            findRemplace.TopMost = true;
            findRemplace.ShowDialog();
        }

        Find_and_Remplace.Find_Remplace_Execute_EventArgs eventArgFill;
        /// <summary>
        /// Find / Replace windows tools genera this events when a customer click Execute.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Find_remplace_find_remplace_execute(object sender, Find_and_Remplace.Find_Remplace_Execute_EventArgs e)
        {
            eventArgFill = e;

            string filter;

            if (_bindingSource.Filter == null)
                filter = e.Filterby;
            else
                if (e.Filterby != null)
                    filter = e.Filterby + " AND " + _bindingSource.Filter;
                else
                    filter = _bindingSource.Filter;

            #region"Find"

            if (e.IsFind)
            {
                _bindingSource.SuspendBinding();

                if (e.IsRow)
                {
                    _bindingSource.ResumeBinding();
                    return;
                }

                if (e.IsColumn)

                {
                    using (var dv = new DataView(GetTable(), filter, "Status DESC", DataViewRowState.CurrentRows))
                    {
                        if (dv.Count == 0)
                        {
                            _bindingSource.ResumeBinding();
                            return;
                        }

                        foreach (DataRowView row in dv)
                        {
                            row["Status"] = "Selected(" + e.SelectColor.ToArgb() + ")";
                        }

                        _dataGridView.AreSelectedRows = true;
                        toolStripLabel_Information_Label.Text = @"You are selecting " + dv.Count + @" Rows in Column " + e.Filterby;
                        toolStripLabel_Help.Text = @"Riht Click and select 'UnSelect all Rows' to clear that selection.";
                    }

                    _dataGridView.Sort(_dataGridView.Columns["Status"], ListSortDirection.Descending);

                    _dataGridView.Refresh();

                    _bindingSource.ResumeBinding();
                    return;
                }

                if (e.IsDataBase)
                {
                    _bindingSource.ResumeBinding();
                    return;
                }

                _bindingSource.ResumeBinding();
            }
            #endregion

            #region"Replace"

            if (e.IsReplace)
            {
                _bindingSource.SuspendBinding();

                if (e.IsRow)
                {
                    _bindingSource.ResumeBinding();
                    return;
                }

                if (e.IsColumn)
                {
                    var sort = _dataGridView.CurrentColumnActive.Name + " Desc";

                    using (var dv = new DataView(GetTable(), filter, sort, DataViewRowState.CurrentRows))
                    {
                        if (dv.Count == 0)
                        {
                            _bindingSource.ResumeBinding();
                            return;
                        }

                        int dataViewColumnIndex = dv.Table.Columns.IndexOf(e.CurrentColumnActive.Name);

                        switch (e.Match_)
                        {
                            case " IS NULL":
                                {
                                    foreach (DataRowView row in dv)
                                    {
                                        row[dataViewColumnIndex] = e.Replaceby;
                                    }
                                    break;
                                }
                            case " < ":
                                {
                                    foreach (DataRowView row in dv)
                                    {
                                        row[dataViewColumnIndex] = e.Replaceby;
                                    }
                                    break;
                                }
                            case " > ":
                                {
                                    foreach (DataRowView row in dv)
                                    {
                                        row[dataViewColumnIndex] = e.Replaceby;
                                    }
                                    break;
                                }
                            case " <> ":
                                {
                                    foreach (DataRowView row in dv)
                                    {
                                        row[dataViewColumnIndex] = e.Replaceby;
                                    }
                                    break;
                                }
                            case " >= AND <= ":
                                {
                                    foreach (DataRowView row in dv)
                                    {
                                        row[dataViewColumnIndex] = e.Replaceby;
                                    }
                                    break;
                                }
                            default:
                                {
                                    foreach (DataRowView row in dv)
                                    {
                                        string _data = row[dataViewColumnIndex].ToString();
                                        _data = _data.Replace(e.Searchby, e.Replaceby);
                                        row[dataViewColumnIndex] = _data;
                                        //    row.EndEdit();
                                    }
                                    break;
                                }
                        }

                        _bindingSource.EndEdit();
                    }
                }

                if (e.IsDataBase)
                {
                    _bindingSource.ResumeBinding();
                    return;
                }

                _bindingSource.ResumeBinding();
            }

            #endregion;

            #region"Fill"

            if (e.IsFill)
            {
                if (e.IsRow)
                {
                    _bindingSource.ResumeBinding();
                    return;
                }

                if (e.IsColumn)
                {
                    _bindingSource.SuspendBinding();

                    Thread writeSetupThread = new Thread(FillThisColumn);
                    writeSetupThread.Start();

                    _bindingSource.ResumeBinding();
                }

                if (e.IsDataBase)
                {
                    _bindingSource.ResumeBinding();
                    return;
                }
            }
            #endregion
        }

        void FillThisColumn()
        {
            try
            {
                foreach (DataRowView row in _bindingSource)
                {
                    row[eventArgFill.ColumnName] = eventArgFill.Replaceby;
                }
            }
            catch (Exception error)
            {
                string err = error.Message;
            }
        }

        void HideThisColumn(DataGridViewColumn columnToHide)
        {
            var hideColumn = new ToolStripMenuItem
            {
                Size = ToolStripMenuItem_HideThisColumn.Size,
                BackColor = Color.Ivory,
                Name = columnToHide.Name,
                Text = columnToHide.HeaderText
            };

            ToolStripMenuItem_Columns.DropDownItems.Add(hideColumn);

            columnToHide.Visible = false;
        }


        DataTable GetTable()
        {
            DataTable table = new DataTable();

            var dataSourceType = _bindingSource.DataSource.GetType();

            if (dataSourceType.BaseType == typeof(DataSet))
                table = ((DataSet)_bindingSource.DataSource).Tables[_bindingSource.DataMember];

            if (dataSourceType.BaseType == typeof(DataTable))
                table = (DataTable)_bindingSource.DataSource;

            return table;
        }

        /// <summary>
        /// Custom Filter, uses the same dialog 'Find / Replace windows tools', call the second constructor.
        /// This constructor changed the name to Filter and remove Select any color. Wired the event to diferent
        /// procedure, in this case - Filter_execute.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Tool_strip_menu_item_custom_filter_click(object sender, EventArgs e)
        {
            if (_dataGridView.CurrentCell == null)
                return;

            using (var findRemplace = new Find_and_Remplace(_dataGridView.CurrentRowIndex, _dataGridView.CurrentRowActived,
                _dataGridView.CurrentColumnActive.Index, _dataGridView.CurrentColumnActive, _dataGridView.CurrentCellMouseHover, "Filter"))
            {

                findRemplace.Find_Remplace_Execute += Filter_execute;

                findRemplace.Location = new Point(MousePosition.X + _dataGridView.CurrentCell.ContentBounds.Width,
                                                MousePosition.Y - 300 - _dataGridView.CurrentCell.ContentBounds.Height);

                findRemplace.ShowDialog();
            }
        }

        /// <summary>
        /// Filter Tools, this will filter the rows and only show the rows that meet the qualifications.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Filter_execute(object sender, Find_and_Remplace.Find_Remplace_Execute_EventArgs e)
        {
            if (e.IsRow)
            {
                return;
            }

            if (e.IsColumn)
            {
                ActiveFilter = e.Filterby;
                return;
            }

            if (e.IsDataBase)
            {
                return;
            }
        }

        /// <summary>
        /// Unselect all rows contains Status LIKE '*Selected*'"
        /// Remove the selected background color in its rows.
        /// </summary>
        public void UnSelectRow()
        {
            Tool_strip_menu_item_un_select_all_rows_click(new object(), new EventArgs());
        }

        void Tool_strip_menu_item_un_select_all_rows_click(object sender, EventArgs e)
        {
            _dataGridView.Refresh();
            _dataGridView.AreSelectedRows = false;
            toolStripLabel_Information_Label.Text = @"You are selecting " + _bindingSource.Count + @" Rows in " + _bindingSource.Filter;
            toolStripLabel_Help.Text = Settings.Default.ThisIsAnExternalFilter;
        }

        void ToolStripMenuItem_AutoSizeMode_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // Set true, the change was by mouse, need save the setting;
            NeedSaveData = true;

            switch (e.ClickedItem.Text)
            {
                case "Fill the display":
                    {
                        _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                        return;
                    }
                case "All Cells":
                    {
                        _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                        return;
                    }
                case "Column Header":
                    {
                        _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                        return;
                    }
                case "Displayed Cells":
                    {
                        _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                        return;
                    }
                case "All Cells Except Header":
                    {
                        _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader;
                        return;
                    }
                case "Displayed Cells Except Header":
                    {
                        _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCellsExceptHeader;
                        return;
                    }
                case "None":
                    {
                        _dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                        return;
                    }
            }
            IsMouseDrivenEvent = true;
        }

        void ToolStripMenuItem_Setting_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            List<string> _keytoDelete = new List<string>(0);
            DialogResult result;


            switch (e.ClickedItem.Text)

            {
                case "Clear Columns":
                    {
                        foreach (KeyValuePair<string, int> pair in ColumnState)
                        {
                            if (pair.Key.Contains(_controlName))
                                _keytoDelete.Add(pair.Key);
                        }

                        if (_keytoDelete.Count != 0)
                        {
                            result = MessageBox.Show("Cleared setting of " + _keytoDelete.Count + " Columns",
                                            "Clear Column Setting",
                                            MessageBoxButtons.YesNoCancel,
                                            MessageBoxIcon.Exclamation);

                            if (result == DialogResult.Yes)
                            {
                                foreach (string _key in _keytoDelete)
                                    ColumnState.Remove(_key);
                            }
                            Settings.Default.ColumnStateWidth = Get_String.GetString(ColumnState);
                            Settings.Default.Save();
                            return;
                        }

                        result = MessageBox.Show("Do you want clear all saved setting",
                                                              "Clear All Setting",
                                                              MessageBoxButtons.YesNoCancel,
                                                              MessageBoxIcon.Stop);
                        if (result == DialogResult.Yes)
                            ColumnState.Clear();

                        Settings.Default.ColumnStateWidth = Get_String.GetString(ColumnState);
                        Settings.Default.Save();
                        return;
                    }
            }
        }

        void ToolStripMenuItem_Alignment_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (_dataGridView.CurrentColumnIndex == -1)
                return;

            NeedSaveData = true;
            DataGridViewCellStyle customCellStyle = new DataGridViewCellStyle(_dataGridView.Columns[_dataGridView.CurrentColumnIndex].DefaultCellStyle);

            switch (e.ClickedItem.Text)
            {
                case "Left <--":
                    {
                        customCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        _dataGridView.CurrentColumnActive.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        _dataGridView.CurrentColumnActive.DefaultCellStyle = customCellStyle;
                        return;
                    }
                case "  --> Center <--":
                    {
                        customCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        _dataGridView.CurrentColumnActive.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        _dataGridView.CurrentColumnActive.DefaultCellStyle = customCellStyle;
                        return;
                    }
                case "             --> Right":
                    {
                        customCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        _dataGridView.CurrentColumnActive.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                        _dataGridView.CurrentColumnActive.DefaultCellStyle = customCellStyle;
                        return;
                    }
            }
            IsMouseDrivenEvent = true;
        }

        #endregion "End ContextMenuStrip_DataGridView"

        #region"Tools Strip"

        void InitializeToolStrip()
        {
            bindingNavigatorDeleteItem.Enabled = false;
        }

        void ToolStripButtonSaveClick(object sender, EventArgs e)
        {
            NeedSaveData = false;

            if (_dataGridView.CurrentRow != null)
            {
                DataRowView row = (DataRowView)_dataGridView.CurrentRow.DataBoundItem;
                DataRow rowData = row.Row;
                rowData.EndEdit();
                _bindingSource.EndEdit();
            }

            Save_Requested_EventArgs save_Requested_EventArgs = new Save_Requested_EventArgs()
            {
                SaveEvent = NotificationEvents.DataBaseUpDated,
                DataTableName = _dataTable.TableName
            };

            On_Save_Requested(save_Requested_EventArgs);

            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " tool_strip_button_save hit by the mouse at " + DateTime.Now)
                    }));
        }

        void ToolStripButtonRefreshClick(object sender, EventArgs e)
        {
            On_Refresh_Requested(new Refresh_Requested_EventArgs(_bindingSource.Filter));


            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>

                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " tool_strip_button_refresh hit by the mouse at " + DateTime.Now)
                    }));
        }

        void ToolStripMenuItemBarGraphicsClick(object sender, EventArgs e)
        {
            if (_dataGridView.CurrentColumnActive.ValueType.FullName == "System.Double")
            {
                _dataGridView.CurrentColumnActive.CellTemplate = new DataGridViewBarGraphCell();
                _dataGridView.DataSource = _bindingSource;
                _bindingSource.ResetBindings(true);
                //  _dataGridView.Columns.RemoveAt(_currentColumnIndex);
                //  _dataGridView.Columns.Add(new DataGridViewBarGraphColumn());

            }
        }

        void ToolStripButtonPrintClick(object sender, EventArgs e)
        {
            DataTable table = new DataTable();

            DataRow datarow;

            foreach (DataGridViewColumn column in _dataGridView.Columns)
            {
                if (!column.Visible)
                    continue;

                table.Columns.Add(column.HeaderText, typeof(string));
            }

            foreach (DataGridViewRow row in _dataGridView.Rows)
            {
                if (row.IsNewRow)
                    continue;

                datarow = table.NewRow();

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (!cell.Visible || cell.Value == null)
                        continue;

                    datarow[cell.OwningColumn.Name] = cell.Value.ToString();
                }

                datarow.EndEdit();
                table.Rows.Add(datarow);
            }

            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " tool_strip_button_print hit by the mouse at " + DateTime.Now)
                    }));

            //  MyStuff11net.ListViewPrint _myListviewPrint = new ListViewPrint(_dataGridView);

            //   ListViewPrint _myListviewPrint = new ListViewPrint(table);

            //	_myListviewPrint.ShowDialog();

            table.Dispose();
            //	_myListviewPrint.Dispose();
        }

        void ToolStripMenuItemExportToExcellClick(object sender, EventArgs e)
        {
            try
            {
                On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " toolStripMenuItem_ExportToExcell hit by the mouse at " + DateTime.Now)
                    }));
                //     ExportToExcell _exportToExcell = new ExportToExcell();      

                //     _exportToExcell.ExcelFormattingStyle = _exportToExcell.GetExcelFormatFromScreen();

                //Pass your Dataset and Specify the style..
                //     _exportToExcell.ExportDataToExcel(GetDataSet(), _exportToExcell.GetExportStyle());
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error in Export to Excell " + ee.Message, "Error in Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void toolStripMenuItemExportToCSV_Click(object sender, EventArgs e)
        {
            try
            {
                On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " toolStripMenuItem_ExportToCSV hit by the mouse at " + DateTime.Now)
                    }));

                //  ExportToCSV _exportToCSV = new ExportToCSV(_dataGridView);
                //  _exportToCSV.ShowDialog();

                //  _exportToCSV.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error in Export to CSV " + ee.Message, "Error in Export to CSV", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void toolStripMenuItemExportToTXT_Click(object sender, EventArgs e)
        {
            try
            {
                On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " toolStripMenuItem_ExportToTXT hit by the mouse at " + DateTime.Now)
                    }));

                //   ExportToTXT _exportToTXT = new ExportToTXT(_dataGridView);
                //   _exportToTXT.ShowDialog();

                //   _exportToTXT.Dispose();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error in Export to TXT " + ee.Message, "Error in Export to TXT", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void toolStripMenuItemExportToWebPage_Click(object sender, EventArgs e)
        {
            try
            {
                On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " toolStripMenuItem_ExportToWebPage hit by the mouse at " + DateTime.Now)
                    }));

                //	ExporToWebPage _exportToWebPage = new ExporToWebPage(_dataGridView);
                //	_exportToWebPage.ShowDialog();
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error in Export to WebPage " + ee.Message, "Error in Export to WebPage.",
                                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void ToolStripMenuItemCustomizedClick(object sender, EventArgs e)
        {

        }

        void TestToolStripMenuItemClick(object sender, EventArgs e)
        {
            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " test_tool_strip_menu_item hit by the mouse at " + DateTime.Now)
                    }));

            var test = new DataGridViewBarGraphColumn();
            test.HeaderText = "Test Graph";
            test.Name = "Test Graph";
            test.DataPropertyName = _dataGridView.CurrentColumnActive.DataPropertyName;
            test.DefaultHeaderCellType = _dataGridView.CurrentColumnActive.DefaultHeaderCellType;

            //    _dataGridView.Columns.RemoveAt(_currentColumnIndex);

            _dataGridView.Columns.Insert(_dataGridView.CurrentColumnIndex, test);
        }

        void BindingNavigatorAddNewItemClick(object sender, EventArgs e)
        {
            // Removed the linked in BindingNavigator that raises the 'Add New Item' action.

            // Cancel the edit in binding-navigators AddNew click event.  
            // _bindingSource.CancelEdit(); //Specified argument was out of the range of valid values.

            OnBindingNavigatorAddNewItem_Event(e);
        }

        void BindingNavigatorDeleteItemMouseDown(object sender, MouseEventArgs e)
        {
            bindingNavigatorDeleteItem.Tag = true;
        }

        void BindingNavigatorDeleteItemClick(object sender, EventArgs e)
        {
            if (_bindingSource.Position == -1)
                return;

            // if DataTable do not contains column Status return.
            //if (!(((DataRowView)_bindingSource.Current).DataView.Table.Columns.Contains("Status")))
            //    return;

            if (CurrentRowStatus.Unerasable)
            {
                MessageBox.Show("Error, this row is marked as \"UNERASABLE\"",
                                "Unerasable row. Call a system manager to access this row",
                                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            On_UserDeletingRow(new DataGridViewRowCancelEventArgs(_dataGridView.CurrentRowActived));

            On_LogFileMessage(new Custom_Events_Args.LogFileMessageEventArgs(new List<string>
                    {
                        Tags.NewLine(""),
                        Tags.NewLineBold(_employeeName + " " + _employeeLastName),
                        Tags.NewLine(Name + " deleting a row by hit the bindingNavigatorDeleteItem by the mouse at " + DateTime.Now)
                    },
                     (DataRowView)_bindingSource.Current));

            _bindingSource.RemoveCurrent();

            bindingNavigatorDeleteItem.Enabled = false;
        }

        #endregion"Tools Strip"


        /// <summary>
        /// Utilized to print.
        /// </summary>
        /// <returns></returns>
        DataSet GetDataSet()
        {
            string stringMessage = "";

            DataSet dataSet = new DataSet("DataSetToExport");
            DataTable dataTable = new DataTable("TabletoExport");

            try
            {
                stringMessage = "DataGridViewColumn _column in _dataGridView.Columns";
                foreach (DataGridViewColumn column in _dataGridView.Columns)
                {
                    if (!column.Visible)
                        continue;

                    dataTable.Columns.Add(column.Name, column.ValueType);
                }

                stringMessage = "DataGridViewRow _row in _dataGridView.Rows";
                foreach (DataGridViewRow row in _dataGridView.Rows)
                {
                    DataRow dr = dataTable.NewRow();

                    if (row.IsNewRow)
                        continue;

                    stringMessage = "Process _row " + row.Index;
                    foreach (DataGridViewColumn column in _dataGridView.Columns)
                    {
                        if (!column.Visible)
                            continue;

                        stringMessage = "Process _row " + row.Index + " and " + column.Name;
                        if (column.ValueType == typeof(string))
                        {
                            if (row.Cells[column.Name].Value != DBNull.Value)
                            {
                                dr[column.Name] = row.Cells[column.Name].Value.ToString();
                                continue;
                            }
                        }

                        if (column.ValueType == typeof(int))
                        {
                            if (row.Cells[column.Name].Value != DBNull.Value && row.Cells[column.Name].Value != null)
                            {
                                dr[column.Name] = Convert.ToInt32(row.Cells[column.Name].Value.ToString());
                                continue;
                            }
                        }

                        if (column.ValueType == typeof(bool))
                        {
                            if (row.Cells[column.Name].Value != DBNull.Value)
                            {
                                if ((bool)row.Cells[column.Name].Value)
                                    dr[column.Name] = "true";
                                else
                                    dr[column.Name] = "false";
                            }
                        }
                    }

                    dr.EndEdit();
                    dataTable.Rows.Add(dr);
                }
                dataTable.EndInit();

            }
            catch (Exception error)
            {
                MessageBox.Show(@"Error in Export to Excell process. " + error.Message + stringMessage, @"DataGridView GetDataSet",
                                                                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }

            dataSet.Tables.Add(dataTable);
            return dataSet;
        }

        class DataGridViewExt : DataGridView
        {
            public DataGridViewExt()
            {
                InitializeProperties();
                SetupTimer();
            }

            void InitializeProperties()
            {
                #region Code stolen from designer

                AllowDrop = true;
                AllowUserToAddRows = false;
                AllowUserToDeleteRows = false;
                AllowUserToOrderColumns = true;
                AllowUserToResizeRows = false;
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
                EnableHeadersVisualStyles = false;
                MultiSelect = false;
                ReadOnly = true;
                RowHeadersVisible = false;
                SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                CellMouseDown += dataGridView1_CellMouseDown;
                DragOver += dataGridView1_DragOver;
                DragLeave += dataGridView1_DragLeave;
                DragEnter += dataGridView1_DragEnter;
                Paint += DataGridView1PaintSelection;
                Paint += dataGridView1_Paint_RowDivider;
                DefaultCellStyleChanged += DataGridView1DefaultcellStyleChanged;
                Scroll += DataGridView1Scroll;

                #endregion

                _ignoreSelectionChanged = false;
                OverallSelectionChanged += OnOverallSelectionChanged;
                _dividerBrush = new SolidBrush(Color.Red);
                _selectionPen = new Pen(Color.Blue);
                DividerHeight = 4;
                SelectionWidth = 3;
            }

            int? _predictedInsertIndex; //Index to draw divider at.  Null means no divider
            System.Windows.Forms.Timer _autoScrollTimer;
            int _scrollDirection;
            static DataGridViewRow _selectedRow;
            bool _ignoreSelectionChanged;
            static event EventHandler<EventArgs> OverallSelectionChanged;
            SolidBrush _dividerBrush;
            Pen _selectionPen;

            #region Designer properties
            /// <summary>
            /// The color of the divider displayed between rows while dragging
            /// </summary>
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("The color of the divider displayed between rows while dragging")]
            public Color DividerColor
            {
                get { return _dividerBrush.Color; }
                set { _dividerBrush = new SolidBrush(value); }
            }

            /// <summary>
            /// The color of the border drawn around the selected row
            /// </summary>
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("The color of the border drawn around the selected row")]
            public Color SelectionColor
            {
                get { return _selectionPen.Color; }
                set { _selectionPen = new Pen(value); }
            }

            /// <summary>
            /// Height (in pixels) of the divider to display
            /// </summary>
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("Height (in pixels) of the divider to display")]
            [DefaultValue(4)]
            public int DividerHeight { get; set; }

            /// <summary>
            /// Width (in pixels) of the border around the selected row
            /// </summary>
            [Browsable(true)]
            [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
            [Category("Appearance")]
            [Description("Width (in pixels) of the border around the selected row")]
            [DefaultValue(3)]
            public int SelectionWidth { get; set; }
            #endregion

            #region Selection
            /// <summary>
            /// All instances of this class share an event, so that only one row
            /// can be selected throughout all instances.
            /// This method is called when a row is selected on any DataGridView
            /// </summary>
            void OnOverallSelectionChanged(object sender, EventArgs e)
            {
                if (sender != this && SelectedRows.Count != 0)
                {
                    ClearSelection();
                    Invalidate();
                }
            }

            protected override void OnSelectionChanged(EventArgs e)
            {
                if (_ignoreSelectionChanged)
                    return;

                if (SelectedRows.Count != 1 || SelectedRows[0] != _selectedRow)
                {
                    _ignoreSelectionChanged = true; //Following lines cause event to be raised again
                    if (_selectedRow == null || _selectedRow.DataGridView != this)
                    {
                        ClearSelection();
                    }
                    else
                    {
                        _selectedRow.Selected = true; //Deny new selection
                        if (OverallSelectionChanged != null)
                            OverallSelectionChanged(this, EventArgs.Empty);
                    }
                    _ignoreSelectionChanged = false;
                }
                else
                {
                    base.OnSelectionChanged(e);
                    if (OverallSelectionChanged != null)
                        OverallSelectionChanged(this, EventArgs.Empty);
                }
            }

            public void SelectRow(int rowIndex)
            {
                _selectedRow = Rows[rowIndex];
                _selectedRow.Selected = true;
                Invalidate();
            }
            #endregion

            #region Selection highlighting
            void DataGridView1PaintSelection(object sender, PaintEventArgs e)
            {
                if (_selectedRow == null || _selectedRow.DataGridView != this)
                    return;

                Rectangle displayRect = GetRowDisplayRectangle(_selectedRow.Index, false);
                if (displayRect.Height == 0)
                    return;

                _selectionPen.Width = SelectionWidth;
                int heightAdjust = (int)Math.Ceiling((float)SelectionWidth / 2);
                e.Graphics.DrawRectangle(_selectionPen, displayRect.X - 1, displayRect.Y - heightAdjust,
                                         displayRect.Width, displayRect.Height + SelectionWidth - 1);
            }

            void DataGridView1DefaultcellStyleChanged(object sender, EventArgs e)
            {
                DefaultCellStyle.SelectionBackColor = DefaultCellStyle.BackColor;
                DefaultCellStyle.SelectionForeColor = DefaultCellStyle.ForeColor;
            }

            void DataGridView1Scroll(object sender, ScrollEventArgs e)
            {
                Invalidate();
            }
            #endregion

            #region Drag-and-drop
            protected override void OnDragDrop(DragEventArgs args)
            {
                if (args.Effect == DragDropEffects.None)
                    return;

                //Convert to coordinates within client (instead of screen-coordinates)
                Point clientPoint = PointToClient(new Point(args.X, args.Y));

                //Get index of row to insert into
                DataGridViewRow dragFromRow = (DataGridViewRow)args.Data.GetData(typeof(DataGridViewRow));
                int newRowIndex = GetNewRowIndex(clientPoint.Y);

                //Adjust index if both rows belong to same DataGridView, due to removal of row
                if (dragFromRow.DataGridView == this && dragFromRow.Index < newRowIndex)
                {
                    newRowIndex--;
                }

                //Clean up
                RemoveHighlighting();
                _autoScrollTimer.Enabled = false;

                //Only go through the trouble if we're actually moving the row
                if (dragFromRow.DataGridView != this || newRowIndex != dragFromRow.Index)
                {
                    //Insert the row
                    MoveDraggedRow(dragFromRow, newRowIndex);

                    //Let everyone know the selection has changed
                    SelectRow(newRowIndex);
                }
                base.OnDragDrop(args);
            }

            void dataGridView1_DragLeave(object sender, EventArgs e1)
            {
                RemoveHighlighting();
                _autoScrollTimer.Enabled = false;
            }

            void dataGridView1_DragEnter(object sender, DragEventArgs e)
            {
                e.Effect = e.Data.GetDataPresent(typeof(DataGridViewRow))
                                ? DragDropEffects.Move
                                : DragDropEffects.None;
            }

            void dataGridView1_DragOver(object sender, DragEventArgs e)
            {
                if (e.Effect == DragDropEffects.None)
                    return;

                Point clientPoint = PointToClient(new Point(e.X, e.Y));

                //Note: For some reason, HitTest is failing when clientPoint.Y = dataGridView1.Height-1.
                // I have no idea why.
                // clientPoint.Y is always 0 <= clientPoint.Y < dataGridView1.Height
                if (clientPoint.Y < Height - 1)
                {
                    int newRowIndex = GetNewRowIndex(clientPoint.Y);
                    HighlightInsertPosition(newRowIndex);
                    StartAutoscrollTimer(e);
                }
            }

            void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
            {
                if (e.Button == MouseButtons.Left && e.RowIndex >= 0)
                {
                    SelectRow(e.RowIndex);
                    var dragObject = Rows[e.RowIndex];
                    DoDragDrop(dragObject, DragDropEffects.Move);
                    //TODO: Any way to make this *not* happen if they only click?
                }
            }

            /// <summary>
            /// Based on the mouse position, determines where the new row would
            /// be inserted if the user were to release the mouse-button right now
            /// </summary>
            /// <param name="clientY">
            /// The y-coordinate of the mouse, given with respectto the control
            /// (not the screen)
            /// </param>
            int GetNewRowIndex(int clientY)
            {
                int lastRowIndex = Rows.Count - 1;

                //DataGridView has no cells
                if (Rows.Count == 0)
                    return 0;

                //Dragged above the DataGridView
                if (clientY < GetRowDisplayRectangle(0, true).Top)
                    return 0;

                //Dragged below the DataGridView
                int bottom = GetRowDisplayRectangle(lastRowIndex, true).Bottom;
                if (bottom > 0 && clientY >= bottom)
                    return lastRowIndex + 1;

                //Dragged onto one of the cells.  Depending on where in cell,
                // insert before or after row.
                var hittest = HitTest(2, clientY); //Don't care about X coordinate

                if (hittest.RowIndex == -1)
                {
                    //This should only happen when midway scrolled down the page,
                    //and user drags over header-columns
                    //Grab the index of the current top (displayed) row
                    return FirstDisplayedScrollingRowIndex;
                }

                //If we are hovering over the upper-quarter of the row, place above;

                // otherwise below.  Experimenting shows that placing above at 1/4 
                //works better than at 1/2 or always below
                if (clientY < GetRowDisplayRectangle(hittest.RowIndex, false).Top

                   + Rows[hittest.RowIndex].Height / 4)
                    return hittest.RowIndex;
                return hittest.RowIndex + 1;
            }

            void MoveDraggedRow(DataGridViewRow dragFromRow, int newRowIndex)
            {
                dragFromRow.DataGridView.Rows.Remove(dragFromRow);
                Rows.Insert(newRowIndex, dragFromRow);
            }
            #endregion

            #region Drop-and-drop highlighting
            //Draw the actual row-divider
            void dataGridView1_Paint_RowDivider(object sender, PaintEventArgs e)
            {
                if (_predictedInsertIndex != null)
                {
                    e.Graphics.FillRectangle(_dividerBrush, GetHighlightRectangle());
                }
            }

            Rectangle GetHighlightRectangle()
            {
                int width = DisplayRectangle.Width - 2;

                int relativeY = _predictedInsertIndex > 0
                                     ? GetRowDisplayRectangle((int)_predictedInsertIndex - 1, false).Bottom
                                     : Columns[0].HeaderCell.Size.Height;

                if (relativeY == 0)
                    relativeY = GetRowDisplayRectangle(FirstDisplayedScrollingRowIndex, true).Top;
                int locationX = Location.X + 1;
                int locationY = relativeY - (int)Math.Ceiling((double)DividerHeight / 2);
                return new Rectangle(locationX, locationY, width, DividerHeight);
            }

            void HighlightInsertPosition(int rowIndex)
            {
                if (_predictedInsertIndex == rowIndex)
                    return;

                Rectangle oldRect = GetHighlightRectangle();
                _predictedInsertIndex = rowIndex;
                Rectangle newRect = GetHighlightRectangle();

                Invalidate(oldRect);
                Invalidate(newRect);
            }

            void RemoveHighlighting()
            {
                if (_predictedInsertIndex != null)
                {
                    Rectangle oldRect = GetHighlightRectangle();
                    _predictedInsertIndex = null;
                    Invalidate(oldRect);
                }
                else
                {
                    Invalidate();
                }
            }
            #endregion

            #region Autoscroll
            void SetupTimer()
            {
                _autoScrollTimer = new System.Windows.Forms.Timer
                {
                    Interval = 250,
                    Enabled = false
                };
                _autoScrollTimer.Tick += OnAutoscrollTimerTick;
            }

            void StartAutoscrollTimer(DragEventArgs args)
            {
                Point position = PointToClient(new Point(args.X, args.Y));

                if (position.Y <= Font.Height / 2 &&
                   FirstDisplayedScrollingRowIndex > 0)
                {
                    //Near top, scroll up
                    _scrollDirection = -1;
                    _autoScrollTimer.Enabled = true;
                }
                else if (position.Y >= ClientSize.Height - Font.Height / 2 &&
                        FirstDisplayedScrollingRowIndex < Rows.Count - 1)
                {
                    //Near bottom, scroll down
                    _scrollDirection = 1;
                    _autoScrollTimer.Enabled = true;
                }
                else
                {
                    _autoScrollTimer.Enabled = false;
                }
            }

            void OnAutoscrollTimerTick(object sender, EventArgs e)
            {
                //Scroll up/down
                FirstDisplayedScrollingRowIndex += _scrollDirection;
            }
            #endregion

        }

        #region Helper Methods

        /// <summary>
        /// Returns the height of the column. The height is defined as the area 
        /// between the bottom portion of the caption area and either the 
        /// bottom of the client rectangle, or the top of the horizontal scroll 
        /// bar if it’s visible.
        /// </summary>
        public int GetColumnHeight(int topmostYCoordinate)
        {
            var height = ClientSize.Height;

            //   if (  ScrollBars. HorizScrollBar.Visible)
            //       height -= HorizScrollBar.Height;

            return height - topmostYCoordinate;
        }

        /// <summary>
        /// Returns the height of the column header. In order to make this 
        /// calculation, you  need to pass in the topmost y-coordinate of the 
        /// header. This method will then invoke the 
        /// GetBottommostColumnHeaderYCoordinate, which is a recursive method 
        /// that is invoked repeatedly until the DataGrid hit test determines 
        /// that the current coordinates no longer lie within the boundaries 
        /// of a ColumnHeader.
        /// </summary>
        public int GetColumnHeaderHeight(int x, int y)






        {
            return GetBottommostColumnHeaderYCoordinate(x, y) - y;
        }

        /// <summary>
        /// Calculates the leftmost x coordinate for the column corresponding 
        /// to the parameterized column index. By accessing the GridColumnStyle 
        /// style – which is discussed in the article -- we’re able to get the 
        /// current column widths (this changes when you resize columns) for 
        /// the columns that precede the current column. 
        /// </summary>
        public int GetBottommostColumnHeaderYCoordinate(int x, int currentY)





        {
            var hti = _dataGridView.HitTest(x, currentY);
            var yCoordinate = currentY;

            if (hti.Type == DataGridViewHitTestType.ColumnHeader)
                yCoordinate = GetBottommostColumnHeaderYCoordinate(x, ++currentY);

            return yCoordinate;
        }

        /// <summary>
        /// Calculates the leftmost x coordinate for the column corresponding 
        /// to the parameterized column index. By accessing the 
        /// GridColumnStyle style, which is discussed in detail in the article,
        /// we’re able to get the current column widths (this changes when you 
        /// resize columns) for the columns that precede the current column. 		
        /// </summary>
        public int GetLeftmostColumnHeaderXCoordinate(int displayedIndex)




        {
            var xCoordinate = _dataGridView.RowHeadersVisible ? _dataGridView.RowHeadersWidth : 0;

            foreach (var column in _dataGridView.DisplayedColumns)
            {
                if (column.DisplayIndex == displayedIndex)
                    break;

                xCoordinate += column.Width;
            }

            return xCoordinate - _dataGridView.HorizontalScrollingOffset;
        }

        /// <summary>
        /// This is another recursive method that returns the Y-coordinate of 
        /// the topmost portion of the column header. First, a check is 
        /// performed to see if the DataGrid caption is visible. If not, the 
        /// Y-coordinate is set to zero and the method returns. Otherwise, a 
        /// recursion is performed until the DataGrid hit test determines that 
        /// the current Y-coordinate value does not fall within the boundaries 
        /// of a ColumnHeader. 
        /// </summary>
        public int GetTopmostColumnHeaderYCoordinate(int currentX, int currentY)







        {
            var hti = _dataGridView.HitTest(currentX, currentY);
            var yCoordinate = currentY;

            if (!_dataGridView.ColumnHeadersVisible)
                yCoordinate = 0;
            else
                if (hti.Type == DataGridViewHitTestType.ColumnHeader)
                    yCoordinate = GetTopmostColumnHeaderYCoordinate(currentX, --currentY);
                else
                    yCoordinate++;

            return yCoordinate;
        }

        #endregion

        class DraggedDataGridColumn : IDisposable
        {
            #region data fields

            // data fields
            Rectangle m_initialRegion;
            Rectangle m_currentRegion;

            int m_index;
            Image m_columnImage;
            Point m_cursorLocation;

            bool disposed;

            #endregion

            #region Properties

            /// <summary>
            /// An integer representing the original column index.
            /// </summary>
            public int Index
            {
                get
                {
                    CheckState();
                    return m_index;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the region of the column at
            /// the time the drag and drop operation was initiated.
            /// </summary>	
            public Rectangle InitialRegion
            {
                get
                {
                    CheckState();
                    return m_initialRegion;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the current region of the 
            /// column that is being dragged. This is the only member that can be 
            /// modified after an instance has been created.
            /// </summary>
            public Rectangle CurrentRegion
            {
                get
                {
                    CheckState();
                    return m_currentRegion;
                }
                set
                {
                    CheckState();
                    m_currentRegion = value;
                }
            }

            /// <summary>
            /// A Bitmap object containing a bitmap representation of the column at 
            /// the time that the drag and drop operation was initiated.
            /// </summary>
            public Image ColumnImage
            {
                get
                {
                    CheckState();
                    return m_columnImage;
                }
            }

            /// <summary>
            /// A Point structure representing the cursor location relative to the 
            /// origin of m_initialRegion.
            /// </summary>
            public Point CursorLocation
            {
                get
                {
                    CheckState();
                    return m_cursorLocation;
                }
            }

            #endregion

            #region Constructors
            public DraggedDataGridColumn(int index, Rectangle initialRegion, Point cursorLocation, Image columnImage)
            {
                m_index = index;
                m_initialRegion = initialRegion;
                m_currentRegion = initialRegion;
                m_cursorLocation = cursorLocation;
                m_columnImage = columnImage;
            }

            public DraggedDataGridColumn(int index, Rectangle initialRegion, Point cursorLocation) : this(index, initialRegion, cursorLocation, null) { }

            #endregion

            public void Dispose()
            {
                if (!disposed)
                {
                    m_initialRegion = Rectangle.Empty;
                    m_currentRegion = Rectangle.Empty;

                    m_index = -1;
                    m_cursorLocation = Point.Empty;

                    if (m_columnImage != null)
                    {
                        m_columnImage.Dispose();
                    }

                    disposed = true;
                }

                // Remove this object from the finalization queue so the 
                // finalizes doesn't invoke this method again.
                GC.SuppressFinalize(this);

            }

            // NOTE: We do not implement the destructor because we are not 
            // explicitly dealing with unmanaged resources.

            // ~DraggedDataGridColumn() { }

            /// <summary>
            /// Throw an ObjectDisposedException if this object has already been
            /// disposed.
            /// </summary>
            void CheckState()
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("DraggedDataGridColumn object has already been disposed.");
                }
            }

        }

        class DraggedDataGridColumnTest : IDisposable
        {
            #region data fields

            // data fields
            Rectangle m_initialRegion;
            Rectangle m_currentRegion;

            int m_index;
            Image m_columnImage;
            Point m_cursorLocation;

            bool disposed;

            #endregion

            #region Properties

            DataGridView _dataGridView;

            /// <summary>
            /// An integer representing the original column index.
            /// </summary>
            public int Index
            {
                get
                {
                    CheckState();
                    return m_index;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the region of the column at
            /// the time the drag and drop operation was initiated.
            /// </summary>	
            public Rectangle InitialRegion
            {
                get
                {
                    CheckState();
                    return m_initialRegion;
                }
            }

            /// <summary>
            /// A Rectangle structure that identifies the current region of the 
            /// column that is being dragged. This is the only member that can be 
            /// modified after an instance has been created.
            /// </summary>
            public Rectangle CurrentRegion
            {
                get
                {
                    CheckState();
                    return m_currentRegion;
                }
                set
                {
                    CheckState();
                    m_currentRegion = value;
                }
            }

            /// <summary>
            /// A Bitmap object containing a bitmap representation of the column at 
            /// the time that the drag and drop operation was initiated.
            /// </summary>
            public Image ColumnImage
            {
                get
                {
                    CheckState();
                    return m_columnImage;
                }
            }

            /// <summary>
            /// A Point structure representing the cursor location relative to the 
            /// origin of m_initialRegion.
            /// </summary>
            public Point CursorLocation
            {
                get
                {
                    CheckState();
                    return m_cursorLocation;
                }
            }

            #endregion

            #region Constructors

            public DraggedDataGridColumnTest(DataGridViewColumn selectedColumn)
            {
                _dataGridView = selectedColumn.DataGridView;
                var _hitTest = _dataGridView.HitTest(selectedColumn.HeaderCell.ContentBounds.Location.X, selectedColumn.HeaderCell.ContentBounds.Location.Y);

                _dataGridView.Columns[selectedColumn.Index].SortMode = DataGridViewColumnSortMode.Programmatic;

                int xCoordinate = GetLeftmostColumnHeaderXCoordinate(selectedColumn.Index);
                var yCoordinate = GetTopmostColumnHeaderYCoordinate(_hitTest.ColumnX, _hitTest.RowY);
                int columnWidth = _dataGridView.Columns[selectedColumn.Index].Width;
                var columnHeight = GetColumnHeight(yCoordinate);

                Size columnSize = new Size(selectedColumn.Width, GetColumnHeight(yCoordinate));

                var startingLocation = new Point(xCoordinate, yCoordinate);
                Rectangle columnRegion = new Rectangle(xCoordinate, yCoordinate, columnWidth, columnHeight);
                var cursorLocation = new Point(_hitTest.ColumnX - xCoordinate, _hitTest.RowY - yCoordinate);

                Bitmap columnImage = (Bitmap)ScreenImage.GetScreenshot(_dataGridView.Handle, startingLocation, columnSize);

                m_index = selectedColumn.Index;
                m_initialRegion = columnRegion;
                m_currentRegion = columnRegion;
                m_cursorLocation = cursorLocation;
                m_columnImage = columnImage;
            }

            #endregion

            public void Dispose()
            {
                if (!disposed)
                {
                    m_initialRegion = Rectangle.Empty;
                    m_currentRegion = Rectangle.Empty;

                    m_index = -1;
                    m_cursorLocation = Point.Empty;

                    if (m_columnImage != null)
                    {
                        m_columnImage.Dispose();
                    }

                    disposed = true;
                }

                Dispose();
                // Remove this object from the finalization queue so the 
                // finalizer doesn't invoke this method again.
                GC.SuppressFinalize(this);
            }

            // NOTE: We do not implement the destructor because we are not 
            // explicitly dealing with unmanaged resources.

            // ~DraggedDataGridColumn() { }

            /// <summary>
            /// Throw an ObjectDisposedException if this object has already been
            /// disposed.
            /// </summary>
            void CheckState()
            {
                if (disposed)
                {
                    throw new ObjectDisposedException("DraggedDataGridColumn object has already been disposed.");
                }
            }

            /// <summary>
            /// Calculates the leftmost x coordinate for the column corresponding 
            /// to the parameterized column index. By accessing the 
            /// GridColumnStyle style, which is discussed in detail in the article,
            /// we’re able to get the current column widths (this changes when you 
            /// resize columns) for the columns that precede the current column. 		
            /// </summary>
            int GetLeftmostColumnHeaderXCoordinate(int columnIndex)
            {
                var xCoordinate = _dataGridView.RowHeadersVisible ? _dataGridView.RowHeadersWidth : 0;

                for (int i = 0; i < columnIndex; i++)
                {
                    xCoordinate += _dataGridView.Columns[i].Width;
                }

                return xCoordinate - _dataGridView.HorizontalScrollingOffset;
            }

            /// <summary>
            /// This is another recursive method that returns the Y-coordinate of 
            /// the topmost portion of the column header. First, a check is 
            /// performed to see if the DataGrid caption is visible. If not, the 
            /// Y-coordinate is set to zero and the method returns. Otherwise, a 
            /// recursion is performed until the DataGrid hit test determines that 
            /// the current Y-coordinate value does not fall within the boundaries 
            /// of a ColumnHeader. 
            /// </summary>
            int GetTopmostColumnHeaderYCoordinate(int currentX, int currentY)
            {
                var hti = _dataGridView.HitTest(currentX, currentY);
                var yCoordinate = currentY;

                if (!_dataGridView.ColumnHeadersVisible)
                    yCoordinate = 0;
                else
                {
                    if (hti.Type == DataGridViewHitTestType.ColumnHeader)
                        yCoordinate = GetTopmostColumnHeaderYCoordinate(currentX, --currentY);
                    else
                        yCoordinate++;
                }

                return yCoordinate;
            }

            /// <summary>
            /// Returns the height of the column. The height is defined as the area 
            /// between the bottom portion of the caption area and either the 
            /// bottom of the client rectangle, or the top of the horizontal scroll 
            /// bar if it’s visible.
            /// </summary>
            int GetColumnHeight(int topmostYCoordinate)
            {
                var height = _dataGridView.ClientSize.Height;

                //   if (_dataGridView.  ScrollBars. HorizScrollBar.Visible)
                //       height -= _dataGridView.HorizScrollBar.Height;

                return height - topmostYCoordinate;
            }
        }
    }
}