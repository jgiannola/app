using System.Collections.Generic;
using System.Linq;

namespace app.web.application.catalogbrowsing.stubs
{
  public class StubDepartmentRepository : IFindDepartments
  {
    public IEnumerable<DepartmentItem> get_the_main_departments_in_the_store()
    {
      return Enumerable.Range(1, 1000).Select(x => new DepartmentItem{name = x.ToString("Department 0")});
    }

    public IEnumerable<DepartmentItem> get_the_sub_departments_in(DepartmentItem the_main_department)
    {
      return Enumerable.Range(1, 10).Select(x => new DepartmentItem{name = x.ToString("SubDepartment 0")});
    }
  }
}