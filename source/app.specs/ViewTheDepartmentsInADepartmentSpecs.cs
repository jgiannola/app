using Machine.Specifications;
using app.web.application.catalogbrowsing;
using app.web.core;
using developwithpassion.specifications.rhinomocks;
using developwithpassion.specifications.extensions;
using System.Collections.Generic;

namespace app.specs
{
  [Subject(typeof(ViewTheDepartmentsInADepartment))]
  public class ViewTheDepartmentsInADepartmentSpecs
  {
    public abstract class concern : Observes<ISupportAUserFeature,
                                      ViewTheDepartmentsInADepartment>
    {
    }

    public class when_run : concern
    {
      static IFindDepartments department_finder;
      static IContainRequestDetails request;
      static DepartmentItem the_main_department;
      static IEnumerable<DepartmentItem> the_sub_departments;
      static IDisplayInformation display_engine;
      Establish c = () =>
      {
        request = fake.an<IContainRequestDetails>();
        department_finder = depends.on<IFindDepartments>();
        the_main_department = new DepartmentItem();
        the_sub_departments = new List<DepartmentItem>();
        display_engine = depends.on<IDisplayInformation>();

        department_finder.setup(x => x.get_the_sub_departments_in(the_main_department)).Return(the_sub_departments);
      };

      Because b = () =>
        sut.process(request);

      It should_display_sub_departments_in_the_main_department = () => 
        display_engine.received(x => x.display(the_sub_departments));
    }
  }
}