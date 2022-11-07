using Base;
using System.Security.Cryptography.X509Certificates;
using System.Timers;
using Types;

namespace Orchestration
{
    public class Customer
    {
        Business.Customer _customer = new Business.Customer();
        public Customer()
        {
        }
        public GenericResponse<CustomerContract> InsertCustomer(CustomerContract customerContract)
        {
            GenericResponse<CustomerContract> returnObject = new GenericResponse<CustomerContract>();
            var selectResponse = _customer.SelectByTCKN(customerContract);
            if (selectResponse.Value is null)
            {
                Business.Customer bocustomer = new Business.Customer();
                var response = bocustomer.Insert(customerContract);
                if (response.Result == true)
                {
                    returnObject = response;
                    return returnObject;
                }
                else
                {
                    returnObject = response;
                    return returnObject;
                }
            }
            else
            {
                returnObject.Result = false;
                returnObject.ResultMessage = "Kullanıcı Mevcut";
            }
            return returnObject;
        }

        public GenericResponse<List<CustomerContract>> GetCustomerList()
        {
            var response = _customer.SelectCustomerList();
            return response;
        }
        public GenericResponse<CustomerContract> DeleteCustomer(CustomerContract customerContract)
        {
            var select = _customer.Select(customerContract);
            if (select.Value is null)
            {
                select.Result = false;
                select.ResultMessage = "Kullanıcı Bulunamadı";
                return select;
            }
            var response = _customer.Delete(customerContract);
            return response;
        }
        public GenericResponse<CustomerContract> SelectByID(CustomerContract customerContract)
        {
            var response = _customer.Select(customerContract);
            return response;
        }
        public GenericResponse<CustomerContract> UpdateCustomer(CustomerContract customerContract)
        {
            var response = _customer.Update(customerContract);
            return response;
        }
    }
}
