using CarFleet_Project.Models.Interfaces;
using CarFleet_Project.Models.Tables;
using System.Text.Json.Nodes;


namespace CarFleet_Project.Services
{
    public class ToDbService
    {
        ICarFleetContext _ctx;

        public ToDbService(ICarFleetContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Vehicle> VehicleConversion(string requestBody)
        {
            try
            {

                JsonNode vehicleNode = JsonNode.Parse(requestBody)!;
                List<int> equipmentIds = vehicleNode["equipmentIds"]!.AsArray().Select(node => node!.GetValue<int>()).ToList();
                List<int> fuelsIds = vehicleNode["fuelsIds"]!.AsArray().Select(node => node!.GetValue<int>()).ToList();
                int vehicleId = vehicleNode!["vehicleId"]!.GetValue<int>();
                int brandId = vehicleNode!["brandId"]!.GetValue<int>();
                int modelId = vehicleNode!["modelId"]!.GetValue<int>(); ;
                int carbodyId = vehicleNode!["carbodyId"]!.GetValue<int>(); ;
                int transmissionTypeId = vehicleNode!["transmissionTypeId"]!.GetValue<int>(); ;
                int yearOfProductionId = vehicleNode!["yearOfProductionId"]!.GetValue<int>(); ;
                string mileage = vehicleNode!["mileage"]!.GetValue<string>(); ;

                Vehicle newVehicle = new Vehicle();
                var brand = await _ctx.GetSpecificBrand(brandId);
                if (brand != null)
                {
                    newVehicle.brand = brand;
                }
                var model = await _ctx.GetSpecificModel(modelId);
                if (model != null)
                {
                    newVehicle.model = model;
                }
                var carbody = await _ctx.GetSpecificCarbody(carbodyId);
                if (carbody != null)
                {
                    newVehicle.carbody = carbody;
                }
                var yearOfProduction = await _ctx.GetSpecificYear(yearOfProductionId);
                if (yearOfProduction != null)
                {
                    newVehicle.yearOfProduction = yearOfProduction;
                }
                var transmissionType = await _ctx.GetSpecificTransmissionType(transmissionTypeId);
                if (transmissionType != null)
                {
                    newVehicle.transmissionType = transmissionType;
                }
                var fuels = await _ctx.GetSpecificFuels(fuelsIds);
                if (fuels != null)
                {
                    newVehicle.fuels = fuels;
                }
                var equipment = await _ctx.GetSpecificEquipment(equipmentIds);
                if (equipment != null)
                {
                    newVehicle.equipment = equipment;
                }
                newVehicle.mileage = mileage;
                return newVehicle;
            }
            catch (Exception ex)
            {
                throw new Exception("Wystąpił błąd podczas pobierania obiektów z bazy danych.", ex);
            }
        }
    }
}
