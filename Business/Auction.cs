using Base;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;
using System.Data.Common;

namespace Business
{
    public class Auction
    {
        public SqlConnection con = new SqlConnection("Data Source= CAN\\SQLEXPRESS;Initial Catalog=GraduationProject;Integrated Security=true");

        public Auction()
        {

        }
        public GenericResponse<AuctionContract> Insert(AuctionContract auctionContract)
        {
            GenericResponse<AuctionContract> returnObject = new GenericResponse<AuctionContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AuctionInsert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("CarID", auctionContract.CarID));
                cmd.Parameters.Add(new SqlParameter("AdvertNumber", auctionContract.CarID+1000));
                cmd.Parameters.Add(new SqlParameter("StartPrice", auctionContract.StartPrice));
                cmd.Parameters.Add(new SqlParameter("EndPrice", auctionContract.EndPrice));
                cmd.Parameters.Add(new SqlParameter("StartDate", auctionContract.StartDate));
                cmd.Parameters.Add(new SqlParameter("EndDate", auctionContract.StartDate.AddHours(12)));
                cmd.Parameters.Add(new SqlParameter("OwnerID", auctionContract.OwnerID));
                cmd.Parameters.Add(new SqlParameter("LastOwnerID", auctionContract.LastOwnerID));
                cmd.Parameters.Add(new SqlParameter("Status", auctionContract.Status));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "İhale başarıyla eklendi";
                return returnObject;
            }
            catch
            {
                con.Close();
                returnObject.Result = false;
                return returnObject;
            }

        }
        public GenericResponse<AuctionContract> Update(AuctionContract auctionContract)
        {
            GenericResponse<AuctionContract> returnObject = new GenericResponse<AuctionContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AuctionUpdate", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("AuctionID", auctionContract.AuctionID));
                cmd.Parameters.Add(new SqlParameter("CarID", auctionContract.CarID));
                cmd.Parameters.Add(new SqlParameter("AdvertNumber", auctionContract.AdvertNumber));
                cmd.Parameters.Add(new SqlParameter("StartPrice", auctionContract.StartPrice));
                cmd.Parameters.Add(new SqlParameter("EndPrice", auctionContract.EndPrice));
                cmd.Parameters.Add(new SqlParameter("StartDate", auctionContract.StartDate));
                cmd.Parameters.Add(new SqlParameter("EndDate", auctionContract.EndDate));
                cmd.Parameters.Add(new SqlParameter("OwnerID", auctionContract.OwnerID));
                cmd.Parameters.Add(new SqlParameter("LastOwnerID", auctionContract.LastOwnerID));
                cmd.Parameters.Add(new SqlParameter("Status", auctionContract.Status));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "İhale başarıyla eklendi";
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                return returnObject;
            }

        }
        public GenericResponse<AuctionContract> Select(AuctionContract auctionContract)
        {
            GenericResponse<AuctionContract> returnObject = new GenericResponse<AuctionContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("AuctionSelectByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("AuctionID", auctionContract.AuctionID));
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    auctionContract.CarID = dataReader.GetInt32("CarID");
                    auctionContract.AdvertNumber = dataReader.GetInt64("AdvertNumber");
                    auctionContract.StartPrice = dataReader.GetInt64("StartPrice");
                    auctionContract.EndPrice = dataReader.GetInt64("EndPrice");
                    auctionContract.StartDate = dataReader.GetDateTime("StartDate");
                    auctionContract.EndDate = dataReader.GetDateTime("EndDate");
                    auctionContract.OwnerID = dataReader.GetInt32("OwnerID");
                    auctionContract.LastOwnerID = dataReader.GetInt32("LastOwnerID");
                    auctionContract.Status = dataReader.GetString("Status");
                    returnObject.Value = auctionContract;
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
        public GenericResponse<AuctionContract> Delete(AuctionContract auctionContract)
        {
            GenericResponse<AuctionContract> returnObject = new GenericResponse<AuctionContract>();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DeleteAuctionByID", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("ID", auctionContract.CarID));
                var response = cmd.ExecuteNonQuery();
                con.Close();
                returnObject.Result = true;
                returnObject.ResultMessage = "İhale silindi";
                return returnObject;
            }
            catch
            {
                returnObject.Result = false;
                returnObject.ResultMessage = "İhale Silinemedi";
                return returnObject;
            }

        }
        public GenericResponse<List<AuctionContract>> SelectAuctionList()
        {
            GenericResponse<List<AuctionContract>> returnObject = new GenericResponse<List<AuctionContract>>();
            SqlCommand cmd = new SqlCommand("SelectAuctionList", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dataReader = cmd.ExecuteReader();
            returnObject.Value = new List<AuctionContract>();
            try
            {
                
                while (dataReader.Read())
                {
                    AuctionContract auctionContract = new AuctionContract();
                    auctionContract.AuctionID = dataReader.GetInt32("AuctionID");
                    auctionContract.CarID = dataReader.GetInt32("CarID");
                    auctionContract.AdvertNumber = dataReader.GetInt64("AdvertNumber");
                    auctionContract.StartPrice = dataReader.GetInt64("StartPrice");
                    auctionContract.EndPrice = dataReader.GetInt64("EndPrice");
                    auctionContract.StartDate = dataReader.GetDateTime("StartDate");
                    auctionContract.EndDate = dataReader.GetDateTime("EndDate");
                    auctionContract.OwnerID = dataReader.GetInt32("OwnerID");
                    auctionContract.LastOwnerID = dataReader.GetInt32("LastOwnerID");
                    auctionContract.Status = dataReader.GetString("Status");
                    returnObject.Result = true;
                    returnObject.ResultMessage = "İhale listesi getirildi";
                    returnObject.Value.Add(auctionContract);
                }
            }
            catch
            {
                returnObject.Result = false;
                returnObject.ResultMessage = "İhale listesi getirelemedi";

            }
            dataReader.Close();
            con.Close();
            return returnObject;
        }
    }
}
