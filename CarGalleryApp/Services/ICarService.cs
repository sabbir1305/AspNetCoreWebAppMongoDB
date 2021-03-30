using CarGalleryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarGalleryApp.Services
{
   public interface ICarService
    {
        IList<Car> Get();
        Car Get(string id);

        Car Create(Car car);

        void Update(string id, Car carIn);

        void Remove(Car carIn);

        void Remove(string id);

    }
}
