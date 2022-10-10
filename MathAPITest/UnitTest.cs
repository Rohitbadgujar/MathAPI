using MathAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using Xunit;

namespace MathAPITest
{
    public class UnitTest
    {
        [Fact]
        public void MinValidTest()
        {
            List<int> numberListTestInput = new List<int>() { 1,3,7,2,7,8 };
            int quantifierTestInput = 4;
            var mathAPI = new MathAPIController(null);
            var response = mathAPI.Min(numberListTestInput, quantifierTestInput) as OkObjectResult;
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);

        }

        [Fact]
        public void MinInValidTest()
        {
            List<int> numberListTestInput = new List<int>() { 1, 3, 7, 2, 7, 8 };
            int quantifierTestInput = 10;
            var mathAPI = new MathAPIController(null);
            var response = mathAPI.Min(numberListTestInput, quantifierTestInput) as BadRequestObjectResult;
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);

        }

        [Fact]
        public void MaxValidTest()
        {
            List<int> numberListTestInput = new List<int>() { 1, 3, 7, 2, 7, 8 };
            int quantifierTestInput = 4;
            var mathAPI = new MathAPIController(null);
            var response = mathAPI.Max(numberListTestInput, quantifierTestInput) as OkObjectResult;
            Assert.NotNull(response);
            Assert.Equal(200, response.StatusCode);

        }

        [Fact]
        public void MaxInValidTest()
        {
            List<int> numberListTestInput = new List<int>() { 1, 3, 7, 2, 7, 8 };
            int quantifierTestInput = 10;
            var mathAPI = new MathAPIController(null);
            var response = mathAPI.Max(numberListTestInput, quantifierTestInput) as BadRequestObjectResult;
            Assert.NotNull(response);
            Assert.Equal(400, response.StatusCode);

        }
        [Fact]
        public void AvgValidTest()
        {
            List<int> numberListTestInput = new List<int>() { 1, 3, 7, 2, 7, 8 };
            var mathAPI = new MathAPIController(null);
            var response = mathAPI.Avg(numberListTestInput) ;
            Assert.Equal(5, Math.Round(response));
        }

        [Fact]
        public void MedianValidTest()
        {
            List<double> numberListTestInput = new List<double>() { 1, 3, 7, 2, 7, 8 };
            var mathAPI = new MathAPIController(null);
            var response = mathAPI.Median(numberListTestInput);
            Assert.Equal(5, Math.Round(response));
        }

        [Fact]
        public void PercentileValidTest()
        {
            List<double> numberListTestInput = new List<double>() { 1, 3, 7, 2, 7, 8 };
            int quantifierTestInput = 50;
            var mathAPI = new MathAPIController(null);
            var response = mathAPI.Percentile(numberListTestInput, quantifierTestInput);
            Assert.Equal(3, response);
        }
    }
}
