# Copilot Instructions

## Project Guidelines
- User prefers converting EF BindingList<T> to DataTable → DataView → BindingSource for filtering support in DataGridView (instead of LINQ re-query), as BindingList<T> does not support BindingSource.Filter.
- In DataGridViewControlExtended, row style reassignment (DoOverDefaultCellStyle) is guarded with a `_doOverDefaultCellStyleScheduled` flag to avoid redundant per-row style assignments during font scaling.