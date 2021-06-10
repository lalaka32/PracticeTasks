using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using Tasks;
using Xunit;

namespace Tests
{
    public class OfficialCertificateHelperTests
    {
        private readonly OfficialCertificateHelper _officialCertificateHelper;

        public OfficialCertificateHelperTests()
        {
            _officialCertificateHelper = new OfficialCertificateHelper();
        }

        [Theory]
        [InlineData(2, null, "[[1, 2], [2, 1]]")]
        [InlineData(2, "[{'OfficialDigit': 1, 'CertificateConditions':[2]}]", "[[2, 1]]")]
        [InlineData(4,
            @"[{'OfficialDigit': 1, 'CertificateConditions':[2]}, {'OfficialDigit': 2, 'CertificateConditions':[3,4]}]",
            "[[3, 4, 2, 1], [4, 3, 2, 1]]")]
        [InlineData(4,
            @"[{'OfficialDigit': 2, 'CertificateConditions':[1]}, {'OfficialDigit': 1, 'CertificateConditions':[3,4]}]",
            "[[3, 4, 1, 2], [4, 3, 1, 2]]")]
        public void GetOrderCombinationsTest(int numberOfOfficials, string rules, string expectedOrderString)
        {
            //Arrange
            var expectedOrderArray = JsonConvert.DeserializeObject<List<List<int>>>(expectedOrderString);
            //Act
            var order = _officialCertificateHelper.GetOrderCombinations(numberOfOfficials, rules);
            //Assert
            Assert.Equal(expectedOrderArray, order);
        }
    }
}