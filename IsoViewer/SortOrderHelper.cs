using System.Windows.Forms;
using System.ComponentModel;

namespace Ps.Iso.Viewer {
  public static class SortOrderHelper {
    public static ListSortDirection ToSortDirection(this SortOrder sortOrder) {
      return sortOrder == SortOrder.Descending ?
        ListSortDirection.Descending : ListSortDirection.Ascending;
    }
  }
}
