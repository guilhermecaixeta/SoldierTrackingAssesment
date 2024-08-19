using FluentAssertions;
using Infra.SoldierTrackingAssesment.Models;
using NetTopologySuite.Geometries;
using System.Text.Json;

namespace SoldierTrackingAssesment.Tests
{
    public class PersistenceTests : TestStartup
    {
        [Fact]
        public async Task ShouldPersistCountry()
        {
            var country = new Country { Name = "Portugal" };
            dbContext.Countries.Add(country);
            await dbContext.SaveChangesAsync();

            dbContext.Countries.Any().Should().BeTrue();
        }

        [Fact]
        public async Task ShouldPersistRank()
        {
            var rank = new Rank { Title = "Soldier" };
            dbContext.Ranks.Add(rank);
            await dbContext.SaveChangesAsync();

            dbContext.Ranks.Any().Should().BeTrue();
        }

        [Fact]
        public async Task ShouldPersistSoldier()
        {
            var rank = new Rank { Title = "Soldier" };
            var country = new Country { Name = "Portugal" };
            var soldier = new Soldier { Country = country, Name = "Some Soldier", Rank = rank };
            dbContext.Soldiers.Add(soldier);
            await dbContext.SaveChangesAsync();

            dbContext.Soldiers.Any().Should().BeTrue();
        }

        [Fact]
        public async Task ShouldPersistGeolocationSensor()
        {
            var sensor = new GeolocalizationSensor { Name = "Geolocalizator", Type = "Geolocalization" };
            dbContext.GeolocalizationSensors.Add(sensor);
            await dbContext.SaveChangesAsync();

            dbContext.GeolocalizationSensors.Any().Should().BeTrue();
        }

        [Fact]
        public async Task ShouldPersistLocation()
        {
            var sensor = new GeolocalizationSensor { Name = "Geolocalizator", Type = "Geolocalization" };

            var point = new Point(-74.006, 40.7128) { SRID = 4326 };
            var location = new Infra.SoldierTrackingAssesment.Models.Location { Coordinates = point, Sensor = sensor };
            dbContext.Locations.Add(location);
            await dbContext.SaveChangesAsync();

            dbContext.Locations.Any().Should().BeTrue();
        }

        [Fact]
        public async Task ShouldPersistTraining()
        {
            var obj = new { Description = "Some Training", StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(7) };
            var training = new Training { Information = JsonSerializer.Serialize(obj, JsonSerializerOptions.Default) };

            dbContext.Trainings.Add(training);
            await dbContext.SaveChangesAsync();

            dbContext.Trainings.Any().Should().BeTrue();
        }

        [Fact]
        public async Task ShouldPersistTrainingData()
        {
            var rank = new Rank { Title = "Soldier" };
            var country = new Country { Name = "Portugal" };
            var soldier = new Soldier { Country = country, Name = "Some Soldier", Rank = rank };

            var sensor = new GeolocalizationSensor { Name = "Geolocalizator", Type = "Geolocalization" };

            var obj = new { Description = "Some Training", StartDate = DateTime.UtcNow, EndDate = DateTime.UtcNow.AddDays(7) };
            var training = new Training { Information = JsonSerializer.Serialize(obj, JsonSerializerOptions.Default) };

            var trainingData = new TrainingData
            {
                Sensor = sensor,
                Soldier = soldier,
                Training = training
            };

            dbContext.TrainingDatas.Add(trainingData);
            await dbContext.SaveChangesAsync();

            dbContext.TrainingDatas.Any().Should().BeTrue();
        }
    }
}