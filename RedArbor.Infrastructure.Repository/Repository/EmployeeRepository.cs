using RedArbor.Infrastructure.Repository.Interfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using RedArbor.Infrastructure.Repository.Resources;
using RedArbor.Domain.Entities.EntityModels;

namespace RedArbor.Infrastructure.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string connectionString;
        SqlConnection connection;

        public EmployeeRepository()
        {
            InitDb();
        }


        private void InitDb()
        {
            connectionString =  $"Persist Security Info  = {InfrastructureResource.PersistSecurityInfo}; " +
                                $"data source = {InfrastructureResource.DataSource}; " +
                                $"initial catalog = {InfrastructureResource.DataBaseName}; " +
                                $"user id = {InfrastructureResource.UserId}; " +
                                $"password = {InfrastructureResource.Password}";

            connection = new SqlConnection(connectionString);
        }

        public EmployeeEntity[] GetAllEmployees()
        {
            connection.Open();

            string query = $"SELECT * FROM {InfrastructureResource.TableName}";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader records = command.ExecuteReader();

                var employeesList = new List<EmployeeEntity>();

                while (records.Read())
                {
                    var employee = new EmployeeEntity
                    {
                        CompanyId = Convert.ToInt32(records["CompanyId"]),
                        CreatedOn = Convert.ToDateTime(records["CreatedOn"]), //"yyyy/MM/dd HH:mm:ss"
                        DeletedOn = Convert.ToDateTime(records["DeletedOn"]),
                        Email = records["Email"].ToString(),
                        Fax = records["Fax"].ToString(),
                        Name = records["Name"].ToString(),
                        LastLogin = Convert.ToDateTime(records["LastLogin"]),
                        Password = records["Password"].ToString(),
                        PortalId = Convert.ToInt32(records["PortalId"]),
                        RoleId = Convert.ToInt32(records["RoleId"]),
                        StatusId = Convert.ToInt32(records["StatusId"]),
                        Telephone = records["Telephone"].ToString(),
                        UpdatedOn = Convert.ToDateTime(records["UpdatedOn"]),
                        Username = records["Username"].ToString()
                    };
                    employeesList.Add(employee);
                }
                //Conversión de Lista a Array por la especificación del enunciado
                return employeesList.Count != 0 ? employeesList.ToArray() : null;
            }
            catch (SystemException)
            {
                throw new Exception(InfrastructureResource.ExceptionAddMsg);
            }
            finally
            {
                connection.Close();
            }

        }


        public EmployeeEntity GetEmployeeById(int id)
        {
            connection.Open();

            try
            {
                string query = $"SELECT * FROM {InfrastructureResource.TableName} WHERE CompanyId = {id}";

                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader records = command.ExecuteReader();

                var employee = new EmployeeEntity();

                if (records.Read())
                {
                    employee.CompanyId = Convert.ToInt32(records["CompanyId"]);
                    employee.CreatedOn = Convert.ToDateTime(records["CreatedOn"]);
                    employee.DeletedOn = Convert.ToDateTime(records["DeletedOn"]);
                    employee.Email = records["Email"].ToString();
                    employee.Fax = records["Fax"].ToString();
                    employee.Name = records["Name"].ToString();
                    employee.LastLogin = Convert.ToDateTime(records["LastLogin"]);
                    employee.Password = records["Password"].ToString();
                    employee.PortalId = Convert.ToInt32(records["PortalId"]);
                    employee.RoleId = Convert.ToInt32(records["RoleId"]);
                    employee.StatusId = Convert.ToInt32(records["StatusId"]);
                    employee.Telephone = records["Telephone"].ToString();
                    employee.UpdatedOn = Convert.ToDateTime(records["UpdatedOn"]);
                    employee.Username = records["Username"].ToString();

                    return employee;
                }
                throw new Exception();
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }


        public EmployeeEntity AddEmployee(EmployeeEntity employeeEntity)
        {
            connection.Open();

            try
            {
                string query = $"INSERT INTO {InfrastructureResource.TableName} VALUES " +
                   $"({employeeEntity.CompanyId}, " +
                   $"'{employeeEntity.CreatedOn}', " +
                   $"'{employeeEntity.DeletedOn}', " +
                   $"'{employeeEntity.Email}', " +
                   $"'{employeeEntity.Fax}', " +
                   $"'{employeeEntity.Name}', " +
                   $"'{employeeEntity.LastLogin}', " +
                   $"'{employeeEntity.Password}', " +
                   $"{employeeEntity.PortalId}, " +
                   $"{employeeEntity.RoleId}, " +
                   $"{employeeEntity.StatusId}, " +
                   $"'{employeeEntity.Telephone}', " +
                   $"'{employeeEntity.UpdatedOn}', " +
                   $"'{employeeEntity.Username}')";

                SqlCommand command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                connection.Close();

                return GetEmployeeById(employeeEntity.CompanyId);
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }


        public bool UpdateEmployeeUsernameById(int id, string username)
        {
            connection.Open();

            try
            {
                string query = $"UPDATE {InfrastructureResource.TableName} SET Username = '{username}' WHERE CompanyId = {id}";

                SqlCommand command = new SqlCommand(query, connection);
                var rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0 ? true : false;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }

        public bool DeleteEmployeeById(int id)
        {
            connection.Open();

            try
            {
                string query = $"DELETE FROM {InfrastructureResource.TableName} WHERE CompanyId = {id}";

                SqlCommand command = new SqlCommand(query, connection);
                var rowsAffected = command.ExecuteNonQuery();

                return rowsAffected > 0 ? true : false;
            }
            catch (Exception)
            {
                throw new Exception();
            }
            finally
            {
                connection.Close();
            }
        }
    }






}
