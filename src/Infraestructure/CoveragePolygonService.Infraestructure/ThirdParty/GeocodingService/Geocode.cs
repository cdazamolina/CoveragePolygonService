using CoveragePolygonService.Core.DTO;
using CoveragePolygonService.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace CoveragePolygonService.Infraestructure.ThirdParty.GeocodingService
{
    public class Geocode : IGeocode
    {
        private readonly ILogger<Geocode> _logger;
        private readonly string _baseUrl;
        private readonly string _pathUrl;

        public Geocode(IConfiguration configuration, ILogger<Geocode> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _baseUrl = configuration["ThirdParties:Geocoding:BaseUrl"];
            _pathUrl = configuration["ThirdParties:Geocoding:PathUrl"];
        }

        public async Task<RouteCoverage> GetRouteByAddress(IEnumerable<RouteCoverage> routeCoverages, string address)
        {
            var client = new RestClient(_baseUrl);
            var request = new RestRequest(_pathUrl)
                .AddQueryParameter(nameof(address), address)
                .AddJsonBody(routeCoverages);
            var response = await client.PostAsync(request);

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                _logger.LogError($"Error from geocoding service [{response.StatusCode}]: {response.ErrorMessage}");
                return null;
            }

            return JsonSerializer.Deserialize<RouteCoverage>(response.Content);
        }
    }
}
