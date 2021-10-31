using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace EmployeeManagement
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection("");
        }
        public int UpdateEmployeeSalary(SalaryUpdateModal modal)
        {
            SqlConnection salaryconnection = ConnectionSetup();
            int Salary = 0;
            try
            {
                using (salaryconnection)
                {
                    SalaryDetailModal displayModal = new SalaryDetailModal();
                    SqlCommand command = new SqlCommand("SpUpdateEmployeeSalary",salaryconnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", modal.SalaryId);
                    command.Parameters.AddWithValue("@month", modal.Month);
                    command.Parameters.AddWithValue("@salary", modal.EmployeeSalary);
                    command.Parameters.AddWithValue("@EmpId", modal.EmployeeId);
                    salaryconnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModal.EmployeeId = (int)dr["EmployeeID"];
                            displayModal.EmployeeName = dr["EmployeeName"].ToString();
                            displayModal.EmployeeSalary = (int)dr["EmpSalary"];
                            displayModal.Month = dr["SalaryMonth"].ToString();
                            displayModal.SalaryId = (int)dr["SalaryId"];
                            Console.WriteLine("{0},{1},{2}",
                                displayModal.EmployeeName,
                                displayModal.EmployeeSalary,
                                displayModal.Month);
                            Salary = displayModal.EmployeeSalary;

                        }
                    }
                }
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                salaryconnection.Close();
            }
            return Salary;
        }
    }
}
