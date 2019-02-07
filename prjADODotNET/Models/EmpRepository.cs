using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using prjADODotNET.Models;
using System.Linq;

namespace prjADODotNET.Models
{
    public class EmpRepository
    {
        public string ConnectionString
        {
             get {
                    string constr = @"Data Source=(LocalDB)\MSSQLLocalDB;" +
                        "AttachDbFilename=|DataDirectory|Employee.mdf;" +
                        "Integrated Security=True";
                    return constr;
                }
        }

        /// <summary>
        /// 員工新增
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public int AddEmployee(tEmployee employee)
        {
           
            int fEmpId = 0;
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PR_Employee_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fName", SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@fPhone", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@fDepId", SqlDbType.Int);
                    cmd.Parameters.Add("@fEmpId", SqlDbType.Int).Direction = ParameterDirection.Output;

                    cmd.Parameters["@fName"].Value = employee.fName;
                    cmd.Parameters["@fPhone"].Value = employee.fPhone;
                    cmd.Parameters["@fDepId"].Value = employee.fDepId;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    fEmpId = Convert.ToInt32(cmd.Parameters["@fEmpId"].Value);
                    conn.Close();
                }
            }

            return fEmpId;
        }

        /// <summary>
        /// 員工編輯
        /// </summary>
        /// <param name="employee"></param>
        public void UpdateEmployee(tEmployee employee)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PR_Employee_UpdateByPK", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fEmpId", SqlDbType.Int);
                    cmd.Parameters.Add("@fName", SqlDbType.NVarChar, 10);
                    cmd.Parameters.Add("@fPhone", SqlDbType.VarChar, 10);
                    cmd.Parameters.Add("@fDepId", SqlDbType.Int);

                    cmd.Parameters["@fEmpId"].Value = employee.fEmpId;
                    cmd.Parameters["@fName"].Value = employee.fName;
                    cmd.Parameters["@fPhone"].Value = employee.fPhone;
                    cmd.Parameters["@fDepId"].Value = employee.fDepId;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 員工刪除
        /// </summary>
        /// <param name="Id"></param>
        public void DeleteEmployee(int Id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_PR_Employee_DeleteByPK", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fEmpId", SqlDbType.Int);
                    cmd.Parameters["@fEmpId"].Value = Id;

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        /// <summary>
        /// 依部門編號查詢員工資料
        /// </summary>
        /// <param name="fDepId">部門編號</param>
        /// <returns></returns>
        public List<tEmployeeResult> GetEmployeesByDepId(int fDepId)
        {
            DataTable dt = new DataTable();
            List<tEmployeeResult> EmpList = new List<tEmployeeResult>();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetEmployeeByDepId", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fDepId", SqlDbType.Int);
                    cmd.Parameters["@fDepId"].Value = fDepId;

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    conn.Close();
                }
            }

            EmpList = (from DataRow dr in dt.Rows
                       select new tEmployeeResult()
                       {
                           fDepId = Convert.ToInt32(dr["fDepId"]),
                           fDepName = Convert.ToString(dr["fDepName"]),
                           fEmpId = Convert.ToInt32(dr["fEmpId"]),
                           fName = Convert.ToString(dr["fName"]),
                           fPhone = Convert.ToString(dr["fPhone"])
                       }).ToList();

            return EmpList;           
        }

        /// <summary>
        /// 依員工編號查詢員工資料
        /// </summary>
        /// <param name="fEmpId">員工編號</param>
        /// <returns></returns>
        public tEmployee GetEmployeesByEmpID(int fEmpId)
        {
            DataTable dt = new DataTable();
            tEmployee Emp = new tEmployee();
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetEmployeeByEmpID", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@fEmpId", SqlDbType.Int);
                    cmd.Parameters["@fEmpId"].Value = fEmpId;
                    conn.Open();
                    using (var dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            Emp.fDepId = Convert.ToInt32(dr["fDepId"]);                         
                            Emp.fEmpId = Convert.ToInt32(dr["fEmpId"]);
                            Emp.fName = Convert.ToString(dr["fName"]);
                            Emp.fPhone = Convert.ToString(dr["fPhone"]);
                        }
                    }
                    conn.Close();
                }
            }           

            return Emp;
        }

        /// <summary>
        /// 讀取部門資料
        /// </summary>
        /// <returns></returns>
        public List<tDepartment> GetAllDepartment()
        {
            DataTable dt = new DataTable();
            List<tDepartment> EmpList = new List<tDepartment>();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("usp_GetAllDepartment", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    conn.Open();
                    da.Fill(dt);
                    conn.Close();
                }
            }

            EmpList = (from DataRow dr in dt.Rows
                       select new tDepartment()
                       {
                           fDepId = Convert.ToInt32(dr["fDepId"]),
                           fDepName = Convert.ToString(dr["fDepName"])
                       }).ToList();

            return EmpList;
        }
    }
}