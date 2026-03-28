namespace MyStuff11net
{
    public class Notification
    {
        /// <summary>
        /// notification.Text
        /// notification.Title
        /// notification.Description
        /// notification.MessageIcon
        /// notifycation.NotifycationEvents
        /// notification.String_Filter
        /// notification.DateCreated
        /// notification.Created_by
        /// notification.Properties
        /// notification.Status
        /// </summary>
        /// <param name="textName"></param>
        /// <param name="title"></param>
        /// <param name="description"></param>
        /// <param name="messageIcon"></param>
        /// <param name="NotifycationEvents"></param>
        /// <param name="stringFilter"></param>
        /// <param name="dateCreated"></param>
        /// <param name="createdBy"></param>
        /// <param name="properties"></param>
        /// <param name="status"></param>
        public Notification(string textName, string title, string description, int messageIcon, int NotifycationEvent,
                            string stringFilter, DateTime dateCreated, string createdBy,
                            string properties, string status)
        {
            Text_Name = textName;          // 0 notification.Text
            Title = title;             // 1 notification.Title
            Description = description;       // 2 notification.Description
            MessageIcon = (ToolTipIcon)messageIcon;       // 3 notification.MessageIcon
            NotifycationEvents = (MyCode.NotificationEvents)NotifycationEvent; // 4 notifycation.NotifycationEvents
            DepartmentName = "";    // 5 notification.DepartmentName
            String_Filter = stringFilter;      // 5 notification.String_Filter
            DateCreated = dateCreated;       // 6 notification.DateCreated
            Created_by = createdBy;         // 7 notification.Created_by
            Properties = properties;        // 8 notification.Properties
            Status = status;            // 9 notification.Status
        }

        /// <summary>
        ///  0-notification.Text
        ///  1-notification.Title
        ///  2-notification.Description
        ///  3-notification.MessageIcon
        ///  4-notifycation.NotifycationEvents
        ///  5-notification.String_Filter
        ///  6-notification.DateCreated
        ///  7-notification.Created_by
        ///  8-notification.Properties
        ///  9-notification.Status
        /// </summary>
        /// <param name="values"></param>
        public Notification(object[] values)
        {
            Text_Name = values[0].ToString();    // 0 notification.Text
            Title = values[1].ToString();    // 1 notification.Title
            Description = values[2].ToString();    // 2 notification.Description
            MessageIcon = (ToolTipIcon)values[3];    // 3 notification.MessageIcon
            NotifycationEvents = (MyCode.NotificationEvents)values[4];    // 4 notifycation.NotifycationEvents
            DepartmentName = values[5].ToString();    // 5 notification.DepartmentName
            DateCreated = (DateTime)values[6];     // 6 notification.DateCreated
            Created_by = values[7].ToString();    // 7 notification.Created_by
            Properties = values[8].ToString();    // 8 notification.Properties
            Status = values[9].ToString();    // 9 notification.Status

        }

        /// <summary>
        ///  0-notification.Text
        ///  1-notification.Title
        ///  2-notification.Description
        ///  3-notification.MessageIcon
        ///  4-notifycation.NotifycationEvents
        ///  5-notification.String_Filter
        ///  6-notification.DateCreated
        ///  7-notification.Created_by
        ///  8-notification.Properties
        ///  9-notification.Status
        /// </summary>
        public void NotificationHelp()
        {/*
                On_NotificationsToSends(new Notification(
                                                     "DataBase has been updated.",                       // 0 notification.Text
                                                     "Warning, DataBase updated.",                       // 1 notification.Title
                                                     "The database has been updated by an user.",        // 2 notification.Description
                                                     (int)ToolTipIcon.Info,                              // 3 notification.MessageIcon
                                                     (int)MyCode.NotifycationEvents.DataBaseUpDated,     // 4 notifycation.NotifycationEvents
                                                     Settings.Default.ApplicationDepartmentName,         // 5 notification.String_Filter
                                                     DateTime.Now,                                       // 6 notification.DateCreated
                                                     CurrentEmployeesLogIn.FullName,                     // 7 notification.Created_by
                                                     "properties",                                       // 8 notification.Properties
                                                     "Status"                                            // 9 notification.Status
                                                    ));
              */
        }

        public string Text_Name;
        public string Title;
        public string Description;
        public ToolTipIcon MessageIcon;
        public MyCode.NotificationEvents NotifycationEvents;
        public string String_Filter;
        public string DepartmentName;
        public DateTime DateCreated;
        public string Created_by;
        public string Properties;
        public string Status;
    }

}
