using Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Business
{
    public class Car:BusinessModel<CarContract>
    {
        public SqlConnection con = new SqlConnection("Data Source= CAN\\SQLEXPRESS;Initial Catalog=GraduationProject;Integrated Security=true");
        public GenericResponse<CarContract> InsertCar(CarContract carContract)
        {
            GenericResponse<CarContract> returnObject = new GenericResponse<CarContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("CarInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("Brand", carContract.Brand));
                cmd.Parameters.Add(new SqlParameter("Series", carContract.Series));
                cmd.Parameters.Add(new SqlParameter("Model", carContract.Model));
                cmd.Parameters.Add(new SqlParameter("Year", carContract.Year));
                cmd.Parameters.Add(new SqlParameter("Fuel", carContract.Fuel));
                cmd.Parameters.Add(new SqlParameter("Gear", carContract.Gear));
                cmd.Parameters.Add(new SqlParameter("Status", carContract.Status));
                cmd.Parameters.Add(new SqlParameter("BodyType", carContract.BodyType));
                cmd.Parameters.Add(new SqlParameter("Kilometer", carContract.Kilometer));
                cmd.Parameters.Add(new SqlParameter("EnginePower", carContract.EnginePower));
                cmd.Parameters.Add(new SqlParameter("EngineCapacity", carContract.EngineCapacity));
                cmd.Parameters.Add(new SqlParameter("Color", carContract.Color));
                cmd.Parameters.Add(new SqlParameter("Warranty", carContract.Warranty));
                cmd.Parameters.Add(new SqlParameter("VehicleStatus", carContract.VehicleStatus));
                cmd.Parameters.Add(new SqlParameter("OwnerID", carContract.OwnerID));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "Araç Başarıyla Eklendi";
                returnObject.Value = carContract;
                return returnObject;
            }
            catch (Exception ex)
            {
                returnObject.Result = false;
                returnObject.ResultMessage = ex.ToString();
                return returnObject;
            }
        }
        public GenericResponse<CarContract> GetCar(CarContract carContract)
        {
            GenericResponse<CarContract> returnObject = new GenericResponse<CarContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SelectCarByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", carContract.ID));
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    carContract.Brand = dataReader.GetString("Brand");
                    carContract.Series = dataReader.GetString("Series");
                    carContract.Model = dataReader.GetString("Model");
                    carContract.Year = dataReader.GetInt32("Year");
                    carContract.Fuel = dataReader.GetString("Fuel");
                    carContract.Gear = dataReader.GetString("Gear");
                    carContract.Status = dataReader.GetString("Status");
                    carContract.BodyType = dataReader.GetString("BodyType");
                    carContract.Kilometer = dataReader.GetInt64("Kilometer");
                    carContract.EnginePower = dataReader.GetInt32("EnginePower");
                    carContract.EngineCapacity = dataReader.GetString("EngineCapacity");
                    carContract.Color = dataReader.GetString("Color");
                    carContract.Warranty = dataReader.GetString("Warranty");
                    carContract.VehicleStatus = dataReader.GetString("VehicleStatus");
                    carContract.OwnerID = dataReader.GetInt32("OwnerID");
                    returnObject.Value = carContract;
                    returnObject.Result = true;
                    returnObject.ResultMessage = "Araç Başarıyla Getirildi";
                }
                con.Close();
                return returnObject;
            }
            catch (Exception ex)
            {
                returnObject.Result = false;
                returnObject.ResultMessage = ex.ToString();
                return returnObject;
            }

        }
        public GenericResponse<CarContract> Delete(CarContract carContract)
        {
            GenericResponse<CarContract> returnObject = new GenericResponse<CarContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteCarByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", carContract.ID));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "Araç silindi";
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                returnObject.ResultMessage = "Araç Silinemedi";
                return returnObject;
            }

        }
        public GenericResponse<List<CarContract>> GetCarList()
        {
            CarContract carContract = new CarContract();
            GenericResponse<List<CarContract>> returnObject = new GenericResponse<List<CarContract>>();
            returnObject.Value = new List<CarContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("GetCarList",con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    carContract = new CarContract();
                    carContract.ID= dataReader.GetInt32("ID");
                    carContract.Brand = dataReader.GetString("Brand");
                    carContract.Series = dataReader.GetString("Series");
                    carContract.Model = dataReader.GetString("Model");
                    carContract.Year = dataReader.GetInt32("Year");
                    carContract.Fuel = dataReader.GetString("Fuel");
                    carContract.Gear = dataReader.GetString("Gear");
                    carContract.Status = dataReader.GetString("Status");
                    carContract.BodyType = dataReader.GetString("BodyType");
                    carContract.Kilometer = dataReader.GetInt64("Kilometer");
                    carContract.EnginePower = dataReader.GetInt32("EnginePower");
                    carContract.EngineCapacity = dataReader.GetString("EngineCapacity");
                    carContract.Color = dataReader.GetString("Color");
                    carContract.Warranty = dataReader.GetString("Warranty");
                    carContract.VehicleStatus = dataReader.GetString("VehicleStatus");
                    carContract.OwnerID = dataReader.GetInt32("OwnerID");
                    returnObject.Value.Add(carContract);
                    returnObject.Result = true;
                    returnObject.ResultMessage = "Araç Başarıyla Getirildi";
                }
                con.Close();
                return returnObject;
            }
            catch(Exception ex)
            {
                returnObject.Result = false;
                returnObject.ResultMessage = ex.ToString();
                return returnObject;
            }
        }
        public GenericResponse<CarContract> Update(CarContract carContract)
        {
            GenericResponse<CarContract> returnObject = new GenericResponse<CarContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UpdateCar", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", carContract.ID));
                cmd.Parameters.Add(new SqlParameter("Brand", carContract.Brand));
                cmd.Parameters.Add(new SqlParameter("Series", carContract.Series));
                cmd.Parameters.Add(new SqlParameter("Model", carContract.Model));
                cmd.Parameters.Add(new SqlParameter("Year", carContract.Year));
                cmd.Parameters.Add(new SqlParameter("Fuel", carContract.Fuel));
                cmd.Parameters.Add(new SqlParameter("Gear", carContract.Gear));
                cmd.Parameters.Add(new SqlParameter("Status", carContract.Status));
                cmd.Parameters.Add(new SqlParameter("BodyType", carContract.BodyType));
                cmd.Parameters.Add(new SqlParameter("Kilometer", carContract.Kilometer));
                cmd.Parameters.Add(new SqlParameter("EnginePower", carContract.EnginePower));
                cmd.Parameters.Add(new SqlParameter("EngineCapacity", carContract.EngineCapacity));
                cmd.Parameters.Add(new SqlParameter("Color", carContract.Color));
                cmd.Parameters.Add(new SqlParameter("Warranty", carContract.Warranty));
                cmd.Parameters.Add(new SqlParameter("VehicleStatus", carContract.VehicleStatus));
                cmd.Parameters.Add(new SqlParameter("OwnerID", carContract.OwnerID));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "Araç Başarıyla Güncellendi";
                returnObject.Value = carContract;
                return returnObject;
            }
            catch (Exception ex)
            {
                returnObject.Result = false;
                returnObject.ResultMessage = ex.ToString();
                return returnObject;
            }

        }

        public GenericResponse<CarContract> Get(CarContract entity)
        {
            GenericResponse<CarContract> returnObject = new GenericResponse<CarContract>();
            return returnObject;
        }
    }
}
