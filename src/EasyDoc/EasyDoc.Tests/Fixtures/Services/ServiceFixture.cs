using EasyDoc.Domain.Core.Bus;
using Moq;

namespace EasyDoc.Tests.Fixtures.Services
{
    public class ServiceFixture
    {
        public Mock<IMediatorHandler> Bus { get; set; }

        public ServiceFixture()
        {
            Bus = new Mock<IMediatorHandler>();
        }
    }
}
