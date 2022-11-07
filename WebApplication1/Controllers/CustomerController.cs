using Microsoft.AspNetCore.Mvc;
using Types;
using Orchestration;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        public CustomerController()
        {

        }
        [HttpPost]
        public JsonResult Insert(CustomerContract customerContract)
        {
            Customer customer = new();
            var response = customer.InsertCustomer(customerContract);
            return new JsonResult(response);
        }
        [HttpPut]

        public JsonResult Update(CustomerContract customerContract)
        {
            Customer customer = new();
            var response = customer.UpdateCustomer(customerContract);
            return new JsonResult(response);
        }
        [HttpGet]
        public JsonResult Get(CustomerContract customerContract)
        {
            Customer customer = new();
            var response = customer.SelectByID(customerContract);
            return new JsonResult(response);
        }
        [Route("SelectCustomerList")]
        [HttpGet]
        public JsonResult SelectCustomerList()
        {
            CustomerContract customerContract = new CustomerContract();
            Customer customer = new();
            var response = customer.GetCustomerList();
            return new JsonResult(response);
        }
        [HttpDelete]
        public JsonResult Delete(int ID)
        {
            CustomerContract customerContract = new CustomerContract();
            customerContract.ID = ID;
            Customer customer = new();
            var response = customer.DeleteCustomer(customerContract);
            return new JsonResult(response);
        }
    }
}
