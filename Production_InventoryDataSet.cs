using System.Text.RegularExpressions;
using System.ComponentModel;
namespace StockRoom11net
{


    public partial class Production_InventoryDataSet
    {
        partial class Table_Projects_TreeViewDataTable
        {
        }

        partial class Table_TimeLine_TreeViewDataTable
        {
        }

        partial class Table_TimeLineDataTable
        {
        }

        partial class Table_TimeLineDataTable
        {
        }

        partial class Table_Labels_SMTDataTable
        {
        }

        partial class Table_StockRoomDataTable
        {
        }
    }

}

namespace StockRoom11net.Production_InventoryDataSetTableAdapters
{

    public partial class Table_StockRoomTreeviewTableAdapter
    {



    }


    public partial class Table_StockRoomTableAdapter
    {
        /// <summary>
        /// Used by FillWithFilter and FillWithGroupFilter methods. 
        /// Used to restore original SelectCommand.CommandText after a FillWith* call
        /// </summary>
        private string _originalSqlCommandText = "";

        /// <summary>
        /// The data adapter's select command sql string (CommandText)
        /// </summary>
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        /// <summary>
        /// The data adapter's select command sql string (CommandText)
        /// </summary>
        public string SelectCommandText
        {
            get
            {
                // If get is called before another usage of this class, the command collection 
                // will not have been initialized yet
                if ((this._commandCollection == null))
                    this.InitCommandCollection();

                // Keep the original sql around for resetting after filtered fills
                if (_originalSqlCommandText == "")
                    _originalSqlCommandText = this._commandCollection[0].CommandText;

                return this._commandCollection[0].CommandText;
            }
            set
            {
                if ((this._commandCollection == null))
                    this.InitCommandCollection();

                if (_originalSqlCommandText == "")
                    _originalSqlCommandText = this._commandCollection[0].CommandText;

                this._commandCollection[0].CommandText = value;
            }
        }

        /// <summary>
        /// Used by GetTokenizedSqlCommandText()
        /// Given a SQL clause to find, return the position in the SQL the clause begins at.
        /// Note: If a column name contains a sql clause keyword (" where ", " group by ", 
        /// " having ", " order by") then this will fail badly. 
        /// For example, if exists a column: [is having guests]
        /// </summary>   
        /// <param name="sql">Indicates the sql command text to search in</parameter>
        private int GetSqlClausePosition(string sql, string clause)
        {
            if (clause == "")
                return -1;

            Regex r;
            Match m;
            r = new Regex(" " + clause + " ", RegexOptions.IgnoreCase);
            m = r.Match(sql);
            if (m.Value == "")
                return -1; // Have to do this because m.Index will be zero, not -1

            return m.Index;
        }

        /// <summary>
        /// Used by GetTokenizedSqlCommandText()
        /// Given a SQL clause to find, return the position in the SQL the clause begins at.
        /// Note: If a column name contains a sql clause keyword (" where ", " group by ", 
        /// " having ", " order by") then this will fail badly. For example, if exists a 
        /// column: [is having guests]
        /// </summary>   
        /// <param name="sql">Indicates the sql command text to sanitize.</parameter>
        private string SanitizeSQL(string sql)
        {
            if (sql == "") return "";
            // Clean up SQL for processing. Replace tabs with spaces, make all SQL keywords lower case
            sql = sql.Replace("\t", " ");
            sql = Regex.Replace(sql, " where ", " where ", RegexOptions.IgnoreCase);
            sql = Regex.Replace(sql, " group by ", " group by ", RegexOptions.IgnoreCase);
            sql = Regex.Replace(sql, " order by ", " order by ", RegexOptions.IgnoreCase);
            return sql;
        }

        /// <summary>
        /// Used by FillWithFilter and FillWithGroupFilter methods.
        /// Given a SQL string, insert a token within the requested SQL clause (where, having, 
        /// order by) for replacement with a filter.
        /// </summary>   
        /// <param name="sqlClauseFilter">Indicates which clause in the SQL the token should be 
        /// placed after.</parameter>
        private string GetTokenizedSqlCommandText(string sqlClauseFilter = "where", string token = " ~!~ ")
        {
            sqlClauseFilter = sqlClauseFilter.ToLower();
            string commandText = SelectCommandText;
            if (commandText == "")
                return "";

            commandText = SanitizeSQL(commandText);

            if (sqlClauseFilter == "order by")
            {
                int orderByStartPos = GetSqlClausePosition(commandText, "order by");
                if (orderByStartPos < 0) return commandText += " ORDER BY " + token;
                return commandText.Substring(0, orderByStartPos) + " ORDER BY " + token;
            }

            if (sqlClauseFilter == "having")
            {
                int havingStartPos = GetSqlClausePosition(commandText, "having");
                int orderByStartPos = GetSqlClausePosition(commandText, "order by");
                if (orderByStartPos >= 0) return commandText.Insert(orderByStartPos, token);
                if (havingStartPos < 0) return commandText += " HAVING " + token;
                return commandText.Substring(0, havingStartPos) + " HAVING " + token;
            }

            if (sqlClauseFilter == "where")
            {
                int whereStartPos = GetSqlClausePosition(commandText, "where");
                int groupByStartPos = GetSqlClausePosition(commandText, "group by");
                int orderByStartPos = GetSqlClausePosition(commandText, "order by");

                if (groupByStartPos >= 0)
                {
                    // Has GROUP BY clause. Can insert right before " group by "
                    if (whereStartPos >= 0) token = " AND " + token;
                    return commandText.Insert(groupByStartPos, token);
                }

                if (orderByStartPos >= 0)
                {
                    // No GROUP BY but has ORDER BY. Can insert right before " order by "
                    if (whereStartPos >= 0) token = " AND " + token;
                    return commandText.Insert(orderByStartPos, token);
                }

                // No WHERE, GROUP or ORDER BY clauses. Easy peesy
                if (whereStartPos < 0)
                    return commandText += " WHERE ~!~";

                // No GROUP or ORDER BY clauses, has WHERE clause. Easy peesy
                return commandText.Insert(whereStartPos, token);
            }

            return ""; // invalid sqlClauseFilter
        }

