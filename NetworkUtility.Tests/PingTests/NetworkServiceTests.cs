using FluentAssertions;
using FluentAssertions.Extensions;
using NetworkUtility.Ping;
using System.Net.NetworkInformation;
using Xunit;

namespace NetworkUtility.Tests.PingTests
{
    public class NetworkServiceTests
    {
        public readonly NetworkService networkService;

        public NetworkServiceTests()
        {
            // SUT
            networkService = new NetworkService();
        }

        // Check out documentation (https://fluentassertions.com/strings/)
        [Fact]
        public void NetworkService_SendPing_ReturnString()
        {
            // Arrange - variables, classes, mocks

            // Act
            var result = networkService.SendPing();

            // Assert
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Success: Ping Sent");
            result.Should().Contain("Success", Exactly.Once());

        }

        // Check out documentation (https://fluentassertions.com/numerictypes/)
        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(2, 2, 4)]
        public void NetworkService_PingTimeout_ReturnInt(int a, int b, int expected)
        {
            // Arrange

            // Act
            var result = networkService.PingTimeout(a, b);

            // Assert
            result.Should().Be(expected);
            result.Should().BeGreaterThanOrEqualTo(2);
            result.Should().NotBeInRange(-10000, 0);
        }

        // Check out documentation (https://fluentassertions.com/datetimespans/)
        [Fact]
        public void NetworkService_LastPingDate_ReturnDateTime()
        {
            // Arrange - variables, classes, mocks

            // Act
            var result = networkService.LastPingDate();

            // Assert
            result.Should().BeAfter(1.January(2010));
            result.Should().BeBefore(1.January(2030));

        }


        [Fact]
        public void NetworkService_GetPingOptions_ReturnObject()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = networkService.GetPingOptions();

            // Assert WARNING: "Be" careful
            result.Should().BeOfType<PingOptions>();
            result.Should().BeEquivalentTo(expected);
            result.Ttl.Should().Be(1);
        }


        [Fact]
        public void NetworkService_MostRecentPings_ReturnListOfObjects()
        {
            // Arrange
            var expected = new PingOptions()
            {
                DontFragment = true,
                Ttl = 1
            };

            // Act
            var result = networkService.MostRecentPings();

            // Assert WARNING: "Be" careful
            result.Should().BeOfType<List<PingOptions>>();
            result.Should().ContainEquivalentOf(expected);
            result.Should().Contain(x => x.DontFragment == true);
        }
    }
}
