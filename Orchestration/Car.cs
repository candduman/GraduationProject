using Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Types;

namespace Orchestration
{
    public class Car
    {
        Business.Car _car = new Business.Car();
        public Car()
        {

        }

        public GenericResponse<CarContract> InsertCar(CarContract car)
        {
            TimeSpan startDate = new TimeSpan(10, 00, 0);
            var response = _car.InsertCar(car);
            return response;
        }
        public GenericResponse<CarContract> GetCar(CarContract car)
        {
            var response = _car.GetCar(car);
            if(response.Value == null)
            {
                response.Result = false;
                response.ResultMessage = "Araç Bulunamadı";
            }
            return response;
        }
        public GenericResponse<CarContract> DeleteCar(CarContract car)
        {
            var select = _car.GetCar(car);
            if(select.Value is null)
            {
                select.Result = false;
                select.ResultMessage = "Araç Bulunamadı";
                return select;
            }
            var response = _car.Delete(car);
            return response;
        }
        public GenericResponse<List<CarContract>> GetCarList()
        {
            var response = _car.GetCarList();
            return response;
        }
        public GenericResponse<CarContract> UpdateCar(CarContract carContract)
        {
            CarContract carContract1 = new CarContract();
            carContract1.ID = carContract.ID;
            var select = _car.GetCar(carContract1);
            if(select.Value is null)
            {
                select.Result = false;
                select.ResultMessage = "Araç bulunamadı";
                return select;
            }
            var response = _car.Update(carContract);
            return response;
        }
    }
}