        /// <summary>
        /// Fill the data table using a filter on the WHERE clause of the original SelectCommand.
        /// If whereClauseFilter = "order by", entire ORDER BY clause is replaced, not appended to
        /// </summary>   
        /// <param name="whereClauseFilter">SQL WHERE clause without the string "WHERE". 
        /// Ex: "id = 1 and salary > 100000. Enum: where, group by, having, order by"</parameter>
        public void FillWithFilter(Production_InventoryDataSet.Table_StockRoomDataTable dt, string clauseToFilter, string whereClauseFilter, bool resetSql = true)
        {
            if (clauseToFilter != "" && whereClauseFilter != "")
                SelectCommandText = GetTokenizedSqlCommandText(clauseToFilter).Replace("~!~", whereClauseFilter);
            this.Fill(dt);
            // Reset command text so other callers don't get filtered results
            if (resetSql) SelectCommandText = _originalSqlCommandText;
        }

        /// <summary>
        /// Fill the data table using a filter on the WHERE clause of the original SelectCommand.
        /// </summary>   
        /// <param name="whereClauseFilter">SQL WHERE clause without the string "WHERE". 
        /// Ex: "id = 1 and salary > 100000"</parameter>
        public void FillWithWhereFilter(Production_InventoryDataSet.Table_StockRoomDataTable dt, string filter, bool resetSql = true)
        {
            FillWithFilter(dt, "where", filter, resetSql);
        }

        /// <summary>
        /// Fill the data table using a filter on the HAVING clause of the original SelectCommand.
        /// Used when the SQL contains a GROUP BY clause and you want to filter for certain groups
        /// </summary>   
        /// <param name="havingClauseFilter">SQL HAVING clause without the string "HAVING". 
        /// Ex: "count(*) > 1000"</parameter>
        public void FillWithGroupFilter(Production_InventoryDataSet.Table_StockRoomDataTable dt, string filter, bool resetSql = true)
        {
            FillWithFilter(dt, "having", filter, resetSql);
        }

        /// <summary>Fill the data table REPLACING the ORDER BY clause of the original SelectCommand</summary>   
        /// <param name="filterNoSqlToken">SQL ORDER BY clause without the string "ORDER BY". 
        /// Ex: "1 DESC, DATEPART(MONTH, OrderDate) ASC"</parameter>
        public void FillOrdered(Production_InventoryDataSet.Table_StockRoomDataTable dt, string filter, bool resetSql = true)
        {
            FillWithFilter(dt, "order by", filter, resetSql);
        }

        public virtual int FillByLastAccessTime(Production_InventoryDataSet.Table_StockRoomDataTable dataTable, System.DateTime? LastAccessTime)
        {
            this.Adapter.SelectCommand = this.CommandCollection[0];
            if ((LastAccessTime.HasValue))
            {
                this.Adapter.SelectCommand.Parameters[0].Value = ((System.DateTime)(LastAccessTime.Value));
            }
            else
            {
                this.Adapter.SelectCommand.Parameters[0].Value = System.DBNull.Value;
            }
            if ((this.ClearBeforeFill))
            {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }





        /*
         * Example compound usage:
         * 
         *  Table: 
         *      CREATE TABLE Orders (id INT, OrderTotalDenorm DECIMAL(9,2), OrderDate DATETIME)
         *      
         *  SelectCommand (dataset built with VS Designer): 
         *      SELECT COUNT(*) AS Orders, 
         *          DATEPART(YEAR, OrderDate) AS [Year], 
         *          DATEPART(MONTH, OrderDate) AS [Month]
         *      FROM Orders
         *      GROUP BY DATEPART(YEAR, OrderDate), DATEPART(MONTH, OrderDate)
         *      ORDER BY 1 DESC, 3 ASC
         *      
         *  Task: Custom DataTable filled using a filter that shows only months with greater than 1000 orders for the 
         *          last two years, ordered by month ascending, orders descending
         * 
         *  Code:
         *      SelectCommandText = GetTokenizedSqlCommandText("where").Replace("~!~", "DATEPART(YEAR,OrderDate) >= DATEPART(YEAR, GETDATE()) - 1");
         *      SelectCommandText = GetTokenizedSqlCommandText("having").Replace("~!~", "COUNT(*) > 1000");
         *      FillOrdered(Production_InventoryDataSet.Table_StockRoomDataTable, "DATEPART(MONTH, OrderDate), COUNT(*) DESC")
         *      
         */
    }


}