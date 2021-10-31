using EmployeeManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManagementTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenSalaryDetails_AbleToUpdateSalaryDetails()
        {
            Salary salary = new Salary();
            SalaryUpdateModal updateModal = new SalaryUpdateModal()
            {
                SalaryId = 2,
                Month = "Jan",
                EmployeeSalary = 1300,
                EmployeeId = 5
            };
            int EmpSalary = salary.UpdateEmployeeSalary(updateModal);
            Assert.AreEqual(updateModal.EmployeeSalary, EmpSalary);
        }
    }
}
