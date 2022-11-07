using Base;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;
using Types;

namespace Business
{
    public class Customer
    {

        public SqlConnection con = new SqlConnection("Data Source= CAN\\SQLEXPRESS;Initial Catalog=GraduationProject;Integrated Security=true");
        public Customer()
        {
        }

        public GenericResponse<CustomerContract> Insert(CustomerContract _customerContract)
        {
            GenericResponse<CustomerContract> returnObject = new GenericResponse<CustomerContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CustomerInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("FirstName", _customerContract.FirstName));
                cmd.Parameters.Add(new SqlParameter("LastName", _customerContract.LastName));
                cmd.Parameters.Add(new SqlParameter("Password", _customerContract.Password));
                cmd.Parameters.Add(new SqlParameter("BirthDate", _customerContract.BirthDate));
                cmd.Parameters.Add(new SqlParameter("Address", _customerContract.Address));
                cmd.Parameters.Add(new SqlParameter("City", _customerContract.City));
                cmd.Parameters.Add(new SqlParameter("Email", _customerContract.Email));
                cmd.Parameters.Add(new SqlParameter("Gender", _customerContract.Gender));
                cmd.Parameters.Add(new SqlParameter("Phone", _customerContract.Phone));
                cmd.Parameters.Add(new SqlParameter("Country", _customerContract.Country));
                cmd.Parameters.Add(new SqlParameter("TCKN", _customerContract.TCKN));

                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "Kullanıcı başarıyla eklendi";
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                return returnObject;
            }

        }
        public GenericResponse<CustomerContract> Update(CustomerContract _customerContract)
        {
            GenericResponse<CustomerContract> returnObject = new GenericResponse<CustomerContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CustomerUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", _customerContract.ID));
                cmd.Parameters.Add(new SqlParameter("FirstName", _customerContract.FirstName));
                cmd.Parameters.Add(new SqlParameter("LastName", _customerContract.LastName));
                cmd.Parameters.Add(new SqlParameter("BirthDate", _customerContract.BirthDate));
                cmd.Parameters.Add(new SqlParameter("Address", _customerContract.Address));
                cmd.Parameters.Add(new SqlParameter("City", _customerContract.City));
                cmd.Parameters.Add(new SqlParameter("Email", _customerContract.Email));
                cmd.Parameters.Add(new SqlParameter("Gender", _customerContract.Gender));
                cmd.Parameters.Add(new SqlParameter("Phone", _customerContract.Phone));
                cmd.Parameters.Add(new SqlParameter("Country", _customerContract.Country));
                cmd.Parameters.Add(new SqlParameter("TCKN", _customerContract.TCKN));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Value = _customerContract;
                returnObject.Result = true;
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                return returnObject;
            }

        }
        public GenericResponse<CustomerContract> Select(CustomerContract _customerContract)
        {
            GenericResponse<CustomerContract> returnObject = new GenericResponse<CustomerContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CustomerSelectByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", _customerContract.ID));
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    _customerContract.FirstName = dataReader.GetString("FirstName");
                    _customerContract.LastName = dataReader.GetString("LastName");
                    _customerContract.BirthDate = dataReader.GetString("BirthDate");
                    _customerContract.Address = dataReader.GetString("Address");
                    _customerContract.City = dataReader.GetString("City");
                    _customerContract.Email = dataReader.GetString("Email");
                    _customerContract.Gender = dataReader.GetString("Gender");
                    _customerContract.Phone = dataReader.GetString("Phone");
                    _customerContract.Country = dataReader.GetString("Country");
                    _customerContract.Balance = dataReader.GetInt32("Balance");
                    _customerContract.Status = dataReader.GetString("Status");
                    _customerContract.TCKN = dataReader.GetInt64("TCKN");
                    returnObject.Value = _customerContract;
                    returnObject.Result = true;
                }
                dataReader.Close();
                con.Close();
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                returnObject.ResultMessage = "Kullanıcı Getirirken Hata";
                return returnObject;
            }

        }
        public GenericResponse<CustomerContract> SelectByTCKN(CustomerContract _customerContract)
        {
            GenericResponse<CustomerContract> returnObject = new GenericResponse<CustomerContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CustomerSelectByTCKN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("TCKN", _customerContract.TCKN));
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    _customerContract.ID = dataReader.GetInt32("ID");
                    _customerContract.FirstName = dataReader.GetString("FirstName");
                    _customerContract.LastName = dataReader.GetString("LastName");
                    _customerContract.BirthDate = dataReader.GetString("BirthDate");
                    _customerContract.Address = dataReader.GetString("Address");
                    _customerContract.City = dataReader.GetString("City");
                    _customerContract.Email = dataReader.GetString("Email");
                    _customerContract.Gender = dataReader.GetString("Gender");
                    _customerContract.Phone = dataReader.GetString("Phone");
                    _customerContract.Country = dataReader.GetString("Country");
                    _customerContract.Balance = dataReader.GetInt32("Balance");
                    _customerContract.Status = dataReader.GetString("Status");
                    _customerContract.TCKN = dataReader.GetInt64("TCKN");
                    returnObject.Value = _customerContract;
                }
                dataReader.Close();
                con.Close();
                returnObject.Result = true;
                return returnObject;

            }
            catch
            {
                returnObject.Result = false;
                return returnObject;
            }

        }
        public GenericResponse<CustomerContract> Delete(CustomerContract _customerContract)
        {
            GenericResponse<CustomerContract> returnObject = new GenericResponse<CustomerContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteCustomerByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", _customerContract.ID));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "Kullanıcı silindi";
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                returnObject.ResultMessage = "Kullanıcı Silinemedi";
                return returnObject;
            }

        }
        public GenericResponse<List<CustomerContract>> SelectCustomerList()
        {
            GenericResponse<List<CustomerContract>> returnObject = new GenericResponse<List<CustomerContract>>();
            returnObject.Value = new List<CustomerContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CustomerSelectList", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    CustomerContract _customerContract = new CustomerContract();
                    _customerContract.ID = dataReader.GetInt32("ID");
                    _customerContract.FirstName = dataReader.GetString("FirstName");
                    _customerContract.LastName = dataReader.GetString("LastName");
                    _customerContract.BirthDate = dataReader.GetString("BirthDate");
                    _customerContract.Address = dataReader.GetString("Address");
                    _customerContract.City = dataReader.GetString("City");
                    _customerContract.Email = dataReader.GetString("Email");
                    _customerContract.Gender = dataReader.GetString("Gender");
                    _customerContract.Phone = dataReader.GetString("Phone");
                    _customerContract.Country = dataReader.GetString("Country");
                    _customerContract.Balance = dataReader.GetInt32("Balance");
                    _customerContract.Status = dataReader.GetString("Status");
                    _customerContract.TCKN = dataReader.GetInt64("TCKN");
                    returnObject.Result = true;
                    returnObject.ResultMessage = "Müşteri listesi getirildi";
                    returnObject.Value.Add(_customerContract);
                }
                dataReader.Close();
                con.Close();
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                returnObject.ResultMessage = "Müşteri listesi getirelemedi";
                return returnObject;
            }
        }
    }
}

