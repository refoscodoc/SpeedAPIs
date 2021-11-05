using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using First.Models;
using First.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace First.Services
{
    public class BusinessProvider
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public BusinessProvider(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        public async Task<GuitarViewModel> AddGuitar(GuitarViewModel guitar)
        {
            var newGuitar = new GuitarModel
            {
                Id = Guid.NewGuid(),
                Brand = guitar.Brand,
                Year = guitar.Year,
                Wood = guitar.Wood,
                Price = guitar.Price
            };

            var der = await _dataAccessProvider.AddGuitar(newGuitar);

            var result = new GuitarViewModel()
            {
                Id = Guid.NewGuid(),
                Wood = der.Wood,
                Brand = der.Brand,
                Year = der.Year,
                Price = der.Price
            };

            return result;
        }
        
        public async Task<IEnumerable<GuitarModel>> GetGuitars()
        {
            var data = await _dataAccessProvider.GetGuitars();

            var result = data.Select(guitar => new GuitarModel
            {
                Id = guitar.Id,
                Brand = guitar.Brand,
                Price = guitar.Price,
                Year = guitar.Year,
                Wood = guitar.Wood
            });

            return result;
        }

        public async Task<GuitarModel> DeleteGuitar(GuitarModel guitar)
        {
            await _dataAccessProvider.DeleteGuitar(guitar);
            return null;
        }

        public async Task<GuitarModel> EditGuitar(GuitarModel guitar)
        {
            var newGuitar = new GuitarModel
            {
                Id = guitar.Id,
                Brand = guitar.Brand,
                Year = guitar.Year,
                Wood = guitar.Wood,
                Price = guitar.Price
            };

            return await _dataAccessProvider.EditGuitar(newGuitar);
        }

        public Task<GuitarModel> SearchGuitar(GuitarModel guitar)
        {
            throw new System.NotImplementedException();
            return null;
        }
    }
}